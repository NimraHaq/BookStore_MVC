using EadProject.Models;
using EadProject.Data;
using EadProject.Repositories.Interfaces;
using System.Linq;
using AutoMapper;

namespace EadProject.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private readonly BookStoreContext _bookStoreContext = null;
        private readonly IMapper _mapper = null;

        public UsersRepository(BookStoreContext bookStoreContext, IMapper mapper)
        {
            _bookStoreContext = bookStoreContext;
            _mapper = mapper;
        }

        public List<BookModel>? GetBuyerCartBooks(int buyerId)
        {

            //var user = _bookStoreContext.BuyerTable.First(u => u.Id == buyerId);
            var user = _bookStoreContext.BuyerTable.Find(buyerId);
           // var user = _bookStoreContext.BuyerTable.Where(x => x.BookTable).SingleorDefault(m => m.)
              //  var user = _bookstoreContext.Include(x => x.bookTable).SingleorDefault(m => m.Id == buyerId);

            /*List<BookTable> books = new List<BookTable>();
            foreach(BookTable book in books)
            {

            }*/

            List<BookModel> bookTable = new List<BookModel>();
            if (user != null)
            {
                if (user.Cart?.Any() == true)
                {
                    foreach (BookTable bookRecord in user.Cart)
                    {
                        bookTable.Add(new BookModel()
                        {
                            Id = bookRecord.Id,
                            BookName = bookRecord.BookName,
                            BookAuthor = bookRecord.BookAuthor,
                            NumberOfPages = bookRecord.NumberOfPages,
                            Language = bookRecord.Language,
                            Category = bookRecord.Category,
                            BookPictureURL = bookRecord.BookPictureURL,
                            shortDescription = bookRecord.shortDescription,
                            Price = bookRecord.Price,
                            SellerId = bookRecord.SellerId
                        });
                    }
                    return bookTable;
                }
            }
            return null;
        }
        public void AddBookToBuyerCart(int userId, int bookId)
        {
            //getting the user object
            BuyerTable user = _bookStoreContext.BuyerTable.First(u => u.Id == userId);
            //now getting the book object
            BookTable? book = _bookStoreContext.BookTable.Where(b => b.Id == bookId).FirstOrDefault();
            if (book != null)
            {
                if(user.Cart == null)
                {

                }
                //adding book object in user cart
                user.Cart.Add(book);
                _bookStoreContext.SaveChanges();
                Console.WriteLine("count " + user.Cart.Count());
            }
        }
        public bool RemoveSellerByUsername(string username)
        {
            SellerTable seller = _bookStoreContext.SellerTable.First(s => s.UserName == username);
            _bookStoreContext.SellerTable.Remove(seller);
            _bookStoreContext.SaveChanges();
            return true;
        }
        public bool RemoveBuyerByUsername(string username)
        {
            BuyerTable buyer = _bookStoreContext.BuyerTable.First(s => s.UserName == username);
            _bookStoreContext.BuyerTable.Remove(buyer);
            _bookStoreContext.SaveChanges();
            return true;
        }
        public string? UserBuyerORSeller(string username)
        {
            List<BuyerModel>? AllBuyers = getAllBuyers();
            foreach(BuyerModel b in AllBuyers)
            {
                if(b.UserName == username)
                {
                    return "buyer";
                }
            }
            List<SellerModel>? AllSellers = getAllSellers();
            foreach(SellerModel s in  AllSellers)
            {
                if(s.UserName == username)
                {
                    return "seller";
                }
            }
            return null;
        }
        public int AddNewBuyer(UserModel user)
        {
            var newUser = new BuyerTable()
            {
                Id = user.Id,
                Name = user.Name,
                UserName = user.UserName,
                Password = user.Password,
                ProfilePictureURL = user.profilePictureURL,
                CreatedBy = user.Id
            };
            _bookStoreContext.BuyerTable.Add(newUser);
            _bookStoreContext.SaveChanges();
            return newUser.Id;
        }
        public int AddNewSeller(UserModel user)
        {
            var newUser = new SellerTable()
            {
                Id = user.Id,
                Name = user.Name,
                UserName = user.UserName,
                Password = user.Password,
                ProfilePictureURL = user.profilePictureURL,
                CreatedBy = user.Id
            };
            _bookStoreContext.SellerTable.Add(newUser);
            _bookStoreContext.SaveChanges();
            return newUser.Id;
        }

        public void SetCreatedByBuyer(int id)
        {
            BuyerTable buyer = _bookStoreContext.BuyerTable.First(u => u.Id == id);
            buyer.CreatedBy = id;
            _bookStoreContext.SaveChanges();

        }
        public void SetCreatedBySeller(int id)
        {
            SellerTable seller = _bookStoreContext.SellerTable.First(u => u.Id == id);
            seller.CreatedBy = id;
            _bookStoreContext.SaveChanges();

        }
        public List<BuyerModel> getAllBuyers()
        {
            /*the data we get from database is of the type "UsersTable" , we need
            to convert it to "User" type, as data is passed through models and in views we deal
            with model classes i.e. users
            */

            List<BuyerModel> buyers = new List<BuyerModel>();
            var allBuyers = _bookStoreContext.BuyerTable.ToList();
            if (allBuyers?.Any() == true)
            {
                foreach (var user in allBuyers)
                {
                    buyers.Add(_mapper.Map<BuyerModel>(user));
                    /*buyers.Add(new BuyerModel()
                    {
                        Id = user.Id,
                        Name = user.Name,
                        UserName = user.UserName,
                        Password = user.Password,
                        ProfilePictureURL = user.ProfilePictureURL
                    });*/
                }
            }
            //VALIDATING THE AUTOMAPPERS
            
           /* if (buyers?.Any() == true)
            {
                foreach (var user in buyers)
                {
                    BuyerTable buyerModel = _mapper.Map<BuyerTable>(user);
                    Console.WriteLine("-------------Buyer model to buyer table---------------");
                    Console.WriteLine("Buyer table " + user.Name + " " + user.UserName + " " + user.Password + " " + user.Id + " " + user.ProfilePictureURL + "\n");
                    Console.WriteLine("buyer Model " + buyerModel.Name+ " " + buyerModel.UserName + " " + buyerModel.Password + " " + buyerModel.Id + " " + buyerModel.ProfilePictureURL + "\n");
                    Console.WriteLine("----------------------------");

                }
            }*/
            
            //
            return buyers;
        }
        public List<SellerModel> getAllSellers()
        {
            /*the data we get from database is of the type "UsersTable" , we need
            to convert it to "User" type, as data is passed through models and in views we deal
            with model classes i.e. users
            */

            List<SellerModel> sellers = new List<SellerModel>();
            var allSellers = _bookStoreContext.SellerTable.ToList();
            if (allSellers?.Any() == true)
            {
                foreach (var user in allSellers)
                {
                    sellers.Add(_mapper.Map<SellerModel>(user));
                    /*sellers.Add(new SellerModel()
                    {
                        Id = user.Id,
                        Name = user.Name,
                        UserName = user.UserName,
                        Password = user.Password,
                        ProfilePictureURL = user.ProfilePictureURL
                    });*/
                }
            }

            ///validating the automappers
            /*
            if (allSellers?.Any() == true)
            {
                foreach (var user in allSellers)
                {
                    SellerModel sellerModel = _mapper.Map<SellerModel>(user);
                    Console.WriteLine("----------------------------");
                    Console.WriteLine("Seller table " + user.Name + " " + user.UserName + " " + user.Password + " " + user.Id + " " + user.ProfilePictureURL + "\n");
                    Console.WriteLine("Seller Model " + sellerModel.Name + " " + sellerModel.UserName + " " + sellerModel.Password + " " + sellerModel.Id + " " + sellerModel.profilePictureURL + "\n");
                    Console.WriteLine("----------------------------");

                }
            }
            */

            //
            return sellers;
        }
        public BuyerModel? ifBuyerExists(string username, string password)
        {
            List<BuyerModel> allBuyers = new List<BuyerModel>();
            allBuyers = getAllBuyers();
            foreach (var user in allBuyers)
            {
                if (user.UserName == username && user.Password == password)
                {
                    return user;
                }
            }
            return null;
        }
        public SellerModel? ifSellerExists(string username, string password)
        {
            List<SellerModel> allSellers = new List<SellerModel>();
            allSellers = getAllSellers();
            foreach (var user in allSellers)
            {
                if (user.UserName == username && user.Password == password)
                {
                    return user;
                }
            }
            return null;
        }
        public bool ifUserNameExists(string username)
        {
            List<BuyerModel> allBuyers = new List<BuyerModel>();
            allBuyers = getAllBuyers();
            foreach (var user in allBuyers)
            {
                if (user.UserName == username)
                {
                    return true;  //if username already exists, return true
                }
            }
            List<SellerModel> allSellers = new List<SellerModel>();
            allSellers = getAllSellers();
            foreach (var user in allSellers)
            {
                if (user.UserName == username)
                {
                    return true;  //if username already exists, return true
                }
            }

            return false;
        }
        public BuyerModel? GetBuyerById(int id)
        {
            List<BuyerModel> list = getAllBuyers();
            foreach (BuyerModel user in list)
            {
                if (user.Id == id)
                {
                    return user;
                }
            }
            return null;
        }
        public SellerModel? GetSellerById(int id)
        {
            List<SellerModel> list = getAllSellers();
            foreach (SellerModel user in list)
            {
                if (user.Id == id)
                {
                    return user;
                }
            }
            return null;
        }
    }
}
