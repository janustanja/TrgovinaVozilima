import { Button, Col, Form, Row } from "react-bootstrap";
import { Link, useNavigate, useParams } from "react-router-dom";
import { RouteNames } from "../../constants";
import Service from "../../services/VoziloService";
import { useEffect, useState } from "react";
import VrstaVozilaService from '../../services/VrstaVozilaService';
import DobavljacService from '../../services/DobavljacService';
import KupacService from '../../services/KupacService';


export default function VozilaPromjena(){

    const navigate = useNavigate();
    const routeParams= useParams();

    const[vrsteVozila, setVrsteVozila]=useState([]);
    const[vrstaVozilaSifra, setVrstaVozilaSifra]=useState(0);

    const[dobavljaci, setDobavljaci]=useState([]);
    const[dobavljacSifra, setDobavljacSifra]=useState(0);

    const[kupci, setKupci]=useState([]);
    const[kupacSifra, setKupacSifra]=useState(0);

    const[vozilo, setVozilo]=useState({});

    async function dohvatiVrsteVozila(){
        const odgovor = await VrstaVozilaService.get();
        setVrsteVozila(odgovor);
    }

    async function dohvatiDobavljace(){
        const odgovor = await DobavljacService.get();
        setDobavljaci(odgovor);
    }

    async function dohvatiKupce(){
        const odgovor = await KupacService.get();
        setKupci(odgovor);
    }


    async function dohvatiVozila() 
    {
        const odgovor = await Service.getBySifra(routeParams.sifra);
        if(odgovor.greska){
            alert(odgovor.poruka);
            return;
        }
        let vozilo =odgovor.poruka;
        setVozilo(vozilo);
        setVrstaVozilaSifra(vozilo.vrstaVozilaSifra);
        setDobavljacSifra(vozilo.dobavljacSifra);
        setKupacSifra(vozilo.kupacSifra);
    
    }
    async function dohvatiInicijalnePodatke(){
        await dohvatiVrsteVozila();
        await dohvatiDobavljace();
        await dohvatiKupce();
        await dohvatiVozila();
    }

    useEffect(()=>{
        dohvatiInicijalnePodatke();
    },[])

    async function promjena(e){
        const odgovor= await Service.promjena(routeParams.sifra, e);
        if(odgovor.greska){
            alert(odgovor.poruka);
            return;
        }
        console.log(RouteNames.VOZILO_PREGLED)
        navigate(RouteNames.VOZILO_PREGLED)

    }


    function odradiSubmit(e){
        e.preventDefault();

        const podaci = new FormData(e.target);

        promjena(
            {
                vrstaVozilaSifra: vrstaVozilaSifra,
                dobavljacSifra: dobavljacSifra,
                marka: podaci.get('marka'),
                godProizvodnje: podaci.get('godProizvodnje'),
                prijedeniKm: podaci.get('prijedeniKm'),
                cijena: podaci.get('cijena'),
                kupacSifra: kupacSifra
            }
        );

    }

    return(
        <>
        Promjena vozila
        <Form onSubmit={odradiSubmit}>

            <Form.Group className='mb-3' controlId="vrstaVozila">
                <Form.Label>Vrsta vozila</Form.Label>
                <Form.Select
                value={vrstaVozilaSifra}
                onChange={(e)=>{setVrstaVozilaSifra(e.target.value)}}
                >
                    {vrsteVozila && vrsteVozila.map((s,index)=>(
                        <option key={index} value={s.sifra}>
                            {s.naziv}
                        </option>
                    ))}
                </Form.Select>
            </Form.Group>

            <Form.Group className='mb-3' controlId="dobavljac">
                <Form.Label>Dobavljač</Form.Label>
                <Form.Select
                 value={dobavljacSifra}
                 onChange={(e)=>{setDobavljacSifra(e.target.value)}}
                 >
                    {dobavljaci && dobavljaci.map((s,index)=>(
                        <option key={index} value={s.sifra}>
                            {s.naziv}
                        </option>
                    ))}
                    </Form.Select> 
            </Form.Group>

            <Form.Group controlId="marka">
                <Form.Label>Marka</Form.Label>
                <Form.Control type="text" name="marka" required
                defaultValue={vozilo.marka} />
            </Form.Group>

            <Form.Group controlId="godProizvodnje">
                <Form.Label>Godina proizvodnje</Form.Label>
                <Form.Control type="int" name="godProizvodnje" required
                defaultValue={vozilo.godProizvodnje} />
            </Form.Group>

            <Form.Group controlId="prijedeniKm">
                <Form.Label>Prijeđeni kilometri</Form.Label>
                <Form.Control type="int" name="prijedeniKm" required
                defaultValue={vozilo.prijedeniKm} />
            </Form.Group>


            <Form.Group controlId="cijena">
                <Form.Label>Cijena</Form.Label>
                <Form.Control type="int" name="cijena" required
                defaultValue={vozilo.cijena} />
            </Form.Group>

            <Form.Group className='mb-3' controlId="kupac">
                <Form.Label>Kupac</Form.Label>
                <Form.Select
                value={kupacSifra}
                onChange={(e)=>{setKupacSifra(e.target.value)}}
                >
                    {kupci && kupci.map((s,index)=>(
                        <option key={index} value={s.sifra}>
                            {s.ime+ ' '+ s.prezime}
                        </option>
                    ))}
                </Form.Select>
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