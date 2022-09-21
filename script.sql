CREATE DATABASE dbBook4u;
USE dbBook4u;

CREATE TABLE tbLivro(
    idLivro VARCHAR NOT NULL,
    titulo VARCHAR(100) NOT NULL,
    autor VARCHAR(100) NOT NULL,
    link VARCHAR
);

CREATE TABLE tbUsuario(
    idUsuario INT PRIMARY KEY AUTO_INCREMENT,
    login VARCHAR(50) NOT NULL,
    senha VARCHAR(20) NOT NULL,
    nome VARCHAR (100) NOT NULL
);

CREATE TABLE tbLivroUsuario(
    fkUsuario INT NOT NULL,
    fkLivro VARCHAR NOT NULL,
    FOREIGN KEY (fkLivro) REFERENCES tbLivro (idLivro),
    FOREIGN KEY (fkUsuario) REFERENCES tbUsuario (idUsuario)
);
