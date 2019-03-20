using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static KrokusTaak.Recept;

namespace KrokusTaak.CSV
{
    public static class CSVHandler
    {

        public static void GenerateCSVFromList<T>(List<T> items, String filePath, String fileName) where T : class
        {
            var output = "";
            var delimiter = ';';
            var properties = typeof(T).GetProperties()
             .Where(n =>
             n.PropertyType == typeof(string)
             || n.PropertyType == typeof(bool)
             || n.PropertyType == typeof(char)
             || n.PropertyType == typeof(byte)
             || n.PropertyType == typeof(decimal)
             || n.PropertyType == typeof(int)
             || (n.PropertyType.IsGenericType && n.PropertyType.GetGenericTypeDefinition() == typeof(List<>))
             || n.PropertyType == typeof(ReceptTypes)
             || n.PropertyType == typeof(DateTime)
             || n.PropertyType == typeof(DateTime?));

            using (var sw = new StringWriter())
            {
                var header = properties
                .Select(n => n.Name)
                .Aggregate((a, b) => a + delimiter + b);
                sw.WriteLine(header);
                foreach (var item in items)
                {
                    Console.WriteLine(properties);
                    var row = properties
                    .Select(n =>
                    n.PropertyType == typeof(List<Ingredient>) ? string.Join(",", ((List<Ingredient>)n.GetValue(item, null)).Select(x => x.Name)) : n.GetValue(item, null))
                    .Select(n => n == null ? "null" : n.ToString()).Aggregate((a, b) => a + delimiter + b);
                    sw.WriteLine(row);
                }
                output = sw.ToString();
            }
            Console.WriteLine("\nExported " + fileName + " to : ");
            Console.WriteLine(filePath + fileName);
            File.WriteAllText(filePath + fileName, output);



        }

        public static List<T> FromCSVToList<T>(String filePath, String fileName) where T : class
        {
            return File.ReadAllLines(filePath + fileName).Skip(1).Select(v => (T)Activator.CreateInstance(typeof(T), new object[] { v })).ToList();

        }
    }
}
