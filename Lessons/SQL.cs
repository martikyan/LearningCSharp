using System;
using System.Data;
using System.Data.SQLite;
using System.Linq;

namespace LearningCSharp.Lessons
{
    public static class SQL
    {
        private const string connectionString = @"connection string here";

        [Demo]
        public static void SqlReading()
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                using (SQLiteCommand command = new SQLiteCommand("SELECT * FROM persons;", connection))
                {
                    SQLiteDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        int id = reader.GetInt32(0);
                        string name = reader.GetString(1);

                        Console.WriteLine($"ID: {id}, NAME: {name}");
                    }
                }
            }
        }

        [Demo]
        public static void SqlWriting()
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                // Get last id
                int lastId = 0;
                using (SQLiteCommand command = new SQLiteCommand(connection))
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = "SELECT MAX(id) FROM persons;";

                    var reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        lastId = reader.GetInt32(0);
                    }
                }

                using (SQLiteCommand command = new SQLiteCommand(connection))
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = "INSERT into persons VALUES (@id, @name)";
                    command.Parameters.AddWithValue("@id", lastId + 1);
                    command.Parameters.AddWithValue("@name", GenerateRandomName());
                    command.ExecuteNonQuery();
                }
            }

            Console.WriteLine("Done.");
        }

        private static string GenerateRandomName()
        {
            Random random = new Random();

            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

            return new string(Enumerable.Repeat(chars, 5)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}