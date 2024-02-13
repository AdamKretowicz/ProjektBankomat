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

        public List<string[]> Get(string columns = "*", string whereColumn = null, string whereValue = null)
        {
            try
            {
                if (database.TryConnect())
                {
                    return database.Get(this.TableName, columns, whereColumn, whereValue);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            return null;
        }

        public void Update(Dictionary<string, string> columns, string whereColumn, int whereValue)
        {
            try
            {
                if (database.TryConnect())
                {
                    database.Update(this.TableName, columns, whereColumn, whereValue);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        public List<string[]> Insert(Dictionary<string, string> columns, string returnCol = "*")
        {
            try
            {
                if (database.TryConnect())
                {
                    return database.Insert(this.TableName, columns, this.PrimaryKey, returnCol);
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
