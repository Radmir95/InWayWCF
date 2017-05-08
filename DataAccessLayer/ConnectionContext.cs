using System.Configuration;
using System.Data;
using System.Data.Common;

namespace DataAccessLayer
{
    public class ConnectionContext
    {
        private readonly DbProviderFactory _provider;
        private readonly string _connectionString;
        private readonly string _name;

        public ConnectionContext()
        {
           
            _name = "System.Data.SqlClient";
            _provider = DbProviderFactories.GetFactory("System.Data.SqlClient");
            _connectionString = "Server = tcp:inwaysql.database.windows.net; Initial Catalog = InWaySQL; Persist Security Info = False; User ID = rkhusnut; Password = Asilvertopmustbe1; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30;";
        }

        public IDbConnection Create()
        {
            var connection = _provider.CreateConnection();
            if (connection == null)
                throw new ConfigurationErrorsException(
                    $"Failed to create a connection using the connection string named '{_name}' in app/web.config.");

            connection.ConnectionString = _connectionString;
            connection.Open();
            return connection;
        }
    }
}
