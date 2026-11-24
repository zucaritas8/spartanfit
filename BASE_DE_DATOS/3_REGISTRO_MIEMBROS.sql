-- =====================================================================
-- SPARTANFIT - Registro de miembros (procedimientos almacenados)
-- Ejecutar DESPUES de 1_SPARTANFIT_FINAL.sql y 2_USUARIOS_LOGIN.sql
-- (se puede ejecutar varias veces).
--
-- Al registrar un miembro se crean, en una sola transaccion:
--   1) su USUARIO   -> usuario: miembro_<CI>   contrasena inicial: su CI (guardada como hash SHA-256)
--   2) su MIEMBRO   -> datos personales
--   3) su INSCRIPCION (plan) -> DIARIO, PASADO-DIA o MENSUAL, empezando hoy
-- =====================================================================
USE SPARTANFIT;
GO

-- ---------------------------------------------------------------------
-- REGISTRAR MIEMBRO
-- ---------------------------------------------------------------------
CREATE OR ALTER PROCEDURE SP_REGISTRAR_MIEMBRO
    @CI               VARCHAR(15),
    @NOMBRE           NVARCHAR(50),
    @APELLIDOS        NVARCHAR(50),
    @DIRECCION        NVARCHAR(150) = NULL,
    @TELEFONO         VARCHAR(12)   = NULL,
    @CORREO           NVARCHAR(100) = NULL,
    @FECHA_NACIMIENTO DATE,
    @MODALIDAD        NVARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;
    SET XACT_ABORT ON;

    SET @CI        = LTRIM(RTRIM(ISNULL(@CI, '')));
    SET @NOMBRE    = LTRIM(RTRIM(ISNULL(@NOMBRE, N'')));
    SET @APELLIDOS = LTRIM(RTRIM(ISNULL(@APELLIDOS, N'')));

    IF @CI = ''        THROW 50001, N'El CI es obligatorio.', 1;
    IF @NOMBRE = N''   THROW 50002, N'El nombre es obligatorio.', 1;
    IF @APELLIDOS = N'' THROW 50003, N'Los apellidos son obligatorios.', 1;
    IF @FECHA_NACIMIENTO > CAST(GETDATE() AS DATE)
        THROW 50004, N'La fecha de nacimiento no puede ser futura.', 1;
    IF @MODALIDAD NOT IN (N'DIARIO', N'PASADO-DIA', N'MENSUAL')
        THROW 50005, N'El plan debe ser DIARIO, PASADO-DIA o MENSUAL.', 1;
    IF EXISTS (SELECT 1 FROM MIEMBRO WHERE CI = @CI)
        THROW 50006, N'Ya existe un miembro registrado con ese CI.', 1;

    DECLARE @usuario NVARCHAR(100) = N'miembro_' + @CI;
    IF EXISTS (SELECT 1 FROM USUARIO WHERE USUARIO = @usuario)
        THROW 50007, N'Ya existe un usuario para ese CI.', 1;

    DECLARE @hoy DATE = CAST(GETDATE() AS DATE);
    DECLARE @fin DATE = CASE @MODALIDAD
                            WHEN N'MENSUAL'    THEN DATEADD(MONTH, 1, @hoy)
                            WHEN N'PASADO-DIA' THEN DATEADD(DAY, 1, @hoy)
                            ELSE @hoy
                        END;

    DECLARE @idUsuario INT, @idMiembro INT;

    BEGIN TRANSACTION;

        INSERT INTO USUARIO (USUARIO, PASSWORD_HASH, ESTADO)
        VALUES (@usuario, CONVERT(VARCHAR(64), HASHBYTES('SHA2_256', @CI), 2), 'ACTIVO');
        SET @idUsuario = SCOPE_IDENTITY();

        INSERT INTO MIEMBRO (ID_USUARIO, CI, NOMBRE, APELLIDOS, DIRECCION, TELEFONO, CORREO_ELECTRONICO, FECHA_NACIMIENTO)
        VALUES (@idUsuario, @CI, @NOMBRE, @APELLIDOS,
                NULLIF(LTRIM(RTRIM(@DIRECCION)), N''),
                NULLIF(LTRIM(RTRIM(@TELEFONO)), ''),
                NULLIF(LTRIM(RTRIM(@CORREO)), N''),
                @FECHA_NACIMIENTO);
        SET @idMiembro = SCOPE_IDENTITY();

        INSERT INTO INSCRIPCION (ID_MIEMBRO, FECHA_INICIO, FECHA_FIN, MODALIDAD, ESTADO)
        VALUES (@idMiembro, @hoy, @fin, @MODALIDAD, N'ACTIVO');

    COMMIT TRANSACTION;

    SELECT @idMiembro AS ID_MIEMBRO, @usuario AS USUARIO;
