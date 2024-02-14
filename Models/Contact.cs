using System.ComponentModel.DataAnnotations;

namespace Contact_Manager_Application.Models
{
    public class Contact
    {
        //setting the properties of the Contact class alongside error handling
        
        public int Id { get; set; }

        //The Required component allows for easy handling with non-nullable properties.
        [Required(ErrorMessage = "Please enter a first name.")]
        //Using regular expression to ensure that the first name string has no numbers in it.
        [RegularExpression(@"^[^\d]+$", ErrorMessage = "Please enter a valid first name.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter a last name.")]
        //Using regular expression to ensure that the last name string has no numbers in it.
        [RegularExpression(@"^[^\d]+$", ErrorMessage = "Please enter a valid last name")]
        public string LastName { get; set; }

        //Using regular expression to check if the string is formatted correctly for a phone number.
        [Required(ErrorMessage = "Please enter a phone number.")]
        [RegularExpression(@"^1-\d{3}-\d{3}-\d{4}$|^\d{3}-\d{3}-\d{4}$", ErrorMessage = "Please enter a valid phone number.")]
        public string Phone { get; set; }

        //Using regular expression to check if the string is formatted correctly for an email.
        [Required(ErrorMessage = "Please enter an Email.")]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Please enter a valid Email.")]
        public string Email { get; set; }

        //nullable attribute "organization"
        public string? Organization { get; set; }

        //Requiring the selection of a category from the dropdown list
        [Required(ErrorMessage = "Please choose a Category.")]
        public string CategoryId { get; set; }

        public Category? Category { get; set; }

        //making the timestamp attribute for inputted data
        public DateTime Log { get; set; }

        //creating the slug that will display a contact name at the end of the url
        public string Slug => 
            FirstName?.Replace(' ', '-').ToLower() + '-' + LastName?.Replace(' ', '-').ToLower();

        //default empty constructor
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

        //constructor that takes in all values for submitting as a proper object
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
