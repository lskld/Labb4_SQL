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
        public static void MainMenu()
        {
            var menuChoice = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                .Title("Welcome to the Schools internal Databse. Please use the menu below to proceed.")
                .PageSize(10)
                .AddChoices(new[]
                {
                    "Check amount of teachers in each department",
                    "Show information about all students",
                    "See list of active courses",
                    "Grade a student"
                }));
            MainMenuChoices(menuChoice);
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
                        break;

                    case "Grade a student":
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
    }
}
