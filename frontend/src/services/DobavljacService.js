import { HttpService } from "./HttpService";



async function get(){
    return await HttpService.get('/Dobavljac')
    .then((odgovor)=>{
        //console.table(odgovor.data)
        return odgovor.data;
    })
    .catch((e)=>{})
}

async function dodaj(dobavljac){
    return HttpService.post('/Dobavljac', dobavljac)
    .then(()=>{return {greska:false, poruka: 'Dodano'}})
    .catch(()=>{return{greska: true, poruka: 'Problem kod dodavanja'}})
}

async function promjena(sifra,dobavljac){
    return HttpService.put('/Dobavljac/'+sifra, dobavljac)
    .then(()=>{return {greska:false, poruka: 'Promjenjeno'}})
    .catch(()=>{return{greska: true, poruka: 'Problem kod promjene'}})
}
async function obrisi(sifra){
    return HttpService.delete('/Dobavljac/'+sifra)
    .then(()=>{return {greska:false, poruka: 'Obrisano'}})
    .catch(()=>{return{greska: true, poruka: 'Problem kod brisanja'}})
}
async function getBySifra(sifra){
    return await HttpService.get('/Dobavljac/' + sifra)
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