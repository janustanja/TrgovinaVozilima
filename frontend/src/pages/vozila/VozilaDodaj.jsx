import { Button, Col, Form, Row } from "react-bootstrap";
import { Link, Route, useNavigate } from "react-router-dom";
import { RouteNames } from "../../constants";
import VoziloService from "../../services/VoziloService";


export default function VozilaDodaj(){

    const navigate= useNavigate();

    async function dodaj(vozilo){
        const odgovor= await VoziloService.dodaj(vozilo);
        if(odgovor.greska){
            alert(odgovor.poruka)
            return
        }
        Navigate(RouteNames.VOZILO_PREGLED)

    }




    function odradiSubmit(e){
        e.preventDefault();

        let podaci = new FormData(e.target);

        dodaj(
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
        Dodavanje vozila
        <Form onSubmit={odradiSubmit}>

            <Form.Group controlId="vrstaVozila">
                <Form.Label>Vrstavozila</Form.Label>
                <Form.Control type="text" name="vrstaVozila" required />
            </Form.Group>

            <Form.Group controlId="dobavljac">
                <Form.Label>Dobavljac</Form.Label>
                <Form.Control type="text" name="dobavljac" required />
            </Form.Group>

            <Form.Group controlId="marka">
                <Form.Label>Marka</Form.Label>
                <Form.Control type="text" name="marka" required />
            </Form.Group>

            <Form.Group controlId="godProizvodnje">
                <Form.Label>GodProizvodnje</Form.Label>
                <Form.Control type="int" name="godProizvodnje" required />
            </Form.Group>

            <Form.Group controlId="prijedeniKm">
                <Form.Label>PrijedeniKm</Form.Label>
                <Form.Control type="int" name="prijedeniKM" required />
            </Form.Group>


            <Form.Group controlId="cijena">
                <Form.Label>Cijena</Form.Label>
                <Form.Control type="int" name="cijena" required />
            </Form.Group>

            <Form.Group controlId="kupac">
                <Form.Label>Kupac</Form.Label>
                <Form.Control type="text" name="kupac" required />
            </Form.Group>

        <hr/>

         <Row className="akcije">
            <Col xs={6} sm={6} md={3} lg={2} xl={6} xxl={6}>
            <Link
            to={RouteNames.VOZILO_PREGLED}
            className="btn btn-danger siroko"
            >Odustani</Link>    
            </Col>
            <Col xs={6} sm={6} md={9} lg={10} xl={6} xxl={6}>
                <Button 
                variant ="success" type="submit" className="siroko">
                    Dodaj vozilo
                </Button>
            </Col>
        </Row>
        

     </Form>

</>



        
    )
}