Main - Feature 9

using System;
using System.Threading.Tasks;
using Microsoft.Owin;

namespace OwinSelfHost
{
    public class LoggingMiddleware : OwinMiddleware
    {
        public override async Task Invoke(IOwinContext context)
        {
            Console.WriteLine("Begin Request");
            await Next.Invoke(context);
            Console.WriteLine("End Request");
        }

        public LoggingMiddleware(OwinMiddleware next) 
            : base(next)
        {
        }
    }
}