--1 - CRIAR O BANCO
CREATE DATABASE programacao_do_zero;

-- 2 - USAR O BANCO
USE programacao_do_zero;

-- 3 - CRIAR TABELA USUÁRIO
CREATE TABLE usuario (
	id INT NOT NULL AUTO_INCREMENT,
	nome VARCHAR(50) NOT NULL,
	sobrenome VARCHAR(150) NOT NULL,
	telefone VARCHAR(15) NOT NULL,
	email VARCHAR(50) NOT NULL,
	genero VARCHAR(20) NOT NULL,
	senha VARCHAR(30) NOT NULL,
	PRIMARY KEY (id)
);
-- 4 - CRIAR TABELA ENDEREÇO
CREATE TABLE endereco (
	id INT NOT NULL AUTO_INCREMENT,
	rua VARCHAR(250) NOT NULL,
	numero VARCHAR(30) NOT NULL,
	bairro VARCHAR(150) NOT NULL,
	cidade VARCHAR(250) NOT NULL,
	complemento VARCHAR(150) NULL,
	cep VARCHAR(9) NOT NULL,
	estado VARCHAR(2) NOT NULL,
	PRIMARY KEY (id)
);

-- 5 -RELACIONAR TABELA ENDEREÇO COM TABELA USUÁRIO
ALTER TABLE endereco ADD usuario_id INT NOT NULL;

ALTER TABLE endereco ADD CONSTRAINT FK_usuario FOREIGN KEY (usuario_id) REFERENCES usuario(id);

-- 6 - INSERIR USUÁRIOS 
INSERT INTO usuario(
nome, sobrenome, telefone, email, genero, senha) 
VALUES('Renato', 'Gava' ,'(11) 99532-4543', 'renatogava2@live.com', 'Masculino', '123')


INSERT INTO usuario(
nome, sobrenome, telefone, email, genero, senha)
VALUES('Gustavo', 'Agusto', '11 92531-2343', 'gaugustavo2@live.com', 'Masculino', 'teste342')

-- 7 - SELECIONAR TODOS OS USUÁRIOS
SELECT * FROM usuario;

-- 8 - SELECIONAR UM USUÁRIO ESPECÍFICO
SELECT * FROM usuario WHERE email = 'renatogava2@live.com';

-- 9 - ALTERAR USUÁRIO
UPDATE usuario SET email = 'gustavoaugusto@hotmail.com' WHERE id = 3;

-- 10 - EXCLUIR USUÁRIO
DELETE FROM usuario WHERE id = 2;
