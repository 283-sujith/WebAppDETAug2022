using Library.Models;

namespace Library.Services
{
    public interface IBookService
    {
        IEnumerable<Book> GetAll();

        Book Add(IBookService newBook);

        Book GetById(Guid id);

        void Remove(Guid id);

        Book Add(Book value);
    }
}
