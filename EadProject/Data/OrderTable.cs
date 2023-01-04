

namespace EadProject.Data
{
    public class OrderTable
    {
        public int Id { get; set; }
        //against every book, one order will be generated
        public string DeliveryAdress { get; set; }

        
        public int BuyerID { get; set; }


        public bool OrderDelivered { get; set; }

        public int BookId { get; set; }
        public virtual BookTable? BooksToOrder { get; set; }


        //seller id is present in the BookModel object
    }
}
