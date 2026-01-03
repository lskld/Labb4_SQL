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
        private static bool _runProgram = true;

        /// <summary>
        /// Displays welcome message in ASCII art and prompts user a menu of choices
        /// using AnsiConsole.
        /// </summary>
        public static void MainMenu()
        {
            while(_runProgram)
            {
                Console.Clear();
                AnsiConsole.Write(
                    new FigletText("Space School Database")
                        .LeftJustified()
                        .Color(Color.Red));

                var menuChoice = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                .Title("Welcome to the Space School internal Database. Please use the menu below to proceed.")
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
        
        /// <summary>
        /// Takes in a string from the Main Menu choices and uses a switch case to 
        /// execute different methods depending on the choice. 
        /// </summary>
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
                        AnsiConsole.WriteLine("Goodbye");
                        _runProgram = false;
                        break;
                }
            }
        }
        
        /// <summary>
        /// Takes in the database context, returns a list of classes by their names and 
        /// prompts the user with a choice menu of all classes. Returns the chosen class
        /// name as a string.
        /// </summary>
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

        /// <summary>
        /// Takes in the database contex. Sorts out all Courses by their name that are 
        /// status active. Prompts the user to choose one active course, and returns that
        /// course as a Course object. 
        /// </summary>
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

        /// <summary>
        /// Takes in database context and a string holding a name of a course. Makes a list of students
        /// and checks if they belong to the chosen course. Sums those students and prompts the
        /// user to choose one of them, that is returned as a Student object. 
        /// </summary>
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
        
        /// <summary>
        /// Prompts the user a menu to choose a grade from F => A and returns the
        /// choice as a char.
        /// </summary>
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

        /// <summary>
        /// Takes in a student object, and prompts the user to confirm that they are the 
        /// teacher responsible for that student. Returns the Employee object if true or null
        /// if false. 
        /// </summary>
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
