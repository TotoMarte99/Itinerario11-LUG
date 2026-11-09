/* ============================================================
   BiciGestion - Script de instalacion de la base de datos
   SQL Server
   ============================================================ */

-- 1) Crear la base de datos si no existe
IF DB_ID('BiciGestionDB') IS NULL
BEGIN
    CREATE DATABASE BiciGestionDB;
END
GO

USE BiciGestionDB;
GO

/* ------------------------------------------------------------
   2) Tabla TIPO_BICICLETA
   ------------------------------------------------------------ */
IF OBJECT_ID('dbo.ALQUILER', 'U') IS NOT NULL
    DROP TABLE dbo.ALQUILER;
GO

IF OBJECT_ID('dbo.TIPO_BICICLETA', 'U') IS NOT NULL
    DROP TABLE dbo.TIPO_BICICLETA;
GO

CREATE TABLE dbo.TIPO_BICICLETA
(
    ID_TIPO_BICICLETA INT IDENTITY(1,1) NOT NULL,
    DESCRIPCION       NVARCHAR(50)      NOT NULL,
    CONSTRAINT PK_TIPO_BICICLETA PRIMARY KEY (ID_TIPO_BICICLETA)
);
GO

/* ------------------------------------------------------------
   3) Tabla ALQUILER
   ------------------------------------------------------------ */
CREATE TABLE dbo.ALQUILER
(
    NUMERO_ALQUILER   INT IDENTITY(1,1) NOT NULL,
    ID_TIPO_BICICLETA INT               NOT NULL,
    DNI_CLIENTE       VARCHAR(20)       NOT NULL,
    IMPORTE_TOTAL     DECIMAL(18,2)     NOT NULL,
    FECHA_REGISTRO    DATETIME          NOT NULL,
    FECHA_ALQUILER    DATETIME          NOT NULL,
    CONSTRAINT PK_ALQUILER PRIMARY KEY (NUMERO_ALQUILER),
    CONSTRAINT FK_ALQUILER_TIPO_BICICLETA
        FOREIGN KEY (ID_TIPO_BICICLETA)
        REFERENCES dbo.TIPO_BICICLETA (ID_TIPO_BICICLETA),
    CONSTRAINT CK_ALQUILER_IMPORTE CHECK (IMPORTE_TOTAL > 0)
);
GO

/* ------------------------------------------------------------
   4) Datos precargados de tipos de bicicleta
   ------------------------------------------------------------ */
INSERT INTO dbo.TIPO_BICICLETA (DESCRIPCION) VALUES
    (N'Urbana'),
    (N'Montaña'),
    (N'Electrica');
GO

/* ------------------------------------------------------------
   5) Datos de prueba de alquileres
   ------------------------------------------------------------ */
INSERT INTO dbo.ALQUILER (ID_TIPO_BICICLETA, DNI_CLIENTE, IMPORTE_TOTAL, FECHA_REGISTRO, FECHA_ALQUILER) VALUES
    (1, '30111222', 1500.00, GETDATE(), DATEADD(DAY, 1, GETDATE())),
    (2, '28999888', 2500.50, GETDATE(), DATEADD(DAY, 2, GETDATE())),
    (3, '35444555', 4000.00, GETDATE(), DATEADD(DAY, 3, GETDATE()));
GO

/* ------------------------------------------------------------
   6) Verificacion
   ------------------------------------------------------------ */
SELECT * FROM dbo.TIPO_BICICLETA;
SELECT * FROM dbo.ALQUILER;
GO
