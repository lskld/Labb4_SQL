-- Creates stored procedure that shows all necessary student information from a student Id

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

-- Create stored procedure that taked a studentId and returns important information about that student



