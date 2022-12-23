namespace CRUD1.Data
{
    public class Connection
    {
        private string SQLInfo = string.Empty;
        public Connection()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            SQLInfo = builder.GetSection("ConnectionStrings:SQLInfo").Value;
        }
        public string GetSQLInfo() { return SQLInfo; }
    }
}
