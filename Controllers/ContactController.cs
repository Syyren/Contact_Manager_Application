using Contact_Manager_Application.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Contact_Manager_Application.Controllers
{
    public class ContactController : Controller
    {
        //declaring the contact context class as an object that is a property of the controller
        private ContactContext context { get; set; }

        //setting the constructor that takes in the context as a parameter and applies it to the property
        public ContactController(ContactContext ctx) { context = ctx; }

        //action method that returns the index view
        public IActionResult Index()
        {
            //ensures the loading of the categories
            var contacts = context.Contacts.Include(contact => contact.Category).OrderBy(
                contact => contact.FirstName).ToList();
            return View(contacts); //returns a view that has a table with a list of the contacts in the database
        }

        //action method that gets the details of a specified contact via its id
        [HttpGet]
        public IActionResult Details(int id)
        {
            //ensures the loading of the category
            var contact = context.Contacts.Include(c => c.Category).FirstOrDefault(c => c.Id == id);
            return View(contact); //returns a view that shows the details of that specific id
        }

        //action method that gets the necessary information to add a new contact
        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            ViewBag.Categories = context.Categories.OrderBy(category => category.Name).ToList();
            return View("Edit", new Contact()); //returns a blank edit view to enter in the details
        }

        //action method that loads the necessary information to edit a contact
        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            ViewBag.Categories = context.Categories.OrderBy(category => category.Name).ToList();
            var contact = context.Contacts.Find(id);
            return View(contact); //returns a filled in view to edit a contact's details
        }

        //action method that determines whether the input is an add or edit form and then posts the relevant data
        [HttpPost]
        public IActionResult Edit(Contact contact)
        {
            if (ModelState.IsValid)
            {
                if (contact.Id == 0)
                    context.Contacts.Add(contact);
                else
                    context.Contacts.Update(contact);
                context.SaveChanges();
                return RedirectToAction("Details", "Contact", contact); 
                //returns to the details page after saving the changes
            }
            else
            {
                ViewBag.Action = (contact.Id == 0) ? "Add" : "Edit";
                ViewBag.Categories = context.Categories.OrderBy(category => category.Name).ToList();
                return View(contact); //returns to the index after adding the new contact
            }
        }

        //action method that gets the necessary information to delete a contact via id
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var contact = context.Contacts.Find(id);
            return View(contact); //returns a view with the information for the contact being deleted
        }

        //action method that posts a deletion of a given contact
        [HttpPost]
        public IActionResult Delete(Contact contact)
        {
            context.Contacts.Remove(contact);
            context.SaveChanges();
            return RedirectToAction("Index", "Contact"); //returns the index view after deletion is successful
        }

        //action method for error handling, returns the error view
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
