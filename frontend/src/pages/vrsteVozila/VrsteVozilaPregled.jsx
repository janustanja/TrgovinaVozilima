import { useEffect, useState } from "react"
import VrstaVozilaService from "../../services/VrstaVozilaService"
import { Button, Table } from "react-bootstrap";
import { Link, useNavigate } from "react-router-dom";
import { RouteNames } from "../../constants";


export default function VrsteVozilaPregled(){

    const navigate=useNavigate();
    const [vrsteVozila, setVrsteVozila]= useState();
    


    async function dohvatiVrsteVozila(){
        const odgovor = await VrstaVozilaService.get()
        setVrsteVozila(odgovor)
    }
    useEffect(()=>{
        dohvatiVrsteVozila();
    }, [])

    function obrisi(sifra){
        if(!confirm(`Sigurno obrisati`)){
            return;
        }
        brisanjeVrsteVozila(sifra);
    }

    async function brisanjeVrsteVozila(sifra){
        const odgovor= await VrstaVozilaService.obrisi(sifra);
        if(odgovor.greska){
            alert(odgovor.poruka);
            return;
        }
        dohvatiVrsteVozila();
    }



    return (
        <>
        <Link
        to={RouteNames.VRSTAVOZILA_NOVI}
        className="btn btn-success siroko"
        >Dodaj novu vrstu vozila</Link>
        <Table striper bordered hover responsive>
            <thead>
                <tr>
                    <th>Naziv</th>
                    <th>Akcija</th>
                </tr>
            </thead>
            <tbody>
                {vrsteVozila && vrsteVozila.map((vrstaVozila, index)=>(
                    <tr key={index}>
                        <td>
                            {vrstaVozila.naziv}
                        </td>
                        
                        <td>
                            <Button
                                onClick={()=>navigate(`/vrsteVozila/${vrstaVozila.sifra}`)}
                                >Promjena
                            </Button>
                            &nbsp;&nbsp;&nbsp;
                            <Button
                                variant= "danger"
                                onClick={()=>obrisi(vrstaVozila.sifra)}
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