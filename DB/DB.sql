--DBCC CHECKIDENT('DetalleOrden', RESEED, 0) -- Resetea el IDENTITY Comenzando de 0
--CREATE TYPE NuevoTipoDeDato FROM INT NOT NULL -- Creamos un tipo de dato nuevo con cualquier valor (INT, NVARCHAR, FLOAT, DECIMAL...)

SET NOCOUNT ON
GO

USE master
GO
IF EXISTS (SELECT * FROM sysdatabases WHERE NAME = 'SolTerraRestaurant')
		DROP DATABASE SolTerraRestaurant
GO
DECLARE @device_directory NVARCHAR(520)
SELECT @device_directory = SUBSTRING(filename, 1, CHARINDEX(N'master.mdf', LOWER(filename)) - 1)
FROM master.dbo.sysaltfiles WHERE dbid = 1 AND fileid = 1

EXECUTE (N'CREATE DATABASE SolTerraRestaurant
  ON PRIMARY (NAME = N''SolTerraRestaurant'', FILENAME = N''' + @device_directory + N'solTerraRestaurant.mdf'')
  LOG ON (NAME = N''SolTerraRestaurant_log'',  FILENAME = N''' + @device_directory + N'solTerraRestaurant.ldf'')')

GO
SET QUOTED_IDENTIFIER ON
GO
SET DATEFORMAT mdy
GO
USE "SolTerraRestaurant"
GO

---------------------------------- CREATE TABLES ------------------------------------------------------------------------------------------------------------
----------------------------------------------------------------------------------------------------------------------------------------------------------------
CREATE TABLE "Departamento"
(
	"No_Departamento" "INT" IDENTITY (1, 1) NOT NULL,
	"NombreDepartamento" VARCHAR(50) NOT NULL

	CONSTRAINT "PK_Departamentos" PRIMARY KEY  CLUSTERED 
	(
		"No_Departamento"
	)
);
GO
 CREATE  INDEX "NombreDepartamento" ON "dbo"."Departamento"("NombreDepartamento")
GO

CREATE TABLE "Sucursal"
(
	"Id_Sucursal" "INT" IDENTITY (1, 1) NOT NULL,
	"NombreSucursal" NVARCHAR (30) NOT NULL,
	"NombreEncargado" NVARCHAR (30) NULL,
	"Telefono" NVARCHAR(24) NOT NULL,
	"Dirección" NVARCHAR(100) NULL,
	"No_Departamento" "INT" NOT NULL FOREIGN KEY REFERENCES [dbo]."Departamento" (No_Departamento),
	"Estado" NVARCHAR(50) NOT NULL CHECK ("Estado" IN ('Abierto', 'Cerrado'))

	CONSTRAINT "PK_Sucursales" PRIMARY KEY  CLUSTERED 
	(
		"Id_Sucursal"
	),
	CONSTRAINT UQ_Datos_Sucursales UNIQUE ("Telefono", "NombreEncargado")
);
GO
 CREATE  INDEX "NombreSucursal" ON "dbo"."Sucursal"("NombreSucursal")
GO
 CREATE  INDEX "NombreEncargado" ON "dbo"."Sucursal"("NombreEncargado")
GO
CREATE TABLE "Empleado"
(
	"IdEmpleado" "INT" IDENTITY (1, 1) NOT NULL,
	"PrimerNombre" NVARCHAR(60) NOT NULL,
	"SegundoNombre" NVARCHAR(60) NULL,
	"PrimerApellido" NVARCHAR(60) NOT NULL,
	"SegundoApellido" NVARCHAR(60) NULL,
	"Direccion" NVARCHAR(500) NULL,
	"Telefono" NVARCHAR(24) NULL,
	"No_Cedula" NVARCHAR(30) NOT NULL,
	"FechaContratacion" "DATETIME" NULL,
	"Photo" "IMAGE" NULL ,
	"PhotoPath" NVARCHAR(255) NULL,
	"Estado" NVARCHAR(30) NULL
	CONSTRAINT "PK_Empleados" PRIMARY KEY  CLUSTERED 
	(
		"IdEmpleado"
	),
	CONSTRAINT "CK_FechaContratacion" CHECK (FechaContratacion < getdate()),
	CONSTRAINT UQ_Datos_Empleado UNIQUE (Telefono, No_Cedula)
);
GO
 CREATE  INDEX "PrimerNombre" ON "dbo"."Empleado"("PrimerNombre")
GO
 CREATE  INDEX "PrimerApellido" ON "dbo"."Empleado"("PrimerApellido")
GO
 CREATE  INDEX "No_Cedula" ON "dbo"."Empleado"("No_Cedula")
GO

CREATE TABLE "Det_Empleado"
(
	"Id_DT_Empleado" "INT" IDENTITY (1, 1) NOT NULL,
	"IdEmpleado" "INT" NOT NULL FOREIGN KEY REFERENCES [dbo]."Empleado" (IdEmpleado),
	"Id_Sucursal" "INT" NOT NULL FOREIGN KEY REFERENCES [dbo]."Sucursal" (Id_Sucursal),
	"Tipo_Empleado" VARCHAR(60) NOT NULL

	CONSTRAINT "PK_DT_Empleados" PRIMARY KEY  CLUSTERED 
	(
		"Id_DT_Empleado"
	)
);
GO
 CREATE  INDEX "Tipo_Empleado" ON "dbo"."Det_Empleado"("Tipo_Empleado")
GO

CREATE TABLE "Categoria"
(
	"No_Categoria" "INT" IDENTITY(1, 1) NOT NULL,
	"NombreCategoria" NVARCHAR(30) NOT NULL

	CONSTRAINT "PK_Categorias" PRIMARY KEY  CLUSTERED 
	(
		"No_Categoria"
	)
);
GO
 CREATE  INDEX "NombreCategoria" ON "dbo"."Categoria"("NombreCategoria")
GO

CREATE TABLE "Plato"
(
	"IdPlato" "INT" IDENTITY(1, 1) NOT NULL,
	"NombrePlato" NVARCHAR(70) NOT NULL,
	"Descripcion" NVARCHAR(500) NOT NULL,
	"Id_Sucursal" "INT" NOT NULL FOREIGN KEY REFERENCES [dbo]."Sucursal" (Id_Sucursal),
	"No_Categoria" "INT" NOT NULL FOREIGN KEY REFERENCES [dbo]."Categoria" (No_Categoria),
	"Precio" FLOAT NOT NULL

	CONSTRAINT "PK_Platos" PRIMARY KEY CLUSTERED
	(
		"IdPlato"
	)
);
GO
 CREATE  INDEX "NombrePlato" ON "dbo"."Plato"("NombrePlato")
GO

CREATE TABLE "Proveedor"
(
	"IdProveedor" "INT" IDENTITY(1, 1) NOT NULL,
	"NombreProveedor" NVARCHAR(50) NOT NULL,
	"Telefono" NVARCHAR(24) NULL,
	"CorreoElectronico" NVARCHAR(50) NULL,
	"Direccion" NVARCHAR(100) NULL,
	"No_Departamento" "INT" NOT NULL FOREIGN KEY REFERENCES [dbo]."Departamento"(No_Departamento)

	CONSTRAINT "PK_Proveedores" PRIMARY KEY CLUSTERED
	(
		"IdProveedor"
	)
);
GO
 CREATE  INDEX "NombreProveedor" ON "dbo"."Proveedor"("NombreProveedor")
GO
 CREATE  INDEX "CorreoElectronico" ON "dbo"."Proveedor"("CorreoElectronico")
GO

CREATE TABLE "Insumo" 
(
	"IdInsumo" "INT" IDENTITY(1, 1) NOT NULL,
	"NombreIngrediente" NVARCHAR(80) NOT NULL,
	"IdProveedro" "INT" NOT NULL FOREIGN KEY REFERENCES [dbo]."Proveedor"(IdProveedor),
	"CantidadComprada" FLOAT NULL,
	"Precio" FLOAT NOT NULL

	CONSTRAINT "PK_Insumos" PRIMARY KEY CLUSTERED
	(
		"IdInsumo"
	)
);
GO
 CREATE  INDEX "NombreIngrediente" ON "dbo"."Insumo"("NombreIngrediente")
GO


CREATE TABLE "DetallePlato"
(
	"IdDetallePlato" "INT" IDENTITY(1, 1) NOT NULL,
	"IdPlato" "INT" NOT NULL FOREIGN KEY REFERENCES [dbo]."Plato"(IdPlato),
	"IdInsumo" "INT" NOT NULL FOREIGN KEY REFERENCES [dbo]."Insumo"(IdInsumo),
	"MedidaIngrediente" FLOAT NULL

	CONSTRAINT "PK_DetallePlatos" PRIMARY KEY CLUSTERED
	(
		"IdDetallePlato"
	)
);

CREATE TABLE "Area"
(
	"IdArea" "INT" IDENTITY(1, 1) NOT NULL,
	"NombreArea" NVARCHAR(50) NOT NULL,
	"CantidadClientes" "INT" NOT NULL CHECK ("CantidadClientes" > 0 AND "CantidadClientes" < 100),
	"Estado" NVARCHAR(50) NULL CHECK ("Estado" IN ('Llena', 'Libre'))

	CONSTRAINT "PK_Areas" PRIMARY KEY CLUSTERED
	(
		"IdArea"	
	)
);
GO
 CREATE  INDEX "NombreArea" ON "dbo"."Area"("NombreArea")
GO

CREATE TABLE "Mesa"
(
	"IdMesa" "INT" IDENTITY(1, 1) NOT NULL,
	"IdSucursal" "INT" NOT NULL FOREIGN KEY REFERENCES [dbo]."Sucursal"(Id_Sucursal),
	"IdArea" "INT" NOT NULL FOREIGN KEY REFERENCES [dbo]."Area"(IdArea),
	"CantidadAsientos" "INT" NOT NULL,
	"Estado" NVARCHAR(50) NULL CHECK ("Estado" IN ('Habilitada', 'Deshabilitada', 'Reservada'))

	CONSTRAINT "PK_Mesas" PRIMARY KEY CLUSTERED
	(
		"IdMesa"
	)
);
GO
 CREATE  INDEX "Estado" ON "dbo"."Mesa"("Estado")
GO

CREATE TABLE "Cliente" 
(
	"IdCliente" "INT" IDENTITY(1, 1) NOT NULL,
	"PrimerNombre" NVARCHAR(20) NOT NULL,
	"SegundoNombre" NVARCHAR(20) NULL,
	"PrimerApellido" NVARCHAR(20) NOT NULL,
	"SegundoApellido" NVARCHAR(20) NULL,
	"No_Cedula" NVARCHAR(30) NOT NULL,
	"Telefono" VARCHAR(24) NULL,
	"Fecha" DATETIME NULL

	CONSTRAINT "PK_Clientes" PRIMARY KEY CLUSTERED
	(
		"IdCliente"
	),
	CONSTRAINT UQ_Datos_Clientes UNIQUE (Telefono, No_Cedula)
);
GO
 CREATE  INDEX "PrimerNombre" ON "dbo"."Cliente"("PrimerNombre")
GO
 CREATE  INDEX "No_Cedula" ON "dbo"."Cliente"("No_Cedula")
GO

CREATE TABLE "Orden"
(
	"IdOrden" "INT" IDENTITY(1, 1) NOT NULL,
	"TipoPago" NVARCHAR(50) NOT NULL,
	"Fecha" "DATETIME" NULL,
	"HoraAtencion" "TIME" NULL,

	CONSTRAINT "PK_Ordenes" PRIMARY KEY CLUSTERED
	(
		"IdOrden"
	)
);
GO
 CREATE  INDEX "TipoPago" ON "dbo"."Orden"("TipoPago")
GO

CREATE TABLE "DetalleOrden"
(
	"IdDetalleOrden" "INT" IDENTITY(1, 1) NOT NULL,
	"IdOrden" "INT" NOT NULL FOREIGN KEY REFERENCES [dbo]."Orden"(IdOrden),
	"IdEmpleado" "INT" NOT NULL FOREIGN KEY REFERENCES [dbo]."Empleado"(IdEmpleado),
	"IdPlato" "INT" NOT NULL FOREIGN KEY REFERENCES [dbo]."Plato"(IdPlato),
	"IdMesa" "INT" NOT NULL FOREIGN KEY REFERENCES [dbo]."Mesa"(IdMesa),
	"IdCliente" "INT" NULL FOREIGN KEY REFERENCES [dbo]."Cliente"(IdCliente),
	"Monto" FLOAT NULL 
	CONSTRAINT "PK_DetalleOrdenes" PRIMARY KEY CLUSTERED
	(
		"IdDetalleOrden"
	)
);

CREATE TABLE "Menu"
(
	"IdMenu" "INT" NOT NULL IDENTITY(1, 1),
	"Nombre" NVARCHAR(80) NULL,
	"Icon" NVARCHAR(100) NULL

	CONSTRAINT "PK_Menu" PRIMARY KEY CLUSTERED
	(
		"IdMenu"
	),
	CONSTRAINT UQ_Datos_Menu UNIQUE ("Nombre")
);
GO
 CREATE  INDEX "Nombre" ON "dbo"."Menu"("Nombre");
GO

CREATE TABLE "SubMenu" 
(
	"IdSubMenu" "INT" NOT NULL IDENTITY(1, 1),
	"IdMenu" "INT" NOT NULL FOREIGN KEY REFERENCES [dbo]."Menu"(IdMenu),
	"Nombre" NVARCHAR(80) NOT NULL,
	"NombreFormulario" VARCHAR(100) NULL

	CONSTRAINT "PK_SubMenu" PRIMARY KEY CLUSTERED
	(
		"IdSubMenu"
	),
	CONSTRAINT UQ_Datos_SubMenu UNIQUE ("Nombre", "NombreFormulario")
);
GO
	CREATE INDEX "Nombre" ON "dbo"."SubMenu"("Nombre");
GO
	CREATE INDEX "NombreFormulario" ON "dbo"."SubMenu"("NombreFormulario");
GO

CREATE TABLE "Rol"
(
	"IdRol" "INT" IDENTITY(1, 1) NOT NULL,
	"NombreRol" NVARCHAR(50) NOT NULL

	CONSTRAINT "PK_Roles" PRIMARY KEY CLUSTERED
	(
		"IdRol"
	)
);
GO
 CREATE  INDEX "NombreRol" ON "dbo"."Rol"("NombreRol")
GO

CREATE TABLE "Permiso"
(
	"IdPermiso" "INT" NOT NULL IDENTITY(1, 1),
	"IdRol" "INT" NOT NULL FOREIGN KEY REFERENCES [dbo]."Rol"("IdRol"),
	"IdSubMenu" "INT" NOT NULL FOREIGN KEY REFERENCES [dbo]."SubMenu"("IdSubmenu"),
	"Estado" NVARCHAR(50) NULL

	CONSTRAINT "PK_Permisos" PRIMARY KEY CLUSTERED
	(
		"IdPermiso"
	)
);
GO
 CREATE  INDEX "Estado" ON "dbo"."Permiso"("Estado")
GO

CREATE TABLE "Usuario"
(
	"IdUsuario" "INT" IDENTITY (1, 1) NOT NULL,
	"IdEmpleado" "INT" NOT NULL FOREIGN KEY REFERENCES [dbo]."Empleado"(IdEmpleado),
	"NombreUsuario" NVARCHAR(50) NOT NULL,
	"Contraseña" VARCHAR(100) NOT NULL,
	"IdRol" "INT" NOT NULL FOREIGN KEY REFERENCES [dbo]."Rol"(IdRol),
	"EstadoUsuario" VARCHAR(50) NOT NULL,
	"EstadoContraseña" VARCHAR(50) NOT NULL

	CONSTRAINT "PK_Usuarios" PRIMARY KEY CLUSTERED
	(
		"IdUsuario"
	),
	CONSTRAINT UQ_Datos_Usuario UNIQUE ("NombreUsuario", "IdEmpleado", "Contraseña")

);
GO
 CREATE  INDEX "NombreUsuario" ON "dbo"."Usuario"("NombreUsuario")
GO

CREATE TABLE "DetalleFactura"
(
	"IdDetalleFactura" "INT" IDENTITY(1, 1) NOT NULL,
	"IdDetalleOrden" "INT" NOT NULL FOREIGN KEY REFERENCES [dbo]."DetalleOrden"(IdDetalleOrden),
	"SubTotal" FLOAT NOT NULL,
	"IVA" FLOAT NOT NULL,
	"Total" DECIMAL NOT NULL

	CONSTRAINT "PK_DetalleFactura" PRIMARY KEY CLUSTERED
	(
		"IdDetalleFactura"
	)
);

CREATE TABLE "Factura"
(
	"IdFactura" "INT" IDENTITY(1, 1) NOT NULL,
	"IdSucursal" "INT" NOT NULL FOREIGN KEY REFERENCES [dbo]."Sucursal" (Id_Sucursal),
	"IdDetalleFactura" "INT" NOT NULL FOREIGN KEY REFERENCES [dbo]."DetalleFactura"(IdDetalleFactura),
	"Fecha" "DATETIME" NULL,
	"IdUsuario" "INT" NOT NULL FOREIGN KEY REFERENCES [dbo]."Usuario"(IdUsuario)
	CONSTRAINT "PK_Facturas" PRIMARY KEY CLUSTERED
	(
		"IdFactura"
	)
);

GO

---------------------------------- VIEWS ON TABLES ------------------------------------------------------------------------------------------------------------
----------------------------------------------------------------------------------------------------------------------------------------------------------------
CREATE VIEW "Sucursales" AS
SELECT 
	sl.NombreSucursal AS [Sucursal], em.PrimerNombre +' '+ em.SegundoNombre AS [Encargado],
	sl.Telefono, dp.NombreDepartamento, sl.Dirección, sl.Estado
FROM Det_Empleado dtE INNER JOIN Sucursal sl ON dtE.Id_Sucursal = sl.Id_Sucursal
INNER JOIN Departamento dp ON dp.No_Departamento = sl.No_Departamento
INNER JOIN Empleado em ON em.IdEmpleado = dtE.IdEmpleado
WHERE dtE.Tipo_Empleado = 'Encargado'

GO
CREATE VIEW "Empleados" AS
SELECT 
	em.IdEmpleado AS [Id Empleado],
	em.PrimerNombre +' '+ em.PrimerApellido AS [Nombre Empleado],
	em.Telefono,
	em.No_Cedula,
	em.Direccion,
	em.FechaContratacion AS [Fecha Contrato],
	sl.NombreSucursal AS [Sucursal],
	dt.Tipo_Empleado
FROM Det_Empleado dt INNER JOIN Empleado em ON em.IdEmpleado = dt.IdEmpleado
INNER JOIN Sucursal sl ON sl.Id_Sucursal = dt.Id_Sucursal

GO
CREATE VIEW "Proveedores" AS
SELECT 
	pd.NombreProveedor AS [Proveedor],
	pd.Telefono,
	pd.CorreoElectronico,
	dt.NombreDepartamento AS [Departamento],
	pd.Direccion
FROM Departamento dt INNER JOIN Proveedor pd ON pd.No_Departamento = dt.No_Departamento

GO
CREATE VIEW "Platos" AS
SELECT
	pt.NombrePlato AS [Nombre Plato],
	ct.NombreCategoria AS [Categoria],
	pt.Descripcion,
	sl.NombreSucursal AS [Sucursal],
	pt.Precio
FROM Plato pt INNER JOIN Sucursal sl ON sl.Id_Sucursal = pt.Id_Sucursal
INNER JOIN Categoria ct ON ct.No_Categoria = pt.No_Categoria

GO
CREATE VIEW "Mesas" AS
SELECT
	ar.NombreArea AS [Lugar],
	ms.CantidadAsientos AS [Cantidad Asientos],
	sl.NombreSucursal AS [Sucursal],
	ms.Estado AS [Estado]
FROM Mesa ms INNER JOIN Sucursal sl ON sl.Id_Sucursal = ms.IdSucursal
INNER JOIN Area ar ON ar.IdArea = ms.IdArea

GO
CREATE VIEW "Insumos" AS
SELECT
	im.NombreIngrediente AS [Insumo],
	pd.NombreProveedor AS [Proveedor],
	im.CantidadComprada AS [Cantidad Comprada],
	im.Precio AS [Precio Unitario]
FROM Insumo im INNER JOIN Proveedor pd ON pd.IdProveedor = im.IdProveedro

GO
CREATE VIEW "DetallePlatos" AS
SELECT
	pt.NombrePlato AS [Nombre del Platillo],
	im.NombreIngrediente AS [Ingredientes]
FROM DetallePlato dtp INNER JOIN Plato pt ON pt.IdPlato = dtp.IdPlato
INNER JOIN Insumo im ON im.IdInsumo = dtp.IdInsumo

GO
CREATE VIEW "Ordenes" AS 
SELECT ord.idOrden AS [Orden],
cl.PrimerNombre+' '+cl.PrimerApellido AS [Cliente],
pl.NombrePlato AS [Platillo],
ms.CantidadAsientos AS [Asientos],
ar.NombreArea AS [Lugar],
em.PrimerNombre+' '+em.PrimerApellido AS [Empleado],
(SELECT 
--	ord.IdOrden,
--	COUNT(dto.IdOrden),
	SUM(pl.Precio)
FROM Plato pl INNER JOIN DetalleOrden dto ON dto.IdPlato = pl.IdPlato 
INNER JOIN Orden ord ON ord.IdOrden = dto.IdOrden
WHERE ord.IdOrden = dt.IdOrden
GROUP BY ord.IdOrden) AS [Monto]
FROM DetalleOrden dt
INNER JOIN Orden ord ON ord.IdOrden = dt.IdOrden
INNER JOIN Cliente cl ON cl.IdCliente = dt.IdCliente
INNER JOIN Plato pl ON pl.IdPlato = dt.IdPlato
INNER JOIN Mesa ms ON ms.IdMesa = dt.IdMesa
INNER JOIN Area ar ON ar.IdArea = ms.IdArea
INNER JOIN Empleado em ON em.IdEmpleado = dt.IdEmpleado

GO
---------------------------------- INSERT ON TABLES ------------------------------------------------------------------------------------------------------------
----------------------------------------------------------------------------------------------------------------------------------------------------------------
INSERT INTO Departamento(NombreDepartamento) VALUES ('Boaco')
INSERT INTO Departamento(NombreDepartamento) VALUES ('Carazo')
INSERT INTO Departamento(NombreDepartamento) VALUES ('Chinandega')
INSERT INTO Departamento(NombreDepartamento) VALUES ('Chontales')
INSERT INTO Departamento(NombreDepartamento) VALUES ('Esteli')
INSERT INTO Departamento(NombreDepartamento) VALUES ('Granada')
INSERT INTO Departamento(NombreDepartamento) VALUES ('Jinotega')
INSERT INTO Departamento(NombreDepartamento) VALUES ('León')
INSERT INTO Departamento(NombreDepartamento) VALUES ('Madriz')
INSERT INTO Departamento(NombreDepartamento) VALUES ('Managua')
INSERT INTO Departamento(NombreDepartamento) VALUES ('Masaya')
INSERT INTO Departamento(NombreDepartamento) VALUES ('Matagalpa')
INSERT INTO Departamento(NombreDepartamento) VALUES ('Nueva Segovia')
INSERT INTO Departamento(NombreDepartamento) VALUES ('Río San Juan')
INSERT INTO Departamento(NombreDepartamento) VALUES ('Rivas')

GO
--
--
INSERT INTO Sucursal (NombreSucursal, NombreEncargado, Telefono, Dirección, No_Departamento, Estado) VALUES ('SolTerra-Maple', '', '22764537', 'Km 4 1/2 Carretera Norte, Managua, Nicaragua', 10, 'Abierto')
INSERT INTO Sucursal (NombreSucursal, NombreEncargado, Telefono, Dirección, No_Departamento, Estado) VALUES ('SolTerra-Rose', '', '22764554', 'Comunidad de Yankee No.1 Jinotega, JINOTEGA', 7, 'Abierto')
INSERT INTO Sucursal (NombreSucursal, NombreEncargado, Telefono, Dirección, No_Departamento, Estado) VALUES ('SolTerra-Casita', '', '22764547', 'Frente al Parque Los Chocoyitos Jinotepe, CARAZO', 2, 'Abierto')
INSERT INTO Sucursal (NombreSucursal, NombreEncargado, Telefono, Dirección, No_Departamento, Estado) VALUES ('SolTerra-Larte', '', '22764534', 'Esquina opuesta a la Real Basílica Catedral de León , LEÓN', 8, 'Abierto')
INSERT INTO Sucursal (NombreSucursal, NombreEncargado, Telefono, Dirección, No_Departamento, Estado) VALUES ('SolTerra-Rites', '', '22753537', 'Playa Hermosa San Juan Del Sur, RIVAS', 15, 'Abierto')

GO
--
--
INSERT INTO Empleado(PrimerNombre, SegundoNombre, PrimerApellido, SegundoApellido, Direccion, Telefono, No_Cedula, FechaContratacion, Photo, PhotoPath, Estado) VALUES
('Erwing', 'Aarón', 'Ulloa','Silva', 'Bo.Marvin Salazar km 34 carretera Boaco', '81637193', '001-260400-1058A', CONVERT (date, GETDATE()), '','', 'Activo'),
('Elias', 'Manuel', 'Fuentes', '', 'Blvd. Jean Paul Genie, rotonda 800 mts al oeste Managua', '87674409', '001-281200-1075D', CONVERT (date, GETDATE()), '','', 'Activo'),
('Juan', 'David', 'Flores', 'Delgado', 'Pista del Mayoreo km 8.5 carretera norte, de la subasta 250mts al sur. a 5min del Aeropuerto Managua', '85398140', '500-201198-5784Y', CONVERT (date, GETDATE()), '','', 'Activo'),
('Maria', 'Melissa', 'Lopéz',' ', 'Carretera Norte, Aeropuerto Internacional Augusto Cesar Sandino, Managua 11059, Nicaragua Managua', '58497492', '877-070398-9800U', CONVERT (date, GETDATE()), '','', 'Activo'),
('Marco', 'Antonio', 'Mendéz','Lara', 'Carretera Masaya Km 8.2 Managua', '85903461', '988-050499-0954T', CONVERT (date, GETDATE()), '','', 'Activo'),
('Amanda', 'Raquel', 'Tylor',' ', 'Villa Fontana-Managua | Pizza Hut Villa Fontana 1c Oeste 1c Norte 1c Est Managua', '80348249', '980-080598-8903S', CONVERT (date, GETDATE()), '','', 'Activo'),
('José', 'Daniel', 'Treminio',' ', '15 Avenida Sureste, 500 m. al sur de Villa Fontana del Club Terraza Managua', '88547390', '908-101298-8964D', CONVERT (date, GETDATE()), '','', 'Activo'),
('Lucas', 'Matias', 'Lopéz','Ramos', 'Planes de Altamira KM. 4.5 Carretera a Masaya del Restaurante Tip Top 75 varas al Oeste, #10 Managua', '84634735', '888-090188-9746I', CONVERT (date, GETDATE()), '','', 'Activo'),
('Fernando', 'Josué', 'Montiel','', 'Residencial Bolonia del canal 2 TV, 1 cuadra lago 75 varas abajo calle 12 suroeste Managua', '87389600', '787-050900-7836D', CONVERT (date, GETDATE()), '','', 'Activo'),
('Daniela', 'Melissa', 'Peréz',' ', 'Reparto San Juan, Gimnasio Hercules 1C al sur 1/2 al este. #314 Managua', '85769077', '066-060998-7893Y', CONVERT (date, GETDATE()), '','', 'Activo'),
('John', '', 'Frusciante',' ', 'Calle 7A 35 AV S.O. Monzeñor Lezcano del nuevo banco Lafise 35 avenida 3.5 cuadras este Managua', '56734647', '009-081188-6754T', CONVERT (date, GETDATE()), '','', 'Activo'),
('David', ' ', 'Spenser',' ', 'De la rotonda El Periodista 300 metros al norte, 100 metros al este luego 50 metros al norte - Casa color beish con terraza y porton Café Managua', '87960287', '783-070489-0937Y', CONVERT (date, GETDATE()), '','', 'Activo'),
('Juan', 'Daniel', 'Baca',' ', 'De la rotonda El Periodista 300 metros al norte ', '86950787', '783-090488-0967Y', CONVERT (date, GETDATE()), '','', 'Activo')

GO
--
--
INSERT INTO Det_Empleado(Id_Sucursal, IdEmpleado, Tipo_Empleado) VALUES (1, 1, 'Encargado');
INSERT INTO Det_Empleado(Id_Sucursal, IdEmpleado, Tipo_Empleado) VALUES (1, 2, 'Chef');
INSERT INTO Det_Empleado(Id_Sucursal, IdEmpleado, Tipo_Empleado) VALUES (1, 3, 'Mesero');
INSERT INTO Det_Empleado(Id_Sucursal, IdEmpleado, Tipo_Empleado) VALUES (1, 4, 'Mesera');
INSERT INTO Det_Empleado(Id_Sucursal, IdEmpleado, Tipo_Empleado) VALUES (1, 5, 'Mesero');
INSERT INTO Det_Empleado(Id_Sucursal, IdEmpleado, Tipo_Empleado) VALUES (1, 6, 'Chef');
INSERT INTO Det_Empleado(Id_Sucursal, IdEmpleado, Tipo_Empleado) VALUES (2, 7, 'Encargado');
INSERT INTO Det_Empleado(Id_Sucursal, IdEmpleado, Tipo_Empleado) VALUES (2, 8, 'Chef');
INSERT INTO Det_Empleado(Id_Sucursal, IdEmpleado, Tipo_Empleado) VALUES (2, 9, 'Mesero');
INSERT INTO Det_Empleado(Id_Sucursal, IdEmpleado, Tipo_Empleado) VALUES (1, 10, 'Chef');
INSERT INTO Det_Empleado(Id_Sucursal, IdEmpleado, Tipo_Empleado) VALUES (2, 11, 'Mesero');
INSERT INTO Det_Empleado(Id_Sucursal, IdEmpleado, Tipo_Empleado) VALUES (2, 12, 'Mesero');
INSERT INTO Det_Empleado(Id_Sucursal, IdEmpleado, Tipo_Empleado) VALUES (3, 13, 'Encargado');

GO
--
--
INSERT INTO Categoria(NombreCategoria) VALUES ('Entradas')
INSERT INTO Categoria(NombreCategoria) VALUES ('Especiales')
INSERT INTO Categoria(NombreCategoria) VALUES ('Ejecutivos')
INSERT INTO Categoria(NombreCategoria) VALUES ('Bebidas')

GO
--
--
INSERT INTO Plato (NombrePlato, Descripcion, Id_Sucursal, No_Categoria, Precio) VALUES
('CEVICHE DE REINETA', 'La reineta contiene omega 3 que favorece la disminución de factores de riesgo cardiovascular, 4 personas pueden comer', 1, 1, 100.00),
('WRAP DE ATÚN', 'Tortillas en forma de taco con un sabroso atun y otras especias 1 persona', 1, 1, 155.04),
('MOUSSE DE ATÚN AL ENELDO', 'El atún contiene omega 3 que favorece la disminución de factores de riesgo cardiovascular, 4 porciones', 1, 1, 250.07)

GO
--
--
INSERT INTO Proveedor(NombreProveedor, Telefono, CorreoElectronico, Direccion, No_Departamento) VALUES
('CENTRAL AMERICAN FISHERIES, S.A.', ' +(505) 2263-0453', 'centralamerica.fisheries@gmail.com', 'Semáforos del Mercado Mayoreo 1c al Este.
Managua, Nicaragua.', 10),
('Molinos de Nicaragua, S.A. (MONISA)', '+(505) 2552-2291', 'monisaproductsSA@gmail.com', 'Granada, al Final de la Calle Inmaculada', 10),
('Cosecho', '+(505) 8947-9871', 'cosechonic@gmail.com', 'CALLE 98 101 A 23 BARRIO ORTIZ, APARTADO, ANTIOQUIA', 10)

GO
--
--
INSERT INTO Area (NombreArea, CantidadClientes, Estado) VALUES
('Terraza', 30, 'Libre'),
('Salón no Fumadores', 50, 'Libre'),
('Salón Fumadores', 50, 'Libre')

GO
--
--
INSERT INTO Mesa (IdArea, CantidadAsientos, IdSucursal, Estado) VALUES
(1, 2, 1, 'Habilitada'), (1, 2, 2, 'Habilitada'), (2, 2, 1, 'Habilitada'), (2, 2, 2, 'Habilitada'),
(1, 2, 1, 'Habilitada'), (1, 2, 2, 'Habilitada'), (2, 2, 1, 'Habilitada'), (2, 2, 2, 'Habilitada'),
(1, 4, 1, 'Habilitada'), (1, 4, 2, 'Habilitada'), (2, 4, 1, 'Habilitada'), (2, 4, 2, 'Habilitada'),
(1, 5, 1, 'Habilitada'), (1, 5, 2, 'Habilitada'), (2, 5, 1, 'Habilitada'), (2, 5, 2, 'Habilitada'),
(1, 2, 1, 'Habilitada'), (1, 2, 2, 'Habilitada'), (2, 2, 1, 'Habilitada'), (2, 2, 2, 'Habilitada'),
(1, 5, 1, 'Habilitada'), (1, 5, 2, 'Habilitada'), (2, 5, 1, 'Habilitada'), (2, 5, 2, 'Habilitada'),
(3, 2, 1, 'Habilitada'), (3, 2, 2, 'Habilitada'), (1, 2, 3, 'Habilitada'), (2, 2, 3, 'Habilitada'), (3, 2, 3, 'Habilitada'),
(3, 2, 1, 'Habilitada'), (3, 2, 2, 'Habilitada'), (1, 2, 3, 'Habilitada'), (2, 2, 3, 'Habilitada'), (3, 2, 3, 'Habilitada'),
(3, 4, 1, 'Habilitada'), (3, 4, 2, 'Habilitada'), (1, 4, 3, 'Habilitada'), (2, 4, 3, 'Habilitada'), (3, 4, 3, 'Habilitada'),
(3, 5, 1, 'Habilitada'), (3, 5, 2, 'Habilitada'), (1, 5, 3, 'Habilitada'), (2, 5, 3, 'Habilitada'), (3, 5, 3, 'Habilitada'),
(3, 2, 1, 'Habilitada'), (3, 2, 2, 'Habilitada'), (1, 2, 3, 'Habilitada'), (2, 2, 3, 'Habilitada'), (3, 2, 3, 'Habilitada'),
(3, 5, 1, 'Habilitada'), (3, 5, 2, 'Habilitada'), (1, 5, 3, 'Habilitada'), (2, 5, 3, 'Habilitada'), (3, 5, 3, 'Habilitada')

GO
--
--
INSERT INTO Insumo (NombreIngrediente, IdProveedro, CantidadComprada, Precio) VALUES
('Reineta', 1, 800.05, 50.06), ('Lechuga', 3, 20, 15.02),
('Pimentón Rojo', 3, 20, 10.04), ('Atún', 1, 50, 20.09),
('Pimentón Verde', 3, 20, 10.04), ('Yogurt natural', 2, 12, 23.08),
('Cebollín', 3, 20, 15.04), ('Mostaza Dijon', 2, 4, 14.04),
('Cebollas Moradas', 3, 20, 13.04), ('Queso Crema', 2, 400, 30.01),
('Aceite', 2, 10, 10.00), ('Huevo', 3, 12, 6.02),
('Limón', 3, 20, 5.02), ('Crema', 2, 3, 40.07),
('Maseca', 2, 20, 17.05), ('Tortilla', 2, 20, 5.00),
('Palta', 2, 20, 11.22)

GO
--
--
INSERT INTO DetallePlato (IdPlato, IdInsumo, MedidaIngrediente) VALUES
(1, 1, 300.00), (2, 17, 1), (3, 4, 1),
(1, 3, 1), (2, 16, 0.25), (3, 10, 0.286601),
(1, 5, 1), (2, 9, 1), (3, 5, 1),
(1, 7, 1), (2, 2, 0.33), (3, 13, 1),
(1, 9, 2), (2, 4, 0.5), (3, 14, 0.559),
(1, 11, 0.236588), (2, 6, 0.25), (3, 12, 2),
(1, 13, 2), (2, 8, 1)

GO
--
--
INSERT INTO Cliente (PrimerNombre, SegundoNombre, PrimerApellido, SegundoApellido, No_Cedula, Telefono, Fecha) VALUES
('Marcos', 'Antonio', 'Castro', '', '983-080789-0938I', '87940387', CONVERT(VARCHAR(110),DATEADD(YEAR,0,GETDATE()),107)),
('Lian', 'Daniel', 'Marenco', 'Treminio', '968-100488-0348S', '84945787', CONVERT(VARCHAR(110),DATEADD(YEAR,0,GETDATE()),107)),
('Franchesco', 'José', 'Mungia', '', '453-111188-2834M', '57840347', CONVERT(VARCHAR(110),DATEADD(YEAR,0,GETDATE()),107)),
('Abelardo', 'Fretsh', 'Luque', '', '103-080599-0328Y', '84540287', CONVERT(VARCHAR(110),DATEADD(YEAR,0,GETDATE()),107)),
('Eliseo', 'de Jesús', 'Artola', '', '763-080500-0838P', '82940767', CONVERT(VARCHAR(110),DATEADD(YEAR,0,GETDATE()),107))

GO
--
--
INSERT INTO Orden (TipoPago, Fecha, HoraAtencion) VALUES
('Tarjeta de Crédito', CONVERT (date, GETDATE()), CONVERT (time, GETDATE())),
('Tarjeta de Crédito', CONVERT (date, GETDATE()), CONVERT (time, GETDATE())),
('Tarjeta de Crédito', CONVERT (date, GETDATE()), CONVERT (time, GETDATE())),
('Contado', CONVERT (date, GETDATE()), CONVERT (time, GETDATE()))

GO
--
--
INSERT INTO DetalleOrden (IdOrden, IdCliente, IdPlato, IdMesa, IdEmpleado, Monto) VALUES
(1, 1, 1, 9, 3, ''), 
(1, 1, 2, 9, 3, ''), 
(1, 1, 2, 9, 3, ''), 
(2, 2, 3, 11, 5, ''),
(2, 2, 1, 11, 5, ''),
(2, 2, 2, 11, 5, '')

GO
--
--
INSERT INTO Menu (Nombre, Icon) VALUES
('Catálogo', 'Icon\Catálogo.png'),
('Operaciones', 'Icon\Operaciones.png'),
('Reportes', 'Icon\Reporte.png'),
('Seguridad', 'Icon\Seguridad.png'),
('Ajustes', 'Icon\Ajuste.png')

GO
--
--
INSERT INTO SubMenu (IdMenu, Nombre, NombreFormulario) VALUES
-- Catálogo 
(1, 'Clientes', 'formClientes'),
(1, 'Empleados', 'formEmpleados'),
(1, 'Platillos', 'formPlatillos'),
(1, 'Proveedor', 'formProveedores'),
(1, 'Insumos', 'formInsumos'),
(1, 'Mesas', 'formMesas'),
(1, 'Departamentos', 'formDepartamentos'),

-- Operaciones
(2, 'Ordenes', 'formOrdenes'),
(2, 'Reservas', 'formReservas'),


-- Reportes
(3, 'Factura', 'formFactura'),
(3, 'Recaudaciones', 'formRecaudación'),
(3, 'Reporte', 'formReporte'),

-- Seguridad
(4, 'Usuarios', 'formUsuarios'),
(4, 'Sucursales', 'formSucursales')

GO
--
--
INSERT INTO Rol (NombreRol) VALUES
('Administrador'),
('Recepcionista'),
('Gerente')

GO
--
--
INSERT INTO Permiso (IdRol, IdSubMenu, Estado) VALUES
(1, 1, 'Activo'), (2, 1, 'Activo'), (3, 1, 'Activo'),
(1, 2, 'Activo'), (2, 2, 'Lock'), (3, 2, 'Activo'),
(1, 3, 'Activo'), (2, 3, 'Activo'), (3, 3, 'Activo'),
(1, 4, 'Activo'), (2, 4, 'Lock'), (3, 4, 'Activo'),
(1, 5, 'Activo'), (2, 5, 'Lock'), (3, 5, 'Activo'),
(1, 6, 'Activo'), (2, 6, 'Activo'), (3, 6, 'Activo'),
(1, 7, 'Activo'), (2, 7, 'Lock'), (3, 7, 'Activo'),
(1, 8, 'Activo'), (2, 8, 'Activo'), (3, 8, 'Activo'),
(1, 9, 'Activo'), (2, 9, 'Activo'), (3, 9, 'Activo'),
(1, 10, 'Activo'), (2, 10, 'Lock'), (3, 10, 'Activo'),
(1, 11, 'Activo'), (2, 11, 'Lock'), (3, 11, 'Activo'),
(1, 12, 'Activo'), (2, 12, 'Lock'), (3, 12, 'Activo'),
(1, 13, 'Activo'), (2, 13, 'Lock'), (3, 13, 'Lock'),
(1, 14, 'Activo'), (2, 14, 'Lock'), (3, 14, 'Lock')

GO

---------------------------------- STORED PROCEDURE ------------------------------------------------------------------------------------------------------------
----------------------------------------------------------------------------------------------------------------------------------------------------------------

--REGISTRAR USUARIO
CREATE PROCEDURE "RegistrarUsuario"
@IdEmpleado "INT", @User NVARCHAR(80), @Rol "INT", @Pass NVARCHAR(150)
AS
IF EXISTS (SELECT em.IdEmpleado FROM [dbo]."Empleado" em WHERE em.IdEmpleado = @IdEmpleado AND em.Estado = 'Activo')
	BEGIN
		INSERT INTO [Usuario] VALUES
		(@IdEmpleado, @User, ENCRYPTBYPASSPHRASE(@Pass, @Pass), @Rol, 'Activo', 'Desactualizada')
	END
ELSE 
	BEGIN
		PRINT ('EMPLEADO DESHABILITADO')
	END

GO
-------------------------- REGISTROS ---------------------------------------
EXEC RegistrarUsuario 1, 'Ulloa Silva', 1, 'Sol25Terra'
EXEC RegistrarUsuario 3, 'JuanD', 2, 'Sol25Terra'

-----------------------------------------------------------------------------
GO

--VALIDAR ACCESO
CREATE PROCEDURE "Acceso"
@User NVARCHAR(80), @Pass NVARCHAR(150)
AS
IF EXISTS (SELECT Us.NombreUsuario FROM Usuario Us WHERE
CAST(DECRYPTBYPASSPHRASE(@Pass, Us.Contraseña) AS VARCHAR (100)) = @Pass AND (Us.NombreUsuario = @User) AND (Us.EstadoUsuario = 'Activo'))
	BEGIN
		SELECT 'Acceso Valido' AS Resultado,
		(SELECT Us.IdUsuario FROM Usuario Us WHERE
		CAST(DECRYPTBYPASSPHRASE(@Pass, Us.Contraseña) AS VARCHAR (100)) = @Pass AND (Us.NombreUsuario = @User) AND (Us.EstadoUsuario = 'Activo')) AS [Id Usuario],
		(SELECT Us.NombreUsuario FROM Usuario Us WHERE
		CAST(DECRYPTBYPASSPHRASE(@Pass, Us.Contraseña) AS VARCHAR (100)) = @Pass AND (Us.NombreUsuario = @User) AND (Us.EstadoUsuario = 'Activo')) AS [Usuario],
		(SELECT rl.NombreRol FROM Usuario Us INNER JOIN Rol rl ON rl.IdRol = Us.IdRol WHERE
		CAST(DECRYPTBYPASSPHRASE(@Pass, Us.Contraseña) AS VARCHAR (100)) = @Pass AND (Us.NombreUsuario = @User) AND (Us.EstadoUsuario = 'Activo')) AS [Rol],
		(SELECT Us.EstadoContraseña FROM Usuario Us WHERE
		CAST(DECRYPTBYPASSPHRASE(@Pass, Us.Contraseña) AS VARCHAR (100)) = @Pass AND (Us.NombreUsuario = @User) AND (Us.EstadoUsuario = 'Activo')) AS [EstatusPass],
		(SELECT sc.NombreSucursal FROM Usuario us INNER JOIN Empleado em ON em.IdEmpleado = us.IdEmpleado
		INNER JOIN Det_Empleado dem ON dem.IdEmpleado = em.IdEmpleado INNER JOIN Sucursal sc ON sc.Id_Sucursal = dem.Id_Sucursal WHERE
		CAST(DECRYPTBYPASSPHRASE(@Pass, Us.Contraseña) AS VARCHAR (100)) = @Pass AND (Us.NombreUsuario = @User) AND (Us.EstadoUsuario = 'Activo')) AS [Sucursal]
	END
ELSE
	BEGIN
		SELECT 'Denegado' AS Resultado
	END

GO
-------------------------- VALIDACIONES ---------------------------------------
EXEC Acceso 'Ulloa Silva', 'Sol25Terra'
EXEC Acceso 'JuanD', 'Sol25Terra'

-------------------------------------------------------------------------------
GO
--EDITAR USUARIO
CREATE PROCEDURE "Ed_Usuario"
@IdUser "INT", @IdEmpleado "INT", @User NVARCHAR(80), @Rol "INT", @Pass NVARCHAR(150)
AS
UPDATE "Usuario" SET
	IdEmpleado = @IdEmpleado,
	NombreUsuario = @User,
	IdRol = @Rol,
	Contraseña = (ENCRYPTBYPASSPHRASE(@Pass, @Pass))

WHERE IdUsuario = @IdUser

GO
-------------------------- EDITAR USUARIO ---------------------------------------


---------------------------------------------------------------------------------
GO

--CAMBIAR ESTADO USUARIO
CREATE PROCEDURE "Cb_Es_Usuario"
@IdUser "INT"
AS
DECLARE @Status VARCHAR(30)
SET @Status = (SELECT Us.EstadoUsuario FROM "Usuario" Us WHERE Us.IdUsuario = @IdUser)
IF (@Status = 'Activo')
	BEGIN
		UPDATE "Usuario" SET EstadoUsuario = 'Deshabilitado'
		WHERE IdUsuario = @IdUser
	END
ELSE
	BEGIN
		UPDATE "Usuario" SET EstadoUsuario = 'Activo'
		WHERE IdUsuario = @IdUser
	END

GO
-------------------------- CAMBIAR ESTADO USUARIO ---------------------------------------


-----------------------------------------------------------------------------------------
GO

--CAMBIAR ESTADO CONTRASEÑA USUARIO
CREATE PROCEDURE "Cb_Es_Pass_Usuario"
@IdUser "INT"
AS
DECLARE @Status VARCHAR(30)
SET @Status = (SELECT Us.EstadoContraseña FROM "Usuario" Us WHERE Us.IdUsuario = @IdUser)
IF (@Status = 'Actualizada')
	BEGIN
		UPDATE "Usuario" SET EstadoContraseña = 'Desactualizada'
		WHERE IdUsuario = @IdUser
	END
ELSE
	BEGIN
		UPDATE "Usuario" SET EstadoContraseña = 'Actualizada'
		WHERE IdUsuario = @IdUser
	END

GO
-------------------------- CAMBIAR ESTADO CONTRASEÑA USUARIO ---------------------------------------


---------------------------------------------------------------------------------------------------
GO
--VISTAS MENU XML
CREATE PROCEDURE "XML"
@IdUser "INT"
AS
BEGIN
SELECT 
	(SELECT VistaMenu.Nombre, VistaMenu.Icon,
		(SELECT  
			Sm.Nombre, Sm.NombreFormulario 
		FROM Permiso Pr INNER JOIN Rol Rl ON rl.IdRol = Pr.IdRol
		INNER JOIN SubMenu Sm ON Sm.IdSubMenu = Pr.IdSubMenu
		INNER JOIN Menu Mn ON Mn.IdMenu = Sm.IdMenu
		INNER JOIN Usuario U ON U.IdRol = Pr.IdRol AND Pr.Estado = 'Activo'
		WHERE U.IdUsuario = Us.IdUsuario AND Sm.IdMenu = VistaMenu.IdMenu
		FOR XML PATH('SubMenu'), TYPE) AS [DetalleSubMenu]	
	FROM
		(
			SELECT DISTINCT 
				Mn.* 
			FROM Permiso Pr INNER JOIN Rol Rl ON rl.IdRol = Pr.IdRol
			INNER JOIN SubMenu Sm ON Sm.IdSubMenu = Pr.IdSubMenu
			INNER JOIN Menu Mn ON Mn.IdMenu = Sm.IdMenu
			INNER JOIN Usuario U ON U.IdRol = Pr.IdRol AND Pr.Estado = 'Activo'
			WHERE U.IdUsuario = Us.IdUsuario
		)VistaMenu
	FOR XML PATH('Menu'), TYPE) AS [DetalleMenu]

FROM Usuario Us 
WHERE Us.IdUsuario = @IdUser
FOR XML PATH(''), ROOT('Permisos')
END
-------------------------- XML ---------------------------------------
EXEC XML 1
EXEC XML 2


-----------------------------------------------------------------------

GO
--VISTAS CLIENTES
CREATE PROC "MS_Clientes" AS
SELECT 
	Cl.IdCliente AS [Id Cliente],
	Cl.PrimerNombre +' '+ Cl.SegundoNombre +' '+ Cl.PrimerApellido +' '+ Cl.SegundoApellido AS [Nombre Cliente],
	Cl.No_Cedula AS [Cedula],
	Cl.Telefono AS [Telefono], 
	CONVERT(VARCHAR(110),DATEADD(YEAR,0,GETDATE()),107) AS [Fecha Registro]
FROM Cliente Cl
GO
-------------------------- VISTAS CLIENTES ---------------------------------------
EXEC "MS_Clientes"

----------------------------------------------------------------------------------
GO

-- REGISTRAR CLIENTES
CREATE PROC "RG_Clientes"
@P_Nombre NVARCHAR(20), @S_Nombre NVARCHAR(20), @P_Apellido NVARCHAR(20), @S_Apellido NVARCHAR(20),
@No_Cedula NVARCHAR(30), @No_Telefono VARCHAR(24)
AS
INSERT INTO Cliente (PrimerNombre, SegundoNombre, PrimerApellido, SegundoApellido, No_Cedula, Telefono) VALUES
(@P_Nombre, @S_Nombre, @P_Apellido, @S_Apellido, @No_Cedula, @No_Telefono)
GO
-------------------------- REGISTRAR CLIENTES ---------------------------------------
EXEC "RG_Clientes" 'Lester', 'Jose', 'Romero', 'Garcia', '002-071200-9043E', '88953542'

----------------------------------------------------------------------------------
GO

-- EDITAR CLIENTES
CREATE PROC "ED_Clientes"
@IdCliente "INT", @P_Nombre NVARCHAR(20), @S_Nombre NVARCHAR(20), @P_Apellido NVARCHAR(20), @S_Apellido NVARCHAR(20),
@No_Cedula NVARCHAR(30), @No_Telefono VARCHAR(24)
AS
UPDATE Cliente SET
PrimerNombre = @P_Nombre,
SegundoNombre = @S_Nombre,
PrimerApellido = @P_Apellido,
SegundoApellido = @S_Apellido,
No_Cedula = @No_Cedula,
Telefono = @No_Telefono
WHERE IdCliente = @IdCliente
GO
-------------------------- EDITAR CLIENTES ---------------------------------------
--EXEC "ED_Clientes" 2, 'Mario', 'Abel', 'Baca', 'Garcia', '003-071299-9025T', '84953642'

----------------------------------------------------------------------------------
GO
--VISTA CLIENTE BY ID
CREATE PROC "VS_ID_Cliente"
@IdCliente "INT"
AS
SELECT 
	Cl.PrimerNombre,
	Cl.SegundoNombre,
	Cl.PrimerApellido,
	Cl.SegundoApellido,
	Cl.No_Cedula,
	Cl.Telefono
FROM Cliente Cl
WHERE Cl.IdCliente = @IdCliente
GO
-------------------------- VISTA CLIENTE BY ID ---------------------------------------
EXEC "VS_ID_Cliente" 2

----------------------------------------------------------------------------------
GO
-- BUSCAR CLIENTE SCROLL
CREATE PROC "BS_Cliente_SC"
@Element NVARCHAR(100)
AS
SELECT
	Cl.PrimerNombre +' '+ Cl.SegundoNombre +' '+ Cl.PrimerApellido +' '+ Cl.SegundoApellido AS [Nombre Cliente],
	Cl.No_Cedula AS [Cedula],
	Cl.Telefono AS [Telefono],
	CONVERT(VARCHAR(110),DATEADD(YEAR,0,GETDATE()),107) AS [Fecha Registro]
FROM Cliente Cl WHERE
					Cl.PrimerNombre LIKE @Element + '%' OR
					Cl.SegundoNombre LIKE @Element + '%' OR
					Cl.PrimerApellido LIKE @Element + '%' OR
					Cl.SegundoApellido LIKE @Element + '%' OR
					Cl.No_Cedula LIKE @Element + '%' OR
					Cl.Telefono LIKE @Element + '%' OR
					CONVERT(VARCHAR(110),DATEADD(YEAR,0,GETDATE()),107) LIKE @Element + '%'



EXEC "BS_Cliente_SC" 'Marco'





		-- (SELECT DISTINCT
		-- 	Sl.NombreSucursal, Sl.NombreEncargado
		-- FROM Usuario Us INNER JOIN Empleado Em ON Em.IdEmpleado = Us.IdEmpleado AND Us.EstadoUsuario = 'Activo'
		-- INNER JOIN Det_Empleado Dte ON Dte.IdEmpleado = Em.IdEmpleado
		-- INNER JOIN Sucursal Sl ON Sl.Id_Sucursal = Dte.Id_Sucursal AND Sl.Estado = 'Abierto'
		-- INNER JOIN Mesa Ms ON Ms.IdSucursal = Sl.Id_Sucursal 
		-- INNER JOIN Area Ar ON Ar.IdArea = Ms.IdArea
		-- WHERE Us.IdUsuario = U.IdUsuario AND Sl.Id_Sucursal = VistaMesa.IdSucursal
		-- FOR XML PATH('SucursalMesas'), TYPE) AS [DetalleSucMesa],

		-- (SELECT DISTINCT
		-- 	Ar.NombreArea, Ar.CantidadClientes
		-- FROM Usuario Us INNER JOIN Empleado Em ON Em.IdEmpleado = Us.IdEmpleado AND Us.EstadoUsuario = 'Activo'
		-- INNER JOIN Det_Empleado Dte ON Dte.IdEmpleado = Em.IdEmpleado
		-- INNER JOIN Sucursal Sl ON Sl.Id_Sucursal = Dte.Id_Sucursal AND Sl.Estado = 'Abierto'
		-- INNER JOIN Mesa Ms ON Ms.IdSucursal = Sl.Id_Sucursal 
		-- INNER JOIN Area Ar ON Ar.IdArea = Ms.IdArea
		-- WHERE Us.IdUsuario = U.IdUsuario AND Ar.IdArea = VistaMesa.IdArea 
		-- FOR XML PATH('AreaMesas'), TYPE) AS [DetalleAreMesa]



SELECT
	Ar.NombreArea, Ar.CantidadClientes
FROM Usuario Us INNER JOIN Empleado Em ON Em.IdEmpleado = Us.IdEmpleado AND Us.EstadoUsuario = 'Activo'
INNER JOIN Det_Empleado Dte ON Dte.IdEmpleado = Em.IdEmpleado
INNER JOIN Sucursal Sl ON Sl.Id_Sucursal = Dte.Id_Sucursal AND Sl.Estado = 'Abierto'
INNER JOIN Mesa Ms ON Ms.IdSucursal = Sl.Id_Sucursal 
INNER JOIN Area Ar ON Ar.IdArea = Ms.IdArea
WHERE Us.IdUsuario = 1 


SELECT
	Sl.NombreSucursal, Sl.NombreEncargado
FROM Usuario Us INNER JOIN Empleado Em ON Em.IdEmpleado = Us.IdEmpleado AND Us.EstadoUsuario = 'Activo'
INNER JOIN Det_Empleado Dte ON Dte.IdEmpleado = Em.IdEmpleado
INNER JOIN Sucursal Sl ON Sl.Id_Sucursal = Dte.Id_Sucursal AND Sl.Estado = 'Abierto'
INNER JOIN Mesa Ms ON Ms.IdSucursal = Sl.Id_Sucursal 
INNER JOIN Area Ar ON Ar.IdArea = Ms.IdArea
WHERE Us.IdUsuario = 1 

SELECT
	Ms.*
FROM Usuario Us INNER JOIN Empleado Em ON Em.IdEmpleado = Us.IdEmpleado AND Us.EstadoUsuario = 'Activo'
INNER JOIN Det_Empleado Dte ON Dte.IdEmpleado = Em.IdEmpleado
INNER JOIN Sucursal Sl ON Sl.Id_Sucursal = Dte.Id_Sucursal AND Sl.Estado = 'Abierto'
INNER JOIN Mesa Ms ON Ms.IdSucursal = Sl.Id_Sucursal 
INNER JOIN Area Ar ON Ar.IdArea = Ms.IdArea
WHERE Us.IdUsuario = 1


GO

CREATE PROCEDURE "MesasXML"
@IdUser "INT"
AS
BEGIN
SELECT

	(SELECT VistaMesa.CantidadAsientos, VistaMesa.Estado, 
		(SELECT DISTINCT
		 	Sl.NombreSucursal
		 FROM Usuario Us INNER JOIN Empleado Em ON Em.IdEmpleado = Us.IdEmpleado AND Us.EstadoUsuario = 'Activo'
		 INNER JOIN Det_Empleado Dte ON Dte.IdEmpleado = Em.IdEmpleado
		 INNER JOIN Sucursal Sl ON Sl.Id_Sucursal = Dte.Id_Sucursal AND Sl.Estado = 'Abierto'
		 INNER JOIN Mesa Ms ON Ms.IdSucursal = Sl.Id_Sucursal 
		 INNER JOIN Area Ar ON Ar.IdArea = Ms.IdArea
		 WHERE Us.IdUsuario = U.IdUsuario AND Sl.Id_Sucursal = VistaMesa.IdSucursal
		 FOR XML PATH('SucursalMesas'), TYPE) AS [DetalleSucMesa],

		(SELECT DISTINCT
		 	Ar.NombreArea
		 FROM Usuario Us INNER JOIN Empleado Em ON Em.IdEmpleado = Us.IdEmpleado AND Us.EstadoUsuario = 'Activo'
		 INNER JOIN Det_Empleado Dte ON Dte.IdEmpleado = Em.IdEmpleado
		 INNER JOIN Sucursal Sl ON Sl.Id_Sucursal = Dte.Id_Sucursal AND Sl.Estado = 'Abierto'
		 INNER JOIN Mesa Ms ON Ms.IdSucursal = Sl.Id_Sucursal 
		 INNER JOIN Area Ar ON Ar.IdArea = Ms.IdArea
		 WHERE Us.IdUsuario = U.IdUsuario AND Ar.IdArea = VistaMesa.IdArea 
		 FOR XML PATH('AreaMesas'), TYPE) AS [DetalleAreMesa]

	FROM
	(
		SELECT
			Ms.*, Sl.NombreSucursal, Ar.NombreArea, Ar.CantidadClientes
		FROM Usuario Us INNER JOIN Empleado Em ON Em.IdEmpleado = Us.IdEmpleado AND Us.EstadoUsuario = 'Activo'
		INNER JOIN Det_Empleado Dte ON Dte.IdEmpleado = Em.IdEmpleado
		INNER JOIN Sucursal Sl ON Sl.Id_Sucursal = Dte.Id_Sucursal AND Sl.Estado = 'Abierto'
		INNER JOIN Mesa Ms ON Ms.IdSucursal = Sl.Id_Sucursal 
		INNER JOIN Area Ar ON Ar.IdArea = Ms.IdArea
		WHERE Us.IdUsuario = U.IdUsuario
	)VistaMesa
	FOR XML PATH('Mesa'), TYPE) AS [DetalleMesa]
FROM Usuario U 
WHERE U.IdUsuario = @IdUser
FOR XML PATH(''), ROOT('Usuarios')
END





















---------------------------------- LOGIN AND USERS ------------------------------------------------------------------------------------------------------------
----------------------------------------------------------------------------------------------------------------------------------------------------------------
GO
--LOGIN Y USUARIO
CREATE LOGIN adminSolTerra WITH PASSWORD = 'Sol7080Terra'
CREATE LOGIN ProgramadorDB WITH PASSWORD = 'Sol77Terra'
EXEC SP_ADDUSER adminSolTerra, adminSolTerra
EXEC SP_ADDUSER ProgramadorDB, Programmer

GO
--ROL
CREATE ROLE sistemaAdministrador

GO
GRANT EXECUTE ON SCHEMA::dbo TO sistemaAdministrador
GO
sp_addrolemember sistemaAdministrador, Programmer
select @@servername