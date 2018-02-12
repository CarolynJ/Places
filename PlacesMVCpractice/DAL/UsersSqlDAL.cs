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

        public List<User> GetAllUsers()
        {
            List<User> output = new List<User>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(SQL_GetUsers, conn);
                   
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        output.Add(CreateUser(reader));
                    }
                   
                }
            }
            catch(SqlException e)
            {
                throw e;
            }
            return output;
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