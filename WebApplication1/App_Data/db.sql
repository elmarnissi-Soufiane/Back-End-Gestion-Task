use master
create database Craft
use craft

create table memebres(IdM varchar(255) primary key,Nom varchar (255),Prenom varchar (255),Email varchar (255),Num int)
insert into memebres values ('FB323223','soufiane','elmarnissi','soufianelemarnissi@gmail.com',0625342542)
create table projet(IdP int primary key IDENTITY(1,1),Titre varchar (255),Proprie varchar (255),TypeP varchar (255),DateL date,Progression int)
insert into projet values('prj1','proprie1','type1','12/12/2023',60)
create table Task(IdT int primary key IDENTITY(1,1),Descriptiont varchar (255),Duree int ,Statu varchar (255),IdP int foreign key references projet(IdP))
insert into Task values ('testetststettetstettstetstetetstetstetstet',2,'in procces',1)
create table Job(IdJ int primary key IDENTITY(1,1),IdP int foreign key references projet(IdP),IdM varchar(255) foreign key references memebres(IdM),IdT int foreign key references Task(IdT))

select * from projet

alter table Task Add IdM Varchar(255) foreign key references memebres(IdM)


create table Admine(Id int primary key IDENTITY(1,1),Email varchar(255),Pass varchar(255))

insert into Admine values ('Admin','Admin')