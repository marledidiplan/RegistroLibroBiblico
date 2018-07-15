CREATE DATABASE DbLibro
GO
use DbLibro
GO
CREATE TABLE Libro
(
	LibroId int primary key identity,
	Fecha Datetime,
	Descripcion varchar(50),
	Tipo Varchar(20)

);

