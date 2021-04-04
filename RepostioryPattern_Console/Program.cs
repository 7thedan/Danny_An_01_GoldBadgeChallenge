using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepostioryPattern_Console
{
    //single responsibility
    class Program
    {
        static void Main(string[] args)
        {
            ProgramUI program = new ProgramUI();
            program.Run();
        }
    }
}
