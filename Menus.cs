using Labb4_SQL.Models;
using Microsoft.EntityFrameworkCore;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Text;

namespace Labb4_SQL
{
    public class Menus
    {
        static bool runProgram = true;
        public static void MainMenu()
        {
            while(runProgram)
            {
                Console.Clear();
                var menuChoice = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                .Title("Welcome to the Schools internal Databse. Please use the menu below to proceed.")
                .PageSize(10)
                .AddChoices(new[]
                {
                    "Check amount of teachers in each department",
                    "Show information about all students",
                    "See list of active courses",
                    "Grade a student",
                    "Exit program"
                }));
                MainMenuChoices(menuChoice);
            }      
        }
        public static void MainMenuChoices(string choiceString)
        {
            using (var context = new SchoolDbContext())
            {
                switch (choiceString)
                {
                    case "Check amount of teachers in each department":
                        HelperMethods.ShowTeachersInDepartment(context);
                        break;

                    case "Show information about all students":
                        var classChoice = ChooseClass(context);
                        HelperMethods.ShowStudentInformation(context, classChoice);
                        break;

                    case "See list of active courses":
                        HelperMethods.ShowActiveCourses(context);
                        break;

                    case "Grade a student":
                        var course = ChooseCourse(context);
                        var student = ChooseStudentByCourse(context, course);
                        var grade = ChooseGrade();
                        var gradingTeacher = ConfirmCorrectTeacher(student);
                        HelperMethods.GradeStudent(context, course, student, grade, gradingTeacher);
                        break;
                    case "Exit program":
                        Console.WriteLine("Goodbye");
                        runProgram = false;
                        break;
                }
            }
        }
        public static string ChooseClass(SchoolDbContext context)
        {
            var classes = context.Classes
                .Select(c => c.ClassName)
                .ToList();

            var classChoice = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                .Title("Please choose one of the following classes:")
                .PageSize(10)
                .AddChoices(classes));

            return classChoice;
        }

        public static Course? ChooseCourse(SchoolDbContext context)
        {
            var activeCourses = context.Courses
                .Where(c => c.IsActive)
                .ToList();

            var activeCourseNames = activeCourses
                .Select(c => c.CourseName)
                .ToList();

            var courseChoice = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                .Title("Please choose one of the following active courses to grade")
                .PageSize(20)
                .AddChoices(activeCourseNames));

            Course? selectedCourse = activeCourses
                .FirstOrDefault(c => c.CourseName == courseChoice);

            return selectedCourse;
        }

        public static Student? ChooseStudentByCourse(SchoolDbContext context, Course chosenCourse)
        {
            var students = context.Students
                .Include(s => s.Class)
                    .ThenInclude(c => c.Courses)
                .Include(s => s.Class)
                    .ThenInclude(c => c.ResponsibleTeacher)
                .ToList();

            var studentsInClass = new List<Student>();

            foreach (var student in students)
            {
                foreach (var course in student.Class.Courses)
                {
                    if (course.CourseName == chosenCourse.CourseName)
                    {
                        studentsInClass.Add(student);
                    }
                }
            }

            var studentsInClassNames = studentsInClass
                .Select(s => $"{s.FirstName} {s.LastName}")
                .ToList();

            var studentChoice = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                .Title("Please choose one of the following students to grade")
                .PageSize(10)
                .AddChoices(studentsInClassNames));

            var selectedStudent = studentsInClass
                .FirstOrDefault(s => $"{s.FirstName} {s.LastName}" == studentChoice);

            return selectedStudent;
        }
        public static char ChooseGrade()
        {
            var gradeChoice = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                .Title("What grade will the student recieve?")
                .PageSize(10)
                .AddChoices(new[] { "F", "E", "D", "C", "B", "A" }));

            var gradeChoiceChar = Convert.ToChar(gradeChoice);

            return gradeChoiceChar;
        }

        public static Employee? ConfirmCorrectTeacher(Student student)
        {
            var teacher = student.Class.ResponsibleTeacher;

            var teacherCheck = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                .Title($"Please confirm you are Professor. {teacher.LastName},\n" +
                $"who is responsible for grading student {student} in class {student.Class.ClassName}")
                .PageSize(10)
                .AddChoices(new[] {"YES" , "NO"}));

            if (teacherCheck.Equals("YES"))
            {
                return teacher;
            }
            else
            {
                return null;
            }
        }
    }
}
