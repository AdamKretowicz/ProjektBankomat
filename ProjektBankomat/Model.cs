namespace ProjektBankomat
{
    internal class Model
    {
        Database database;
        protected virtual string Columns { get; set; } = "*";
        protected virtual string TableName { get; set; } = "";

        public Model()
        {
            database = new Database();
        }

        public List<string[]> Get()
        {
            try
            {
                if (database.TryConnect())
                {
                    return database.Get(this.Columns, this.TableName);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            return null;
        }
    }
}
