USE UMS;

GO
CREATE PROCEDURE FiltrarUsuario
    @email VARCHAR(50),
    @password VARCHAR(50)
AS
BEGIN
    DECLARE @Result TABLE (
        TipoUsuario INT,
        Documento VARCHAR(10),
        Nombre VARCHAR(40),
        Correo VARCHAR(50),
        DecryptResult VARCHAR(MAX),
        Contraseña VARBINARY(8000)
    );

	DECLARE @profesoresResult TABLE (
        TipoUsuario INT,
        Documento VARCHAR(10),
        Nombre VARCHAR(40),
		Estado INT,
		Area_Especializacion VARCHAR(50),
        Correo VARCHAR(50),
        DecryptResult VARCHAR(MAX),
        Contraseña VARBINARY(8000)
    );

    IF EXISTS (SELECT * FROM Estudiantes WHERE Correo = @email AND CONVERT(VARCHAR(MAX), DECRYPTBYPASSPHRASE('password', Contraseña)) = @password)
		BEGIN
			INSERT INTO @Result
			SELECT
				3 AS TipoUsuario,
				Documento,
				Nombre,
				Correo,
				CONVERT(VARCHAR(MAX), DECRYPTBYPASSPHRASE('password', Contraseña)) AS DecryptResult,
				Contraseña
			FROM Estudiantes
			WHERE Correo = @email AND CONVERT(VARCHAR(MAX), DECRYPTBYPASSPHRASE('password', Contraseña)) = @password;

			SELECT TipoUsuario, Documento, Nombre, Correo, DecryptResult, Contraseña
			FROM @Result;

		END
    ELSE IF EXISTS (SELECT * FROM Profesores WHERE Correo = @email AND CONVERT(VARCHAR(MAX), DECRYPTBYPASSPHRASE('password', Contraseña)) = @password)
		BEGIN
			INSERT INTO @profesoresResult
			SELECT
				2 AS TipoUsuario,
				Documento,
				Nombre,
				Estado,
				Area_Especializacion,
				Correo,
				CONVERT(VARCHAR(MAX), DECRYPTBYPASSPHRASE('password', Contraseña)) AS DecryptResult,
				Contraseña
			FROM Profesores
			WHERE Correo = @email AND CONVERT(VARCHAR(MAX), DECRYPTBYPASSPHRASE('password', Contraseña)) = @password;

			SELECT TipoUsuario, Documento, Nombre,Estado,Area_Especializacion,Correo, DecryptResult, Contraseña
			FROM @profesoresResult;

		END
    ELSE IF EXISTS (SELECT * FROM Administradores WHERE Correo = @email AND CONVERT(VARCHAR(MAX), DECRYPTBYPASSPHRASE('password', Contraseña)) = @password)
		BEGIN
			INSERT INTO @Result
			SELECT
				1 AS TipoUsuario,
				Documento,
				Nombre,
				Correo,
				CONVERT(VARCHAR(MAX), DECRYPTBYPASSPHRASE('password', Contraseña)) AS DecryptResult,
				Contraseña
			FROM Administradores
			WHERE Correo = @email AND CONVERT(VARCHAR(MAX), DECRYPTBYPASSPHRASE('password', Contraseña)) = @password;

			SELECT TipoUsuario, Documento, Nombre, Correo, DecryptResult, Contraseña
			FROM @Result;
		END
END;