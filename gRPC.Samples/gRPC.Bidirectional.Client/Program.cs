using System;
using System.Threading;
using System.Threading.Tasks;
using GRPC.Bidirectional.Core;
using Grpc.Core;

namespace gRPC.Bidirectional.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            // This switch must be set before creating the GrpcChannel/HttpClient.
            AppContext.SetSwitch(
                "System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport", true);

            Run().ContinueWith(task =>
            {
                if (task.IsFaulted)
                {
                    Console.WriteLine(task.Exception.ToString());
                    foreach (var item in task.Exception.InnerExceptions)
                    {
                        Console.WriteLine("--- INNER");
                        Console.WriteLine(item.ToString());
                    }
                }
                else
                {
                    Console.WriteLine("Finished!");
                }
            });
            Console.ReadLine();
        }

        async static Task Run()
        { 
            var requests = new DoMessage[]
            {
                new DoMessage(){In = "First"},
                new DoMessage(){In = "Second"},
                new DoMessage(){In = "Third"},
                new DoMessage(){In = "4"},
                new DoMessage(){In = "5"},
                new DoMessage(){In = "6"},
                new DoMessage(){In = "7"},
                new DoMessage(){In = "8"},
                new DoMessage(){In = "9"},
                new DoMessage(){In = "10"},
                new DoMessage(){In = "11"}
            };

            Channel channel = new Channel("localhost", 50051, ChannelCredentials.Insecure);
            var client = new MyService.MyServiceClient(channel);
            Console.WriteLine("Starting...");

            var options = new CallOptions().WithDeadline(DateTime.UtcNow.AddSeconds(15)).WithWaitForReady(true);
            using (var call = client.Do(options))
            {
                var responseReaderTask = Task.Run(async () =>
                {
                    Console.WriteLine("Receiving...");
                    while (await call.ResponseStream.MoveNext())
                    {
                        Console.WriteLine("Waiting...");
                        var note = call.ResponseStream.Current;
                        Console.WriteLine("Received " + note.In);
                    }
                    Console.WriteLine("End Received");
                }).ContinueWith(task =>
                {
                    if (task.IsFaulted)
                    {
                        Console.WriteLine("SERVER: " + task.Exception.ToString());
                        foreach (var item in task.Exception.InnerExceptions)
                        {
                            Console.WriteLine("--- INNER SERVER");
                            Console.WriteLine(item.ToString());
                        }
                    }
                });


                Console.WriteLine("Sending");
                foreach (DoMessage request in requests)
                {
                    Console.WriteLine("Sending " + request.In);
                    await call.RequestStream.WriteAsync(request);
                    Console.WriteLine("Sent " + request.In);
                }
                await call.RequestStream.CompleteAsync();
                Console.WriteLine("End Sending");
                await responseReaderTask;
            }

            channel.ShutdownAsync().Wait();
            Console.WriteLine("Hello World!");
        }
    }
}
