-------------------------------------------------- STORED PROCEDURES ----------------------------------------------------------
use UMS

Go
-- Stored procedure to filter users based on email and password
CREATE PROCEDURE FiltrarUsuario
    @email VARCHAR(50),
    @password VARCHAR(50)
AS
BEGIN
	-- Declare a table variable to store results for general users
    DECLARE @Result TABLE (
        TipoUsuario INT,
        Documento VARCHAR(10),
        Nombre VARCHAR(40),
        Correo VARCHAR(50),
        DecryptResult VARCHAR(MAX),
        Contraseña VARBINARY(8000)
    );

	-- Declare a table variable to store results for professors
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

	-- Check if the user exists in the 'Students' table
    IF EXISTS (SELECT * FROM Estudiantes WHERE Correo = @email AND CONVERT(VARCHAR(MAX), DECRYPTBYPASSPHRASE('password', Contraseña)) = @password)
		BEGIN
			-- Insert the user details into the result table
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

			-- Select and return user details from the result table
			SELECT TipoUsuario, Documento, Nombre, Correo, DecryptResult, Contraseña
			FROM @Result;

		END
		-- Check if the user exists in the 'Professors' table
    ELSE IF EXISTS (SELECT * FROM Profesores WHERE Correo = @email AND CONVERT(VARCHAR(MAX), DECRYPTBYPASSPHRASE('password', Contraseña)) = @password)
		BEGIN
			-- Insert the professor details into the result table
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

			-- Select and return professor details from the result table
			SELECT TipoUsuario, Documento, Nombre,Estado,Area_Especializacion,Correo, DecryptResult, Contraseña
			FROM @profesoresResult;

		END
		-- Check if the user exists in the 'Administrators' table
    ELSE IF EXISTS (SELECT * FROM Administradores WHERE Correo = @email AND CONVERT(VARCHAR(MAX), DECRYPTBYPASSPHRASE('password', Contraseña)) = @password)
		BEGIN
			-- Insert the administrator details into the result table
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

			-- Select and return administrator details from the result table
			SELECT TipoUsuario, Documento, Nombre, Correo, DecryptResult, Contraseña
			FROM @Result;
		END
END;
