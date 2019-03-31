using GenericCSVExport.Core.Export;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GenericCSVExport.Common.Export
{
    public class CSVExport : ICSVExport
    {
        /// <summary>
        /// Запись содержимого потока  MemoryStream в массив байтов
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="objectlist">Содержимое потока  MemoryStream </param>
        /// <param name="columnNames">Заголовок колонок(если их не указывать, то имена колонок будут имена свойства класса). </param>
        /// <returns></returns>
        public byte[] WriteCSV<T>(IEnumerable<T> objectlist, IEnumerable<string> columnNames = null)
        {
            byte[] bytes = null;
            using (var memStream = new MemoryStream())
            using (var sw = new StreamWriter(memStream, Encoding.GetEncoding("Windows-1251")))
            {
                sw.WriteLine("sep=,"); // В CSV файле запятая служит разделителем между колонками. Для того, чтобы Excel понял, что запятая - это новая колонка                
                foreach (var line in ToCsv(objectlist, columnNames))
                {
                    sw.WriteLine(line);
                }
                sw.Flush();
                memStream.Seek(0, SeekOrigin.Begin);
                bytes = memStream.ToArray();
            }
            return bytes;
        }


        /// <summary>
        /// Превращение IEnumerable<T> в формат данных CSV
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="objectlist">Данные для превращения в CSV формат</param>
        /// <param name="columnNames">Заголовок для колонок</param>
        /// <param name="separator">Разделитель для колонок. У нас будет знак разделителя ","</param>
        /// <param name="header">Является ли заголовком?</param>
        /// <returns></returns>
        private IEnumerable<string> ToCsv<T>(IEnumerable<T> objectlist, IEnumerable<string> columnNames = null, string separator = ",", bool header = true)
        {
            FieldInfo[] fields = typeof(T).GetFields();
            PropertyInfo[] properties = typeof(T).GetProperties();

            if (header)
            {
                if (columnNames != null)
                {
                    yield return string.Join(separator, fields
                        .Select(f =>
                            $"\"{f.Name.Replace("\"", "\"\"")}\"" // Вставляем слово в кавычки, чтобы можно было использовать запятую в csv не как разделитель
                        )
                        .Concat(columnNames
                        .Select(p => p))
                        .ToArray());
                }
                else
                {
                    yield return string.Join(separator, fields
                        .Select(f =>
                            $"\"{f.Name.Replace("\"", "\"\"")}\""  // Вставляем слово в кавычки, чтобы можно было использовать запятую в csv не как разделитель
                        )
                        .Concat(properties
                        .Select(p => p.Name))
                        .ToArray());
                }
            }
            foreach (var o in objectlist)
            {
                yield return string.Join(separator,
                    fields
                    .Select(f =>
                        $"\"{(f.GetValue(o) ?? "").ToString().Replace("\"", "\"\"")}\""
                        )
                    .Concat(properties
                        .Select(p =>
                            $"\"{(p.GetValue(o, null) ?? "").ToString().Replace("\"", "\"\"")}\""))
                    .ToArray());
            }
        }
    }
}
