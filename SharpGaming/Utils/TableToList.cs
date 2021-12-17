using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace SharpGaming.Utils
{
    class TableToList
    {
        public static List<string> ConvertTableToList(Table table)
        {
            var list = new List<string>();
            foreach (var row in table.Rows)
            {
                list.Add(row[0]);
            }
            return list;
        }
    }
}
