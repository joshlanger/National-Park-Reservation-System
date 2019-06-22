namespace Capstone.Tests
{
    public class ParkSqlDao
    {
        private string connectionString;

        public ParkSqlDao(string connectionString)
        {
            this.connectionString = connectionString;
        }
    }
}