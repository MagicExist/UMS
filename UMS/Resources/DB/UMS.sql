CREATE DATABASE UMS;

USE UMS;

CREATE TABLE Tematica_Salones
(
	IdTematica SMALLINT IDENTITY(1,1),
	Tematica VARCHAR(15) NOT NULL,
	CONSTRAINT pk_tematica PRIMARY KEY (IdTematica),
	CONSTRAINT  ck_tematica_valores CHECK (Tematica IN('Informática', 'Diseño', 'Electrónica', 'Normal'))
);


INSERT INTO Tematica_Salones (Tematica) VALUES
('Informática'),
('Electrónica'),
('Diseño'),
('Normal')

CREATE TABLE Estado_Salones
(
	IdEstado SMALLINT IDENTITY(1,1),
	Estado VARCHAR(20) NOT NULL,
	CONSTRAINT pk_estado PRIMARY KEY (IdEstado),
	CONSTRAINT ck_estado_salones CHECK (Estado IN('Libre', 'Ocupado', 'En Mantenimiento'))
);

INSERT INTO Estado_Salones VALUES 
('Libre'),
('Ocupado'),
('En Mantenimiento')

CREATE TABLE Salones
(
	CodigoSalon VARCHAR(6),
	Capacidad TINYINT NOT NULL,
	Softwares TEXT NOT NULL,
	Estado SMALLINT NOT NULL,
	Tematica SMALLINT NOT NULL,
	CONSTRAINT pk_salones PRIMARY KEY (CodigoSalon),
	CONSTRAINT fk_estado FOREIGN KEY (Estado) REFERENCES Estado_Salones(IdEstado),
	CONSTRAINT fk_tematica FOREIGN KEY (Tematica) REFERENCES Tematica_Salones(IdTematica)
);

SELECT * FROM Tematica_Salones
SELECT * FROM Estado_Salones

INSERT INTO Salones (CodigoSalon, Capacidad, Softwares, Estado, Tematica)
VALUES
('6-405', 20, 'Visual Studio, SQL Server, Microsoft Office', 1, 1),
('6-301', 30, 'AutoCAD, Adobe Photoshop, Microsoft Office', 2, 3),
('6-604', 20, 'R, PSeInt, Microsoft Office', 1, 1),
('2-202', 20, 'Proteus, Arduino, Microsoft Office', 2, 2),
('2-107', 40, 'Microsoft Office', 1, 4),
('13-205', 20, 'PSeInt, Microsoft Office', 1, 1),
('24-201', 20, 'AutoCAD, Microsoft Office, Adobe Photoshop', 2, 3),
('9-201', 40, 'Microsoft Office, Adobe Photoshop', 1, 4),
('6-402', 20, 'Proteus, Microsoft Office', 2, 2),
('13-204', 25, 'MySQL, Microsoft Office', 1, 1);

SELECT * FROM Salones;

CREATE TABLE Administradores
(
	Documento VARCHAR(10),
	Nombre VARCHAR(40) NOT NULL,
	Correo VARCHAR(50) NOT NULL UNIQUE,
	Contraseña VARBINARY(8000) NOT NULL,
	CONSTRAINT pk_administradores PRIMARY KEY (Documento)
);

INSERT INTO Administradores (Documento, Nombre, Correo, Contraseña) VALUES
(1025884381, 'Jhonatan Salazar Betancur', 'jhonsal_22@pascualbravo.edu.co', ENCRYPTBYPASSPHRASE('password','pepesur8899'))

SELECT Documento, Nombre, CONVERT(VARCHAR(MAX), DECRYPTBYPASSPHRASE('password', Contraseña)) as password FROM Administradores

CREATE TABLE Asignaciones
(
	IdAsignacion INT IDENTITY(1,1),
	Id_Admin VARCHAR(10),
	Id_Salon VARCHAR(6),
	CONSTRAINT fk_asignaciones PRIMARY KEY (IdAsignacion),
	CONSTRAINT fk_admins FOREIGN KEY (Id_Admin) REFERENCES Administradores(Documento),
	CONSTRAINT fk_salones FOREIGN KEY (Id_Salon) REFERENCES Salones(CodigoSalon)
);

