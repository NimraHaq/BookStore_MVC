
namespace EadProject.Models
{
    public class Order
    {
        //against every book, one order will be generated
        public int OrderNumber { get; set; }
        public string DeliveryAdress { get; set; }
        public BookModel BooksToOrder = new BookModel();
        //seller id is present in the BookModel object
        public int BuyerID { get; set; }

        public int BookQuantity { get; set; }

        public string OrderDelivered { get; set; } //if the seller has delivered the order, he will mark it don
        //after marking it done, it would be removed from the list of his orders.
    }
}
