import { useEffect, useState } from "react"
import DobavljacService from "../../services/DobavljacService"
import { Button, Table } from "react-bootstrap";
import { Link, useNavigate } from "react-router-dom";
import { RouteNames } from "../../constants";


export default function DobavljaciPregled(){

    const [dobavljaci, setDobavljaci]= useState();
    const navigate=useNavigate();


    async function dohvatiDobavljace(){
        const odgovor = await DobavljacService.get()
        setDobavljaci(odgovor)
    }
    useEffect(()=>{
        dohvatiDobavljace();
    }, [])


    return (
        <>
        <Link
        to={RouteNames.DOBAVLJAC_NOVI}
        className="btn btn-success siroko"
        >Dodaj novog dobavljača</Link>
        <Table striper bordered hover responsive>
            <thead>
                <tr>
                    <th>Naziv</th>
                    <th>Adresa</th>
                    <th>Iban</th>
                    <th>Akcija</th>
                </tr>
            </thead>
            <tbody>
                {dobavljaci && dobavljaci.map((dobavljac, index)=>(
                    <tr key={index}>
                        <td>
                            {dobavljac.naziv}
                        </td>
                        <td>
                            {dobavljac.adresa}
                        </td>
                        <td>
                            {dobavljac.iban}
                        </td>
                        <td>
                            <Button
                                onClick={()=>navigate(`/dobavljaci/${dobavljac.sifra}`)}
                                >Promjena
                            </Button>
                        </td>
                    </tr>
                ))}
            </tbody>
        </Table>
        </>
    )


}