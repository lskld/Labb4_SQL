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
        }
    }
}
