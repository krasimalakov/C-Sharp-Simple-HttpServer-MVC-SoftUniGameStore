namespace SoftUniStore
{
    using System;
    using System.Linq;
    using SimpleHttpServer;
    using SimpleMVC;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            var server = new HttpServer(1234, RouteTable.Routes);
            MvcEngine.Run(server, "SoftUniStore");
        }
    }
}