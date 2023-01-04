namespace EadProject.Data
{
    public class BuyerTable : BaseClass
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        //  public string Role { get; set; }
        public string? ProfilePictureURL { get; set; }

        //should have a list of books called cart

       //public List<int> Cart { get; set; } = new List<int>(); 
       public virtual ICollection<BookTable> Cart { get; set; } 

        public BuyerTable()
        {
            Cart = new List<BookTable>();
        }
    }
}
