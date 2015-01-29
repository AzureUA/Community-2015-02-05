namespace Common
{
    public abstract class BaseTransmitter
    {
        protected readonly string _connectionString;
        protected BaseTransmitter(string connectionString)
        {
            _connectionString = connectionString;
        }
    }
}