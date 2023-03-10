Create database bdbiblioteca

go

use bdbiblioteca

/*Tablas*/

create table TblCategorias(
		id_categoria int primary key identity,
		categoria varchar(50) not null
)

create table TblLibros(
	id_libro int primary key identity,
	id_categoria int foreign key references TblCategorias(id_categoria) not null,
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

create table TblEstados(
		id_estado int primary key identity,
		estado varchar(50) not null
)

create table TblPrestamos(
		id_prestamo int primary key identity,
		id_libro int foreign key references TblLibros(id_libro) not null,
		id_usuario int foreign key references TblUsuarios(id_usuario) not null,
		id_estado int foreign key references TblEstados(id_estado) not null,
		copias_libro int not null,
		fecha_prestamo datetime not null,
		fecha_limite datetime not null
)

create table TblDevoluciones(
		id_devolucion int identity primary key,
		id_prestamo int foreign key references TblPrestamos(id_prestamo) not null,
		fecha_devolucion datetime not null
)

go


/*Procedures*/

-- INSERTAR --

create procedure Insertar_TblLibros 
		@id_categoria int,
		@nombre_libro varchar(50),
		@autor_libro varchar(50),
		@editorial_libro varchar(50),
		@copias_libro int,
		@ISBN char(13)
	as
		insert into TblLibros values(@id_categoria,@nombre_libro,@autor_libro,@editorial_libro,@copias_libro,@ISBN)

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
		@isbn char(13),
		@identificacion char(11),
		@id_estado int,
		@copias_libro int,
		@fecha_prestamo datetime,
		@fecha_limite datetime
	as
		insert into TblPrestamos values((select Id from Mostrar_TblLibros where ISBN = @isbn),(select IdUsuario from Mostrar_TblUsuario where ID = @identificacion),@id_estado,@copias_libro,@fecha_prestamo,@fecha_limite)
		update TblLibros set copias_libro = copias_libro - @copias_libro where id_libro = (select Id from Mostrar_TblLibros where ISBN = @isbn)
go
 

create procedure Insertar_TblEstados
		@estado varchar(50)
	as
		insert into TblEstados values(@estado)

go

create procedure Insertar_TblDevoluciones
		@id_prestamo int,
		@fecha_devolucion datetime,
		@copias_libro int
	as
		insert into TblDevoluciones values(@id_prestamo,@fecha_devolucion)
		update TblLibros set copias_libro = copias_libro + @copias_libro where id_libro = (select id_libro from TblPrestamos where id_prestamo = @id_prestamo)
		Update TblPrestamos set id_estado = 3 where id_prestamo = @id_prestamo
go

create procedure Insertar_TblCategorias
		@categoria varchar(50)
	as
		insert into TblCategorias values (@categoria)

go

-- EDITAR --

create procedure Editar_TblLibros
		@id_libro int,
		@id_categoria int,
		@nombre_libro varchar(50),
		@autor_libro varchar(50),
		@editorial_libro varchar(50),
		@copias_libro int,
		@ISBN char(13)
	as
		update TblLibros set id_categoria = @id_categoria, nombre_libro = @nombre_libro, autor_libro = @autor_libro, 
		editorial_libro = @editorial_libro, copias_libro = @copias_libro, ISBN = @ISBN where id_libro = @id_libro

go

create procedure Editar_TblMiembros
		@id_miembro int,
		@nombre_miembro varchar(50),
		@apellido_miembro varchar(50),
		@identificacion_miembro char(11),
		@email_miembro varchar(50),
		@telefono_miembro char(10),
		@direccion_miembro varchar(100)
	as
		update TblMiembros set nombre_miembro = @nombre_miembro, apellido_miembro = @apellido_miembro, 
		identificacion_miembro = @identificacion_miembro, email_miembro = @email_miembro, telefono_miembro = @telefono_miembro, 
		direccion_miembro = @direccion_miembro where id_miembro = @id_miembro

go

create procedure Editar_TblUsuarios
		@id_usuario int,
		@id_miembro int,
		@id_rol int,
		@nombre_usuario varchar(25),
		@clave_usuario varchar(50)
	as
		update TblUsuarios set id_miembro = @id_miembro, id_rol = @id_rol, nombre_usuario = @nombre_usuario, 
		clave_usuario = @clave_usuario where id_usuario = @id_usuario

go

create procedure Editar_TblRoles
		@id_rol int,
		@rol varchar(50)
	as
		update TblRoles set rol = @rol where id_rol = @id_rol

go

create procedure Editar_TblPrestamos
		@id_prestamo int,
		@id_libro int,
		@id_usuario int,
		@id_estado int,
		@fecha_prestamo datetime,
		@fecha_limite datetime
	as
		update TblPrestamos set id_libro = @id_libro, id_usuario = @id_usuario, id_estado = @id_estado, 
		fecha_prestamo = @fecha_prestamo, fecha_limite = @fecha_limite where id_prestamo = @id_prestamo

go

create procedure Editar_TblEstados
		@id_estado int,
		@estado varchar(50)
	as
		update TblEstados set estado = @estado where id_estado = @id_estado

go

create procedure Editar_TblDevoluciones
		@id_devolucion int,
		@id_prestamo int,
		@fecha_devolucion datetime
	as
		update TblDevoluciones set  fecha_devolucion = @fecha_devolucion where id_devolucion = @id_devolucion

go

create procedure Editar_TblCategorias
		@id_categoria int,
		@categoria varchar(50)
	as
		update TblCategorias set categoria = @categoria where id_categoria = @id_categoria

go

-- ELIMINAR --

create procedure Eliminar_TblLibros
		@id_libro int
	as
		delete from TblLibros where id_libro = @id_libro

go

create procedure Eliminar_TblMiembros
		@id_miembro int
	as
		delete from TblMiembros where id_miembro = @id_miembro

go

create procedure Eliminar_TblUsuarios
		@id_usuario int
	as
		delete from TblUsuarios where id_usuario = @id_usuario

go

create procedure Eliminar_TblRoles
		@id_rol int
	as
		delete from TblRoles where id_rol = @id_rol

go

create procedure Eliminar_TblPrestamos
		@id_prestamo int
	as
		delete from TblPrestamos where id_prestamo = @id_prestamo

go

create procedure Eliminar_TblEstados
		@id_estado int
	as
		delete from TblEstados where id_estado = @id_estado

go

create procedure Eliminar_TblDevoluciones
		@id_devolucion int
	as
		delete from TblDevoluciones where id_devolucion = @id_devolucion

go

create procedure Eliminar_TblCategorias
		@id_categoria int
	as
		delete from TblCategorias where id_categoria = @id_categoria

go

/*Vistas*/

-- MOSTRAR LIBROS: Muestra todos los libros almacenados en la base de datos con sus respectivas informaciones --

create view Mostrar_TblLibros as
	select TblLibros.id_libro as 'Id', TblLibros.nombre_libro as 'Nombre', TblCategorias.categoria as 'Categoria', 
	TblLibros.autor_libro as 'Autor', TblLibros.editorial_libro as 'Editorial', 
	TblLibros.copias_libro as 'Copias', TblLibros.ISBN
	from TblLibros
	INNER JOIN TblCategorias on TblLibros.id_categoria = TblCategorias.id_categoria

go


create view Mostrar_TblUsuario as
	select TblUsuarios.id_usuario as 'IdUsuario', TblMiembros.nombre_miembro as 'Nombre', TblMiembros.apellido_miembro as 'Apellido', 
	TblUsuarios.nombre_usuario as 'Usuario', TblRoles.rol as 'Rol',
	TblMiembros.identificacion_miembro as 'ID', TblMiembros.email_miembro as 'E-Mail', 
	TblMiembros.telefono_miembro as 'Telefono', TblMiembros.direccion_miembro as 'Direccion'
	from ((TblUsuarios
	INNER JOIN TblMiembros on TblUsuarios.id_miembro = TblMiembros.id_miembro)
	INNER JOIN TblRoles on TblUsuarios.id_rol = TblRoles.id_rol)

go

create view Mostrar_TblPrestamos as
	select TblPrestamos.id_prestamo as 'Id', TblLibros.nombre_libro as 'Libro', TblLibros.ISBN as 'ISBN', TblMiembros.nombre_miembro + ' ' + 
	TblMiembros.apellido_miembro as 'Prestatario',  TblMiembros.identificacion_miembro as 'Identificacion', TblPrestamos.copias_libro as 'Copias',
	TblPrestamos.fecha_prestamo as 'Fecha de Prestamo', TblPrestamos.fecha_limite as 'Fecha Limite de Prestamo',
	TblEstados.estado as 'Estado de Prestamo'
	from (TblUsuarios
	INNER JOIN TblMiembros on TblUsuarios.id_miembro = TblMiembros.id_miembro),
	((TblPrestamos
	INNER JOIN TblLibros on TblPrestamos.id_libro = TblLibros.id_libro)
	INNER JOIN TblEstados on TblPrestamos.id_estado = TblEstados.id_estado)

go

create view Mostrar_TblDevoluciones as
	select  TblLibros.nombre_libro as 'Libro', TblLibros.ISBN, TblMiembros.nombre_miembro + ' ' + 
	TblMiembros.apellido_miembro as 'Prestatario', TblMiembros.identificacion_miembro as 'Identificacion', TblPrestamos.copias_libro as 'Copias',
	TblDevoluciones.fecha_devolucion as 'Fecha de Devolucion'
	from (TblUsuarios
	INNER JOIN TblMiembros on TblUsuarios.id_miembro = TblMiembros.id_miembro),
	(TblPrestamos
	INNER JOIN TblLibros on TblPrestamos.id_libro = TblLibros.id_libro), TblDevoluciones

go