CREATE TABLE Estudiantes
(
	Documento VARCHAR(10),
	Nombre VARCHAR(40) NOT NULL,
	Correo VARCHAR(50) NOT NULL UNIQUE,
	Contraseña VARBINARY(8000) NOT NULL,
	CONSTRAINT pk_estudiantes PRIMARY KEY (Documento)
);

INSERT INTO Estudiantes (Documento, Nombre, Correo, Contraseña) VALUES 
(1089456231, 'Santiago Ramirez Silva', 'sanriz@pascualbravo.edu.co', ENCRYPTBYPASSPHRASE('password','santi01')),
(1025778232, 'Sandra Ortega Lopez', 'lopez14@pascualbravo.edu.co', ENCRYPTBYPASSPHRASE('password','sandris0418')),
(1040521333, 'Juan David Molina Rojas', 'juan_da@pascualbravo.edu.co', ENCRYPTBYPASSPHRASE('password','estrellita13'))

DELETE FROM Estudiantes;
SELECT * FROM Estudiantes

CREATE TABLE Estado_Profesores
(
	Id SMALLINT IDENTITY(1,1),
	Estado_Profesor VARCHAR(15) NOT NULL,
	CONSTRAINT pk_estado_profesor PRIMARY KEY (Id),
	CONSTRAINT ck_estado_profesor CHECK (Estado_Profesor IN('Contratado', 'Incapacitado', 'Suspendido'))
);

INSERT INTO Estado_Profesores (Estado_Profesor) VALUES 
('Contratado'),
('Incapacitado'),
('Suspendido')

SELECT * FROM Estado_Profesores

CREATE TABLE Profesores 
(
	Documento VARCHAR(10),
	Nombre VARCHAR(40) NOT NULL,
	Estado SMALLINT NOT NULL,
	Area_Especializacion VARCHAR(20) NOT NULL,
	Correo VARCHAR(50) NOT NULL UNIQUE,
	Contraseña VARBINARY(8000) NOT NULL,
	CONSTRAINT pk_profesores PRIMARY KEY (Documento),
	CONSTRAINT fk_estados FOREIGN KEY (Estado) REFERENCES Estado_Profesores(Id)
);

INSERT INTO Profesores (Documento, Nombre, Estado, Area_Especializacion, Correo, Contraseña) VALUES 
(1055480844, 'Jairo Restrepo Velez', 1, 'Formación Específica', 'jairovelez14@pascualbravo.edu.co', ENCRYPTBYPASSPHRASE('password','48090')),
(1077144412, 'Claudia Maria Betancur Ortega', 1, 'Ciencias Básicas', 'claumaria180@pascualbravo.edu.co', ENCRYPTBYPASSPHRASE('password','mariaor90'))

CREATE TABLE Grupos
(
	Id SMALLINT IDENTITY(1,1),
	IdProfesor VARCHAR(10),
	IdEstudiante VARCHAR(10),
	CONSTRAINT pk_grupos PRIMARY KEY (Id),
	CONSTRAINT fk_profesores FOREIGN KEY (IdProfesor) REFERENCES Profesores(Documento),
	CONSTRAINT fk_estudiantes FOREIGN KEY (IdEstudiante) REFERENCES Estudiantes(Documento)
);


CREATE TABLE Tipo_Asignaturas
(
	Id TINYINT IDENTITY(1,1),
	Tipo VARCHAR(20) NOT NULL,
	CONSTRAINT pk_tipo_asignaturas PRIMARY KEY (Id),
	CONSTRAINT ck_asignaturas CHECK (Tipo IN('Ciencias Básicas', 'Ciencias Aplicadas', 'Formación Específica', 'Socio humanísticas'))
);

