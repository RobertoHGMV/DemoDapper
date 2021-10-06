using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace DemoDapper.Api.Infra.Connections
{
    public class DemoDapperContext : IDisposable
    {
        public IDbConnection Connection{ get; }

        public DemoDapperContext(IConfiguration configuration)
        {
            Connection = new NpgsqlConnection(configuration.GetConnectionString("ConnPostgres"));
            Connection.Open();
        }

        public void Dispose() => Connection?.Dispose();
    }
}