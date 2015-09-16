using System;
using Microsoft.Owin.Hosting;

namespace OwinSelfHost
{
    class Program
    {
        static void Main(string[] args)
        {
            using (WebApp.Start<Startup>("http://localhost:9999"))
            {
                Console.WriteLine("Press ENTER to exit");
                Console.ReadLine();
            }
        }
    }
}
