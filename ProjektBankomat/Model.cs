namespace ProjektBankomat
{
    internal class Model
    {
        Database database;
        //protected virtual string Columns { get; set; } = "*";
        protected virtual string TableName { get; set; } = "";
        protected virtual string PrimaryKey { get; set; } = "";

        public Model()
        {
            database = new Database();
        }

        public List<string[]> Get(string columns = "*")
        {
            try
            {
                if (database.TryConnect())
                {
                    return database.Get(this.TableName, columns);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            return null;
        }

        public void Update(Dictionary<string, string> columns, int id)
        {
            try
            {
                if (database.TryConnect())
                {
                    database.Update(this.TableName, columns, id, this.PrimaryKey);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
