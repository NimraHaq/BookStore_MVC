namespace EadProject.Models
{
    public class SellerModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        //  public string Role { get; set; }
        public string? ProfilePictureURL { get; set; }

        public List<BookModel> BooksOffered { get; set; } = new List<BookModel>();
    }
}
