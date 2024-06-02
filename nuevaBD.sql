CREATE DATABASE Task
use Task
/*----------------------------------------------------------------------------------------------------------------------------------*/
CREATE TABLE Roles (
    roleId INT identity(1,1) PRIMARY KEY,
    roleNombre NVARCHAR(50)
);
/*----------------------------------------------------------------------------------------------------------------------------------*/
INSERT INTO Roles(roleNombre) VALUES
('GrupoEstudiante'),
('Estudiante');

SELECT * FROM Roles

/*----------------------------------------------------------------------------------------------------------------------------------*/
-- Crear tablas
CREATE TABLE Usuarios (
    usuarioId INT IDENTITY(1,1) PRIMARY KEY,    
    roleId INT,
    nombre NVARCHAR(100),
    usuario NVARCHAR(100),
    passwordHash VARBINARY(256), -- Ajuste el tamaño según sea necesario
    create_at DATETIME,    
    FOREIGN KEY (roleId) REFERENCES Roles(roleId)
);

/*
HASHBYTES (sirve para encriptar la clave)
GETDATE (PARA OBTENER LA FECHA Y HORA DEL EQUIPO)
*/
INSERT INTO Usuarios(roleId, nombre, usuario, passwordHash, create_at) VALUES 
(1, 'JEU VASQUEZ', 'admin', HASHBYTES('SHA2_256', '123'), GETDATE()),
(2, 'Abisai', 'estudiante', HASHBYTES('SHA2_256', '123'), GETDATE());

/*----------------------------------------------------------------------------------------------------------------------------------*/
SELECT * FROM Usuarios
/*----------------------------------------------------------------------------------------------------------------------------------*/
SELECT * FROM Usuarios WHERE usuario COLLATE Latin1_General_CS_AS = 'admin' AND passwordHash = HASHBYTES('SHA2_256', '123');
/*----------------------------------------------------------------------------------------------------------------------------------*/
CREATE PROCEDURE loginUsuario
(
    @usuario NVARCHAR(100),
    @passwordHash VARBINARY(256),
    @idUsuario INT OUTPUT
)
AS 
BEGIN 
SET @idUsuario =0
IF EXISTS (SELECT * FROM Usuarios 
WHERE usuario COLLATE Latin1_General_CS_AS = @usuario 
AND passwordHash = @passwordHash)

SET @idUsuario = (SELECT usuarioId FROM Usuarios WHERE usuario COLLATE Latin1_General_CS_AS = @usuario AND passwordHash = @passwordHash)
END

/*----------------------------------------------------------------------------------------------------------------------------------*/
DECLARE @usuario_salida INT
DECLARE @passwordHash VARBINARY(256)
SET @passwordHash = HASHBYTES('SHA2_256', '123')
EXEC loginUsuario 'estudiante',@passwordHash, @usuario_salida OUTPUT
SELECT @usuario_salida


CREATE TABLE Estados(
	EstadoID INT IDENTITY (1,1) PRIMARY KEY,
	Estado VARCHAR (30)
);
GO
CREATE TABLE Materias(
	MateriaID INT IDENTITY (1,1) PRIMARY KEY,
	Materia VARCHAR (50)
);
GO
CREATE TABLE Tareas(
	TareaID INT IDENTITY (1,1) PRIMARY KEY,
	Tarea VARCHAR (50),
	Materia VARCHAR (50),
	Fecha_Asignación DATE,
	Fecha_Entrega DATE,
	MedioEntrega VARCHAR (30),
	EstadoID INT
);

create table Asigancion(
id_asignacion INT not null primary key,
id_user INT not null,
id_task INT not null,
Fecha_asignacion datetime,

foreign key(id_user) references Users(userId),
foreign key (id_task)references Tasks(taskId),
);
CREATE TABLE Alerts (
    alertid INT identity(1,1) PRIMARY KEY,
    taskId INT,
    fechaHora datetime,
    descripcion NVARCHAR(255),
    FOREIGN KEY (taskId) REFERENCES Tasks(taskId)
);

