using System;
using P4API;

namespace P4API.Test
{
    /// <summary>
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// </summary>
        static Program()
        {
            P4API.Bootstrapper.Initialize();
        }

        /// <summary>
        /// </summary>
        public static int Main(string[] args)
        {
            using (var c = new P4Connection())
            {
                try
                {
                    c.Connect();
                    P4RecordSet ret = c.Run("reconcile", "//database/trunk/logging/...");
                    ret.DumpToConsole();
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(ex.GetType().FullName);
                    Console.Write(": ");
                    Console.WriteLine(ex.Message);
                    Console.WriteLine(ex.StackTrace);
                    Console.ResetColor();
                }
                finally
                {
                    Console.ReadKey();
                }
            }
            return 0;
        }

    }

}
