USE UMS;

-- Automate the insertion of data into the 'Usuarios' table taking into account the type of user.
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

-- Change the status of the classroom when an update is performed on the Clases table.

CREATE TRIGGER TR_CambiarEstadoSalones
ON Clases
AFTER INSERT
AS 
BEGIN

    UPDATE Salones 
    SET Estado = 2 
    WHERE CodigoSalon IN (SELECT Codigo_Salon FROM inserted);

END
GO

-- Before allowing the admin to change the classroom, this trigger compares the current hour with the initial hour of the class to determine if there is at least one-hour difference. 
-- If so, it then checks whether there is other class with similar characteristics to avoid making an assignment there.

GO
CREATE TRIGGER TR_VerificarHorario
ON Clases
AFTER UPDATE
AS
BEGIN
	
    DECLARE @HoraActual TIME
    DECLARE @HoraInicio TIME
    DECLARE @DiferenciaHoras INT

    DECLARE @CodigoSalon VARCHAR(6)
    DECLARE @IdSalonInsert INT

    SELECT @IdSalonInsert = Id FROM inserted;
    SELECT @CodigoSalon = Codigo_Salon FROM inserted;

    SET @HoraActual = CONVERT(TIME, GETDATE())
    SELECT @HoraInicio = Hora_Inicio FROM Clases WHERE Id = @IdSalonInsert;
    SET @DiferenciaHoras = DATEDIFF(HOUR, @HoraActual, @HoraInicio)

    IF ABS(@DiferenciaHoras) <= 1
    BEGIN
        PRINT('No se puede realizar el cambio de salón con menos de una hora de anticipación.');
        ROLLBACK TRANSACTION;
    END
    ELSE IF EXISTS (SELECT * FROM Clases WHERE Codigo_Salon = @CodigoSalon AND Hora_Inicio = @HoraInicio AND Dia = (SELECT Dia FROM inserted)
          AND Id <> @IdSalonInsert)
    BEGIN
        PRINT('El salón está ocupado en ese lapso.');
        ROLLBACK TRANSACTION;
    END
    ELSE
    BEGIN
	    UPDATE Salones 
		SET Estado = 2 
		WHERE CodigoSalon IN (SELECT Codigo_Salon FROM inserted);


		UPDATE Salones 
		SET Estado = 1 
		WHERE CodigoSalon IN (SELECT Codigo_Salon FROM deleted);
        PRINT('La actualización del salón fue exitosa.');

        INSERT INTO Asignaciones (Id_Admin, Id_Clase, Fecha_Asignacion)
        SELECT '1025884381', Id, GETDATE() FROM inserted;
    END
END;