using System;
using System.Data;
using System.Text;

namespace Recipe.Writers.Implementation
{
    public class Writer : IWriter
    {
        public void Write(DataTable reportData)
        {
            StringBuilder reportBuilder = new StringBuilder();

            foreach (DataRow row in reportData.Rows)
            {
                int i;
                object[] array = row.ItemArray;

                for (i = 0; i < array.Length - 1; i++)
                {
                    reportBuilder.Append(array[i].ToString() + ": ");
                }

                reportBuilder.AppendLine(array[i].ToString());      
            }

            Console.WriteLine(reportBuilder.ToString());
        }
    }
}
