using AuthorAPI.Models;

namespace AuthorAPI.Services
{
    public class AuthorService : IAuthorService
    {
        public readonly DigitalBookContext _context;
        String _result=String.Empty;

        public AuthorService(DigitalBookContext context)
        {
            _context = context;
        }

        public long getID()
        {
            Random random = new Random();
            int ran = random.Next(1000, 9999);
            return Convert.ToInt64(DateTime.Now.ToString("yyyyyddMMmmss")) + ran;
        }

        public String CreateBook(Book book)
        {
            try
            {
                book.Bookid = getID();
                book.CreatedDate = DateTime.Now;
                book.ModifiedDate = DateTime.Now;
                book.Active = true;
                _context.Books.Add(book);
                _context.SaveChanges();
                _result = $"Book {book.Title} Added Successfully";
            }
            catch
            {
                _result = "Problem While Adding Book";
            }
            return _result;
        }

        public string Signup(User user)
        {
            try
            {
                user.Userid = getID();
                _context.Users.Add(user);
                _context.SaveChanges();
                _result= "Account Created Successfully.";
            }
            catch
            {
                _result = "Problem While Creating Account.";
            }
            return _result;
        }

        public string Login(User user)
        {
            try
            {
                if (_context.Users.Where(s => s.Username == user.Username).Count() == 0)
                {
                    return "Invalid Username!!";
                }
                if (_context.Users.Where(s => s.Password == user.Password && s.Username == user.Username).Count() == 0)
                {
                    return "Invalid Password!!";
                }
                _result= "OK";
            }
            catch
            {
                _result = "Problem While Login.";
            }
            return _result;
        }

        public string BlockBook(long bookid)
        {
            try
            {
                if (_context.Books.Where(b => b.Bookid == bookid).Count() == 0)
                {
                    _result= "Book Not Found.";
                }
                else
                {
                    var book = _context.Books.First(s => s.Bookid == bookid);
                    book.Active = false;
                    _context.SaveChanges();
                    _result= "OK";
                }
            }
            catch
            {
                _result = "Problem While Blocking Book";
            }
            return _result;
        }

        public string UnBlockBook(long bookid)
        {
            try
            {
                if (_context.Books.Where(b => b.Bookid == bookid && b.Active == false).Count() == 0)
                {
                    _result= "Blocked Book Not Found.";
                }
                else
                {
                    var book = _context.Books.First(s => s.Bookid == bookid);
                    book.Active = true;
                    _context.SaveChanges();
                    _result= "OK";
                }
            }
            catch
            {
                _result = "Problem While Unblocking Book";
            }
            return _result;
        }

        public string UpdateBook(Book book)
        {
            try
            {
                book.ModifiedDate = DateTime.Now;
                _context.Entry(book).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();
                _result= "Book Details Updated Successfully";
            }
            catch
            {
                _result = "Problem While Updating Book";
            }
            return _result;
        }

    }
}