END
GO

-- ---------------------------------------------------------------------
-- ACTUALIZAR DATOS DE UN MIEMBRO
-- ---------------------------------------------------------------------
CREATE OR ALTER PROCEDURE SP_ACTUALIZAR_MIEMBRO
    @ID_MIEMBRO       INT,
    @CI               VARCHAR(15),
    @NOMBRE           NVARCHAR(50),
    @APELLIDOS        NVARCHAR(50),
    @DIRECCION        NVARCHAR(150) = NULL,
    @TELEFONO         VARCHAR(12)   = NULL,
    @CORREO           NVARCHAR(100) = NULL,
    @FECHA_NACIMIENTO DATE
AS
BEGIN
    SET NOCOUNT ON;
    SET XACT_ABORT ON;

    SET @CI        = LTRIM(RTRIM(ISNULL(@CI, '')));
    SET @NOMBRE    = LTRIM(RTRIM(ISNULL(@NOMBRE, N'')));
    SET @APELLIDOS = LTRIM(RTRIM(ISNULL(@APELLIDOS, N'')));

    IF NOT EXISTS (SELECT 1 FROM MIEMBRO WHERE ID_MIEMBRO = @ID_MIEMBRO)
        THROW 50011, N'El miembro no existe.', 1;
    IF @CI = ''         THROW 50001, N'El CI es obligatorio.', 1;
    IF @NOMBRE = N''    THROW 50002, N'El nombre es obligatorio.', 1;
    IF @APELLIDOS = N'' THROW 50003, N'Los apellidos son obligatorios.', 1;
    IF @FECHA_NACIMIENTO > CAST(GETDATE() AS DATE)
        THROW 50004, N'La fecha de nacimiento no puede ser futura.', 1;
    IF EXISTS (SELECT 1 FROM MIEMBRO WHERE CI = @CI AND ID_MIEMBRO <> @ID_MIEMBRO)
        THROW 50006, N'Ya existe otro miembro registrado con ese CI.', 1;

    UPDATE MIEMBRO
       SET CI = @CI,
           NOMBRE = @NOMBRE,
           APELLIDOS = @APELLIDOS,
           DIRECCION = NULLIF(LTRIM(RTRIM(@DIRECCION)), N''),
           TELEFONO = NULLIF(LTRIM(RTRIM(@TELEFONO)), ''),
           CORREO_ELECTRONICO = NULLIF(LTRIM(RTRIM(@CORREO)), N''),
           FECHA_NACIMIENTO = @FECHA_NACIMIENTO
     WHERE ID_MIEMBRO = @ID_MIEMBRO;
END
GO

-- ---------------------------------------------------------------------
-- LISTAR / BUSCAR MIEMBROS (con su ultimo plan)
-- ---------------------------------------------------------------------
CREATE OR ALTER PROCEDURE SP_LISTAR_MIEMBROS
    @BUSCAR NVARCHAR(100) = NULL
AS
BEGIN
    SET NOCOUNT ON;

    SELECT M.ID_MIEMBRO,
           M.CI,
           M.NOMBRE,
           M.APELLIDOS,
           M.TELEFONO,
           M.CORREO_ELECTRONICO AS CORREO,
           M.FECHA_NACIMIENTO,
           M.DIRECCION,
           U.USUARIO,
           I.MODALIDAD,
           I.FECHA_INICIO,
           I.FECHA_FIN,
           CASE WHEN I.ID_INSCRIPCION IS NULL THEN N'SIN PLAN'
                WHEN I.ESTADO = N'ACTIVO' AND I.FECHA_FIN >= CAST(GETDATE() AS DATE) THEN N'VIGENTE'
                ELSE N'VENCIDO' END AS ESTADO_PLAN
    FROM MIEMBRO M
    JOIN USUARIO U ON U.ID_USUARIO = M.ID_USUARIO
    OUTER APPLY (SELECT TOP 1 X.ID_INSCRIPCION, X.MODALIDAD, X.FECHA_INICIO, X.FECHA_FIN, X.ESTADO
                 FROM INSCRIPCION X
                 WHERE X.ID_MIEMBRO = M.ID_MIEMBRO
                 ORDER BY X.FECHA_FIN DESC, X.ID_INSCRIPCION DESC) I
    WHERE @BUSCAR IS NULL
       OR @BUSCAR = N''
       OR M.CI LIKE N'%' + @BUSCAR + N'%'
       OR M.NOMBRE LIKE N'%' + @BUSCAR + N'%'
       OR M.APELLIDOS LIKE N'%' + @BUSCAR + N'%'
    ORDER BY M.ID_MIEMBRO DESC;
END
GO

-- Prueba rapida (opcional):
-- EXEC SP_LISTAR_MIEMBROS;
GO
