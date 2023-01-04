using System.ComponentModel.DataAnnotations;

namespace EadProject.Models
{
    public class UserModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [RegularExpression(@"[^\s]+", ErrorMessage = "Username must not contain spaces.")]
        [Required]
        public string UserName { get; set; }

        [Required]
        [StringLength(8), MinLength(8, ErrorMessage = "Password length is supposed to be 8.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        public string Role { get; set; }

        //the user adds his/her profile picture, we need to deal with that as well
       
        public IFormFile? ProfilePicture { get; set; }

        //
         
        public string? profilePictureURL { get; set; }

        public List<Order> myOrders = new List<Order>(); //for buyer, all placed orders.
                                                         //for seller, all placed orders , current and previous


        public List<BookModel> MyBooks = new List<BookModel>(); 
        //for seller, all the books he offers to sell
        //for buyer, all the books in his cart
        //the books in the buyer cart will be removed when the order is placed.

    }
}
