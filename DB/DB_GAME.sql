create database DB_GAME
use DB_GAME

CREATE TABLE regla (
    id_regla INT PRIMARY KEY IDENTITY(1,1),
    movimiento NVARCHAR(10) NOT NULL, -- 'Piedra', 'Papel' o 'Tijera'
    vence_a NVARCHAR(10) NOT NULL     -- El movimiento que pierde contra este
);
INSERT INTO regla (movimiento, vence_a)
VALUES 
('Papel', 'Piedra'),
('Piedra', 'Tijera'),
('Tijera', 'Papel');

select * from regla
CREATE TABLE jugador (
    id_jugador INT PRIMARY KEY IDENTITY(1,1),
    nombre_jugador NVARCHAR(100) NOT NULL,
    fecha_registro DATETIME DEFAULT GETDATE()
);
select * from jugador
CREATE TABLE partida (
    id_partida INT PRIMARY KEY IDENTITY(1,1),
    id_jugador1 INT NOT NULL,
    id_jugador2 INT NOT NULL,
    ganador INT NULL, -- Se llena con el id_jugador ganador o NULL si no hay ganador
    fecha_inicio DATETIME DEFAULT GETDATE(),
    fecha_fin DATETIME NULL,
    FOREIGN KEY (id_jugador1) REFERENCES jugador(id_jugador),
    FOREIGN KEY (id_jugador2) REFERENCES jugador(id_jugador)
);
CREATE TABLE ronda (
    id_ronda INT PRIMARY KEY IDENTITY(1,1),
    id_partida INT NOT NULL,
    ronda_numero INT NOT NULL, -- Número de la ronda
    movimiento_jugador1 NVARCHAR(10) NOT NULL,
    movimiento_jugador2 NVARCHAR(10) NOT NULL,
    resultado NVARCHAR(10) NOT NULL, -- 'Jugador1', 'Jugador2' o 'Empate'
    id_regla INT NULL, -- Regla que se aplicó para determinar el ganador
    FOREIGN KEY (id_partida) REFERENCES partida(id_partida),
    FOREIGN KEY (id_regla) REFERENCES regla(id_regla)
);


CREATE PROCEDURE sp_insertar_ronda (
    @id_partida INT,
    @ronda_numero INT,
    @mov_jugador1 NVARCHAR(10),
    @mov_jugador2 NVARCHAR(10)
)
AS
BEGIN
    DECLARE @resultado NVARCHAR(10);
    DECLARE @id_regla INT;

    -- Determinar el resultado de la ronda
    IF @mov_jugador1 = @mov_jugador2
    BEGIN
        SET @resultado = 'Empate';
        SET @id_regla = NULL; -- No se aplica ninguna regla en caso de empate
    END
    ELSE
    BEGIN
        SELECT TOP 1 @id_regla = id_regla
        FROM reglas
        WHERE movimiento = @mov_jugador1 AND vence_a = @mov_jugador2;

        IF @id_regla IS NOT NULL
        BEGIN
            SET @resultado = 'Jugador1';
        END
        ELSE
        BEGIN
            -- Si no coincide con la regla anterior, aplica la regla inversa
            SELECT TOP 1 @id_regla = id_regla
            FROM reglas
            WHERE movimiento = @mov_jugador2 AND vence_a = @mov_jugador1;

            SET @resultado = 'Jugador2';
        END
    END

    -- Insertar el resultado en la tabla 'rondas'
    INSERT INTO rondas (id_partida, ronda_numero, movimiento_jugador1, movimiento_jugador2, resultado, id_regla)
    VALUES (@id_partida, @ronda_numero, @mov_jugador1, @mov_jugador2, @resultado, @id_regla);
END;

SELECT 
    r.id_ronda,
    r.ronda_numero,
    r.movimiento_jugador1,
    r.movimiento_jugador2,
    r.resultado,
    reg.movimiento AS regla_movimiento,
    reg.vence_a AS regla_vence_a
FROM rondas r
LEFT JOIN reglas reg ON r.id_regla = reg.id_regla
WHERE r.id_partida = @id_partida;
