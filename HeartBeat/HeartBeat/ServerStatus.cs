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
    }
}
