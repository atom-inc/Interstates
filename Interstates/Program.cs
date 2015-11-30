using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interstates
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                ICommand command = new Option1Command();
                try
                {
                    command.Execute(args[0]);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error. {0}", e.Message);
                }
            }
            else
            {
                Console.WriteLine("Enter input file path.");
            }
            Console.ReadKey();
        }
    }
}
