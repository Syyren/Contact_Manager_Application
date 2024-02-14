using System.ComponentModel.DataAnnotations;

namespace Contact_Manager_Application.Models
{
    public class Contact
    {
        //setting the properties of the Contact class alongside error handling
        
        public int Id { get; set; }

        //The Required component allows for easy handling with non-nullable properties.
        [Required(ErrorMessage = "Please enter a first name.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter a last name.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please enter a phone number.")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Please enter an Email.")]
        public string Email { get; set; }

        public string? Organization { get; set; }

        [Required(ErrorMessage = "Please choose a Category.")]
        public string CategoryId { get; set; }

        public Category? Category { get; set; }

        public DateTime Log { get; set; }

        public string Slug => FirstName?.Replace(' ', '-').ToLower() + '-' + LastName?.Replace(' ', '-').ToLower();

        public Contact()
        {
            Id = 0;
            FirstName = "None";
            LastName = "None";
            Phone = "None";
            Email = "None";
            CategoryId = "U";
            Organization = null;
            Log = DateTime.Now;
        }

        public Contact(int id, string firstName, string lastName, string phone, string email, string category, string? organization)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Phone = phone;
            Email = email;
            CategoryId = category;
            Organization = organization;
            Log = DateTime.Now;
        }
    }
}
