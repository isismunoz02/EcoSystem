-- Paso 1: Insertar Categorías base
INSERT INTO Categorias (nombre, descripcion)
VALUES
('Tecnología Verde',
'Dispositivos de bajo consumo y soluciones IoT sustentables.'),
('Energía Renovable',
'Paneles solares, inversores y almacenamiento de energía.');

-- Paso 2: Insertar Usuario Administrador
INSERT INTO Usuarios (nombre, email, password_hash, rol)
VALUES
('Coordinador EcoSystem',
'admin@ecosystem.com',
'AQAAAAIAAYagAAAAEG...', -- Hash generado por ASP.NET Identity
'Administrador');

-- Paso 3: Insertar Producto vinculado a Categoría 1
INSERT INTO Productos
(categoria_id, nombre, descripcion, precio, stock, sku)
VALUES
(1,
'Sensor IoT Humedad v2',
'Sensor de bajo consumo para monitoreo de suelos agrícolas.',
45.99,
120,
'ECO-IOT-HUM-02');