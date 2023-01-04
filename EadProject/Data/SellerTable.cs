namespace EadProject.Data
{
    public class SellerTable : BaseClass
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

      //  public string Role { get; set; }
        public string? ProfilePictureURL { get; set; }

        
        //one seller can sell multiple books
       
        public virtual List<BookTable> BooksOffered { get; set; } = new List<BookTable>();
        
    }
}
