using EadProject.Models;

namespace EadProject.Repositories.Interfaces
{
    public interface IBooksRepository
    {
        void DeleteBookById(int id);
        bool ifBookIdExists(int id);
        int AddNewBook(BookModel book, int idCreater);
        List<BookModel>? GetAllBooks();
        List<BookModel>? GetAllBooksSeller(int id);
        BookModel? GetBookById(int id);
        void UpdateBookInfo(BookModel bookModel, int ModifierId);
        List<BookModel>? GetBookForName(string name);
        List<BookModel>? GetBookForNamePrice(int minPrice, int? maxPrice, string name);
        List<BookModel>? GetBookForNameCategory(string category, string name);
        List<BookModel>? GetBookForCategoryPrice(string category, int minPrice, int? maxPrice);
        List<BookModel>? GetBookForCategory(string category);
        List<BookModel>? GetBookForPrice(int minPrice, int? maxPrice);
        List<BookModel>? GetBookForPriceCategoryName(string category, int minPrice, int? maxPrice, string name);
    }
}