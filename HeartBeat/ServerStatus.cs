using System.Data;
using System.Data.SqlClient;

namespace HeartBeat
{
    public class ServerStatus
    {
        public int HttpStatus;
        public bool DbStatus;

        public ServerStatus(int status, bool dbStatus)
        {
            HttpStatus = status;
            DbStatus = dbStatus;
        }

        public static bool CheckDbStatus(string connectionString)
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
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
