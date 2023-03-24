-- Creacion de la BD
create database DB_Guillermo_Mejia_Lozada;
go
use DB_Guillermo_Mejia_Lozada;
go
-- Creacion de Tablas
CREATE TABLE fabricante (
  codigo INT IDENTITY(1,1) NOT NULL,
  nombre VARCHAR(100) NULL
);
go
CREATE TABLE producto(
	codigo INT IDENTITY(1,1) PRIMARY KEY,
	nombre VARCHAR (50) NOT NULL,
	precio DECIMAL(9,2) NULL,
	codigo_fabricante INT NULL, 
	FOREIGN KEY (codigo_fabricante) REFERENCES fabricante(codigo)
);
go
-- Registros
INSERT INTO fabricante (nombre) VALUES
('Asus'),
('Lenovo'),
('Hewlett-Packard'),
('Samsung'),
('Seagate'),
('Crucial'),
('Gigabyte'),
('Huawei'),
('Xiaomi');
go
INSERT INTO producto (nombre, precio, codigo_fabricante) VALUES
('Disco duro sata 3', 86.99, 5),
('RAM DDR4', 120.00, 6),
('Disco SSD 1TB', 150.99, 4),
('GeForce GTX 1015Ti', 185.00, 7);


