import { Button, Col, Form, Row } from "react-bootstrap";
import { Link, Route, useNavigate } from "react-router-dom";
import { RouteNames } from "../../constants";
import KupacService from "../../services/KupacService";


export default function KupciDodaj(){

    const navigate= useNavigate();

    async function dodaj(kupac){
        const odgovor= await KupacService.dodaj(kupac);
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

        dodaj(
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
        Dodavanje kupca
        <Form onSubmit={odradiSubmit}>

            <Form.Group controlId="ime">
                <Form.Label>Ime</Form.Label>
                <Form.Control type="text" name="ime" required />
            </Form.Group>

            <Form.Group controlId="prezime">
                <Form.Label>Prezime</Form.Label>
                <Form.Control type="text" name="prezime" required />
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

         <Row>
            <Col xs={6} sm={6} md={3} lg={2} xl={6} xxl={6}>
            <Link
            to={RouteNames.KUPAC_PREGLED}
            className="btn btn-danger siroko"
            >Odustani</Link>    
            </Col>
            <Col xs={6} sm={6} md={9} lg={10} xl={6} xxl={6}>
                <Button variant ="success" type="submit" className="siroko">
                    Dodaj kupca
                </Button>
            </Col>
        </Row>
        

     </Form>

</>



        
    )
}