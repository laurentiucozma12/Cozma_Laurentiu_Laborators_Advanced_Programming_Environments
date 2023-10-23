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

                var books = new List<Book>
                {
                    new Book { Title = "Baltagul", Author = "Mihail Sadoveanu", Price = Decimal.Parse("22") },
                    new Book { Title = "Enigma Otiliei", Author = "George Calinescu", Price = Decimal.Parse("18") },
                    new Book { Title = "Maytrei", Author = "Mircea Eliade", Price = Decimal.Parse("27") }
                };
                context.Books.AddRange(books);

                var customers = new List<Customer>
                {
                    new Customer { Name = "Popescu Marcela", Address = "Str. Plopilor, nr. 24", BirthDate = DateTime.Parse("1979-09-01") },
                    new Customer { Name = "Mihailescu Cornel", Address = "Str. Bucuresti, nr. 45, ap. 2", BirthDate = DateTime.Parse("1969-07-08") }
                };
                context.Customers.AddRange(customers);

                var orders = new List<Order>
                {
                    new Order { CustomerId = customers[0].Id, BookId = books[0].Id },
                    new Order { CustomerId = customers[0].Id, BookId = books[1].Id },
                    new Order { CustomerId = customers[1].Id, BookId = books[2].Id }
                };
                context.Orders.AddRange(orders);


                context.SaveChanges();
            }
        }
    }
}
