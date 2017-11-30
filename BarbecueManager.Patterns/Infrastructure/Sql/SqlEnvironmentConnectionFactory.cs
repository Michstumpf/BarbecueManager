using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace BarbecueManager.Patterns.Infrastructure.Sql
{
    public class SqlEnvironmentConnectionFactory : IConnectionFactory
    {
        private readonly string _environmentKey;

        public SqlEnvironmentConnectionFactory(string environmentKey)
        {
            if (string.IsNullOrWhiteSpace(environmentKey))
                throw new Exception("Variavel de ambiente não informada");

            _environmentKey = environmentKey;
        }

        public IDbConnection CreateConnection()
        {
            var connectionString = Environment.GetEnvironmentVariable(_environmentKey);

            if (string.IsNullOrWhiteSpace(connectionString))
                throw new Exception($"Connection String not defined for variable {_environmentKey}.");

            return new SqlConnection(connectionString);
        }
    }
}
