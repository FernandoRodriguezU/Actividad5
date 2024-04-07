CREATE DATABASE Practico3

CREATE TABLE CLIENTE (
IDCLIENTE INT IDENTITY (1,1) NOT NULL,
NOMBRE NVARCHAR (50) NOT NULL,
APELLIDO NVARCHAR (50) NOT NULL,
CORREO NVARCHAR (20) NULL,
TELEFONO NVARCHAR (50) NULL,
DIRECCION NVARCHAR (50) NOT NULL,
PRIMARY KEY (IDCLIENTE),
);

insert into cliente values('Pedro' ,'Fernandez','pedro@gmail.com','+59172979377','B. San Mateo');
insert into cliente values('Adrián' ,'Pérez' ,'adrian@gmail.com','+59161234567' ,'B. Las Panosas');
insert into cliente values('Belén','González' ,'belen@gmail.com','+59173456789' ,'B. Trigal');
insert into cliente values('Ana' ,'Rodríguez' ,'ana@gmail.com','+59169876543' ,'B. La Loma');
insert into cliente values('Bruno' ,'López' ,'bruno@gmail.com','+59176213456' ,'B. Senac');

SELECT * FROM CLIENTE
