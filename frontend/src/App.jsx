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
        </Routes>


        <hr/>
        &copy; Tanja 2025
      </Container> 
    </>
  )
}

export default App
