create database agenda character set utf8mb4
collate utf8mb4_unicode_ci;

use agenda;

create table if not exists usuarios(
id int primary key not null auto_increment,
nome varchar(250) not null,
senha varchar(250) not null,
cpf varchar(11) not null unique
);

create table if not exists contatos(
id_usuario int not null,
id int primary key not null auto_increment,
nome varchar(250) not null,
telefone varchar(11),
email varchar(250),
foreign key (id_usuario) references usuarios(id)
);

select * from usuarios;
select * from contatos;