CREATE TABLE Comentarios (
    ComentarioId INT identity(1,1) PRIMARY KEY,
    taskId INT,
    userId INT NULL,
    ComentarioText NVARCHAR(MAX),
    comentarioFecha datetime,
    FOREIGN KEY (taskID) REFERENCES Tasks(taskID),
    FOREIGN KEY (userID) REFERENCES Users(userID)
);
/*----------------------------------------------------------------------------------------------------------------------------------*/
CREATE TABLE Menu(
    menuId INT identity(1,1) PRIMARY KEY,
    nombre NVARCHAR(100),
    otros NVARCHAR(100),
);
/*----------------------------------------------------------------------------------------------------------------------------------*/
CREATE TABLE SubMenu(
    subMenuId INT identity(1,1) PRIMARY KEY,
    menuId INT,
    nombre NVARCHAR(100),
    nombreFormulario NVARCHAR(100),
    FOREIGN KEY (menuId) REFERENCES Menu(menuId)
);
/*----------------------------------------------------------------------------------------------------------------------------------*/
CREATE TABLE Permisos(
    permisosId INT identity(1,1) PRIMARY KEY,
    activo NVARCHAR(100),
    roleId INT,
    subMenuId INT,
    FOREIGN KEY (roleId) REFERENCES Roles(roleId),
    FOREIGN KEY (subMenuId) REFERENCES SubMenu(subMenuId)
);
/*----------------------------------------------------------------------------------------------------------------------------------*/
/* fin roles y permisos de usuarios*/
INSERT INTO Menu(nombre,otros) VALUES('Usuarios','Iconos/usuario.png'),('Materias','Iconos/libros.png'),('Tareas','Iconos/lista-de-quehaceres.png'),('Estados','Iconos/estados.png')
update Menu set otros='Iconos/lista-de-quehaceres.png' where menuId=3
SELECT * FROM Menu

/*----------------------------------------------------------------------------------------------------------------------------------*/
delete Menu
/* menu usuarios*/
/*----------------------------------------------------------------------------------------------------------------------------------*/
INSERT INTO SubMenu(menuId,nombre,nombreFormulario) VALUES
(1,'Crear Usuario','frmCrearUsuario'),
(1,'Ver Usuarios','frmVerUsuario'),
(1,'Editar Usuario','frmEditarUsuario'),
(1,'Eliminar Usuario','frmEliminarUsuario');
/* menu materias*/
/*----------------------------------------------------------------------------------------------------------------------------------*/
INSERT INTO SubMenu(menuId,nombre,nombreFormulario) VALUES
(2,'Crear Materia','frmCrearMaterias'),
(2,'Ver Materias','frmVerMaterias'),
(2,'Editar Materia','frmEditarMaterias'),
(2,'Eliminar Materia','frmEliminarMaterias');
/*----------------------------------------------------------------------------------------------------------------------------------*/
INSERT INTO SubMenu(menuId,nombre,nombreFormulario) VALUES
(3,'Crear Tarea','frmCrearTarea'),
(3,'Ver Tarea','frmVerTarea'),
(3,'Editar Tarea','frmEditarTarea'),
(3,'Eliminar Tarea','frmEliminarTarea');
/*----------------------------------------------------------------------------------------------------------------------------------*/
INSERT INTO SubMenu(menuId,nombre,nombreFormulario) VALUES
(4,'Crear Estado','frmCrearEstado'),
(4,'Ver Estados','frmVerEstado'),
(4,'Editar Estado','frmEditarEstado'),
(4,'Eliminar Estado','frmEliminarEstado');
/*----------------------------------------------------------------------------------------------------------------------------------*/
SELECT * FROM SubMenu
/*----------------------------------------------------------------------------------------------------------------------------------*/
INSERT INTO Permisos(activo,roleId,subMenuId) VALUES
('T',1,1),
('T',1,2),
('T',1,3),
('T',1,4),
('T',1,5),
('T',1,6),
('T',1,7),
('T',1,8),
('T',1,9),
('T',1,10),
('T',1,11),
('T',1,12),
('T',1,13),
('T',1,14),
('T',1,15),
('T',1,16);
/*----------------------------------------------------------------------------------------------------------------------------------*/
INSERT INTO Permisos(activo,roleId,subMenuId) VALUES
('F',2,1),
('T',2,2),
('T',2,3),
('F',2,4),
('T',2,5),
('T',2,6),
('T',2,7),
('T',2,8),
('T',2,9),
('T',2,10),
('T',2,11),
('T',2,12),
('T',2,13),
('T',2,14),
('T',2,15),
('T',2,16);
/*----------------------------------------------------------------------------------------------------------------------------------*/
SELECT * FROM Permisos


