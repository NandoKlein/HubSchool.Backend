CREATE TABLE dbo.aluno(
	[id] bigint NOT NULL IDENTITY ,
	[matricula] bigint NOT NULL,
	[name] varchar(80) NOT NULL,
	[login] varchar(80) NOT NULL,
	[senha] varchar(80) NOT NULL,
	[address] varchar(100) NOT NULL,
	[birthday] DATETIME2(6) NOT NULL,
	[email] varchar(80) NOT NULL,
	[phone] varchar(80) NOT NULL,
	[dataDaMatricula] DATETIME2(6) NOT NULL
PRIMARY KEY ([id]))

CREATE TABLE dbo.professor(
	[id] bigint NOT NULL IDENTITY ,	
	[name] varchar(80) NOT NULL,
	[login] varchar(80) NOT NULL,
	[senha] varchar(80) NOT NULL,
	[address] varchar(100) NOT NULL,
	[birthday] DATETIME2(6) NOT NULL,
	[email] varchar(80) NOT NULL,
	[phone] varchar(80) NOT NULL,
	[dataDaContratacao] DATETIME2(6) NOT NULL
PRIMARY KEY ([id]))

CREATE TABLE dbo.turma(
	[id] bigint NOT NULL IDENTITY ,	
	[name] varchar(80) NOT NULL,
	[codProfessor] bigint NOT NULL,	
	[codAluno] bigint NOT NULL  	
PRIMARY KEY ([id]))