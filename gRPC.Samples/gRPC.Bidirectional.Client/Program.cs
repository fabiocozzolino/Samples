using System;
using System.Threading;
using System.Threading.Tasks;
using gRPC.Bidirectional.Core;
using Grpc.Core;

namespace gRPC.Bidirectional.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Run();
            Console.ReadLine();
        }

        async static Task Run()
        { 
            var requests = new DoRequest[]
            {
                new DoRequest(){In = "First"},
                new DoRequest(){In = "Second"},
                new DoRequest(){In = "Third"},
                new DoRequest(){In = "4"},
                new DoRequest(){In = "5"},
                new DoRequest(){In = "6"},
                new DoRequest(){In = "7"},
                new DoRequest(){In = "8"},
                new DoRequest(){In = "9"},
                new DoRequest(){In = "10"},
                new DoRequest(){In = "11"}
            };

            Channel channel = new Channel("127.0.0.1:5001", ChannelCredentials.Insecure);
            var client = new gRPC.Bidirectional.Core.MyService.MyServiceClient(channel);

            Console.WriteLine("Starting...");

            using (var call = client.Do(new CallOptions()))
            {
                var responseReaderTask = Task.Run(async () =>
                {
                    Console.WriteLine("Receiving...");
                    while (await call.ResponseStream.MoveNext())
                    {
                        Console.WriteLine("Waiting...");
                        var note = call.ResponseStream.Current;
                        Console.WriteLine("Received " + note.Out);
                    }
                    Console.WriteLine("End Received");
                });

                Thread.Sleep(500);
                Console.WriteLine("Sending");
                foreach (DoRequest request in requests)
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
