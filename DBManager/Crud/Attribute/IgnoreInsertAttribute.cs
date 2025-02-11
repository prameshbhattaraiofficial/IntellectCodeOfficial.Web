namespace DBManager
{
    /// <summary>
    /// Optional IgnoreInsert attribute. Custom for Dapper.SimpleCRUD to exclude
    /// a property from Insert methods
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class IgnoreInsertAttribute : System.Attribute
    {
    }
}