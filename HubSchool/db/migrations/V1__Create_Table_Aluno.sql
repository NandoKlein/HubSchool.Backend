CREATE TABLE dbo.aluno(
	[id] bigint NOT NULL IDENTITY ,
	[matricula] bigint NOT NULL,
	[name] varchar(80) NOT NULL,
	[address] varchar(100) NOT NULL,
	[birthday] DATETIME2(6) NOT NULL,
	[email] varchar(80) NOT NULL,
	[phone] varchar(80) NOT NULL,
	[dataDaMatricula] DATETIME2(6) NOT NULL
PRIMARY KEY ([id]))