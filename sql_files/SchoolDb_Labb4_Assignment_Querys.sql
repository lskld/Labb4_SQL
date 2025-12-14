USE SchoolDb

-- Shows all departments and their average monthly salary

SELECT DepartmentName AS 'Department Name', AVG(Salary) AS 'Average Salary' FROM Employees 
INNER JOIN Departments ON Departments.DepartmentId = Employees.DepartmentId
GROUP BY DepartmentName 

-- Shows all departments and the total salary they pay out per month

SELECT DepartmentName AS 'Department Name', SUM(Salary) AS 'Total Salary / month' FROM Employees 
INNER JOIN Departments ON Departments.DepartmentId = Employees.DepartmentId
GROUP BY DepartmentName 
