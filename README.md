# Cadastro de pessoas

CRUD de Cadastro de Pessoas com CSharp e Firebird.

# Fazer Login no APP (este login é default e não persistido):

Usuário: admin
Senha: admin

# Criar a base de dados:

CREATE DATABASE 'C:\Database\cadastro.fbd' USER 'SYSDBA' PASSWORD 'masterkey' PAGE_SIZE = 4096 DEFAULT CHARACTER SET WIN1251;
COMMIT;

# Acessar a base de dados:

CONNECT 'C:\Database\cadastro.fbd' USER SYSDBA PASSWORD masterkey;

# Criar a tabela de pessoas;

CREATE TABLE PESSOAS (ID INT NOT NULL PRIMARY KEY, NOME VARCHAR(50), ENDERECO VARCHAR(50), TELEFONE CHAR(30), EMAIL VARCHAR(100));
COMMIT;

# Inserindo uma pessoa:

INSERT INTO PESSOAS(ID,NOME,ENDERECO,TELEFONE,EMAIL) VALUES(1,'Alisson Jaques', 'Rua Projetada 2', '(37)9 9459-4578', 'alisson.jaques@dominio.com');

Obs: versão do Firebird: 2.5.1 - Link do Provedor: http://www.firebirdsql.org/en/net-provider/
