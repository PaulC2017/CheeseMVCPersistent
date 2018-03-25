using System.ComponentModel.DataAnnotations;


namespace CheeseMVC.ViewModels
{
    public class AddMenuViewModel
    {
        [Required(ErrorMessage = "You must enter a name for the menu")]
        [Display(Name = "Menu Name")]
        public string Name { get; set; }

        /*//default constructor

        public AddMenuViewModel()  // default consstructor needed to make model binding work in the EntityFramework 
        {

        }
         */


    }
}
