import { Button, Col, Form, Row } from "react-bootstrap";
import { Link, useNavigate, useParams } from "react-router-dom";
import { RouteNames } from "../../constants";
import VrstaVozilaService from "../../services/VrstaVozilaService";
import { useEffect, useState } from "react";


export default function VrsteVozilaPromjena(){

    const navigate = useNavigate();
    const[vrstaVozila, setVrstaVozila]=useState({});
    const routeParams= useParams();

    async function dohvatiVrsteVozila() 
    {
        const odgovor = await VrstaVozilaService.getBySifra(routeParams.sifra)
        setVrstaVozila(odgovor)
        
    }

    useEffect(()=>{
        dohvatiVrsteVozila();
    },[])

    async function promjena(vrstaVozila){
        const odgovor= await VrstaVozilaService.promjena(routeParams.sifra, vrstaVozila);
        if(odgovor.greska){
            alert(odgovor.poruka)
            return
        }
        console.log(RouteNames.VRSTAVOZILA_PREGLED)
        navigate(RouteNames.VRSTAVOZILA_PREGLED)

    }




    function odradiSubmit(e){
        e.preventDefault();

        let podaci = new FormData(e.target);

        promjena(
            {
                naziv: podaci.get('naziv'),
            }
        );

    }



    return(
        <>
        Promjena vrste vozila
        <Form onSubmit={odradiSubmit}>

            <Form.Group controlId="naziv">
                <Form.Label>Naziv</Form.Label>
                <Form.Control type="text" name="naziv" required 
                defaultValue={vrstaVozila.naziv}/>
            </Form.Group>

        <hr/>

         <Row>
            <Col xs={6} sm={6} md={3} lg={2} xxl={6}>
            <Link
            to={RouteNames.VRSTAVOZILA_PREGLED}
            className="btn btn-danger siroko"
            >Odustani</Link>    
            </Col>
            <Col xs={6} sm={6} md={9} lg={10} xxl={6}>
                <Button variant ="success" type="submit" className="siroko">
                    Promjeni vrstu vozila
                </Button>
            </Col>
        </Row>
        

        </Form>

</>



        
    )
}