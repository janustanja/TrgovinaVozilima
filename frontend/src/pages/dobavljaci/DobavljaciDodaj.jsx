import { Col, Row } from "react-bootstrap";
import { Link } from "react-router-dom";
import { RouteNames } from "../../constants";


export default function DobavljaciDodaj(){
    return(
        <>
        Dodavanje dobavljača
        <Row>
            <Col>
            <Link
            to={RouteNames.DOBAVLJAC_PREGLED}
            className="btn btn-danger siroko"
            >Odustani</Link>    
            </Col>
        </Row>
        </>
    )
}