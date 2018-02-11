using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PlacesMVCpractice.Models;
using System.Data.SqlClient;

namespace PlacesMVCpractice.DAL
{
    public class UsersSqlDAL
    {
        private string SQL_GetUsers = "SELECT * FROM users";
        private string SQL_NewUser = "INSERT INTO users VALUES(@firstName, @preferredVacation);";
        private readonly string connectionString = @"Data Source=.\sqlexpress;Initial Catalog=vacation;Integrated Security=True";

        public User GetUser(int UserId)
        {
            User output = new User();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(SQL_GetUsers, conn);
                    cmd.Parameters.AddWithValue("@userId", UserId);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        output = CreateUser(reader);
                    }
                    return output;
                }
            }
            catch(SqlException e)
            {
                throw e;
            }
        }

        public bool SaveNewUser(User newUser)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(SQL_NewUser, conn);
                    cmd.Parameters.AddWithValue("@firstName", newUser.FirstName);
                    cmd.Parameters.AddWithValue("@preferredVacation", newUser.PreferredVacation);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    return rowsAffected > 0;
                }
            }
            catch(SqlException e)
            {
                throw e;
            }
        }

        private User CreateUser(SqlDataReader reader)
        {
            return new User
            {
                UserId = Convert.ToInt32(reader["userId"]),
                FirstName = Convert.ToString(reader["firstName"]),
                PreferredVacation = Convert.ToString(reader["preferredVacation"])
            };
        }

    }
}