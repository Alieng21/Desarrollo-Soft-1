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
		id_estado int foreign key references TblEstados(id_estado) not null,
		fecha_retiro datetime not null,
		fecha_limite datetime not null
)

create table TblEstados(
		id_estado int primary key identity,
		estado varchar(50) not null
)

create table TblDevoluciones(
		id_devoluciones int identity primary key,
		id_prestamo int foreign key references TblPrestamos(id_prestamo) not null,
		fecha_devolucion datetime not null
)

go
/*Procedures*/

create procedure Insertar_TblLibros 
		@nombre_libro varchar(50),
		@autor_libro varchar(50),
		@editorial_libro varchar(50),
		@copias_libro int,
		@ISBN char(13)
	as
		insert into TblLibros values(@nombre_libro,@autor_libro,@editorial_libro,@copias_libro,@ISBN)

go

create procedure Insertar_TblMiembros
		@nombre_miembro varchar(50),
		@apellido_miembro varchar(50),
		@identificacion_miembro char(11),
		@email_miembro varchar(50),
		@telefono_miembro char(10),
		@direccion_miembro varchar(100)
	as
		insert into TblMiembros values(@nombre_miembro,@apellido_miembro,@identificacion_miembro,@email_miembro,@telefono_miembro,@direccion_miembro)

go

create procedure Insertar_TblUsuarios
		@id_miembro int,
		@id_rol int,
		@nombre_usuario varchar(25),
		@clave_usuario varchar(50)
	as
		insert into	TblUsuarios values(@id_miembro,@id_rol,@nombre_usuario,@clave_usuario)

go

create procedure Insertar_TblRoles
		@rol varchar(50)
	as
		insert into TblRoles values(@rol)

go

create procedure Insertar_TblPrestamos
		@id_libro int,
		@id_usuario int,
		@id_estado int,
		@fecha_retiro datetime,
		@fecha_limite datetime
	as
		insert into TblPrestamos values(@id_libro,@id_usuario,@id_estado,@fecha_retiro,@fecha_limite)

go

create procedure Insertar_TblEstados
		@estado varchar(50)
	as
		insert into TblEstados values(@estado)

go

create procedure Insertar_TblDevoluciones
		@id_prestamo int,
		@fecha_devolucion datetime
	as
		insert into TblDevoluciones values(@id_prestamo,@fecha_devolucion)