/*----------------------------------------------------------------------------------------------------------------------------------*/
/* MENU */
SELECT DISTINCT m.* FROM Permisos p
JOIN Roles r ON r.roleId=p.roleId
JOIN SubMenu sub ON sub.subMenuId=p.subMenuId
JOIN Menu m ON m.menuId=sub.menuId
JOIN Usuarios u ON u.roleId=p.roleId AND p.activo='T'
WHERE u.usuarioId=2

/*----------------------------------------------------------------------------------------------------------------------------------*/
/* SUBMENU */
SELECT sub.* FROM Permisos p
JOIN Roles r ON r.roleId=p.roleId
JOIN SubMenu sub ON sub.subMenuId=p.subMenuId
JOIN Menu m ON m.menuId=sub.menuId
JOIN Usuarios u ON u.roleId=p.roleId AND p.activo='T'
WHERE u.usuarioId=2

/*----------------------------------------------------------------------------------------------------------------------------------*/

SELECT 

	(SELECT vistaMenu.nombre, vistaMenu.otros,
		(SELECT sub.nombre, sub.nombreFormulario FROM Permisos p
		JOIN Roles r ON r.roleId=p.roleId
		JOIN SubMenu sub ON sub.subMenuId=p.subMenuId
		JOIN Menu m ON m.menuId=sub.menuId 
		JOIN Usuarios u ON u.roleId=p.roleId AND p.activo='T'
		WHERE u.usuarioId=us.usuarioId AND sub.menuId=vistaMenu.menuId
		FOR XML PATH('SUBMENU'),TYPE) AS 'DetalleSubMenu'
	FROM 
	(SELECT DISTINCT m.* FROM Permisos p
	JOIN Roles r ON r.roleId=p.roleId
	JOIN SubMenu sub ON sub.subMenuId=p.subMenuId
	JOIN Menu m ON m.menuId=sub.menuId
	JOIN Usuarios u ON u.roleId=p.roleId AND p.activo='T'
	WHERE u.usuarioId=us.usuarioId
	) vistaMenu
	FOR XML PATH('MENU'),TYPE) AS 'DetalleMenu'
FROM Usuarios us
WHERE usuarioId =2
FOR xml path(''), root('Permisos')

/*----------------------------------------------------------------------------------------------------------------------------------*/
/* CREANDO XML PARA LOS DATOS DEL MENU Y SUBMENU QE TENDRAN PERMISOS LOS USUARIOS */
CREATE PROCEDURE obtenerPermisos(
@idUsuario INT
)
AS
BEGIN
SELECT 

	(SELECT vistaMenu.nombre, vistaMenu.otros,
		(SELECT sub.nombre, sub.nombreFormulario FROM Permisos p
		JOIN Roles r ON r.roleId=p.roleId
		JOIN SubMenu sub ON sub.subMenuId=p.subMenuId
		JOIN Menu m ON m.menuId=sub.menuId 
		JOIN Usuarios u ON u.roleId=p.roleId AND p.activo='T'
		WHERE u.usuarioId=us.usuarioId AND sub.menuId=vistaMenu.menuId
		FOR XML PATH('SUBMENU'),TYPE) AS 'DetalleSubMenu'
	FROM 
	(SELECT DISTINCT m.* FROM Permisos p
	JOIN Roles r ON r.roleId=p.roleId
	JOIN SubMenu sub ON sub.subMenuId=p.subMenuId
	JOIN Menu m ON m.menuId=sub.menuId
	JOIN Usuarios u ON u.roleId=p.roleId AND p.activo='T'
	WHERE u.usuarioId=us.usuarioId
	) vistaMenu
	FOR XML PATH('MENU'),TYPE) AS 'DetalleMenu'
