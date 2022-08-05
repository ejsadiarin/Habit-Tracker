﻿using System;
using Microsoft.Data.Sqlite;

namespace habit_tracker
{
    class Program
    {
        static string connectionString = @"Data Source=habit-Tracker.db";
        static void Main(string[] args)
        {

            // Create Database

            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                var tableCmd = connection.CreateCommand();

                tableCmd.CommandText =
                    @"CREATE TABLE IF NOT EXISTS drink_water (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Date TEXT,
                        Quantity INTEGER
                        )";

                tableCmd.ExecuteNonQuery();

                connection.Close();
            }
            GetUserInput();
        }
        // =========== Main Menu ============== //
        static void GetUserInput()
        {
            Console.Clear();

            bool isRunning = true;

            // selections or options //
            while (isRunning == true)
            {
                Console.WriteLine("========== MAIN MENU =========\n");
                Console.WriteLine("Welcome to Habit Tracker: Track your glasses of water!\n");

                Console.WriteLine("Please choose from the options below to interact with your records:\n");

                Console.WriteLine("Type 0 to close the application");
                Console.WriteLine("Type 1 to view all previous records");
                Console.WriteLine("Type 2 to insert/create a record");
                Console.WriteLine("Type 3 to update a record");
                Console.WriteLine("Type 4 to delete a record");
                Console.WriteLine("----------------------------------------------------------------------");

                string select = Console.ReadLine();

                switch (select.Trim())
                {
                    case "0":
                        Console.WriteLine("Thank you for using!");
                        isRunning = false;
                        break;
                    // case "1":
                    //     Retrieve();
                    //     break;
                    case "2":
                        Create();
                        break;
                    // case "3":
                    //     Update();
                    //     break;
                    // case "4":
                    //     Delete();
                    //     break;
                    default:
                        Console.WriteLine("Invalid Input! Please only type from 0 - 4."); // can create new method when return back to main menu
                        break;
                }
            }
        }


        private static void Create()
        {
            string date = GetDateInput();
            int quantity = GetNumberInput("Enter the quantity of glasses or your unit of measure in the day (no decimal allowed). Type B to return to main menu.\n");

            // Put inputs in database
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                var tableCmd = connection.CreateCommand();

                tableCmd.CommandText =
                    $"INSERT INTO drink_water(date, quantity) VALUES ({date}, {quantity})";

                tableCmd.ExecuteNonQuery();

                connection.Close();
            }
        }

        internal static string GetDateInput()
        {
            Console.WriteLine("Please enter the date in this format: mm-dd-yyyy. Type 0 to return to main menu.\n");

            string dateInput = Console.ReadLine();

            if (dateInput == "0") GetUserInput();

            return dateInput;

        }

        internal static int GetNumberInput(string message)
        {
            Console.WriteLine(message);
            // can be: (without string message parameter & argument)
            // Console.WriteLine("Enter the quantity of glasses or your unit of measure in the day. Type B to return to main menu.\n");

            string quantityInput = Console.ReadLine();

            if (quantityInput.ToUpper() == "B") GetUserInput();

            int finalQuantity = Convert.ToInt32(quantityInput);

            return finalQuantity;
        }
    }
}