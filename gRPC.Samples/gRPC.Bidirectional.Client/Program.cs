using System;
using Grpc.Core;

namespace gRPC.Bidirectional.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Channel channel = new Channel("127.0.0.1:50052", ChannelCredentials.Insecure);
            var client = new gRPC.Bidirectional.Core(channel);

            // YOUR CODE GOES HERE

            channel.ShutdownAsync().Wait();
            Console.WriteLine("Hello World!");
        }
    }
}
