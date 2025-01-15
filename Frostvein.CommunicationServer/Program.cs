using Grpc.Core;

namespace Frostvein.CommunicationServer
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            const int Port = 5000;

            var server = new Server
            {
                Services = { CommunicationService.BindService(new CommunicationServiceImpl()) },
                Ports = { new ServerPort("127.0.0.1", Port, ServerCredentials.Insecure) }
            };

            server.Start();
            Console.WriteLine($"Communication Server is running on port {Port}...");
            Console.ReadKey();

            await server.ShutdownAsync();
        }
    }
}
