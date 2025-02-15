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
    dodaj
    
}