INSERT INTO Tipo_Asignaturas (Tipo) VALUES
('Ciencias Básicas'),
('Ciencias Aplicadas'),
('Formación Específica'),
('Socio humanísticas')

CREATE TABLE Asignaturas 
(
	Codigo VARCHAR(10),
	Nombre VARCHAR(40) NOT NULL,
	Tipo TINYINT NOT NULL,
	Creditos TINYINT NOT NULL,
	CONSTRAINT pk_asignaturas PRIMARY KEY (Codigo),
	CONSTRAINT fk_tipo FOREIGN KEY (Tipo) REFERENCES Tipo_Asignaturas(Id)
);

SELECT * FROM Tipo_Asignaturas

INSERT INTO Asignaturas (Codigo, Nombre, Tipo, Creditos) VALUES
('FE18097', 'Bases de datos II', 3, 4),
('BA75045','Calculo Integral',1,4)

CREATE TABLE Dia_Clases
(
	Id TINYINT IDENTITY(1,1),
	Dia VARCHAR(10) NOT NULL,
	CONSTRAINT pk_dia_clases PRIMARY KEY (Id),
	CONSTRAINT ck_dias CHECK (Dia IN('Lunes', 'Martes', 'Miércoles', 'Jueves', 'Viernes', 'Sábado'))
);

INSERT INTO Dia_Clases (Dia) VALUES
('Lunes'),
('Martes'),
('Miércoles'),
('Jueves'),
('Viernes'),
('Sábado')

SELECT * FROM Dia_Clases

CREATE TABLE Clases
(
	Id INT IDENTITY(1,1),
	Dia TINYINT NOT NULL,
	Hora_Inicio DATETIME NOT NULL,
	Hora_Final DATETIME NOT NULL,
	Id_Grupo SMALLINT NOT NULL,
	Codigo_Salon VARCHAR(6) NOT NULL,
	Codigo_Asignatura VARCHAR(10) NOT NULL,
	CONSTRAINT pk_clases PRIMARY KEY (Id),
	CONSTRAINT fk_dia_clases FOREIGN KEY (Dia) REFERENCES Dia_Clases(Id),
	CONSTRAINT fk_grupos FOREIGN KEY (Id_Grupo) REFERENCES Grupos(Id),
	CONSTRAINT fk_salones2 FOREIGN KEY (Codigo_Salon) REFERENCES Salones(CodigoSalon),
	CONSTRAINT fk_asignaturas FOREIGN KEY (Codigo_Asignatura) REFERENCES Asignaturas(Codigo)
);

CREATE TABLE Peticiones
(
	Id SMALLINT IDENTITY(1,1),
	Id_Administrador VARCHAR(10) NOT NULL,
	Id_Usuarios VARCHAR(10) NOT NULL,
	Asunto VARCHAR(40) NOT NULL,
	Descripcion TEXT,
	Estado_Peticion VARCHAR(10) NOT NULL,
	CONSTRAINT pk_peticiones PRIMARY KEY (Id),
	CONSTRAINT fk_administradores FOREIGN KEY (Id_Administrador) REFERENCES Administradores(Documento),
	CONSTRAINT ck_estado_peticion CHECK(Estado_Peticion IN('Pendiente','Respondida'))
);

INSERT INTO Peticiones (Id_Administrador, Id_Usuarios, Asunto, Descripcion, Estado_Peticion) VALUES
('1025884381', '1025778232', 'Errores en mi horario', 'Hola, buenas tardes. Mi horario tiene un error en las horas ya que estas no concuerdan con lo que matriculé, por favor corregirlas.','Pendiente'),
('1025884381','1077144412','Asignatura en horario que no corresponde','Buenas tardes administrador. Mi horario contiene una materia que no dicto, me gustaria que lo corrigiese lo antes posible.','Respondida')


