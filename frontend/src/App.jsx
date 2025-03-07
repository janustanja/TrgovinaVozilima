import 'bootstrap/dist/css/bootstrap.min.css'
import './App.css'
import { Container } from 'react-bootstrap'
import NavBarEdunova from './components/NavBarEdunova'
import { RouteNames } from './constants'
import Pocetna from './pages/Pocetna'
import { Route, Routes } from 'react-router-dom'
import DobavljaciPregled from './pages/dobavljaci/DobavljaciPregled'
import DobavljaciDodaj from './pages/dobavljaci/DobavljaciDodaj'
import DobavljaciPromjena from './pages/dobavljaci/DobavljaciPromjena'
import KupciPregled from './pages/kupci/KupciPregled'
import KupciDodaj from './pages/kupci/KupciDodaj'
import KupciPromjena from './pages/kupci/KupciPromjena'
import VrsteVozilaPregled from './pages/vrsteVozila/VrsteVozilaPregled'
import VrsteVozilaDodaj from './pages/vrsteVozila/VrsteVozilaDodaj'
import VrsteVozilaPromjena from './pages/vrsteVozila/VrsteVozilaPromjena'
import VozilaPregled from './pages/vozila/VozilaPregled'
import VozilaDodaj from './pages/vozila/VozilaDodaj'
import VozilaPromjena from './pages/vozila/VozilaPromjena'
import EraDijagram from './pages/EraDijagram'

function App() {
  return (
    <>
     <Container>
        <NavBarEdunova />
        
        <Routes>
          <Route path={RouteNames.HOME} element={<Pocetna />} />
          <Route path={RouteNames.DOBAVLJAC_PREGLED} element ={<DobavljaciPregled />} />
          <Route path={RouteNames.DOBAVLJAC_NOVI} element={<DobavljaciDodaj/>} />
          <Route path={RouteNames.DOBAVLJAC_PROMJENA} element={<DobavljaciPromjena />} />

          <Route path={RouteNames.KUPAC_PREGLED} element ={< KupciPregled />} />
          <Route path={RouteNames.KUPAC_NOVI} element={<KupciDodaj/>} />
          <Route path={RouteNames.KUPAC_PROMJENA} element={<KupciPromjena />} />

          <Route path={RouteNames.VRSTAVOZILA_PREGLED} element ={<VrsteVozilaPregled />} />
          <Route path={RouteNames.VRSTAVOZILA_NOVI} element={<VrsteVozilaDodaj/>} />
          <Route path={RouteNames.VRSTAVOZILA_PROMJENA} element={<VrsteVozilaPromjena />} />

          <Route path={RouteNames.VOZILO_PREGLED} element ={<VozilaPregled />} />
          <Route path={RouteNames.VOZILO_NOVI} element={<VozilaDodaj/>} />
          <Route path={RouteNames.VOZILO_PROMJENA} element={<VozilaPromjena />} />

          <Route path={RouteNames.ERA} element={<EraDijagram />} /> 

        </Routes>


        <hr/>
        &copy; Tanja 2025
      </Container> 
    </>
  )
}

export default App
