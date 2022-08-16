using ReaderAPI.Models;

namespace ReaderAPI.Services
{
    public class ReaderService : IReaderService
    {
        public readonly DigitalBookContext _context;

        String _result = String.Empty;

        public ReaderService(DigitalBookContext context)
        {
            _context = context;
        }

        public List<Book> SearchBook(Book book)
        {
            return _context.Books.ToList().Where(p => (p.Price.GetValueOrDefault(0) == Convert.ToDecimal(book.Price) || p.Category == book.Category || p.Publisher == book.Publisher) && p.Active == true).ToList();
        }

        public long getID()
        {
            Random random = new Random();
            int ran = random.Next(1000, 9999);
            return Convert.ToInt64(DateTime.Now.ToString("yyyyyddMMmmss")) + ran;
        }

        public string Buy(Payment payment)
        {
            try
            {
                payment.PaymentDate = DateTime.Now;
                payment.Paymentid = getID();
                _context.Payments.Add(payment);
                _context.SaveChanges();
                _result= "Book Purchased Successfully.";
            }
            catch
            {
                _result = "Problem While Purchasing Book";
            }
            return _result;
        }

        public List<Book> GetPurchasedBooks(String email)
        {
            return _context.Books.Where(b => (_context.Payments.Where(s => s.Email == email).Select(t => t.Bookid)).Contains(b.Bookid)).ToList();
        }

        public Book ReadBook(int bookid)
        {
            return _context.Books.Where(b => b.Bookid == bookid && b.Active == true).First();
        }
        public Book getPurchasedBookbyPaymentID(int paymentid)
        {
            return _context.Books.Where(b => b.Bookid == (_context.Payments.Where(d => d.Paymentid == paymentid).Select(s => s.Bookid)).First()).First();
        }
    }
}
