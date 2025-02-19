import { Button, Col, Form, Row } from "react-bootstrap";
import { Link, Route, useNavigate } from "react-router-dom";
import { RouteNames } from "../../constants";
import DobavljacService from "../../services/DobavljacService";


export default function DobavljaciDodaj(){

    const navigate= useNavigate();

    async function dodaj(dobavljac){
        const odgovor= await DobavljacService.dodaj(dobavljac);
        if(odgovor.greska){
            alert(odgovor.poruka)
            return
        }
        Navigate(RouteNames.DOBAVLJAC_PREGLED)

    }




    function odradiSubmit(e){
        e.preventDefault();

        let podaci = new FormData(e.target);

        dodaj(
            {
                naziv: podaci.get('naziv'),
                adresa: podaci.get('adresa'),
                iban: podaci.get('iban')
            }
        );

    }



    return(
        <>
        Dodavanje dobavljača
        <Form onSubmit={odradiSubmit}>

            <Form.Group controlId="naziv">
                <Form.Label>Naziv</Form.Label>
                <Form.Control type="text" name="naziv" required />
            </Form.Group>


            <Form.Group controlId="adresa">
                <Form.Label>Adresa</Form.Label>
                <Form.Control type="text" name="adresa" required />
            </Form.Group>

            <Form.Group controlId="iban">
                <Form.Label>Iban</Form.Label>
                <Form.Control type="text" name="iban" required />
            </Form.Group>

        <hr/>

         <Row className="akcije">
            <Col xs={6} sm={6} md={3} lg={2} xl={6} xxl={6}>
            <Link
            to={RouteNames.DOBAVLJAC_PREGLED}
            className="btn btn-danger siroko"
            >Odustani</Link>    
            </Col>
            <Col xs={6} sm={6} md={9} lg={10} xl={6} xxl={6}>
                <Button 
                variant ="success" type="submit" className="siroko">
                    Dodaj dobavljača
                </Button>
            </Col>
        </Row>
        

     </Form>

</>



        
    )
}