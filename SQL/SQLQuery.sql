CREATE DATABASE myfinanceweb
go

use myfinanceweb
go

create table planoconta(
   id int identity(1,1) not null,
   descricao varchar(50) not null,
   tipo char(1) not null,
   primary key(id)

)


create table transacao(
   id int identity(1,1) not null,
   historico varchar(50) not null,
   tipo char(1) not null,
   valor decimal(9,2) not null,
   planocontaid int not null,
   data datetime not null,
   primary key(id),
   foreign key (planocontaid) references planoconta(id),
)
