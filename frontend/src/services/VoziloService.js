import { HttpService } from "./HttpService";



async function get(){
    return await HttpService.get('/Vozilo')
    .then((odgovor)=>{
        //console.table(odgovor.data)
        return odgovor.data;
    })
    .catch((e)=>{})
}

async function dodaj(vozilo){
    return HttpService.post('/Vozilo', vozilo)
    .then(()=>{return {greska:false, poruka: 'Dodano'}})
    .catch(()=>{return{greska: true, poruka: 'Problem kod dodavanja'}})
}

async function promjena(sifra,vozilo){
    return HttpService.put('/Vozilo/'+sifra, vozilo)
    .then(()=>{return {greska:false, poruka: 'Promjenjeno'}})
    .catch(()=>{return{greska: true, poruka: 'Problem kod promjene'}})
}
async function obrisi(sifra){
    return HttpService.delete('/Vozilo/'+sifra)
    .then(()=>{return {greska:false, poruka: 'Obrisano'}})
    .catch(()=>{return{greska: true, poruka: 'Problem kod brisanja'}})
}
async function getBySifra(sifra){
    return await HttpService.get('/Vozilo/' + sifra)
    .then((odgovor)=>{
        //console.table(odgovor.data)
        return odgovor.data;
    })
    .catch((e)=>{})
}


export default {
    get,
    getBySifra,
    dodaj,
    promjena,
    obrisi
    
}