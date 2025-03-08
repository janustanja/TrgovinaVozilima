import { useEffect, useState } from "react"
import VoziloService from "../../services/VoziloService"
import { Button, Table } from "react-bootstrap";
import { Link, useNavigate } from "react-router-dom";
import { RouteNames } from "../../constants";


export default function VozilaPregled(){

    const navigate=useNavigate();
    const [vozila, setVozila]= useState();
    

    async function dohvatiVozila(){
        const odgovor = await VoziloService.get()
        setVozila(odgovor)
    }
    useEffect(()=>{
        dohvatiVozila();
    }, [])
        

    function obrisi(sifra){
        if(!confirm(`Sigurno obrisati`)){
            return;
        }
        brisanjeVozila(sifra);
    }

    async function brisanjeVozila(sifra){
        const odgovor= await VoziloService.obrisi(sifra);
        if(odgovor.greska){
            alert(odgovor.poruka);
            return;
        }
        dohvatiVozila();
    }



    return (
        <>
        <Link
        to={RouteNames.VOZILO_NOVI}
        className="btn btn-success siroko"
        >Dodaj novo vozilo</Link>
        <Table striper bordered hover responsive>
            <thead>
                <tr>
                    <th>VrstaVozila</th>
                    <th>Dobavljac</th>
                    <th>Marka</th>
                    <th>GodProizvodnje</th>
                    <th>PrijedeniKm</th>
                    <th>Cijena</th>
                    <th>Kupac</th>
                    <th>Akcija</th>
                </tr>
            </thead>
            <tbody>
                {vozila && vozila.map((vozilo, index)=>(
                    <tr key={index}>
                        <td>
                            {vozilo.vrstaVozila}
                        </td>
                        <td>
                            {vozilo.dobavljac}
                        </td>
                        <td>
                            {vozilo.marka}
                        </td>
                        <td>
                            {vozilo.godProizvodnje}
                        </td>
                        <td>
                            {vozilo.prijedeniKm}
                        </td>
                        <td>
                            {vozilo.cijena}
                        </td>
                        <td>
                            {vozilo.kupac}
                        </td>
                        <td>
                            <Button
                                onClick={()=>navigate(`/vozila/${vozilo.sifra}`)}
                                >Promjena
                            </Button>
                            &nbsp;&nbsp;&nbsp;
                            <Button
                                variant= "danger"
                                onClick={()=>obrisi(vozilo.sifra)}
                                >Obriši
                            </Button>

                        </td>
                    </tr>
                ))}
            </tbody>
        </Table>
        </>
    )


}