using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PlacesMVCpractice.Models;
using System.Data.SqlClient;

namespace PlacesMVCpractice.DAL
{
    public class VacationSqlDAL
    {
        private readonly string connectionString = @"Data Source=.\sqlexpress;Initial Catalog=vacation;Integrated Security=True";

        public Vacation GetDetail(int id)
        {
            Vacation output = new Vacation();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string SqlQuery = "SELECT * FROM places WHERE id = @id";
                    SqlCommand cmd = new SqlCommand(SqlQuery, conn);
                    cmd.Parameters.AddWithValue("@id", id);
         
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        output = CreateVacation(reader);
                    }
                    return output;
                }
            }
            catch (SqlException e)
            {
                throw e;
            }
        }

        public List<Vacation> GetList()
        {
            List<Vacation> outputList = new List<Vacation>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    String SqlQuery = "SELECT * FROM places ";
                    SqlCommand cmd = new SqlCommand(SqlQuery, conn);

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        outputList.Add(CreateVacation(reader));
                    } 
                }
            }
            catch (SqlException e)
            {
                throw e;
            }

            return outputList;

            throw new NotImplementedException();
        }

        private Vacation CreateVacation(SqlDataReader reader)
        {
            return new Vacation
            {
                Id = Convert.ToInt32(reader["id"]),
                PlaceName = Convert.ToString(reader["placeName"]),
                Description = Convert.ToString(reader["description"]),
                ImageName = Convert.ToString(reader["imageName"])
            };
        }
    }
}

//List<Vacation> GetList();
//Vacation GetDetail(int id);