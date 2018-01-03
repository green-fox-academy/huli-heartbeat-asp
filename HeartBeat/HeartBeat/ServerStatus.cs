using System.Data;
using System.Data.SqlClient;

namespace HeartBeat
{
    public class ServerStatus
    {
        public ServerStatus(int status, bool dbStatus)
        {
            HttpStatus = status;
            DbStatus = dbStatus;
        }
        public int HttpStatus { get; }
        public bool DbStatus { get; }

        public static bool CheckDbStatus(string connectionString)
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    System.Diagnostics.Debug.WriteLine(connection.Database.Length);
                    using (var command = connection.CreateCommand())
                    {
                        command.CommandType = CommandType.Text;
                        command.CommandText = "SELECT 1";
                        command.ExecuteScalar();
                        return true;
                    }
                }
            }
            catch (System.Exception)
            {
                return false;
            }
        }
    }
}
