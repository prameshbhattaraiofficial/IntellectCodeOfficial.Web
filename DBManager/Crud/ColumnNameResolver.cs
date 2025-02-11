using System.Reflection;
namespace DBManager
{
    /// <summary>
    /// </summary>
    public sealed class ColumnNameResolver : IColumnNameResolver
    {
        private ISQLTemplate SqlTemplate { get; set; }
        private QueryBuilder Builder { get; }

        public ColumnNameResolver(ISQLTemplate template, QueryBuilder qbuilder)
        {
            SqlTemplate = template;
            Builder = qbuilder;
        }
        public string ResolveColumnName(PropertyInfo propertyInfo)
        {
            var columnName = Builder.Encapsulate(propertyInfo.Name);

            var columnattr = propertyInfo.GetCustomAttributes(true).SingleOrDefault(attr => attr.GetType().Name == typeof(ColumnAttribute).Name) as dynamic;
            if (columnattr != null)
            {
                columnName = Builder.Encapsulate(columnattr.Name);
            }
            return columnName;
        }
    }
}