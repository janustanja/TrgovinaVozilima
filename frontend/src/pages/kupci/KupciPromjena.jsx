import { Button, Col, Form, Row } from "react-bootstrap";
import { Link, useNavigate, useParams } from "react-router-dom";
import { RouteNames } from "../../constants";
import KupacService from "../../services/KupacService";
import { useEffect, useState } from "react";


export default function KupciPromjena(){

    const navigate = useNavigate();
    const[kupac, setKupac]=useState({});
    const routeParams= useParams();

    async function dohvatiKupca() 
    {
        const odgovor = await KupacService.getBySifra(routeParams.sifra)
        setKupac(odgovor)
        
    }

    useEffect(()=>{
        dohvatiKupca();
    },[])

    async function promjena(kupac){
        const odgovor= await KupacService.promjena(routeParams.sifra, kupac);
        if(odgovor.greska){
            alert(odgovor.poruka)
            return
        }
        console.log(RouteNames.KUPAC_PREGLED)
        navigate(RouteNames.KUPAC_PREGLED)

    }




    function odradiSubmit(e){
        e.preventDefault();

        let podaci = new FormData(e.target);

        promjena(
            {
                ime: podaci.get('ime'),
                prezime: podaci.get('prezime'),
                adresa: podaci.get('adresa'),
                iban: podaci.get('iban')
            }
        );

    }



    return(
        <>
        Promjena kupca
        <Form onSubmit={odradiSubmit}>

            <Form.Group controlId="ime">
                <Form.Label>Ime</Form.Label>
                <Form.Control type="text" name="ime" required 
                defaultValue={kupac.ime}/>
            </Form.Group>

            <Form.Group controlId="prezime">
                <Form.Label>Prezime</Form.Label>
                <Form.Control type="text" name="prezime" required 
                defaultValue={kupac.prezime}/>
            </Form.Group>


            <Form.Group controlId="adresa">
                <Form.Label>Adresa</Form.Label>
                <Form.Control type="text" name="adresa" required
                 defaultValue={kupac.adresa}/>
            </Form.Group>

            <Form.Group controlId="iban">
                <Form.Label>Iban</Form.Label>
                <Form.Control type="text" name="iban" required
                defaultValue={kupac.iban} />
            </Form.Group>

        <hr/>

         <Row>
            <Col xs={6} sm={6} md={3} lg={2} xxl={6}>
            <Link
            to={RouteNames.KUPAC_PREGLED}
            className="btn btn-danger siroko"
            >Odustani</Link>    
            </Col>
            <Col xs={6} sm={6} md={9} lg={10} xxl={6}>
                <Button variant ="success" type="submit" className="siroko">
                    Promjeni kupca
                </Button>
            </Col>
        </Row>
        

        </Form>

</>



        
    )
}