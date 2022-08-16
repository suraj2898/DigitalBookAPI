using AuthorAPI.Models;

namespace AuthorAPI.Services
{
    public interface IAuthorService
    {
        string BlockBook(long bookid);
        string CreateBook(Book book);
        string Login(User user);
        string Signup(User user);
        string UnBlockBook(long bookid);
        string UpdateBook(Book book);
    }
}
