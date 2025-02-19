import { useEffect, useState } from "react"
import KupacService from "../../services/KupacService"
import { Button, Table } from "react-bootstrap";
import { Link, useNavigate } from "react-router-dom";
import { RouteNames } from "../../constants";


export default function KupciPregled(){

    const [kupci, setKupci]= useState();
    const navigate=useNavigate();


    async function dohvatiKupce(){
        const odgovor = await KupacService.get()
        setKupci(odgovor)
    }
    useEffect(()=>{
        dohvatiKupce();
    }, [])

    function obrisi(sifra){
        if(!confirm(`Sigurno obrisati`)){
            return;
        }
        brisanjeKupca(sifra);
    }

    async function brisanjeKupca(sifra){
        const odgovor= await KupacService.obrisi(sifra);
        if(odgovor.greska){
            alert(odgovor.poruka);
            return;
        }
        dohvatiKupce();
    }



    return (
        <>
        <Link
        to={RouteNames.KUPAC_NOVI}
        className="btn btn-success siroko"
        >Dodaj novog kupca</Link>
        <Table striper bordered hover responsive>
            <thead>
                <tr>
                    <th>Ime</th>
                    <th>Prezime</th>
                    <th>Adresa</th>
                    <th>Iban</th>
                    <th>Akcija</th>
                </tr>
            </thead>
            <tbody>
                {Kupac && Kupac.map((kupac, index)=>(
                    <tr key={index}>
                        <td>
                            {kupac.ime}
                        </td>
                        <td>
                            {kupac.prezime}
                        </td>
                        <td>
                            {kupac.adresa}
                        </td>
                        <td>
                            {kupac.iban}
                        </td>
                        <td>
                            <Button
                                onClick={()=>navigate(`/kupco/${kupac.sifra}`)}
                                >Promjena
                            </Button>
                            &nbsp;&nbsp;&nbsp;
                            <Button
                                variant= "danger"
                                onClick={()=>obrisi(kupac.sifra)}
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