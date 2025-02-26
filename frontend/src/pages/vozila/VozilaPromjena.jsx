import { Button, Col, Form, Row } from "react-bootstrap";
import { Link, useNavigate, useParams } from "react-router-dom";
import { RouteNames } from "../../constants";
import VoziloService from "../../services/VoziloService";
import { useEffect, useState } from "react";


export default function VozilaPromjena(){

    const navigate = useNavigate();
    const[vozilo, setVozilo]=useState({});
    const routeParams= useParams();

    async function dohvatiVozila() 
    {
        const odgovor = await VoziloService.getBySifra(routeParams.sifra)
        setVozilo(odgovor)
        
    }

    useEffect(()=>{
        dohvatiVozila();
    },[])

    async function promjena(vozilo){
        const odgovor= await VoziloService.promjena(routeParams.sifra, vozilo);
        if(odgovor.greska){
            alert(odgovor.poruka)
            return
        }
        navigate(RouteNames.VOZILO_PREGLED)

    }




    function odradiSubmit(e){
        e.preventDefault();

        let podaci = new FormData(e.target);

        promjena(
            {
                vrstaVozila: podaci.get('vrstaVozila'),
                dobavljac: podaci.get('dobavljac'),
                marka: podaci.get('marka'),
                godProizvodnje: podaci.get('godProizvodnje'),
                prijedeniKm: podaci.get('prijedeniKm'),
                cijena: podaci.get('cijena'),
                kupac: podaci.get('kupac')

            }
        );

    }



    return(
        <>
        Promjena vozila
        <Form onSubmit={odradiSubmit}>

            <Form.Group controlId="vrstaVozila">
                <Form.Label>Vrstavozila</Form.Label>
                <Form.Control type="text" name="vrstaVozila" required
                defaultValue={vozilo.vrstaVozila} />
            </Form.Group>

            <Form.Group controlId="dobavljac">
                <Form.Label>Dobavljac</Form.Label>
                <Form.Control type="text" name="dobavljac" required 
                defaultValue={vozilo.dobavljac} />
            </Form.Group>

            <Form.Group controlId="marka">
                <Form.Label>Marka</Form.Label>
                <Form.Control type="text" name="marka" required
                defaultValue={vozilo.marka} />
            </Form.Group>

            <Form.Group controlId="godProizvodnje">
                <Form.Label>GodProizvodnje</Form.Label>
                <Form.Control type="int" name="godProizvodnje" required
                defaultValue={vozilo.godProizvodnje} />
            </Form.Group>

            <Form.Group controlId="prijedeniKm">
                <Form.Label>PrijedeniKm</Form.Label>
                <Form.Control type="int" name="prijedeniKM" required
                defaultValue={vozilo.prijedeniKm} />
            </Form.Group>


            <Form.Group controlId="cijena">
                <Form.Label>Cijena</Form.Label>
                <Form.Control type="int" name="cijena" required
                defaultValue={vozilo.cijena} />
            </Form.Group>

            <Form.Group controlId="kupac">
                <Form.Label>Kupac</Form.Label>
                <Form.Control type="text" name="kupac" required
                defaultValue={vozilo.kupac} />
            </Form.Group>
        <hr/>

         <Row>
            <Col xs={6} sm={6} md={3} lg={2} xxl={6}>
            <Link
            to={RouteNames.VOZILO_PREGLED}
            className="btn btn-danger siroko"
            >Odustani</Link>    
            </Col>
            <Col xs={6} sm={6} md={9} lg={10} xxl={6}>
                <Button variant ="success" type="submit" className="siroko">
                    Promjeni vozilo
                </Button>
            </Col>
        </Row>
        

        </Form>

</>



        
    )
}