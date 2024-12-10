-- Crear la base de datos
CREATE DATABASE TiendaLibros;
GO

USE TiendaLibros;
GO

-- Tabla de Categorías (Géneros de libros)
CREATE TABLE Categorias (
    CategoriaId INT IDENTITY(1,1) PRIMARY KEY,
    nombre VARCHAR(50) NOT NULL,
    descripcion VARCHAR(255),
    fecha_creacion DATE,
    activo BIT,
    pais_origen VARCHAR(50)
);
GO

-- Insertar datos de ejemplo en Categorías
INSERT INTO Categorias (nombre, descripcion, fecha_creacion, activo, pais_origen)
VALUES 
    ('Ficción', 'Libros de narrativa que no se basan en hechos reales.', '2024-01-01', 1, 'Estados Unidos'),
    ('No Ficción', 'Libros basados en hechos reales y documentados.', '2024-02-01', 1, 'Reino Unido'),
    ('Misterio', 'Libros que exploran enigmas y situaciones intrigantes.', '2024-03-01', 1, 'Francia');
GO

-- Tabla de Libros
CREATE TABLE Libros (
    LibroId INT IDENTITY(1,1) PRIMARY KEY,
    titulo VARCHAR(255) NOT NULL,
    autor VARCHAR(100),
    duracion INT,  -- Páginas
    clasificacion VARCHAR(20),
    fecha_publicacion DATE,
    CategoriaId INT,
    FOREIGN KEY (CategoriaId) REFERENCES Categorias(CategoriaId)
);
GO

-- Insertar datos de ejemplo en Libros
INSERT INTO Libros (titulo, autor, duracion, clasificacion, fecha_publicacion, CategoriaId)
VALUES 
    ('El Alquimista', 'Paulo Coelho', 192, 'PG', '1988-01-01', 1),
    ('Sapiens: De Animales a Dioses', 'Yuval Noah Harari', 400, 'PG-13', '2011-01-01', 2),
    ('La Chica del Tren', 'Paula Hawkins', 320, 'R', '2015-01-01', 3);
GO

-- Tabla de Tiendas
CREATE TABLE Tiendas (
    TiendaId INT IDENTITY(1,1) PRIMARY KEY,
    nombre VARCHAR(100) NOT NULL,
    direccion VARCHAR(255),
    telefono VARCHAR(15)
);
GO

-- Insertar datos de ejemplo en Tiendas
INSERT INTO Tiendas (nombre, direccion, telefono)
VALUES 
    ('Tienda de Libros Central', 'Av. Principal 640, Lima', '012345678'),
    ('Tienda de Libros Express', 'Calle Comercio 789, Lima', '0987654321');
GO

-- Tabla de Estantes (Salas de la tienda)
CREATE TABLE Estantes (
    EstanteId INT IDENTITY(1,1) PRIMARY KEY,
    TiendaId INT,
    nombre VARCHAR(50) NOT NULL,
    capacidad INT,
    FOREIGN KEY (TiendaId) REFERENCES Tiendas(TiendaId)
);
GO

-- Insertar datos de ejemplo en Estantes
INSERT INTO Estantes (TiendaId, nombre, capacidad)
VALUES 
    (1, 'Estante A', 50),
    (1, 'Estante B', 100),
    (2, 'Estante C', 75);
GO

-- Tabla de Clientes
CREATE TABLE Clientes (
    ClienteId INT IDENTITY(1,1) PRIMARY KEY,
    nombre VARCHAR(100) NOT NULL,
    email VARCHAR(100) UNIQUE,
    telefono VARCHAR(15),
    tipo_cliente VARCHAR(50) NOT NULL  -- Ejemplo: 'VIP', 'Regular'
);
GO

-- Insertar datos de ejemplo en Clientes
INSERT INTO Clientes (nombre, email, telefono, tipo_cliente)
VALUES 
    ('Juan Pérez', 'juan.perez@email.com', '987654321', 'VIP'),
    ('Maria García', 'maria.garcia@email.com', '987654322', 'Regular'),
    ('Carlos López', 'carlos.lopez@email.com', '987654323', 'Regular');
GO

-- Consultas para ver los datos

SELECT * FROM Categorias;

SELECT * FROM Libros;
