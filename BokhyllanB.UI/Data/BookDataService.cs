using BokhyllanB.DataAccess;
using BokhyllanB.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BokhyllanB.UI.Data
{
    public class BookDataService : IBookDataService
    {
        public IEnumerable<Book> getAll()
        {
            using (var ctx = new BokhyllanBDBContext())
            {
                return ctx.Books.AsNoTracking().ToList();
            }
        }

        public void UpdateBook(int id, string title, string author, string description)
        {
            using (var ctx = new BokhyllanBDBContext())
            {
                var result = ctx.Books.Where(b => b.Id == id).FirstOrDefault();
                result.Title = title;
                result.Author = author;
                result.Description = description;
                ctx.SaveChanges();
                    
            }
        }

        public void CreateNewBook()
        {
            using (var ctx = new BokhyllanBDBContext())
            {
                var newBook = new Book {Title = "New Title", Author = "New Author" };
                ctx.Books.Add(newBook);
                ctx.SaveChanges();
            }
        }

        public void DeleteBook(int id)
        {
            using (var ctx = new BokhyllanBDBContext())
            {
                var result = ctx.Books.Where(b => b.Id == id).FirstOrDefault();
                ctx.Books.Remove(result);
                ctx.SaveChanges();
            }
        }
    }
}
