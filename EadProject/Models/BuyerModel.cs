namespace EadProject.Models
{
    public class BuyerModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        //  public string Role { get; set; }
        public string? ProfilePictureURL { get; set; }

        public ICollection<BookModel> Cart { get; set; }

        public BuyerModel()
        {
            Cart = new List<BookModel>();
        }
    }
}
