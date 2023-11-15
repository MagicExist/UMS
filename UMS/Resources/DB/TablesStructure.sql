CREATE DATABASE UMS;

USE UMS;

CREATE TABLE Tematica_Salones
(
	IdTematica SMALLINT IDENTITY(1,1),
	Tematica VARCHAR(15) NOT NULL,
	CONSTRAINT pk_tematica PRIMARY KEY (IdTematica),
	CONSTRAINT  ck_tematica_valores CHECK (Tematica IN('Informática', 'Diseño', 'Electrónica', 'Normal'))
);

CREATE TABLE Estado_Salones
(
	IdEstado SMALLINT IDENTITY(1,1),
	Estado VARCHAR(20) NOT NULL,
	CONSTRAINT pk_estado PRIMARY KEY (IdEstado),
	CONSTRAINT ck_estado_salones CHECK (Estado IN('Libre', 'Ocupado', 'En Mantenimiento'))
);

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

CREATE TABLE Administradores
(
	Documento VARCHAR(10),
	Nombre VARCHAR(40) NOT NULL,
	Correo VARCHAR(50) NOT NULL UNIQUE,
	Contraseña VARBINARY(8000) NOT NULL,
	CONSTRAINT pk_administradores PRIMARY KEY (Documento)
);

CREATE TABLE Asignaciones
(
	IdAsignacion INT IDENTITY(1,1),
	Id_Admin VARCHAR(10) NOT NULL,
	Id_Clase INT NOT NULL,
	Fecha_Asignacion DATETIME NOT NULL,
	CONSTRAINT fk_asignaciones PRIMARY KEY (IdAsignacion),
	CONSTRAINT fk_admins FOREIGN KEY (Id_Admin) REFERENCES Administradores(Documento),
	CONSTRAINT fk_clases FOREIGN KEY (Id_Clase) REFERENCES Clases(Id)
);

CREATE TABLE Estudiantes
(
	Documento VARCHAR(10),
	Nombre VARCHAR(40) NOT NULL,
	Correo VARCHAR(50) NOT NULL UNIQUE,
	Contraseña VARBINARY(8000) NOT NULL,
	CONSTRAINT pk_estudiantes PRIMARY KEY (Documento)
);

CREATE TABLE Estado_Profesores
(
	Id SMALLINT IDENTITY(1,1),
	Estado_Profesor VARCHAR(15) NOT NULL,
	CONSTRAINT pk_estado_profesor PRIMARY KEY (Id),
	CONSTRAINT ck_estado_profesor CHECK (Estado_Profesor IN('Contratado', 'Incapacitado', 'Suspendido'))
);

CREATE TABLE Tipo_Especializaciones
(
	Id TINYINT IDENTITY(1,1),
	Tipo VARCHAR(20) NOT NULL,
	CONSTRAINT pk_tipo_asignaturas PRIMARY KEY (Id),
	CONSTRAINT ck_asignaturas CHECK (Tipo IN('Ciencias Básicas', 'Ciencias Aplicadas', 'Formación Específica', 'Socio humanísticas'))
);

CREATE TABLE Profesores 
(
	Documento VARCHAR(10),
	Nombre VARCHAR(40) NOT NULL,
	Estado SMALLINT NOT NULL,
	Area_Especializacion TINYINT NOT NULL,
	Correo VARCHAR(50) NOT NULL UNIQUE,
	Contraseña VARBINARY(8000) NOT NULL,
	CONSTRAINT pk_profesores PRIMARY KEY (Documento),
	CONSTRAINT fk_estados FOREIGN KEY (Estado) REFERENCES Estado_Profesores(Id),
	CONSTRAINT fk_especializacion FOREIGN KEY (Area_Especializacion) REFERENCES Tipo_Especializaciones(Id)
);

CREATE TABLE Grupos (
    IdGrupo VARCHAR(3) PRIMARY KEY,
    IdProfesor VARCHAR(10),
	CONSTRAINT fk_profesor FOREIGN KEY (IdProfesor) REFERENCES Profesores(Documento)
);

CREATE TABLE GruposEstudiantes (
    IdGrupo VARCHAR(3),
    IdEstudiante VARCHAR(10),
    CONSTRAINT pk_grupos_estudiantes PRIMARY KEY (IdGrupo, IdEstudiante),
    CONSTRAINT fk_grupo FOREIGN KEY (IdGrupo) REFERENCES Grupos(IdGrupo),
    CONSTRAINT fk_estudiante FOREIGN KEY (IdEstudiante) REFERENCES Estudiantes(Documento)
);

CREATE TABLE Asignaturas 
(
	Codigo VARCHAR(10),
	Nombre VARCHAR(40) NOT NULL,
	Tipo TINYINT NOT NULL,
	Creditos TINYINT NOT NULL,
	CONSTRAINT pk_asignaturas PRIMARY KEY (Codigo),
	CONSTRAINT fk_tipo FOREIGN KEY (Tipo) REFERENCES Tipo_Especializaciones(Id)
);

CREATE TABLE Dia_Clases
(
	Id TINYINT IDENTITY(1,1),
	Dia VARCHAR(10) NOT NULL,
	CONSTRAINT pk_dia_clases PRIMARY KEY (Id),
	CONSTRAINT ck_dias CHECK (Dia IN('Lunes', 'Martes', 'Miércoles', 'Jueves', 'Viernes', 'Sábado'))
);

CREATE TABLE Clases
(
	Id INT IDENTITY(1,1),
	Dia TINYINT NOT NULL,
	Hora_Inicio TIME NOT NULL,
	Hora_Final TIME NOT NULL,
	Id_Grupo VARCHAR(3) NOT NULL,
	Codigo_Salon VARCHAR(6) NOT NULL,
	Codigo_Asignatura VARCHAR(10) NOT NULL,
	Detalles TEXT,
	CONSTRAINT pk_clases PRIMARY KEY (Id),
	CONSTRAINT fk_dia_clases FOREIGN KEY (Dia) REFERENCES Dia_Clases(Id),
	CONSTRAINT fk_grupos FOREIGN KEY (Id_Grupo) REFERENCES Grupos(IdGrupo),
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
	Fecha DATETIME NOT NULL,
	Respuesta TEXT,
	CONSTRAINT pk_peticiones PRIMARY KEY (Id),
	CONSTRAINT fk_administradores FOREIGN KEY (Id_Administrador) REFERENCES Administradores(Documento),
	CONSTRAINT ck_estado_peticion CHECK(Estado_Peticion IN('Pendiente','Respondida'))
);

CREATE TABLE Tipo_Usuarios
(
	Id TINYINT IDENTITY(1,1),
	TipoUser VARCHAR(15),
	CONSTRAINT pk_tipo_usuarios PRIMARY KEY (Id),
	CONSTRAINT ck_tipo_usuarios CHECK (TipoUser IN('Administrador', 'Profesor', 'Estudiante'))
);

CREATE TABLE Usuarios
(
	Id VARCHAR(10),
	Tipo TINYINT NOT NULL,
	CONSTRAINT pk_usuarios PRIMARY KEY (Id),
	CONSTRAINT fk_tipos_usuarios FOREIGN KEY (Tipo) REFERENCES Tipo_Usuarios(Id)
);