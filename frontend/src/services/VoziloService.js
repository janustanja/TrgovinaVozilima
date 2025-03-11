import { HttpService } from "./HttpService";



async function get(){
    return await HttpService.get('/Vozilo')
    .then((odgovor)=>{
        //console.table(odgovor.data)
        return odgovor.data;
    })
    .catch((e)=>{console.error(e)})
}

async function getBySifra(sifra){
    return await HttpService.get('/Vozilo/' + sifra)
    .then((odgovor)=>{
        //console.table(odgovor.data)
        return {greska: false, poruka: odgovor.data}
    })
    .catch(()=>{
        return {greska:true, poruka: 'Ne postoji vozilo!'}
    })
}

async function obrisi(sifra){
    return HttpService.delete('/Vozilo/'+sifra)
    .then((odgovor)=>{
        return {greska:false, poruka: odgovor.data}
    })
    .catch((e)=>{
        return{greska: true, poruka: 'Problem kod brisanja'}
    })
}

async function dodaj(Vozilo){
    return await HttpService.post('/Vozilo', Vozilo)
    .then((odgovor)=>{
        return {greska:false, poruka: odgovor.data}})
    .catch((e)=>{
        switch (e.status) {
            case 400:
                let poruke='';
                for(const kljuc in e.response.data.errors){
                    poruke += kljuc + ': '+ e.response.data.errors[kljuc][0]+ '/n';
                }
                return {greska: true, poruka: poruke}
            default:
                return {greska: true, poruka: 'Vozilo se ne može dodati!'}
        }
    })
        
}

async function promjena(sifra,Vozilo){
    return await HttpService.put('/Vozilo/'+sifra, Vozilo)
    .then((odgovor)=>{
        return {greska:false, poruka: odgovor.data}
    })
    .catch((e)=>{
        switch (e.status) {
            case 400:
                let poruke='';
                for(const kljuc in e.response.data.errors){
                    poruke+=kljuc+': '+e.rasponse.data.errors[kljuc][0]+'\n';
                }
                console.log(poruke)
                return{greska:true, poruka:poruke}
            default:
                return{greska:true, poruka: 'Vozilo se ne može promjeniti!'}
        }
    })
}




export default {
    get,
    getBySifra,
    obrisi,
    dodaj,
    promjena,
}