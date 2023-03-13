using System.Data;

namespace WebApi.Repository.Context
{
    public interface IDapperContext
    {
        public string _connectionString { get; set; }
        public IDbConnection Connection { get; }
    }
}