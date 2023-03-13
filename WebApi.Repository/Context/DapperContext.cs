using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace WebApi.Repository.Context
{
    public class DapperContext : IDapperContext
    {
         public string _connectionString { get; set; }

         private IDbConnection _connection;
        public DapperContext(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("SqlConnection");
        }
        public IDbConnection Connection
        {
            get
            {
                if(_connection == null)
                {
                    _connection = new SqlConnection(_connectionString);
                }
                return _connection;
            }
        } 
    }
}
