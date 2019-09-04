using System.Linq;
using BookStore.Models;
using BookStore.Models.Utils;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;
using Book = BookStore.Models.Web.Book;

namespace BookStore.Controllers
{
    public class BooksController : ODataController
    {
        private readonly BookStoreContext _db;

        public BooksController(BookStoreContext context)
        {
            _db = context;
            if (context.Books.Count() == 0)
            {
                foreach (var b in DataSource.GetBooks())
                {
                    context.Books.Add(b);
                    context.Presses.Add(b.Press);
                }

                context.SaveChanges();
            }
        }

        [EnableQuery]
        public IActionResult Get()
        {
            return Ok(_db.Books);
        }

        [EnableQuery]
        public IActionResult Get(int key)
        {
            var book = _db.Books.FirstOrDefault(c => c.Id == key);
            return Ok(Converter.Convert(book));
        }

        [EnableQuery]
        public IActionResult Post([FromBody] Book book)
        {
            _db.Books.Add(Converter.Convert(book));
            _db.SaveChanges();
            return Created(book);
        }

        [EnableQuery]
        public IActionResult Delete([FromBody] int key)
        {
            var b = _db.Books.FirstOrDefault(c => c.Id == key);
            if (b == null) return NotFound();

            _db.Books.Remove(b);
            _db.SaveChanges();
            return Ok();
        }

        [EnableQuery]
        public IActionResult Patch([FromODataUri] int key, Delta<Book> bookDelta)
        {
            var dbBook = _db.Books.FirstOrDefault(c => c.Id == key);
            if (dbBook == null) return NotFound();

            var webBook = Converter.Convert(dbBook);
            bookDelta.Patch(webBook);
            UpdateUtil.CopyData(Converter.Convert(webBook), dbBook);

            _db.SaveChanges();
            return Updated(webBook);
        }
    }
}