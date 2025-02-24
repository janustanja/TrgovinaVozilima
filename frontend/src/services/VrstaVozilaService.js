import { HttpService } from "./HttpService";



async function get(){
    return await HttpService.get('/VrstaVozila')
    .then((odgovor)=>{
        //console.table(odgovor.data)
        return odgovor.data;
    })
    .catch((e)=>{})
}

async function dodaj(vrstaVozila){
    return HttpService.post('/VrstaVozila', vrstaVozila)
    .then(()=>{return {greska:false, poruka: 'Dodano'}})
    .catch(()=>{return{greska: true, poruka: 'Problem kod dodavanja'}})
}

async function promjena(sifra,vrstaVozila){
    return HttpService.put('/VrstaVozila/'+sifra, vrstaVozila)
    .then(()=>{return {greska:false, poruka: 'Promjenjeno'}})
    .catch(()=>{return{greska: true, poruka: 'Problem kod promjene'}})
}
async function obrisi(sifra){
    return HttpService.delete('/VrstaVozila/'+sifra)
    .then(()=>{return {greska:false, poruka: 'Obrisano'}})
    .catch(()=>{return{greska: true, poruka: 'Problem kod brisanja'}})
}
async function getBySifra(sifra){
    return await HttpService.get('/VrstaVozila/' + sifra)
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