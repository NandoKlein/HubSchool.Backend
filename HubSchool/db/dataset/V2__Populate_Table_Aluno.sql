INSERT [dbo].[aluno] ([matricula], [name], [login], [senha], [address], [birthday], [email], [phone], [dataDaMatricula], [foto]) VALUES
(1234, 'Frank', 'Frank@gmail.com', '1234', 'bc', '2020-02-02T00:00:00.0000000' , 'Frank@gmail.com', '4765983265', '2026-03-05T15:33:11.6296560' , '/uploads/alunos/1.PNG'),
(4567, 'Frida', 'Frida@gmail.com', '1234', 'bc', '2021-05-13T00:00:00.0000000' , 'Frida@gmail.com', '4798653214', '2026-03-10T09:06:39.1661370' , '/uploads/alunos/2.PNG'),
(4561, 'Jaque', 'jaque@gmail.com', '1234', 'bc', '1987-10-12T00:00:00.0000000' , 'jaque@gmail.com', '4798756412', '2026-03-10T09:16:12.7472160' , '/uploads/alunos/3.PNG'),
(99945, 'Keny', 'keny@gmail.com', '1234', 'South Park', '1998-06-04T00:00:00.0000000' , 'keny@gmail.com', '47659832145', '2026-03-08T09:31:12.8761830' , '/uploads/alunos/4.PNG'),
(696969, 'Cartman', 'Cartman@gmail.com', '1234', 'South Park', '1998-09-08T00:00:00.0000000' , 'Cartman@gmail.com', '4798653214', '2026-03-08T09:31:57.3602290' , '/uploads/alunos/5.PNG'),
(659874, 'Kyle', 'Kyle@gmail.com', '1234', 'South Park', '1999-02-10T00:00:00.0000000' , 'Kyle@gmail.com', '4798653214', '2026-03-08T09:33:12.6204220' , '/uploads/alunos/6.PNG'),
(456987, 'Stam', 'stam@gmail.com', '1234', 'South Park', '1999-06-17T00:00:00.0000000' , 'stam@gmail.com', '47986532145', '2026-03-08T09:33:58.1086170' , '/uploads/alunos/7.PNG'),
(654123, 'Buthers', 'buthers@gmail.com', '1234', 'South Park', '2000-11-01T00:00:00.0000000' , 'buthers@gmail.com', '47965478521', '2026-03-08T09:35:33.5758440' , '/uploads/alunos/8.PNG'),
(987654, 'Tolkien', 'tolkien@gmail.com', '1234', 'South Park', '1997-09-04T00:00:00.0000000' , 'tolkien@gmail.com', '47659832145', '2026-03-10T09:03:37.9703910' , '/uploads/alunos/9.PNG'),
(654789, 'Tweek', 'tweek@gmail.com', '1234', 'South Park', '2000-04-16T00:00:00.0000000' , 'tweek@gmail.com', '47698546536', '2026-03-10T08:55:57.0423270' , '/uploads/alunos/10.PNG'),
(369852, 'Craig', 'craig@gmail.com', '1234', 'South Park', '2000-10-13T00:00:00.0000000' , 'craig@gmail.com', '47991090782', '2026-03-10T08:57:46.4402340' , '/uploads/alunos/11.PNG'),
(147852, 'Jimmy', 'jimmy@gmail.com', '1234', 'South Park', '2000-08-07T00:00:00.0000000' , 'jimmy@gmail.com', '4798653214', '2026-03-10T08:59:27.1456150' , '/uploads/alunos/12.PNG'),
(236598, 'Wendy', 'wendy@gmail.com', '1234', 'South Park', '2000-04-06T00:00:00.0000000' , 'wendy@gmail.com', '456578965', '2026-03-10T09:01:49.9974410' , '/uploads/alunos/13.PNG'),
(123987, 'Bebe', 'bebe@gmail.com', '1234', 'South Park', '2000-03-18T00:00:00.0000000' , 'bebe@gmail.com', '47965321458', '2026-03-10T09:03:03.4946620' , '/uploads/alunos/14.PNG');

INSERT [dbo].[professor] ([name], [login], [senha], [address], [birthday], [email], [phone], [dataDaContratacao], [foto]) VALUES 
('Mr. Mackey', 'mackey@gmail.com', '1234', 'South Park', '1980-05-05T00:00:00.0000000', 'mackey@gmail.com', '4796541236', '2026-03-08T09:37:53.4096480', '/uploads/professores/1.PNG'),
('Sr. Garrisos', 'garrison@gmail.com', '1234', 'South Park', '1980-10-28T00:00:00.0000000', 'garrison@gmail.com', '47986541235', '2026-03-08T09:40:21.3455730', '/uploads/professores/2.PNG'),
('Pc', 'pc@gmail.com', '1234', 'South Park', '1980-01-14T00:00:00.0000000', 'pc@gmail.com', '47986541235', '2026-03-10T09:40:21.3455730', '/uploads/professores/3.PNG'),
('Srta. Claridge', 'claridge@gmail.com', '1234', 'South Park', '1980-01-14T00:00:00.0000000', 'claridge@gmail.com', '47986541235', '2026-03-10T09:40:21.3455730', '/uploads/professores/4.PNG');

