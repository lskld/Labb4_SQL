-- This document contains all querys that show the database meet the requiredments set in Labb 4.
-- It also produces all the SQL Querys that are asked to be shown by the assigment. 
-- //Theo Lilliesköld, NET25


-- Create stored procedure that taked a studentId and returns important information about that student

CREATE PROCEDURE ShowStudentInformation
(@SID INT)
AS
BEGIN
	SELECT 
		s.FirstName AS 'First Name', 
		s.LastName AS 'Last Name', 
		s.PersonalNumber AS 'Personal Number', 
		c.ClassName AS 'Class Name'
		FROM Students s
	INNER JOIN Classes c ON c.ClassId = s.ClassId
	WHERE S.StudentId = @SID
END
GO

-- Use the stored procedure that was made above

EXEC ShowStudentInformation 51 -- <== Input any Student Id here 

-- Shows all departments and their average monthly salary

SELECT DepartmentName AS 'Department Name', AVG(Salary) AS 'Average Salary' FROM Employees 
INNER JOIN Departments ON Departments.DepartmentId = Employees.DepartmentId
GROUP BY DepartmentName 

-- Shows all departments and the total salary they pay out per month

SELECT DepartmentName AS 'Department Name', SUM(Salary) AS 'Total Salary / month' FROM Employees 
INNER JOIN Departments ON Departments.DepartmentId = Employees.DepartmentId
GROUP BY DepartmentName 

-- Show overview of all school employees, their roles, their work time and salary

SELECT e.FirstName, e.LastName, r.RoleName, e.YearsEmployed, e.Salary FROM Employees e
INNER JOIN Roles r ON r.RoleId = e.RoleId

-- Create a stored procedure to create new employees

CREATE PROCEDURE CreateNewEmployee
	@FirstName NVARCHAR(100),
	@LastName NVARCHAR(100),
	@YearsEmployed INT,
	@Salary INT,
	@DepartmentId INT,
	@RoleId INT
AS
BEGIN
	INSERT INTO Employees (FirstName, LastName, YearsEmployed, Salary, DepartmentId, RoleId)
	VALUES(@FirstName, @LastName, @YearsEmployed, @Salary, @DepartmentId, @RoleId)
END
GO

-- Using the stored procedure created above

EXEC CreateNewEmployee Alexander, Fennell, 1, 35000, 1, 2

-- Create a stored procedure to create new students. Students also contain which class they are in

CREATE PROCEDURE CreateNewStudent
	@FirstName NVARCHAR(100),
	@LastName NVARCHAR(100),
	@PersonalNumber NVARCHAR(13),
	@ClassId INT
AS
BEGIN
	INSERT INTO Students (FirstName, LastName, PersonalNumber, ClassId)
	VALUES(@FirstName, @LastName, @PersonalNumber, @ClassId)
END 
GO

-- Create a stored procedure to create new grades. 
-- Grades contain the student, grading teacher, date and course

CREATE PROCEDURE SetNewGrade
	@SetGrade NVARCHAR(1),
	@GradingDate DATE,
	@EmployeeId INT,
	@StudentId INT,
	@CourseId INT
AS
BEGIN
	INSERT INTO Grades (SetGrade, GradingDate, EmployeeId, StudentId, CourseId)
	VALUES(@SetGrade, @GradingDate, @EmployeeId, @StudentId, @CourseId)
END
GO
