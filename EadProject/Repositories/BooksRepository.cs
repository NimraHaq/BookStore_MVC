using EadProject.Models;
using EadProject.Data;
using EadProject.Repositories.Interfaces;
using AutoMapper;

namespace EadProject.Repositories
{
    public class BooksRepository : IBooksRepository
    //: IBooksRepository
    {
        private readonly BookStoreContext _bookStoreContext = null;
        private readonly IMapper _mapper = null;

        public BooksRepository(BookStoreContext bookStoreContext, IMapper mapper)
        {
            _bookStoreContext = bookStoreContext;
            _mapper = mapper;
        }

        public void DeleteBookById(int id)
        {
            BookTable book = _bookStoreContext.BookTable.First(b => b.Id == id);
            _bookStoreContext.BookTable.Remove(book);
            _bookStoreContext.SaveChanges();
        }

        public bool ifBookIdExists(int id)
        {
            List<BookModel>? allBooks = GetAllBooks();
            if(allBooks == null)
            {
                return false;
            }
            foreach(BookModel b in allBooks)
            {
                if(b.Id == id)
                {
                    return true;
                }
            }
            return false;
        }
        public int AddNewBook(BookModel book, int idCreater)
        {

            //validating automapper
            /*
            BookTable bookTable = _mapper.Map<BookTable>(book);
            Console.WriteLine("----------------Book model to book table conversion------------");
            Console.WriteLine("book table " + bookTable.BookName + " " + bookTable.BookAuthor + " " + bookTable.NumberOfPages + " " + bookTable.Language + " " + bookTable.Price + " " + bookTable.BookPictureURL + "\n");
            Console.WriteLine("book model " + book.BookName + " " + book.BookAuthor + " " + book.NumberOfPages + " " + book.Language + " " + book.Price + " " + book.BookPictureURL + "\n");
            Console.WriteLine("----------------------------");

            */
            BookTable bookToAdd = new BookTable()
            {
                BookName = book.BookName,
                BookAuthor = book.BookAuthor,
                Price = book.Price,
                shortDescription = book.shortDescription,
                Category = book.Category,
                NumberOfPages = book.NumberOfPages,
                Language = book.Language,
                SellerId = book.SellerId,
                BookPictureURL = book.BookPictureURL,
                CreatedBy = idCreater
            }; 
            //BookTable bookToAdd = _mapper.Map<BookTable>(book);
            _bookStoreContext.BookTable.Add(bookToAdd);
            _bookStoreContext.SaveChanges();
            return bookToAdd.Id;
        }
        public List<BookModel>? GetAllBooks()
        {
            List<BookModel> AllBooks = new List<BookModel>();
            var allBooks = _bookStoreContext.BookTable.ToList();
            if (allBooks?.Any() == true)
            {
                foreach (var book in allBooks)
                {
                    //validating automapper
                    /*
                    BookModel bookModel = _mapper.Map<BookModel>(book);
                    Console.WriteLine("----------------Book Table to book model conversion------------");
                    Console.WriteLine("book table " + book.BookName + " " + book.BookAuthor + " " + book.NumberOfPages + " " + book.Language + " " + book.Price + " " + book.BookPictureURL + "\n");
                    Console.WriteLine("book model " + bookModel.BookName + " " + bookModel.BookAuthor + " " + bookModel.NumberOfPages + " " + bookModel.Language + " " + bookModel.Price + " " + bookModel.BookPictureURL + "\n");
                    Console.WriteLine("----------------------------");
                    
                    BookModel myBook = new BookModel()
                    {
                        Id = book.Id,
                        BookName = book.BookName,
                        BookAuthor = book.BookAuthor,
                        Price = book.Price,
                        shortDescription = book.shortDescription,
                        Category = book.Category,
                        NumberOfPages = book.NumberOfPages,
                        Language = book.Language,
                        SellerId = book.SellerId,
                        BookPictureURL = book.BookPictureURL
                    };
                    */
                    
                    BookModel myBook = _mapper.Map<BookModel>(book);
                    AllBooks.Add(myBook);
                }
                return AllBooks;
            }
            return null;
        }
        public List<BookModel>? GetAllBooksSeller(int id)
        {
            List<BookModel>? AllBooks = GetAllBooks();
            if (AllBooks != null)
            {
                List<BookModel> SellerBooks = new List<BookModel>();
                foreach (BookModel b in AllBooks)
                {
                    if (b.SellerId == id)
                    {
                        SellerBooks.Add(b);
                    }
                }
                if (SellerBooks.Count > 0)
                {
                    return SellerBooks;
                }
                return null;
            }
            return null;
        }

        public BookModel? GetBookById(int id)
        {
            List<BookModel> allBooks = GetAllBooks();
            if (allBooks != null)
            {
                foreach (BookModel b in allBooks)
                {
                    if (b.Id == id)
                    {
                        return b;
                    }
                }
            }
            return null;
        }

        public void UpdateBookInfo(BookModel bookModel, int ModifierId)
        {
            BookTable book = _bookStoreContext.BookTable.First(b => b.Id == bookModel.Id);
            book.BookName = bookModel.BookName;
            book.BookAuthor = bookModel.BookAuthor;
            book.NumberOfPages = bookModel.NumberOfPages;
            book.Category = bookModel.Category;
            book.BookPictureURL = bookModel.BookPictureURL;
            book.Price = bookModel.Price;
            book.Language = bookModel.Language;
            book.SellerId = bookModel.SellerId;
            book.shortDescription = bookModel.shortDescription;
            book.ModifiedBy = ModifierId;
            _bookStoreContext.SaveChanges();

        }

        public List<BookModel>? GetBookForName(string name)
        {
            List<BookModel>? AllBooks = GetAllBooks();
            if (AllBooks != null)
            {
                List<BookModel>? ResultBook = new List<BookModel>();
                foreach (BookModel book in AllBooks)
                {
                    if (book.BookName.Contains(name))
                    {
                        ResultBook.Add(book);
                    }
                }
                if (ResultBook.Count > 0)
                {
                    return ResultBook;
                }
            }
            return null;
        }
        public List<BookModel>? GetBookForNamePrice(int minPrice, int? maxPrice, string name)
        {
            List<BookModel>? AllBooks = GetAllBooks();
            if (AllBooks != null)
            {
                List<BookModel>? ResultBook = new List<BookModel>();
                foreach (BookModel book in AllBooks)
                {
                    if (maxPrice != null)
                    {
                        if (book.Price >= minPrice && book.Price <= maxPrice && book.BookName.Contains(name))
                        {
                            ResultBook.Add(book);
                        }
                    }
                    else if (maxPrice == null)
                    {
                        if (book.Price >= minPrice && book.BookName.Contains(name))
                        {
                            ResultBook.Add(book);
                        }
                    }
                }
                if (ResultBook.Count > 0)
                {
                    return ResultBook;
                }
            }
            return null;
        }
        public List<BookModel>? GetBookForNameCategory(string category, string name)
        {
            List<BookModel>? AllBooks = GetAllBooks();
            if (AllBooks != null)
            {
                List<BookModel>? ResultBook = new List<BookModel>();
                foreach (BookModel book in AllBooks)
                {
                    if(book.Category == category && book.BookName.Contains(name))
                    {
                        ResultBook.Add(book);
                    }
                }
                if(ResultBook.Count > 0)
                {
                    return ResultBook;
                }
            }
            return null;
        }
        public List<BookModel>? GetBookForCategoryPrice(string category, int minPrice, int? maxPrice)
        {
            List<BookModel>? AllBooks = GetAllBooks();
            if (AllBooks != null)
            {
                List<BookModel>? ResultBook = new List<BookModel>();
                foreach (BookModel book in AllBooks)
                {
                    if (maxPrice != null)
                    {
                        if (book.Price >= minPrice && book.Price <= maxPrice && book.Category == category)
                        {
                            ResultBook.Add(book);
                        }
                    }
                    else if (maxPrice == null)
                    {
                        if (book.Price >= minPrice && book.Category == category)
                        {
                            ResultBook.Add(book);
                        }
                    }
                }
                if (ResultBook.Count > 0)
                {
                    return ResultBook;
                }
            }
            return null;
        }
        public List<BookModel>? GetBookForCategory(string category)
        {
            List<BookModel>? AllBooks = GetAllBooks();
            if (AllBooks != null)
            {
                List<BookModel>? ResultBook = new List<BookModel>();
                foreach (BookModel book in AllBooks)
                {
                    if(book.Category == category)
                    {
                        ResultBook.Add(book);
                    }
                }
                if (ResultBook.Count > 0)
                {
                    return ResultBook;
                }
            }
            return null;
        }
        public List<BookModel>? GetBookForPrice(int minPrice, int? maxPrice)
        {
            List<BookModel>? AllBooks = GetAllBooks();
            if (AllBooks != null)
            {
                List<BookModel>? ResultBook = new List<BookModel>();
                foreach (BookModel book in AllBooks)
                {
                    if (maxPrice != null)
                    {
                        if (book.Price >= minPrice && book.Price <= maxPrice)
                        {
                            ResultBook.Add(book);
                        }
                    }
                    else if (maxPrice == null)
                    {
                        if (book.Price >= minPrice )
                        {
                            ResultBook.Add(book);
                        }
                    }
                }
                if (ResultBook.Count > 0)
                {
                    return ResultBook;
                }
            }
            return null;
        }
        public List<BookModel>? GetBookForPriceCategoryName(string category,int minPrice, int? maxPrice, string name)
        {
            List<BookModel>? AllBooks = GetAllBooks();
            if (AllBooks != null)
            {
                List<BookModel>? ResultBook = new List<BookModel>();
                foreach (BookModel book in AllBooks)
                {
                    if (maxPrice != null)
                    {
                        if (book.Price >= minPrice && book.Price <= maxPrice && book.Category == category && book.BookName.Contains(name))
                        {
                            ResultBook.Add(book);
                        }
                    }
                    else if (maxPrice == null)
                    {
                        if (book.Price >= minPrice && book.Category == category && book.BookName.Contains(name))
                        {
                            ResultBook.Add(book);
                        }
                    }
                }
                if (ResultBook.Count > 0)
                {
                    return ResultBook;
                }
            }
            return null;
        }
        

    }
}
