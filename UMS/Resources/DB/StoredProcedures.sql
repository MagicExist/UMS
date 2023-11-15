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
        Contraseņa VARBINARY(8000)
    );

	DECLARE @profesoresResult TABLE (
        TipoUsuario INT,
        Documento VARCHAR(10),
        Nombre VARCHAR(40),
		Estado INT,
		Area_Especializacion VARCHAR(50),
        Correo VARCHAR(50),
        DecryptResult VARCHAR(MAX),
        Contraseņa VARBINARY(8000)
    );

    IF EXISTS (SELECT * FROM Estudiantes WHERE Correo = @email AND CONVERT(VARCHAR(MAX), DECRYPTBYPASSPHRASE('password', Contraseņa)) = @password)
		BEGIN
			INSERT INTO @Result
			SELECT
				3 AS TipoUsuario,
				Documento,
				Nombre,
				Correo,
				CONVERT(VARCHAR(MAX), DECRYPTBYPASSPHRASE('password', Contraseņa)) AS DecryptResult,
				Contraseņa
			FROM Estudiantes
			WHERE Correo = @email AND CONVERT(VARCHAR(MAX), DECRYPTBYPASSPHRASE('password', Contraseņa)) = @password;

			SELECT TipoUsuario, Documento, Nombre, Correo, DecryptResult, Contraseņa
			FROM @Result;

		END
    ELSE IF EXISTS (SELECT * FROM Profesores WHERE Correo = @email AND CONVERT(VARCHAR(MAX), DECRYPTBYPASSPHRASE('password', Contraseņa)) = @password)
		BEGIN
			INSERT INTO @profesoresResult
			SELECT
				2 AS TipoUsuario,
				Documento,
				Nombre,
				Estado,
				Area_Especializacion,
				Correo,
				CONVERT(VARCHAR(MAX), DECRYPTBYPASSPHRASE('password', Contraseņa)) AS DecryptResult,
				Contraseņa
			FROM Profesores
			WHERE Correo = @email AND CONVERT(VARCHAR(MAX), DECRYPTBYPASSPHRASE('password', Contraseņa)) = @password;

			SELECT TipoUsuario, Documento, Nombre,Estado,Area_Especializacion,Correo, DecryptResult, Contraseņa
			FROM @profesoresResult;

		END
    ELSE IF EXISTS (SELECT * FROM Administradores WHERE Correo = @email AND CONVERT(VARCHAR(MAX), DECRYPTBYPASSPHRASE('password', Contraseņa)) = @password)
		BEGIN
			INSERT INTO @Result
			SELECT
				1 AS TipoUsuario,
				Documento,
				Nombre,
				Correo,
				CONVERT(VARCHAR(MAX), DECRYPTBYPASSPHRASE('password', Contraseņa)) AS DecryptResult,
				Contraseņa
			FROM Administradores
			WHERE Correo = @email AND CONVERT(VARCHAR(MAX), DECRYPTBYPASSPHRASE('password', Contraseņa)) = @password;

			SELECT TipoUsuario, Documento, Nombre, Correo, DecryptResult, Contraseņa
			FROM @Result;
		END
END;