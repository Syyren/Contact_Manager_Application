namespace Contact_Manager_Application.Models
{
    public class Category
    {
        //Setting up the CategoryID to be used as a foreign key and the category names
        public required string CategoryId { get; set; }
        public required string Name { get; set; }
    }
}
