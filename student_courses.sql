----**************************************************************************************************
---- Create three tables, one for students, one for courses and one to link them both that has a
---- composite primary key.
----**************************************************************************************************
--CREATE TABLE Students
--(
--		Id				int					PRIMARY KEY NOT NULL,						
--		[FirstName]		nvarchar(100),
--		[LastName]		nvarchar(100)
--)
-- GO

--CREATE TABLE Courses
--(
--		Id			int						PRIMARY KEY NOT NULL,
--		[Name]		nvarchar(100),
--		[Points]	int 
--)
-- GO

CREATE TABLE StudentPlans
(
		[StudentId]		int NOT NULL,
		[CourseId]		int NOT NULL,
		CONSTRAINT PK_StudentPlan			PRIMARY KEY ([StudentId], [CourseId]),
		CONSTRAINT FK_StudentId_Students	FOREIGN KEY ([StudentId])	REFERENCES Students(Id),
		CONSTRAINT FK_CourseId_Courses		FOREIGN KEY ([CourseId])	REFERENCES Courses(Id)
)
 GO

----**************************************************************************************************
---- Populate Students, Courses and StudentPlans
----**************************************************************************************************

--INSERT INTO Students (Id, [FirstName], [LastName]) VALUES(1, 'Peter'	, 'Parker'	);
--INSERT INTO Students (Id, [FirstName], [LastName]) VALUES(2, 'John'		, 'Logan'	);
--INSERT INTO Students (Id, [FirstName], [LastName]) VALUES(3, 'Hank'		, 'McCoy'	);
--INSERT INTO Students (Id, [FirstName], [LastName]) VALUES(4, 'Francis'	, 'Castle'	);
--INSERT INTO Students (Id, [FirstName], [LastName]) VALUES(5, 'Matt'		, 'Murdoc'	);
--INSERT INTO Students (Id, [FirstName], [LastName]) VALUES(6, 'Bruce'	, 'Banner'	);
--INSERT INTO Students (Id, [FirstName], [LastName]) VALUES(7, 'Anthony'	, 'Stark'	);
--INSERT INTO Students (Id, [FirstName], [LastName]) VALUES(8, 'Johnny'	, 'Storm'	);
--GO

--INSERT INTO Courses (Id, [Name], [Points]) VALUES(1,	'Heroism'		, 100	);
--INSERT INTO Courses (Id, [Name], [Points]) VALUES(2,	'Flying'		, 50	);
--INSERT INTO Courses (Id, [Name], [Points]) VALUES(3,	'Survivalism'	, 40	);
--INSERT INTO Courses (Id, [Name], [Points]) VALUES(4,	'Engineering'	, 60	);
--INSERT INTO Courses (Id, [Name], [Points]) VALUES(5,	'Chemestry'		, 50	);
--INSERT INTO Courses (Id, [Name], [Points]) VALUES(6,	'Acrobatics'	, 100	);
--INSERT INTO Courses (Id, [Name], [Points]) VALUES(7,	'Wrestling'		, 50	);
--INSERT INTO Courses (Id, [Name], [Points]) VALUES(8,	'Marksmanship'	, 100	);
--GO

--INSERT INTO StudentPlans ([StudentId], [CourseId]) VALUES(1,1);
--INSERT INTO StudentPlans ([StudentId], [CourseId]) VALUES(1,4);
--INSERT INTO StudentPlans ([StudentId], [CourseId]) VALUES(1,5);
--INSERT INTO StudentPlans ([StudentId], [CourseId]) VALUES(1,6);
			
--INSERT INTO StudentPlans ([StudentId], [CourseId]) VALUES(2,3);
--INSERT INTO StudentPlans ([StudentId], [CourseId]) VALUES(2,6);
--INSERT INTO StudentPlans ([StudentId], [CourseId]) VALUES(2,7);

--INSERT INTO StudentPlans ([StudentId], [CourseId]) VALUES(3,1);
--INSERT INTO StudentPlans ([StudentId], [CourseId]) VALUES(3,3);
--INSERT INTO StudentPlans ([StudentId], [CourseId]) VALUES(3,4);
--INSERT INTO StudentPlans ([StudentId], [CourseId]) VALUES(3,5);
--INSERT INTO StudentPlans ([StudentId], [CourseId]) VALUES(3,7);

--INSERT INTO StudentPlans ([StudentId], [CourseId]) VALUES(4,3);
--INSERT INTO StudentPlans ([StudentId], [CourseId]) VALUES(4,7);
--INSERT INTO StudentPlans ([StudentId], [CourseId]) VALUES(4,8);

--INSERT INTO StudentPlans ([StudentId], [CourseId]) VALUES(5,1);
--INSERT INTO StudentPlans ([StudentId], [CourseId]) VALUES(5,6);
--INSERT INTO StudentPlans ([StudentId], [CourseId]) VALUES(5,7);

--INSERT INTO StudentPlans ([StudentId], [CourseId]) VALUES(6,4);
--INSERT INTO StudentPlans ([StudentId], [CourseId]) VALUES(6,5);

--INSERT INTO StudentPlans ([StudentId], [CourseId]) VALUES(7,1);
--INSERT INTO StudentPlans ([StudentId], [CourseId]) VALUES(7,2);
--INSERT INTO StudentPlans ([StudentId], [CourseId]) VALUES(7,4);
--INSERT INTO StudentPlans ([StudentId], [CourseId]) VALUES(7,5);
--INSERT INTO StudentPlans ([StudentId], [CourseId]) VALUES(7,8);

--INSERT INTO StudentPlans ([StudentId], [CourseId]) VALUES(8,1);
--INSERT INTO StudentPlans ([StudentId], [CourseId]) VALUES(8,2);
--INSERT INTO StudentPlans ([StudentId], [CourseId]) VALUES(8,6);
-- GO

--SELECT * FROM Students
--SELECT * FROM Courses
--SELECT * FROM StudentPlans

--SELECT Courses.[Name]
--FROM 
--	Students
--	JOIN StudentPlans on Students.Id = StudentPlans.StudentId
--	JOIN Courses on Courses.Id = StudentPlans.CourseId
--	WHERE Students.FirstName LIKE 'Johnny' AND Students.LastName LIKE 'Storm'