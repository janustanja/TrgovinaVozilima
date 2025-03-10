import { Button, Col, Form, Row } from "react-bootstrap";
import { Link, Route, useNavigate } from "react-router-dom";
import { RouteNames } from "../../constants";
import VoziloService from "../../services/VoziloService";
import VrstaVozilaService from "../../services/VrstaVozilaService";
import DobavljacService from "../../services/DobavljacService";
import KupacService from "../../services/KupacService";


export default function VozilaDodaj(){

    const navigate= useNavigate();

    const[vrsteVozila, setVrsteVozila]=useState([]);
    const[vrstaVozilaSifra, setVrstaVozilaSifra]=useState(0);
    
    const[dobavljaci, setDobavljaci]=useState([]);
    const[dobavljacSifra, setDobavljacSifra]=useState(0);
    
    const[kupci, setKupci]=useState([]);
    const[kupacSifra, setKupacSifra]=useState(0);

    async function dohvatiVrsteVozila(){
            const odgovor = await VrstaVozilaService.get();
            setVrsteVozila(odgovor.poruka);
            setVrstaVozilaSifra(odgovor.poruka[0].sifra);
        }
    
        async function dohvatiDobavljace(){
            const odgovor = await DobavljacService.get();
            setDobavljaci(odgovor.poruka);
            setDobavljacSifra(odgovor.poruka[0].sifra)
        }
    
        async function dohvatiKupce(){
            const odgovor = await KupacService.get();
            setKupci(odgovor.poruka);
            setKupacSifra(odgovor.poruka[0].sifra)
        }

        useEffect(()=>{
            dohvatiVrsteVozila();
            dohvatiDobavljace();
            dohvatiKupce();
          },[]);


    async function dodaj(e){
        const odgovor= await VoziloService.dodaj(e);
        if(odgovor.greska){
            alert(odgovor.poruka)
            return
        }
        Navigate(RouteNames.VOZILO_PREGLED)

    }


    function odradiSubmit(e){
        e.preventDefault();

        const podaci = new FormData(e.target);

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
                <Form.Label>Vrsta vozila</Form.Label>
                <Form.Select
                onChange={(e)=>{setVrstaVozilaSifra(e.target.value)}}
                >
                    {vrsteVozila && vrsteVozila.map((s, index)=>(
                        <option key={index} value={s.sifra}>
                            {s.naziv}
                        </option>
                    ))}
                </Form.Select>
            </Form.Group>

            <Form.Group controlId="dobavljac">
                <Form.Label>Dobavljač</Form.Label>
                <Form.Select
                onChange={(e)=>{setDobavljacSifra(e.target.value)}}
                >
                    {dobavljaci && dobavljaci.map((s, index)=>(
                        <option key={index} value={s.sifra}>
                            {s.naziv}
                        </option>
                    ))}
                </Form.Select>
            </Form.Group>

            <Form.Group controlId="marka">
                <Form.Label>Marka</Form.Label>
                <Form.Control type="text" name="marka" required />
            </Form.Group>

            <Form.Group controlId="godProizvodnje">
                <Form.Label>Godina proizvodnje</Form.Label>
                <Form.Control type="int" name="godProizvodnje" required />
            </Form.Group>

            <Form.Group controlId="prijedeniKm">
                <Form.Label>Prijeđeni kilometri</Form.Label>
                <Form.Control type="int" name="prijedeniKm" required />
            </Form.Group>


            <Form.Group controlId="cijena">
                <Form.Label>Cijena</Form.Label>
                <Form.Control type="int" name="cijena" required />
            </Form.Group>

            <Form.Group controlId="kupac">
                <Form.Label>Kupac</Form.Label>
                <Form.Select
                 onChange={(e)=>{setKupacSifra(e.target.value)}}
                 >
                    {kupci && kupci.map((s, index)=>(
                        <option key={index} value={s.sifra}>
                            {s.ime}
                        </option>
                    ))}
                 </Form.Select>
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