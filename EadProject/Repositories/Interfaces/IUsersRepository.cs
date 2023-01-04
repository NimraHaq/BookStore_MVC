using EadProject.Models;

namespace EadProject.Repositories.Interfaces
{
    public interface IUsersRepository
    {
        void SetCreatedBySeller(int id);
        void SetCreatedByBuyer(int id);
        List<BookModel>? GetBuyerCartBooks(int buyerId);
        void AddBookToBuyerCart(int userId, int bookId);
        int AddNewBuyer(UserModel user);
        int AddNewSeller(UserModel user);
        List<BuyerModel> getAllBuyers();
        List<SellerModel> getAllSellers();
        BuyerModel? ifBuyerExists(string username, string password);
        SellerModel? ifSellerExists(string username, string password);
        bool ifUserNameExists(string username);
        BuyerModel? GetBuyerById(int id);
        SellerModel? GetSellerById(int id);
        string? UserBuyerORSeller(string username);
        bool RemoveSellerByUsername(string username);
        bool RemoveBuyerByUsername(string username);


    }
}