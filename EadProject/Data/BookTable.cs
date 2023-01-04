namespace EadProject.Data
{
    public class BookTable : BaseClassBook
    {
        public int Id { get; set; }
        public string BookName { get; set; }
        public string BookAuthor { get; set; }
        public int Price { get; set; }
        public string shortDescription { get; set; }
        public string Category { get; set; }
        public int NumberOfPages { get; set; }


        public string Language { get; set; }

        public string? BookPictureURL { get; set; }


        public int SellerId { get; set; } //one book can have one seller
       public virtual SellerTable? Seller { get; set ;}
        public virtual ICollection<BuyerTable>? BuyersWithCart { get; set; }

        public BookTable()
        {
            BuyersWithCart = new List<BuyerTable>();
        }

    }
}
