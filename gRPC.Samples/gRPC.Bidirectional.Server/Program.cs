using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Grpc.Core;
using GRPC.Bidirectional.Core;

namespace gRPC.Bidirectional.Remote
{
    class Program
    {
        static void Main(string[] args)
        {
            // This switch must be set before creating the GrpcChannel/HttpClient.
            AppContext.SetSwitch(
                "System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport", true);

            //var features = RouteGuideUtil.ParseFeatures(RouteGuideUtil.DefaultFeaturesFile);

            Server server = new Server
            {
                Services = { MyService.BindService(new MyServiceServer()) },
                Ports = { new ServerPort("127.0.0.1", 50051, ServerCredentials.Insecure) }
            };
            server.Start();

            Console.WriteLine("RouteGuide server listening on port " + 50051);
            Console.WriteLine("Press any key to stop the server...");
            Console.ReadKey();

            server.ShutdownAsync().Wait();

            Console.WriteLine("Hello World!");
        }
    }

    public class MyServiceServer : MyService.MyServiceBase
    {
        public override async Task Do(IAsyncStreamReader<DoMessage> requestStream, IServerStreamWriter<DoMessage> responseStream, ServerCallContext context)
        {
            ////var raceDuration = TimeSpan.Parse(context.RequestHeaders.Single(h => h.Key == "race-duration").Value);

            //// Read incoming messages in a background task
            //DoMessage? lastMessageReceived = null;
            //var readTask = Task.Run(async () =>
            //{
            //    await foreach (var message in requestStream.ReadAllAsync())
            //    {
            //        lastMessageReceived = message;
            //    }
            //});

            //// Write outgoing messages until timer is complete
        
            //await responseStream.WriteAsync();
            

            //await readTask;

            while (await requestStream.MoveNext())
            {
                var note = requestStream.Current;
                await responseStream.WriteAsync(new DoMessage { In = note?.In + "_reply" });
    
            }
        }
    }
}
