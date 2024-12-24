using System;
using System.Data;
using System.Data.SqlTypes;
using Microsoft.AspNetCore;
using Microsoft.Data.SqlClient;
using HealthCareDataMangement.Interfaces;
using HealthCareDataMangement.Response;
using HealthCareDataMangement.Services;
namespace HealthCareDataMangement.DBContext
{
    public class ProductRemove : IDatabaseaccess
    {

        private readonly string _connectionString;
        public ProductRemove(string connectionString)
        {
            _connectionString = connectionString;
        }


        public DataTable Removexpdata(int monthstoexpire)

        {
            var dt = new DataTable();
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("prod_deleteExpiredProducts", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@MonthsToExpire", monthstoexpire);
                        using var sda = new SqlDataAdapter(command);
                        sda.Fill(dt);

                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");

            }
            return dt;
        }
    }
}


