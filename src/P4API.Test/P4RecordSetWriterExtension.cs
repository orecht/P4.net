using System;
using System.Collections.Generic;
using System.Linq;

namespace P4API.Test
{
    /// <summary>
    /// Extension methods for P4RecordSet logging
    /// </summary>
    public static class P4RecordSetWriterExtension
    {
        /// <summary>
        /// Extension method to dumop a P4RexcordSet to console. 
        /// </summary>
        /// <param name="recordSet"></param>
        public static void DumpToConsole(this P4API.P4RecordSet recordSet)
        {
            if (recordSet != null && recordSet.Records != null && recordSet.Records.Count() > 0)
            {
                foreach (var rec in recordSet.Records)
                {
                    foreach (var field in rec.Fields.Keys)
                    {
                        Console.WriteLine("{0}: {1}", field, rec[field]);
                    }
                    foreach (var field in rec.ArrayFields.Keys)
                    {
                        Console.WriteLine("{0}:\n{1}", field, rec[field].Cast<string>().Select(s => "   " + s));
                    }
                }
            }
            else
                Console.WriteLine("P4recodSet is null or empty");
        }
    }
}
