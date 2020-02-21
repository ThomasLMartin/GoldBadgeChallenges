using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_ClaimConsole
{
    class ClaimsConsole : IClaims
    {
        static void Main(string[] args)
        {
            ClaimsConsole console = new ClaimsConsole();
            ClaimUI ui = new ClaimUI(console);
            ui.Run();
        }
        public void Clear()
        {
            Console.Clear();
        }

        public ConsoleKeyInfo ReadKey()
        {
            return Console.ReadKey();
        }

        public string ReadLine()
        {
            return Console.ReadLine();
        }

        public void WriteLine(string str)
        {
            Console.WriteLine(str);
        }

        public void WriteLine(object obj)
        {
            Console.WriteLine(obj);
        }

        public void Wrtie(string str)
        {
            Console.Write(str);
        }
    }
}