CREATE TABLE Tipo_Usuarios
(
	Id TINYINT IDENTITY(1,1),
	TipoUser VARCHAR(15),
	CONSTRAINT pk_tipo_usuarios PRIMARY KEY (Id),
	CONSTRAINT ck_tipo_usuarios CHECK (TipoUser IN('Administrador', 'Profesor', 'Estudiante'))
);

INSERT INTO Tipo_Usuarios (TipoUser) VALUES
('Administrador'),
('Profesor'),
('Estudiante')

CREATE TABLE Usuarios
(
	Id VARCHAR(10),
	Tipo TINYINT NOT NULL,
	CONSTRAINT pk_usuarios PRIMARY KEY (Id),
	CONSTRAINT fk_tipos_usuarios FOREIGN KEY (Tipo) REFERENCES Tipo_Usuarios(Id)
);

INSERT INTO Usuarios (Id, Tipo) VALUES
(1025884381, 1),
(1025778232, 3),
(1040521333, 3),
(1089456231, 3),
(1055480844, 2),
(1077144412, 2)





-------------------------------------------------- STORED PROCEDURES ----------------------------------------------------------
Go
create proc FiltrarUsuario
	@email varchar(50),
	@password varchar(50)
as
begin
 DECLARE @EstudiantesResult TABLE (
        -- Definir las columnas de Estudiantes aquí según tus necesidades
        Documento varchar(10),
        Nombre VARCHAR(40),
		Correo varchar(50),
		Contraseña varbinary(8000),
        -- Otros campos...
        DecryptResult VARCHAR(MAX)
    );

	if exists (select * from Estudiantes where Correo = @email and CONVERT(VARCHAR(MAX), DECRYPTBYPASSPHRASE('password',Contraseña)) = @password)
		begin
			INSERT INTO @EstudiantesResult
			SELECT *, CONVERT(VARCHAR(MAX), DECRYPTBYPASSPHRASE('password', Contraseña)) as DecryptResult
			FROM Estudiantes
			WHERE Correo = @email AND CONVERT(VARCHAR(MAX), DECRYPTBYPASSPHRASE('password', Contraseña)) = @password;
		end
	else if exists (select * from Profesores where Correo = @email and CONVERT(VARCHAR(MAX), DECRYPTBYPASSPHRASE('password',Contraseña)) = @password)
		begin
			(select *,CONVERT(VARCHAR(MAX), DECRYPTBYPASSPHRASE('password',Contraseña)) as Decrypt from Profesores where Correo = @email and CONVERT(VARCHAR(MAX), DECRYPTBYPASSPHRASE('password',Contraseña)) = @password)
		end
	else if exists (select * from Administradores where Correo = @email and CONVERT(VARCHAR(MAX), DECRYPTBYPASSPHRASE('password',Contraseña)) = @password)
		begin
			(select *,CONVERT(VARCHAR(MAX), DECRYPTBYPASSPHRASE('password',Contraseña)) as Decrypt from Administradores where Correo = @email and CONVERT(VARCHAR(MAX), DECRYPTBYPASSPHRASE('password',Contraseña)) = @password)
		end

	SELECT * FROM @EstudiantesResult;
end


exec FiltrarUsuario 'lopez14@gmail.com','sandris0418'



--------------------------------------------------- TRIGGERS ----------------------------------------------------

GO
CREATE TRIGGER TR_AñadirUsuario_Admin
ON Administradores
FOR INSERT
AS
BEGIN
    INSERT INTO Usuarios (Id, Tipo)
	SELECT Documento, 1 FROM inserted

END
GO

GO
CREATE TRIGGER TR_AñadirUsuario_Profesor
ON Profesores
FOR INSERT
AS
BEGIN
    INSERT INTO Usuarios (Id, Tipo)
	SELECT Documento, 2 FROM inserted

END
GO

GO
CREATE TRIGGER TR_AñadirUsuario_Estudiante
ON Estudiantes
FOR INSERT
AS
BEGIN
    INSERT INTO Usuarios (Id, Tipo)
	SELECT Documento, 3 FROM inserted

END
GO




