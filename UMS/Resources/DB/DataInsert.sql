INSERT INTO Tematica_Salones (Tematica) VALUES
('Informática'),
('Electrónica'),
('Diseño'),
('Normal')

INSERT INTO Estado_Salones VALUES 
('Libre'),
('Ocupado'),
('En Mantenimiento')

INSERT INTO Salones (CodigoSalon, Capacidad, Softwares, Estado, Tematica)
VALUES
('6-405', 20, 'Visual Studio, SQL Server, Microsoft Office', 1, 1),
('6-301', 30, 'AutoCAD, Adobe Photoshop, Microsoft Office', 1, 3),
('6-604', 20, 'R, PSeInt, Microsoft Office', 1, 1),
('2-202', 20, 'Proteus, Arduino, Microsoft Office', 1, 2),
('2-107', 40, 'Microsoft Office', 1, 4),
('13-205', 20, 'PSeInt, Microsoft Office', 1, 1),
('24-201', 20, 'AutoCAD, Microsoft Office, Adobe Photoshop', 1, 3),
('9-201', 40, 'Microsoft Office, Adobe Photoshop', 1, 4),
('6-402', 20, 'Proteus, Microsoft Office', 1, 2),
('13-204', 25, 'MySQL, Microsoft Office', 1, 1);

INSERT INTO Administradores (Documento, Nombre, Correo, Contraseña) VALUES
(1025884381, 'Jhonatan Salazar Betancur', 'jhonsal_22@pascualbravo.edu.co', ENCRYPTBYPASSPHRASE('password','pepesur8899'))

INSERT INTO Estudiantes (Documento, Nombre, Correo, Contraseña) VALUES 
(1089456231, 'Santiago Ramirez Silva', 'sanriz@pascualbravo.edu.co', ENCRYPTBYPASSPHRASE('password','santi01')),
(1025778232, 'Sandra Ortega Lopez', 'lopez14@pascualbravo.edu.co', ENCRYPTBYPASSPHRASE('password','sandris0418')),
(1040521333, 'Juan David Molina Rojas', 'juan_da@pascualbravo.edu.co', ENCRYPTBYPASSPHRASE('password','estrellita13')),
(1090433569, 'Carlos González Pérez', 'carlos.gonzalez@pascualbravo.edu.co', ENCRYPTBYPASSPHRASE('password', 'carlos123')),
(1042775212, 'Laura Martínez Rodríguez', 'laura.martinez@pascualbravo.edu.co', ENCRYPTBYPASSPHRASE('password', 'laura456')),
(1025602022, 'Juan Sánchez López', 'juan.sanchez@pascualbravo.edu.co', ENCRYPTBYPASSPHRASE('password', 'juan789')),
(1021470217, 'Ana Pérez Gómez', 'ana.perez@pascualbravo.edu.co', ENCRYPTBYPASSPHRASE('password', 'anaabc032')),
(1056397121, 'Samuel Bastidas Pamplona', 'samu_pamplona@pascualbravo.edu.co', ENCRYPTBYPASSPHRASE('password', 'clodomiro14')),
(1078900154, 'Simón García López', 'lopez-simon@pascualbravo.edu.co', ENCRYPTBYPASSPHRASE('password', 'simoncitogu0'));

INSERT INTO Estado_Profesores (Estado_Profesor) VALUES 
('Contratado'),
('Incapacitado'),
('Suspendido')

INSERT INTO Tipo_Especializaciones(Tipo) VALUES
('Ciencias Básicas'),
('Ciencias Aplicadas'),
('Formación Específica'),
('Socio humanísticas')

INSERT INTO Profesores (Documento, Nombre, Estado, Area_Especializacion, Correo, Contraseña) VALUES 
(1055480844, 'Jairo Restrepo Velez', 1, 3, 'jairovelez14@pascualbravo.edu.co', ENCRYPTBYPASSPHRASE('password','48090')),
(1077144412, 'Claudia Maria Betancur Ortega', 1, 1, 'claumaria180@pascualbravo.edu.co', ENCRYPTBYPASSPHRASE('password','mariaor90')),
(1021664329, 'Andrés Felipe Urrego Restrepo', 1, 2, 'urrego_res@pascualbravo.edu.co', ENCRYPTBYPASSPHRASE('password','88832her')),
(1024681900, 'Osmiri Castaño Ibañez', 1, 4, 'osmi_477@pascualbravo.edu.co', ENCRYPTBYPASSPHRASE('password','avon000')),
(1011209046, 'Bernardo Silva Gomez', 1, 2, 'bernardo-silva@pascualbravo.edu.co', ENCRYPTBYPASSPHRASE('password','48real90'))