FROM Usuarios us
WHERE usuarioId =@idUsuario
FOR xml path(''), root('Permisos')
END
go
EXEC obtenerPermisos 2
go

/*
CREATE TABLE Usuarios (
    usuarioId INT IDENTITY(1,1) PRIMARY KEY,    
    roleId INT,
    nombre NVARCHAR(100),
    usuario NVARCHAR(100),
    passwordHash VARBINARY(256), -- Ajuste el tamaño según sea necesario
    create_at DATETIME,    
    FOREIGN KEY (roleId) REFERENCES Roles(roleId)
);

procedimientos alamcenados
*/

CREATE PROCEDURE listarUsuario
as 
SELECT u.roleId,roleNombre,nombre,usuario,create_at FROM Usuarios u INNER JOIN Roles r ON u.roleId=r.roleId  ORDER BY usuarioId DESC
go

CREATE PROCEDURE buscarUsuario
@nombre NVARCHAR(100)
as
SELECT u.roleId,roleNombre,nombre,usuario,create_at FROM Usuarios u INNER JOIN Roles r ON u.roleId=r.roleId WHERE nombre LIKE @nombre +'%'
go


CREATE PROCEDURE crudUsuario
	@usuarioId INT,
	@roleId INT,
    @nombre NVARCHAR(100),
    @usuario NVARCHAR(100),
    @passwordHash VARBINARY(256),
	@accion varchar(50) output
as
IF(@accion = '1')
BEGIN
	INSERT INTO Usuarios(roleId,nombre,usuario,passwordHash,create_at)
	VALUES(@roleId, @nombre,@usuario, @passwordHash, GETDATE())
	DECLARE @id INT;
        SELECT @id = MAX(usuarioId) FROM Usuarios;

        SET @accion = 'Registro creado con exito ' + CAST(@id AS VARCHAR);
END
ELSE IF(@accion = '2')
BEGIN
UPDATE Usuarios SET roleId=@roleId, nombre=@nombre,usuario=@usuario,passwordHash=HASHBYTES('SHA2_256', @passwordHash) WHERE usuarioId=@usuarioId
SET @accion='Se Actualizo el registro:' +@usuarioId
END
ELSE IF(@accion = '3')
BEGIN
DELETE FROM Usuarios WHERE usuarioId=@usuarioId
SET @accion='Se Elimino el registro:' +@usuarioId
END
go

SELECT *FROM Usuarios;


/*de tareas los procedimientos alamcenados*/
--procedimientos almacenados
create proc sp_listar_tareas
as
select * from tareas order by TareaID
go

exec sp_listar_tareas

CREATE PROCEDURE sp_mantenimiento_tareas
	@TareaID INT,
    @Tarea VARCHAR (50),
	@Materia VARCHAR (50),
	@Fecha_Asignación DATE,
	@Fecha_Entrega DATE,
	@MedioEntrega VARCHAR (30),
	@Estadoid int,
	@Accion VARCHAR (50) OUTPUT
AS
IF (@Accion='1')
BEGIN
	INSERT INTO Tareas (Tarea, Materia, Fecha_Asignación, Fecha_Entrega, MedioEntrega, EstadoID)
	VALUES (@Tarea, @Materia,@Fecha_Asignación, @Fecha_Entrega, @MedioEntrega,@Estadoid)
	SET @Accion='Se agrego correctamente la tarea: ' + @Tarea
END
ELSE IF (@Accion='2')
BEGIN
	UPDATE Tareas SET Tarea=@Tarea, Materia=@Materia, Fecha_Asignación=@Fecha_Asignación,
	Fecha_Entrega=@Fecha_Entrega, MedioEntrega=@MedioEntrega,EstadoID=@Estadoid where TareaID = @TareaID
	SET @Accion='Se modicó correctamente la tarea: ' + @Tarea
	
END
ELSE IF (@Accion='3')
BEGIN
	DELETE FROM Tareas WHERE TareaID=@TareaID
	SET @Accion='Se eliminó correctamente la tarea: ' + @Tarea
END
go