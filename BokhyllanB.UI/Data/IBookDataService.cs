using System.Collections.Generic;
using BokhyllanB.Model;

namespace BokhyllanB.UI.Data
{
    public interface IBookDataService
    {
        IEnumerable<Book> getAll();
        void CreateNewBook();
        void DeleteBook(int id);
        void UpdateBook(int id, string title, string author, string description);
    }
}