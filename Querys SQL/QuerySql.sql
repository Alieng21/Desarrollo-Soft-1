use bdbiblioteca

/*Tablas*/

create table TblLibros(
	id_libro int primary key identity,
	nombre_libro varchar(50) not null,
	autor_libro varchar(50) not null,
	editorial_libro varchar(50) not null,
	copias_libro int not null,
	ISBN char(13) unique not null
)

create table TblMiembros(
	id_miembro int primary key identity,
	nombre_miembro varchar(50) not null,
	apellido_miembro varchar(50) not null,
	identificacion_miembro char(11) not null,
	email_miembro varchar(50) not null,
	telefono_miembro char(10) not null,
	direccion_miembro varchar(100) not null
)

create table TblRoles(
		id_rol int primary key identity,
		rol varchar(50) not null
)

create table TblUsuarios(
		id_usuario int primary key identity,
		id_miembro int foreign key references TblMiembros(id_miembro) not null,
		id_rol int foreign key references TblRoles(id_rol) not null,
		nombre_usuario varchar(25) not null,
		clave_usuario varchar(50) not null
)


create table TblPrestamos(
		id_prestamo int primary key identity,
		id_libro int foreign key references TblLibros(id_libro) not null,
		id_usuario int foreign key references TblUsuarios(id_usuario) not null,
		fecha_retiro datetime not null,
		fecha_limite datetime not null
)

create table T
