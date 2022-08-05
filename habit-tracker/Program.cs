﻿using System;
using Microsoft.Data.Sqlite;

namespace habit_tracker
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.ReadLine();

            // Create Database
            string connectionString = @"Data Source=habit-Tracker.db";

            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                var tableCmd = connection.CreateCommand();

                tableCmd.CommandText = "";
                tableCmd.ExecuteNonQuery();

                connection.Close();
            }
        }
    }
}