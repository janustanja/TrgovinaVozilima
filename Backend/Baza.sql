use master;
go

drop database if exists trgovina;
go

create database trgovina collate Croatian_CI_AS;
go

use trgovina;
go

create table vrstevozila (
sifra int not null primary key identity(1,1),
naziv varchar(30) not null);

create table kupci (
sifra int not null primary key identity(1,1),
ime varchar(30) not null,
prezime varchar(30) not null,
adresa varchar(100) not null,
iban varchar(30) not null
);

create table dobavljaci (
sifra int not null primary key identity(1,1),
naziv varchar(50) not null,
adresa varchar(100) not null,
iban varchar(30) not null
);

create table vozila (
sifra int not null primary key identity(1,1),
vrstavozila int not null references vrstevozila(sifra),
dobavljac int not null references dobavljaci(sifra),
marka varchar(30) not null,
godproizvodnje int not null,
prijedenikm int not null,
cijena decimal(18,2) not null,
kupac int not null references kupci(sifra)
);
insert into vrstevozila (naziv)
values 
('Automobil'),
('Autobus'),
('Kombi'),
('Kamion');

insert into kupci (ime, prezime, adresa, iban)
values
('Mirko', 'Marić', 'Matije Gupca 55 Virovitica', 'HR8452254785126447529'),
('Ivana', 'Kovač', 'Trg bana Josipa Jelačića 2 Zagreb', 'HR8544120326558945258'),
('Jakov', 'Ban', 'Svačićev trg 23 Osijek', 'HR8452654854215978854'),
('Dijana', 'Dombić', 'Miroslava Krleže 75 Varaždin', 'HR7412589632145698753');

insert into dobavljaci (naziv, adresa, iban)
values
('Transport Franić', 'Boškovićeva 13 Beli Manastir', 'HR4552166903487526781'),
('Dominković Prijevoz', 'Cvjetni trg 1 Zagreb', 'HR6223014577521000326'),
('Auto kuća Maras', 'Dalmatinska ulica 8 Split', 'HR1254865770126895587');

insert into vozila(vrstavozila, dobavljac, marka, godproizvodnje, prijedenikm, cijena, kupac)
values
(1, 3, 'Volvo', '2014', 122000, 11000, 4 ),
(4, 1, 'Man', '2008', 682000, 21000, 1 ),
(2, 2, 'Setra', '2000', 800000, 50000, 3 ),
(3, 3, 'Mercedes', '2020', 50000, 33000, 3 )
;

