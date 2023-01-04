using System.ComponentModel.DataAnnotations;


namespace EadProject.Models
{
    public class BookModel
    {
        
        public int Id { get; set; }

        [Required]
        [StringLength(40, ErrorMessage = "Must contain at least 3 characters. Should not contain more than 40 characters", MinimumLength = 3)]
        [Display(Name ="Book Name ")]
        public string BookName { get; set; }


        [Required]
        [StringLength(40, ErrorMessage = "Must contain at least 5 characters. Should not contain more than 40 characters", MinimumLength = 5)]
        [Display(Name = "Author Name ")]
        public string BookAuthor { get; set; }

        [Required]
        [Range(20, 20000, ErrorMessage = "Price range should be between Rs.20 - Rs.20000")]
        public int Price { get; set; }


        [Required]
        [StringLength(400, ErrorMessage = "Must contain at least 20 characters. Should not contain more than 400 characters", MinimumLength = 20)]
        [Display(Name = "Short Description  ")]
        public string shortDescription { get; set; }

        [Required]
        public string Category { get; set; }

        [Display(Name = "Number of Pages ")]
        [Range(5, 10000, ErrorMessage = " Range should be between 5 - 10000")]
        public int NumberOfPages { get; set; }

        [Required]
        public string Language { get; set; }

        public int SellerId { get; set; }     //one book can have one seller
                                      
        public SellerModel? Seller { get; set; }

        public IFormFile? BookPicture { get; set; }

        //

        public string? BookPictureURL { get; set; }

        public ICollection<BuyerModel>? BuyersWithCart { get; set; }

        public BookModel()
        {
            BuyersWithCart = new List<BuyerModel>();    
        }

    }
}
