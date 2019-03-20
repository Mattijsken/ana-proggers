using KrokusTaak.CSV;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KrokusTaak
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(@"-----------------------------------------------------------
|                                                         |
|                    De bit en de byte                    |
|                                                         |
-----------------------------------------------------------

Type 'help' om alle commando's te weergeven.

");
            AppCommands commands = new AppCommands();
            bool doExit = false;
            string input;
            do
            {
                Console.Write(">");
                input = Console.ReadLine();
                doExit = commands.Execute(input);
                Console.WriteLine();
            }
            while (!doExit);
        }
    }
}
