using Cozma_Laurentiu_Lab2.Models;
using Microsoft.EntityFrameworkCore;
using static NuGet.Packaging.PackagingConstants;

namespace Cozma_Laurentiu_Lab2.Data
{
    public class DbInitializator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new LibraryContext(serviceProvider.GetRequiredService<DbContextOptions<LibraryContext>>()))
            {

                if (context.Books.Any())
                {
                    return; // BD a fost creata anterior
                }

                var authors = new List<Author>
                {
                    new Author { FirstName = "Mihail", LastName = "Sadoveanu" },
                    new Author { FirstName = "George", LastName = "Calinescu" },
                    new Author { FirstName = "Mircea", LastName = "Eliade" }
                };

                var books = new List<Book>
                {
                    new Book { Title = "Baltagul", Author = authors[0], Price = Decimal.Parse("22") },
                    new Book { Title = "Enigma Otiliei", Author = authors[1], Price = Decimal.Parse("18") },
                    new Book { Title = "Maytrei", Author = authors[2], Price = Decimal.Parse("27") }
                };
                context.Books.AddRange(books);

                var customers = new List<Customer>
                {
                    new Customer { Name = "Popescu Marcela", Address = "Str. Plopilor, nr. 24", BirthDate = DateTime.Parse("1979-09-01") },
                    new Customer { Name = "Mihailescu Cornel", Address = "Str. Bucuresti, nr. 45, ap. 2", BirthDate = DateTime.Parse("1969-07-08") }
                };
                context.Customers.AddRange(customers);

             /*   var orders = new List<Order>
                {
                    new Order { CustomerId = customers[0].Id, BookId = books[0].Id },
                    new Order { CustomerId = customers[0].Id, BookId = books[1].Id },
                    new Order { CustomerId = customers[1].Id, BookId = books[2].Id }
                };
                context.Orders.AddRange(orders);
             */

                context.SaveChanges();
            }
        }
    }
}
