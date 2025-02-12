import { useEffect, useState } from "react"
import DobavljacService from "../../services/DobavljacService"
import { Table } from "react-bootstrap";
import { Link } from "react-router-dom";
import { RouteNames } from "../../constants";


export default function DobavljaciPregled(){

    const [dobavljaci, setDobavljaci]= useState();


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
                    </tr>
                ))}
            </tbody>
        </Table>
        </>
    )


}