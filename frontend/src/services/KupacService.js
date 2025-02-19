import { HttpService } from "./HttpService";



async function get(){
    return await HttpService.get('/Kupac')
    .then((odgovor)=>{
        //console.table(odgovor.data)
        return odgovor.data;
    })
    .catch((e)=>{})
}

async function dodaj(Kupac){
    return HttpService.post('/Kupac', Kupac)
    .then(()=>{return {greska:false, poruka: 'Dodano'}})
    .catch(()=>{return{greska: true, poruka: 'Problem kod dodavanja'}})
}

async function promjena(sifra,Kupac){
    return HttpService.put('/Kupac/'+sifra, Kupac)
    .then(()=>{return {greska:false, poruka: 'Promjenjeno'}})
    .catch(()=>{return{greska: true, poruka: 'Problem kod promjene'}})
}
async function obrisi(sifra){
    return HttpService.delete('/Kupac/'+sifra)
    .then(()=>{return {greska:false, poruka: 'Obrisano'}})
    .catch(()=>{return{greska: true, poruka: 'Problem kod brisanja'}})
}
async function getBySifra(sifra){
    return await HttpService.get('/Kupac/' + sifra)
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