create database Gestion
go
use Gestion 
go
Create table Usuario (
Id int identity(1,1) primary key,
Nombre varchar(70) not null,
Apellido varchar(70) not null,
FechaNacimiento Date not null,
Rut varchar(9) not null,
Fono varchar(12),
Cargo varchar(100),
Correo varchar(150) not null,
Rol int not null,
IdLogin int not null,
)

Create table "Login"(
Id int identity(1,1) primary key,
Usuario varchar(50) not null,
Contraseña varchar(10) not null
)

Create table Tarea (
Id int identity(1,1) primary key,
IdUsuario int not null,
NombreTarea varchar(100) not null,
Estado int not null,
FechaInicio datetime not null,
FechaTermino datetime
)

go

alter table Usuario
add constraint FK_Usuario_Login Foreign key (IdLogin) references "login" (Id)

alter table Tarea
add constraint FK_Tarea_Usuario foreign key (IdUsuario) references Usuario (Id)

go

insert into "Login" values('rceballos05','123456')
insert into Usuario values('Rodrigo','Ceballos','05-03-1998','197137487','+56123456789','Desarrollador FullStack Vue - .NET','rodrigo@gmail.com',1,1)
insert into Tarea values(1,'Crear Api',1,GETDATE(),NULL)

SELECT * FROM Tarea
SELECT * FROM Login

insert into "Login" values('cortiz1','123456')
go
insert into Usuario values('Camilo','Ortiz','05-04-1998','123456789','+56987654321','Desarrollador FullStack','camilo@gmail.com',1,2)
go
insert into Tarea values(2,'Crear Front end',1,GETDATE(),NULL)
