using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Protobuf;
using Grpc.Core;
using Microsoft.Extensions.Logging;

namespace BookshelfService
{
    public class BookServiceImpl : BookService.BookServiceBase
    {
        private readonly ILogger<BookServiceImpl> _logger;
        public BookServiceImpl(ILogger<BookServiceImpl> logger)
        {
            _logger = logger;
        }

        public override async Task GetAllBooks(AllBooksRequest request, IServerStreamWriter<AllBooksReply> responseStream, ServerCallContext context)
        {
            var pageIndex = 0;
            while (!context.CancellationToken.IsCancellationRequested)
            {
                var books = BooksManager.ReadAll(++pageIndex, request.ItemsPerPage);
                if (!books.Any())
                {
                    break;
                }

                var reply = new AllBooksReply();
                reply.Books.AddRange(books);
                await responseStream.WriteAsync(reply);

                // Gotta look busy
                await Task.Delay(1000);
            }
        }

        public override async Task<NewBookReply> Save(NewBookRequest request, ServerCallContext context)
        {
            return await Task.FromResult(new NewBookReply
            {
                Id = Guid.NewGuid().ToString()
            });
        }

        public override async Task<SendReply> Send(SendRequest request, ServerCallContext context)
        {
            byte[] buffer = new byte[request.Content.CalculateSize()];
            using (CodedOutputStream output = new CodedOutputStream(buffer))
            {
                request.Content.WriteTo(output);
            }

            Console.WriteLine(Encoding.UTF8.GetString(buffer));

            return await Task.FromResult(new SendReply());
        }
    }

    public class BooksManager
    {
        public static Book[] ReadAll(int pageIndex, int itemsPerPage)
        {
            return Books.Skip((pageIndex-1)*itemsPerPage).Take(itemsPerPage).ToArray();
        }

        private static List<Book> books = new List<Book>();
        private static Book[] Books
        {
            get
            {
                if (!books.Any())
                {
                    books.Add(new Book{Title="Il giovane holden", Description="J. D. Salinger"});
                    books.Add(new Book{Title="1984", Description="George Orwell"});
                    books.Add(new Book{Title="Il signore delle mosche", Description="William Golding"});
                    books.Add(new Book{Title="Il buio oltre la siepe", Description="Harper Lee"});
                    books.Add(new Book{Title="Il Signore degli Anelli", Description="J. R. R. Tolkien"});
                    books.Add(new Book{Title="Il mondo nuovo", Description="Aldous Huxley"});
                    books.Add(new Book{Title="Storia di una ladra di libri", Description="Markus Zusak"});
                    books.Add(new Book{Title="Cronache marziane", Description="Ray Bradbury"});
                }

                return books.ToArray();
            }
        }
    }
}
