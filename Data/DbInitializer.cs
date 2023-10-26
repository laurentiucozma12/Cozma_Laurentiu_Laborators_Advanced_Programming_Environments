using Cozma_Laurentiu_Lab2.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Policy;
using static NuGet.Packaging.PackagingConstants;
using Publisher = Cozma_Laurentiu_Lab2.Models.Publisher;

namespace Cozma_Laurentiu_Lab2.Data
{
    public class DbInitializer
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new LibraryContext(serviceProvider.GetRequiredService<DbContextOptions<LibraryContext>>()))
            {

                if (context.Books.Any())
                {
                    return; // BD a fost creata anterior
                }

                var orders = new Order[]
                 {
                     new Order{ BookId = 1, CustomerId =1050, OrderDate = DateTime.Parse("2021-02-25")},
                     new Order{ BookId = 3, CustomerId =1045, OrderDate = DateTime.Parse("2021-09-28")},
                     new Order{ BookId = 1, CustomerId =1045, OrderDate = DateTime.Parse("2021-10-28")},
                     new Order{ BookId = 2, CustomerId =1050, OrderDate = DateTime.Parse("2021-09-28")},
                     new Order{ BookId = 4, CustomerId =1050, OrderDate = DateTime.Parse("2021-09-28")},
                     new Order{ BookId = 6, CustomerId =1050, OrderDate = DateTime.Parse("2021-10-28")},
                 };

                foreach (Order e in orders)
                {
                    context.Orders.Add(e);
                }

                context.SaveChanges();
                var publishers = new Publisher[]
                {
                     new Publisher { PublisherName = "Humanitas", Address = "Str. Aviatorilor, nr. 40,Bucuresti" },
                     new Publisher { PublisherName = "Nemira", Address = "Str. Plopilor, nr. 35,Ploiesti" },
                     new Publisher { PublisherName = "Paralela 45", Address = "Str. Cascadelor, nr.22, Cluj-Napoca" },
                };

                foreach (Publisher p in publishers)
                {
                    context.Publishers.Add(p);
                }

                context.SaveChanges();
                var books = context.Books;
                var publishedbooks = new PublishedBook[]
                {
                     new PublishedBook {
                         BookId = books.Single(c => c.Title == "Maytrei" ).Id, PublisherId = publishers.Single(i => i.PublisherName == "Humanitas").Id
                     },
                     new PublishedBook {
                        BookId = books.Single(c => c.Title == "Enigma Otiliei" ).Id, PublisherId = publishers.Single(i => i.PublisherName == "Humanitas").Id
                     },
                     new PublishedBook {
                        BookId = books.Single(c => c.Title == "Baltagul" ).Id, PublisherId = publishers.Single(i => i.PublisherName == "Nemira").Id
                     },
                     new PublishedBook {
                        BookId = books.Single(c => c.Title == "Fata de hartie" ).Id, PublisherId = publishers.Single(i => i.PublisherName == "Paralela 45").Id
                     },
                     new PublishedBook {
                        BookId = books.Single(c => c.Title == "Panza de paianjen" ).Id, PublisherId = publishers.Single(i => i.PublisherName == "Paralela 45").Id
                     },
                     new PublishedBook {
                        BookId = books.Single(c => c.Title == "De veghe in lanul de secara" ).Id, PublisherId = publishers.Single(i => i.PublisherName == "Paralela 45").Id
                     },
                 };

                foreach (PublishedBook pb in publishedbooks)
                {
                    context.PublishedBooks.Add(pb);
                }
                context.SaveChanges();

                var authors = new List<Author>
                {
                    new Author { FirstName = "Mihail", LastName = "Sadoveanu" },
                    new Author { FirstName = "George", LastName = "Calinescu" },
                    new Author { FirstName = "Mircea", LastName = "Eliade" }
                };

                //var books = new List<Book>
                //{
                //    new Book { Title = "Baltagul", Author = authors[0], Price = Decimal.Parse("22") },
                //    new Book { Title = "Enigma Otiliei", Author = authors[1], Price = Decimal.Parse("18") },
                //    new Book { Title = "Maytrei", Author = authors[2], Price = Decimal.Parse("27") }
                //};
                //context.Books.AddRange(books);

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
