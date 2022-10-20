using Dapper;
using Logic.DTOs.User;
using Logic.Queries.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Queries
{
    public class UserQuery : IUserQuery
    {
        string _connectionString;
        public UserQuery(IConfiguration configuration)
        {
            _connectionString = configuration["ConnectionStrings:DefaultConnection"];
        }

        public List<GetUserResponse> GetAll()
        {
            string querry = $@"SELECT ""Id"", ""Name"", ""Midname"", ""Surname"", ""Email"", ""PhoneNumber"" FROM ""Users""
                                ORDER BY ""DateCreate"" ASC";

            using (IDbConnection db = new Npgsql.NpgsqlConnection(_connectionString))
            {
                return db.Query<GetUserResponse>(querry).ToList();
            }
        }
    }
}
