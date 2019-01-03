using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ExtMethods
{
    public static class EnumerableExt
    {
        /// <summary>
        /// 集合转换为DataTable
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static DataTable ToDataTable<TSource>(this IEnumerable<TSource> source) where TSource : class, new()
        {
            if (source == null)
            {
                throw new Exception("IEnumerable为null");
            }
            try
            {
                var type = typeof(TSource);
                var dt = new DataTable();
                var allProp = type.GetProperties();
                foreach (var item in allProp)
                {
                    dt.Columns.Add(new DataColumn(item.Name));
                }
                foreach (var item in source)
                {
                    if (item!=null)
                    {
                        var row = dt.NewRow();
                        foreach (var propName in allProp)
                        {
                            var val = propName.GetValue(item, null);
                            if (!val.IsDefaultValue())
                            {
                                row[propName.Name] = val;
                            }
                        }
                        dt.Rows.Add(row);
                    }
                }
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
