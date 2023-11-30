using CaTestJz.Application.Common.Interfaces.Persistence;
using CaTestJz.Application.Services.Authentication;
using CaTestJz.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CaTestJz.Infrastructure.Persistence
{
    public class UserRepository : IUserRepository
    {
        public void Add(User user)
        {
            throw new NotImplementedException();
        }

        public async Task<AuthenticationResult> GetUser(string email, string password)
        {
            var result = new AuthenticationResult();
            try
            {
                string directory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                string ConnectionString = $"Server=(localdb)\\mssqllocaldb;AttachDbFileName={directory}\\Database\\CaTestJzDatabase.mdf;Trusted_Connection=True;MultipleActiveResultSets=true";
                string queryString = "SELECT Id, FirstName, LastName FROM [dbo].[User] where Email = @emailParam";
                

                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    SqlCommand command = new SqlCommand(queryString, connection);
                    command.Parameters.AddWithValue("@emailParam", email);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    User user = new();
                    while (await reader.ReadAsync())
                    {
                        user.Id = (int)reader[0];
                        user.FirstName = reader[1].ToString().Trim();
                        user.LastName = reader[2].ToString().Trim();
                        user.Email = email;
                    }
                    reader.Close();

                    result.User = user;
                    result.AllowLogin = true;
                    result.AuthMessage = "Login successfull";
                    return result;
                }
            }
            catch (Exception ex)
            {
                
                result.AuthMessage = $"An error occurred while getting user: {email} : {ex.Message}";
            }
            return result;
        }
    }
}