INSERT [dbo].[aula] ([idTurma], [idProfessor], [capitulo], [statusAula], [resumo], [dataDaAula]) VALUES
(1, 0, 1, 0, 'Neste capítulo, iremos ver as primeiras palavras e expressões em inglês. Vamos aprender cumprimentos básicos, como se apresentar e fazer perguntas simples, iniciando os primeiros diálogos na língua inglesa.', '2026-03-01T00:00:00.0000000'),
(1, 0, 2, 0, 'Neste capítulo, iremos aprender a falar informações simples, como idade, país e nacionalidade. Também veremos números básicos e praticaremos perguntas e respostas curtas em inglês.', '2026-03-02T00:00:00.0000000'),
(1, 0, 3, 0, 'Neste capítulo, iremos aprender palavras relacionadas a objetos comuns do dia a dia, especialmente os usados em sala de aula. Também veremos como identificar e perguntar sobre objetos usando frases simples em inglês.', '2026-03-03T00:00:00.0000000'),
(1, 0, 4, 0, 'Neste capítulo, iremos aprender as cores em inglês e como usá-las para descrever objetos de forma simples.', '2026-03-04T00:00:00.0000000'),
(1, 0, 5, 0, 'Neste capítulo, iremos aprender mais números e como falar quantidades básicas em inglês.', '2026-03-05T00:00:00.0000000'),
(2, 0, 1, 0, 'Neste capítulo, iremos ver as primeiras palavras e expressões em inglês. Vamos aprender cumprimentos básicos, como se apresentar e fazer perguntas simples, iniciando os primeiros diálogos na língua inglesa.', '2026-03-08T00:00:00.0000000'),
(2, 0, 2, 0, 'Neste capítulo, iremos aprender a falar informações simples, como idade, país e nacionalidade. Também veremos números básicos e praticaremos perguntas e respostas curtas em inglês.', '2026-03-09T00:00:00.0000000'),
(2, 0, 3, 0, 'Neste capítulo, iremos aprender palavras relacionadas a objetos comuns do dia a dia, especialmente os usados em sala de aula. Também veremos como identificar e perguntar sobre objetos usando frases simples em inglês.', '2026-03-10T00:00:00.0000000'),
(2, 0, 4, 0, 'Neste capítulo, iremos aprender as cores em inglês e como usá-las para descrever objetos de forma simples.', '2026-03-11T00:00:00.0000000'),
(3, 0, 1, 0, 'Neste capítulo, iremos aprender a usar o Simple Present para falar sobre rotinas, hábitos e fatos do dia a dia.', '2026-03-16T00:00:00.0000000'),
(3, 0, 2, 0, 'Neste capítulo, iremos aprender a usar o Simple Present para falar sobre rotinas, hábitos e fatos do dia a dia.', '2026-03-17T00:00:00.0000000'),
(3, 0, 3, 0, 'Neste capítulo, iremos aprender a descrever pessoas, falando sobre aparência, personalidade e características básicas.', '2026-03-18T00:00:00.0000000');

INSERT [dbo].[frequencia] ([idAula], [idAluno], [presenca]) VALUES
(1, 4, 0),
(1, 5, 0),
(1, 6, 0),
(1, 7, 0),
(1, 8, 0),
(2, 4, 0),
(2, 5, 0),
(2, 6, 0),
(2, 7, 0),
(2, 8, 0),
(3, 4, 0),
(3, 5, 0),
(3, 6, 0),
(3, 7, 0),
(3, 8, 0),
(4, 4, 0),
(4, 5, 0),
(4, 6, 0),
(4, 7, 0),
(4, 8, 0),
(5, 4, 0),
(5, 5, 0),
(5, 6, 0),
(5, 7, 0),
(5, 8, 0),
(6, 9,  0),
(6, 10, 0),
(6, 11, 0),
(6, 12, 0),
(7, 9,  0),
(7, 10, 0),
(7, 11, 0),
(7, 12, 0),
(8, 9,  0),
(8, 10, 0),
(8, 11, 0),
(8, 12, 0),
(9, 9,  0),
(9, 10, 0),
(9, 11, 0),
(9, 12, 0),
(10, 13, 0),
(10, 14, 0),
(11, 13, 0),
(11, 14, 0),
(12, 13, 0),
(12, 14, 0);

INSERT [dbo].[turma] ([name], [idProfessor]) VALUES
('Book 1',   2),
('Book 1 - B', 2),
('Book 2',   2);

INSERT [dbo].[turmaAlunos] ([idTurma], [idAluno]) VALUES
(1, 4),
(1, 5),
(1, 6),
(1, 7),
(1, 8),
(2, 9),
(2, 10),
(2, 11),
(2, 12),
(3, 13),
(3, 14);

INSERT [dbo].[atendente] ([name], [login], [senha], [address], [birthday], [email], [phone], [dataDaContratacao], [foto]) VALUES 
('Toalinha', 'toalinha@gmail.com', '1234', 'South Park', '1980-05-05T00:00:00.0000000', 'toalinha@gmail.com', '4796541236', '2026-03-08T09:37:53.4096480', '/uploads/atendentes/1.PNG');

