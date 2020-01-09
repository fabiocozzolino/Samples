using System;
using Google.Protobuf.WellKnownTypes;
using Grpc.Net.Client;

namespace BookshelfService
{
    class Program
    {
        static void Main(string[] args)
        {
            AppContext.SetSwitch("System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport", true);
            var request = new SendRequest();
            request.Content = new Any();
            request.Content.Value =  Google.Protobuf.ByteString.CopyFromUtf8("{ \"Name\": \"Fabio\",  \"Surname\": \"Cozzolino\" }");
            // The port number(5001) must match the port of the gRPC server.
            var channel = GrpcChannel.ForAddress("http://localhost:5000");
            var client =  new BookService.BookServiceClient(channel);
            try 
            {
                var reply = client.Send(request);
                Console.WriteLine("Greeting: " + reply.Content);
                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
            }
            catch(Exception ex)
            {
                var exc = ex;
                while(exc != null)
                {
                    Console.WriteLine(exc.ToString());
                    exc = exc.InnerException;
                }
            }
        }
    }
}
