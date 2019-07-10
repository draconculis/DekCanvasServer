using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Grpc.Core;
using DekCanvasServer.Core;

namespace DekCanvasServer
{
    class SystemServicesImpl : SystemServices.SystemServicesBase
    {
        // Server side handler of the SayHello RPC
        public override Task<ResizeWindowResponse> ResizeWindow(ResizeWindowRequest request, ServerCallContext context)
        {
            return Task.FromResult(new ResizeWindowResponse { });
        }
    }

    class Program
    {
        const int Port = 50051;

        public static void Main(string[] args)
        {
            Server server = new Server
            {
                Services = { SystemServices.BindService(new SystemServicesImpl()) },
                Ports = { new ServerPort("localhost", Port, ServerCredentials.Insecure) }
            };
            server.Start();

            Console.WriteLine("Greeter server listening on port " + Port);
            Console.WriteLine("Press any key to stop the server...");
            Console.ReadKey();

            server.ShutdownAsync().Wait();
        }
    }

}