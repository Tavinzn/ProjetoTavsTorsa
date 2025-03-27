create database dbGota;
use dbGota;


create table Usuarios(
	Id int primary key auto_increment,
    Nome varchar(50) not null,
    Email varchar(50) not null,
    Senha varchar(50) not null
);

create table Produtos(
	Id int primary key auto_increment,
    Nome varchar(50) not null,
    Descricao varchar(100) not null,
    Preco decimal(6,2) not null
);