CREATE DATABASE dbBook4u;
USE dbBook4u;

CREATE TABLE tbLivro(
	idLivro INT PRIMARY KEY AUTO_INCREMENT,
    detalhes VARCHAR(150) NOT NULL,
    numPag INT NOT NULL,
    titulo VARCHAR(100) NOT NULL,
    autor VARCHAR(100) NOT NULL
);

CREATE TABLE tbUsuario(
	idUsuario INT PRIMARY KEY AUTO_INCREMENT,
    login VARCHAR(50) NOT NULL,
    senha VARCHAR(20) NOT NULL,
    nome VARCHAR (100) NOT NULL
);

CREATE TABLE tbLivroUsuario(
	idLivro INT NOT NULL,
    idUsuario INT NOT NULL,
    CONSTRAINT fkLivro FOREIGN KEY (idLivro) REFERENCES tbLivro (idLivro),
    CONSTRAINT fkUsuario FOREIGN KEY (idUsuario) REFERENCES tbUsuario (idUsuario)
);
