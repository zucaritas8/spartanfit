-- =====================================================================
-- SPARTANFIT - Usuarios para el login
-- Ejecutar DESPUES de 1_SPARTANFIT_FINAL.sql (se puede ejecutar varias veces).
-- Las contrasenas se guardan como hash SHA-256 (el mismo que calcula el sistema).
--
--   USUARIO         CONTRASENA     ROL
--   admin           Admin123       Administrador (control de todo)
--   coach_leo       Coach123       Coach
--   miembro_luis    Miembro123     Atleta - plan MENSUAL
--   miembro_carla   Miembro123     Atleta - plan PASADO-DIA
--   miembro_diego   Miembro123     Atleta - plan DIARIO
-- =====================================================================
USE SPARTANFIT;
GO

-- 1. USUARIOS
INSERT INTO USUARIO (USUARIO, PASSWORD_HASH, ESTADO)
SELECT v.usuario, CONVERT(VARCHAR(64), HASHBYTES('SHA2_256', v.clave), 2), 'ACTIVO'
FROM (VALUES
    (N'admin',         'Admin123'),
    (N'coach_leo',     'Coach123'),
    (N'miembro_luis',  'Miembro123'),
    (N'miembro_carla', 'Miembro123'),
    (N'miembro_diego', 'Miembro123')
) AS v(usuario, clave)
WHERE NOT EXISTS (SELECT 1 FROM USUARIO u WHERE u.USUARIO = v.usuario);
GO

-- 2. COACH (con su especialidad CrossFit & Functional)
INSERT INTO COACH (ID_USUARIO, CI, CODIGO, NOMBRE, APELLIDO, DIRECCION, TELEFONO)
SELECT u.ID_USUARIO, '5551001', 'COACH03', N'Leonardo', N'Salazar', N'Av. Blanco Galindo Km 4', '70010001'
FROM USUARIO u
WHERE u.USUARIO = N'coach_leo'
  AND NOT EXISTS (SELECT 1 FROM COACH WHERE CI = '5551001');
GO

INSERT INTO COACH_ESPECIALIDAD (ID_COACH, ID_ESPECIALIDAD, FECHA_EMISION, FECHA_EXPIRACION)
SELECT c.ID_COACH, e.ID_ESPECIALIDAD, '2025-01-10', '2028-01-10'
FROM COACH c
CROSS JOIN ESPECIALIDAD e
WHERE c.CI = '5551001' AND e.NOMBRE = N'CrossFit & Functional'
  AND NOT EXISTS (SELECT 1 FROM COACH_ESPECIALIDAD ce
                  WHERE ce.ID_COACH = c.ID_COACH AND ce.ID_ESPECIALIDAD = e.ID_ESPECIALIDAD);
GO

-- 3. MIEMBROS
INSERT INTO MIEMBRO (ID_USUARIO, CI, NOMBRE, APELLIDOS, DIRECCION, TELEFONO, CORREO_ELECTRONICO, FECHA_NACIMIENTO)
SELECT u.ID_USUARIO, v.ci, v.nombre, v.apellidos, v.direccion, v.telefono, v.correo, v.nacimiento
FROM (VALUES
    (N'miembro_luis',  '5552001', N'Luis',  N'Fernández', N'Av. Ayacucho #230',  '70020001', 'luis@email.com',  CAST('1997-05-14' AS DATE)),
    (N'miembro_carla', '5552002', N'Carla', N'Quispe',    N'Calle Jordán #85',   '70020002', 'carla@email.com', CAST('1999-09-03' AS DATE)),
    (N'miembro_diego', '5552003', N'Diego', N'Rojas',     N'Av. Heroínas #410',  '70020003', 'diego@email.com', CAST('2001-02-27' AS DATE))
) AS v(usuario, ci, nombre, apellidos, direccion, telefono, correo, nacimiento)
JOIN USUARIO u ON u.USUARIO = v.usuario
WHERE NOT EXISTS (SELECT 1 FROM MIEMBRO m WHERE m.CI = v.ci);
GO

-- 4. PLAN (INSCRIPCION): un miembro por cada modalidad guardada en la base de datos
INSERT INTO INSCRIPCION (ID_MIEMBRO, FECHA_INICIO, FECHA_FIN, MODALIDAD, ESTADO)
SELECT m.ID_MIEMBRO,
       CAST(GETDATE() AS DATE),
       CASE v.modalidad
            WHEN N'MENSUAL'    THEN DATEADD(MONTH, 1, CAST(GETDATE() AS DATE))
            WHEN N'PASADO-DIA' THEN DATEADD(DAY, 1, CAST(GETDATE() AS DATE))
            ELSE CAST(GETDATE() AS DATE)
       END,
       v.modalidad, N'ACTIVO'
FROM (VALUES
    ('5552001', N'MENSUAL'),
    ('5552002', N'PASADO-DIA'),
    ('5552003', N'DIARIO')
) AS v(ci, modalidad)
JOIN MIEMBRO m ON m.CI = v.ci
WHERE NOT EXISTS (SELECT 1 FROM INSCRIPCION i WHERE i.ID_MIEMBRO = m.ID_MIEMBRO);
GO

-- 5. CREDENCIAL de acceso de cada miembro
INSERT INTO CREDENCIAL (ID_MIEMBRO, TIPO, VALOR, ESTADO)
SELECT m.ID_MIEMBRO, N'RFID', v.valor, N'ACTIVO'
FROM (VALUES
    ('5552001', 'RFID_HASH_101'),
    ('5552002', 'RFID_HASH_102'),
    ('5552003', 'RFID_HASH_103')
) AS v(ci, valor)
JOIN MIEMBRO m ON m.CI = v.ci
WHERE NOT EXISTS (SELECT 1 FROM CREDENCIAL c WHERE c.VALOR = v.valor);
GO

-- Verificacion
SELECT u.USUARIO,
       CASE WHEN c.ID_COACH IS NOT NULL THEN 'Coach'
            WHEN m.ID_MIEMBRO IS NOT NULL THEN 'Atleta'
            ELSE 'Administrador' END AS ROL,
       i.MODALIDAD, i.FECHA_INICIO, i.FECHA_FIN
FROM USUARIO u
LEFT JOIN COACH c ON c.ID_USUARIO = u.ID_USUARIO
LEFT JOIN MIEMBRO m ON m.ID_USUARIO = u.ID_USUARIO
LEFT JOIN INSCRIPCION i ON i.ID_MIEMBRO = m.ID_MIEMBRO
WHERE u.USUARIO IN (N'admin', N'coach_leo', N'miembro_luis', N'miembro_carla', N'miembro_diego');
GO
