import { Button, Col, Form, Row } from "react-bootstrap";
import { Link, useNavigate, useParams } from "react-router-dom";
import { RouteNames } from "../../constants";
import DobavljacService from "../../services/DobavljacService";
import { useEffect, useState } from "react";


export default function DobavljaciPromjena(){

    const navigate = useNavigate();
    const[dobavljac, setDobavljac]=useState({});
    const routeParams= useParams();

    async function dohvatiDobavljaca() 
    {
        const odgovor = await DobavljacService.getBySifra(routeParams.sifra)
        setDobavljac(odgovor)
        
    }

    useEffect(()=>{
        dohvatiDobavljaca();
    },[])

    async function dodaj(dobavljac){
        const odgovor=DobavljacService.dodaj(dobavljac);
        if(odgovor.greska){
            alert(odgovor.poruka)
            return
        }
        navigate(RouteNames.DOBAVLJAC_PREGLED)

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
                <Form.Control type="text" name="naziv" required 
                defaultValue={dobavljac.naziv}/>
            </Form.Group>


            <Form.Group controlId="adresa">
                <Form.Label>Adresa</Form.Label>
                <Form.Control type="text" name="adresa" required
                 defaultValue={dobavljac.adresa}/>
            </Form.Group>

            <Form.Group controlId="iban">
                <Form.Label>Iban</Form.Label>
                <Form.Control type="text" name="iban" required
                defaultValue={dobavljac.iban} />
            </Form.Group>

        <hr/>

         <Row>
            <Col xs={6} sm={6} md={3} lg={2} xxl={6}>
            <Link
            to={RouteNames.DOBAVLJAC_PREGLED}
            className="btn btn-danger siroko"
            >Odustani</Link>    
            </Col>
            <Col xs={6} sm={6} md={9} lg={10} xxl={6}>
                <Button variant ="success" type="submit" className="siroko">
                    Dodaj dobavljača
                </Button>
            </Col>
        </Row>
        

        </Form>

</>



        
    )
}