-- 1. Creación de la Base de Datos (con soporte UTF-8 para tildes y eñes)
CREATE DATABASE IF NOT EXISTS miBD
CHARACTER SET utf8mb4
COLLATE utf8mb4_unicode_ci;

USE miBD;

-- 2. Creación de la Tabla Alumnos
CREATE TABLE IF NOT EXISTS alumnos (
    legajo INT NOT NULL,
    nombre VARCHAR(50) NOT NULL,
    apellido VARCHAR(50) NOT NULL,
    email VARCHAR(100) NOT NULL,
    carrera ENUM('Técnico Programación', 'Desarrollo Web', 'Dev Ops') NOT NULL,
    turno ENUM('mañana', 'noche') NOT NULL,
    fecha_inscripcion DATE NOT NULL,
    PRIMARY KEY (legajo)
) ENGINE=InnoDB;

-- 3. Carga de 20 Alumnos de ejemplo (Rango 30M a 48M)
INSERT INTO alumnos (legajo, nombre, apellido, email, carrera, turno, fecha_inscripcion) VALUES
(30154879, 'Carlos', 'Gómez', 'carlos.gomez@frh.utn.edu.ar', 'Técnico Programación', 'noche', '2026-02-10'),
(32451987, 'Ana', 'Rodríguez', 'ana.rodriguez@frh.utn.edu.ar', 'Desarrollo Web', 'mañana', '2026-02-11'),
(34875124, 'Mariano', 'Fernández', 'mariano.fernandez@frh.utn.edu.ar', 'Dev Ops', 'noche', '2026-02-11'),
(35124987, 'Sofía', 'López', 'sofia.lopez@frh.utn.edu.ar', 'Técnico Programación', 'mañana', '2026-02-12'),
(36984125, 'Diego', 'Martínez', 'diego.martinez@frh.utn.edu.ar', 'Desarrollo Web', 'noche', '2026-02-12'),
(37214589, 'Laura', 'García', 'laura.garcia@frh.utn.edu.ar', 'Dev Ops', 'mañana', '2026-02-13'),
(38451296, 'Esteban', 'Pérez', 'esteban.perez@frh.utn.edu.ar', 'Técnico Programación', 'noche', '2026-02-15'),
(39124578, 'Natalia', 'Díaz', 'natalia.diaz@frh.utn.edu.ar', 'Desarrollo Web', 'mañana', '2026-02-16'),
(40258963, 'Lucas', 'Sánchez', 'lucas.sanchez@frh.utn.edu.ar', 'Dev Ops', 'noche', '2026-02-16'),
(41357412, 'Florencia', 'Romero', 'florencia.romero@frh.utn.edu.ar', 'Técnico Programación', 'mañana', '2026-02-17'),
(42148963, 'Gonzalo', 'Álvarez', 'gonzalo.alvarez@frh.utn.edu.ar', 'Desarrollo Web', 'noche', '2026-02-18'),
(43521478, 'Valentina', 'Torres', 'valentina.torres@frh.utn.edu.ar', 'Dev Ops', 'mañana', '2026-02-19'),
(44125896, 'Martín', 'Ruiz', 'martin.ruiz@frh.utn.edu.ar', 'Técnico Programación', 'noche', '2026-02-19'),
(45236987, 'Camila', 'Benítez', 'camila.benitez@frh.utn.edu.ar', 'Desarrollo Web', 'mañana', '2026-02-20'),
(45874123, 'Nicolas', 'Acosta', 'nicolas.acosta@frh.utn.edu.ar', 'Dev Ops', 'noche', '2026-02-22'),
(46215487, 'Julieta', 'Silva', 'julieta.silva@frh.utn.edu.ar', 'Técnico Programación', 'mañana', '2026-02-23'),
(46985214, 'Facundo', 'Pereyra', 'facundo.pereyra@frh.utn.edu.ar', 'Desarrollo Web', 'noche', '2026-02-24'),
(47214569, 'Micaela', 'Rojas', 'micaela.rojas@frh.utn.edu.ar', 'Dev Ops', 'mañana', '2026-02-25'),
(47654128, 'Tomás', 'Marconi', 'tomas.marconi@frh.utn.edu.ar', 'Técnico Programación', 'noche', '2026-02-25'),
(48021547, 'Abril', 'Mendoza', 'abril.mendoza@frh.utn.edu.ar', 'Desarrollo Web', 'mañana', '2026-02-26');