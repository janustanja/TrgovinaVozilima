import { Button, Col, Form, Row } from "react-bootstrap";
import { Link, Route, useNavigate } from "react-router-dom";
import { RouteNames } from "../../constants";
import VrstaVozilaService from "../../services/VrstaVozilaService";


export default function VrsteVozilaDodaj(){

    const navigate= useNavigate();

    async function dodaj(vrstaVozila){
        const odgovor= await VrstaVozilaService.dodaj(vrstaVozila);
        if(odgovor.greska){
            alert(odgovor.poruka)
            return
        }
        Navigate(RouteNames.VRSTAVOZILA_PREGLED)

    }




    function odradiSubmit(e){
        e.preventDefault();

        let podaci = new FormData(e.target);

        dodaj(
            {
                naziv: podaci.get('naziv')
            }
        );

    }



    return(
        <>
        Dodavanje vrste vozila
        <Form onSubmit={odradiSubmit}>

            <Form.Group controlId="naziv">
                <Form.Label>Naziv</Form.Label>
                <Form.Control type="text" name="naziv" required />
            </Form.Group>

        <hr/>

         <Row className="akcije">
            <Col xs={6} sm={6} md={3} lg={2} xl={6} xxl={6}>
            <Link
            to={RouteNames.VRSTAVOZILA_PREGLED}
            className="btn btn-danger siroko"
            >Odustani</Link>    
            </Col>
            <Col xs={6} sm={6} md={9} lg={10} xl={6} xxl={6}>
                <Button 
                variant ="success" type="submit" className="siroko">
                    Dodaj vrstu vozila
                </Button>
            </Col>
        </Row>
        

     </Form>

</>



        
    )
}