INSERT INTO Grupos (IdGrupo, IdProfesor) VALUES
('051','1055480844'),
('054','1077144412'),
('050','1021664329'),
('100','1024681900'),
('053','1011209046'),
('055','1011209046')

INSERT INTO GruposEstudiantes(IdGrupo, IdEstudiante) VALUES
('055','1025778232'),
('055','1089456231'),
('051','1042775212'),
('051', '1056397121'),
('054', '1089456231'),
('053', '1042775212'),
('100', '1078900154'),
('100', '1090433569'),
('051', '1021470217'),
('051', '1025602022'),
('051', '1025778232'),
('054', '1040521333'),
('054', '1042775212'),
('050', '1056397121'),
('050', '1078900154'),
('100', '1089456231'),
('053', '1090433569');

INSERT INTO Asignaturas (Codigo, Nombre, Tipo, Creditos) VALUES
('CA89890', 'Herramientas de programación I', 2, 4),
('FE18097', 'Bases de datos I', 3, 4),
('CB75045','Calculo Integral',1,4),
('CA45732', 'Estructura de datos', 2, 2),
('SH10023', 'Inglés', 4, 1),
('FE89033', 'Algoritmos', 3, 2),
('CA22012', 'Electrónica básica y circuitos digitales', 2, 4),
('CB77821', 'Calculo Diferencial', 1, 4)

INSERT INTO Dia_Clases (Dia) VALUES
('Lunes'),
('Martes'),
('Miércoles'),
('Jueves'),
('Viernes'),
('Sábado')

INSERT INTO Clases (Dia, Hora_Inicio, Hora_Final, Id_Grupo, Codigo_Salon, Codigo_Asignatura, Detalles) VALUES
(6,'03:00:00 PM', '04:00:00 PM', '055', '2-202', 'CA22012', 'Teoria de circuitos digitales'),
(2,'08:00:00 AM','10:00:00 AM','054', '2-107', 'CB77821', 'Se verán las propiedades de los límites'),
(4,'08:00:00 AM','10:00:00 AM','054', '2-107', 'CB77821', 'Ejercicios de práctica de límites'),
(1,'02:00:00 PM','04:00:00 PM', '051', '6-604', 'FE89033', 'Ciclo FOR y WHILE en ejercicios aplicados'),
(5, '06:00:00 AM', '08:00:00 AM', '100', '9-201', 'SH10023', 'Please check the files I have sent to your email'),
(3, '08:00:00 AM', '10:00:00 AM', '053', '6-405', 'CA89890', 'Por favor revisar las diapositivas que les envíe sobre los conceptos de POO. Profundizaremos durante la clase'),
(5, '08:00:00 AM', '10:00:00 AM', '053', '6-405', 'CA89890', 'Quiz sobre conceptos básicos de POO'),
(4, '10:00:00 AM', '12:00:00 PM', '050', '6-604', 'CA45732', 'Manejo de stacks en C#')

INSERT INTO Peticiones (Id_Administrador, Id_Usuarios, Asunto, Descripcion, Estado_Peticion, Fecha, Respuesta) VALUES
('1025884381', '1025778232', 'Errores en mi horario', 'Hola, buenas tardes. Mi horario tiene un error en las horas ya que estas no concuerdan con lo que matriculé, por favor corregirlas.','Pendiente', GETDATE(),''),
('1025884381', '1042775212', 'No puedo observar los detalles', 'Hola, buenas tardes. Mis clases no tienen detalles, ¿por qué ocurre eso?','Pendiente', GETDATE(),''),
('1025884381','1077144412','Asignatura en horario que no corresponde','Buenas tardes administrador. Mi horario contiene una materia que no dicto, me gustaría que lo corrigiese lo antes posible.', 'Respondida','2023-11-12 12:00:00', 'Se acaba de hacer la correción, por favor revisar.');

INSERT INTO Tipo_Usuarios (TipoUser) VALUES
('Administrador'),
('Profesor'),
('Estudiante')