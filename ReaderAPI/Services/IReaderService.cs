using ReaderAPI.Models;

namespace ReaderAPI.Services
{
    public interface IReaderService
    {
        string Buy(Payment payment);
        Book getPurchasedBookbyPaymentID(int paymentid);
        List<Book> GetPurchasedBooks(string email);
        Book ReadBook(int bookid);
        List<Book> SearchBook(Book book);
    }
}
