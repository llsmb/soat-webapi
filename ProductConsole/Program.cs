
using Microsoft.Owin.Hosting;
using System;

namespace ProductConsole
{
    class Program
    {        
        static void Main(string[] args)
        {
            using (WebApp.Start<StartUp>("http://localhost:52914/api/products"))
            {
                Console.ReadLine();
            }
        }
    }
}
