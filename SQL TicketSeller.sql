use master;
go
drop database if exists ticketSeller;
go

create database ticketSeller;
go
alter database ticketSeller collate Croatian_CI_AS;
go

use ticketSeller;

create table occasionCategory(
id int not null primary key identity (1,1),
categoryName varchar (80) not null
);

create table Occasions(
id int not null primary key,
occasionName varchar (80) not null,
occasionPlace varchar (80) not null,
occasionCategoryid int not null,
startTime datetime not null
);

create table Users(
id int not null primary key identity (1,1),
firstName varchar(80) not null,
lastName varchar(80) not null,
oib varchar (80) not null,
adress varchar(80) not null,
email varchar (80) not null,
city varchar (80) not null,
registrationDate datetime not null
);

create table Tickets(
id int not null primary key identity (1,1),
userId int not null, 
occasionId int not null,
seat int,
seated bit,
);

alter table Occasions add foreign key (occasionCategoryid) references occasionCategory (id);
alter table Tickets add foreign key (userId) references Users(id);
alter table Tickets add foreign key (occasionId) references Occasions (id);

insert into occasionCategory (categoryName) values ('Koncerti'),
 ('Predstave'),
 ('Izlozbe');

 select * from occasionCategory;

 insert into Occasions (id,occasionName,occasionPlace,occasionCategoryid,startTime) values ('1','Koncert Miše Kovača','Arena Split','1','2023-11-10'),
 ('2','Predstava Zagrebačkog kazalista','HNK Zagreb','2','2023-12-17'),
 ('3','Izložba Lupino','Galerija Ivana Zajca','3','2024-01-01');

 select * from Occasions;

 insert into Users (firstName,lastName,oib,adress,email,city,registrationDate) values 
 ('Franjo','Franjic','12345678900','VIM 21','F.franjic','Osijek','2023-01-02'),
 ('Marko','Maric','12345678901','VIM 33','M.maric@gmail.com','Osijek','2023-01-01');

 select * from Users;

 insert into tickets (userId,occasionId,seat,seated) values  ('2','2','0','0'),
 ('1','1','13','1');

 select * from tickets;

 insert into occasionCategory (categoryName) values ('Seminari'), ('Memorijali'), ('Utakmice');


 insert into Occasions (id,occasionName,occasionPlace,occasionCategoryid,startTime) values 
 ('5','Memorijal Blage Zadre','Vukovar','5','2024-02-01'),
 ('6','Excell edukacija/seminar','Zagreb','4','2024-03-27'),
 ('4','Utakmica Dinamo Zagreb protiv Osijeka','Zagreb/Stadion Maksimir','6','2023-12-17');

 select * from Occasions where occasionCategoryid='3';

 insert into Users (firstName,lastName,oib,adress,email,city,registrationDate) values ('Đuro','Trubić','12345678900','Trg Josipa Gajskog 777','đ.tr@gmail.com','Vukovar','2023-12-13'),
 ('Ivan','Krišmo','11223344556','VIM 29','bm@gmail.com','Osijek','2023-12-14'),
 ('Bartol','Krišmo','11223344557','VIM 29','im@gmail.com','Osijek','2023-12-14'),
 ('Fran','Latmi','11223344558','VPG 33','f.m@yahoo.com','Osijek','2023-12-14');

 insert into tickets (userId,occasionId,seat,seated) values ('3','4','14','1'), ('4','5','12','1'), ('4','6','22','1');