using ReaderAPI.Models;
using ReaderAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ReaderAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class ReaderController : ControllerBase
    {
        private readonly IReaderService _readerService;

        public ReaderController(IReaderService readerService)
        {
            _readerService = readerService;
        }

        [HttpGet("Book/Search")]
        public IEnumerable<Book> SearchBooks([FromBody] Book book)
        {
            try
            {
               return _readerService.SearchBook(book);
            }
            catch
            {
                return new List<Book>();
            }
        }

        [HttpPost("Book/Buy")]
        public ActionResult<string> Buy([FromBody] Payment payment)
        {
            try
            {
                return Ok(_readerService.Buy(payment));
            }
            catch
            {
                return BadRequest("Problem While Purchasing Book");
            }
        }

        [HttpGet("Book/Bought")]
        public ActionResult<List<Book>> GetPurchasedBooks([FromBody] String email)
        {
            try
            {
                return Ok(_readerService.GetPurchasedBooks(email));
            }
            catch
            {
                return BadRequest("Problem While Getting Purchased Book List");
            }
        }

        [HttpGet("Book/Read")]
        public ActionResult<Book> ReadBook([FromBody] int bookid)
        {
            try
            {                
                return Ok(_readerService.ReadBook(bookid));
            }
            catch
            {
                return BadRequest("Problem While Fetching Book Content");
            }
        }

        [HttpPost("Book/ByPaymentID")]
        public ActionResult<Book> getPurchasedBookbyPaymentID([FromBody] int paymentid)
        {
            try
            {                
                return Ok(_readerService.getPurchasedBookbyPaymentID(paymentid));
            }
            catch
            {
                return BadRequest("Problem While getting purchased Book by Payment ID.");
            }
        }
    }
}
