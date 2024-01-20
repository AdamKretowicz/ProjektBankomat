namespace ProjektBankomat
{
    internal class Bank : Model
    {
        protected override string Columns { get; set; } = "*";
        protected override string TableName { get; set; } = "Banki";
    }
}
