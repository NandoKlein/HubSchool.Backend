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
	[dataDaMatricula] DATETIME2(6) NOT NULL,
	[foto] varchar(200)
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
	[dataDaContratacao] DATETIME2(6) NOT NULL,
	[foto] varchar(200)
PRIMARY KEY ([id]))

CREATE TABLE dbo.turma(
	[id] bigint NOT NULL IDENTITY ,	
	[name] varchar(80) NOT NULL,
	[idProfessor] bigint NOT NULL			
PRIMARY KEY ([id]))

CREATE TABLE dbo.turmaAlunos(
	[idTurma] bigint NOT NULL,	
	[idAluno] bigint NOT NULL,
	PRIMARY KEY ([idTurma], [idAluno]))

	CREATE TABLE dbo.aula(
	[id] bigint NOT NULL IDENTITY ,	
	[idTurma] bigint NOT NULL,
	[idProfessor] bigint NOT NULL,	
	[capitulo]  int NOT NULL,
	[statusAula]  int NOT NULL,
	[resumo] varchar(1000) NOT NULL,	
	[dataDaAula] DATETIME2(6) NOT NULL
PRIMARY KEY ([id]))

CREATE TABLE dbo.frequencia(
	[idAula] bigint NOT NULL,	
	[idAluno] bigint NOT NULL,
	[presenca] int NOT NULL
	PRIMARY KEY ([idAula], [idAluno]))

	CREATE TABLE dbo.homework(
	[idAula] bigint NOT NULL,	
	[idAluno] bigint NOT NULL,
	[idProfessor] bigint NOT NULL,	
	[idTurma] bigint NOT NULL,
	[statusHomework] int NOT NULL,
	[nota] bigint,
	[comentario] varchar(1000),
	[arquivo] varchar(200),
	[prazoDeEntrega] DATETIME2(6)
	PRIMARY KEY ([idAula], [idAluno]))

	CREATE TABLE dbo.atendente(
	[id] bigint NOT NULL IDENTITY ,	
	[name] varchar(80) NOT NULL,
	[login] varchar(80) NOT NULL,
	[senha] varchar(80) NOT NULL,
	[address] varchar(100) NOT NULL,
	[birthday] DATETIME2(6) NOT NULL,
	[email] varchar(80) NOT NULL,
	[phone] varchar(80) NOT NULL,
	[dataDaContratacao] DATETIME2(6) NOT NULL,
	[foto] varchar(200)
PRIMARY KEY ([id]))
	                           