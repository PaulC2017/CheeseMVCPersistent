using System.Collections.Generic;
using System.Linq;
using CheeseMVC.Models;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace CheeseMVC.ViewModels
{
    public class AddMenuItemViewModel
    {
        public int Cheese { get; set; }
        public int menuID { get; set; }
        public Menu Menu { get; set; }

        public List<SelectListItem> Cheeses { get; set; }

       


        //default constructor

        public AddMenuItemViewModel()  // default consstructor needed to make model binding work in the EntityFramework 
        {

        }
        
        public AddMenuItemViewModel(Menu menu, IEnumerable<Cheese> cheese)  // constructor to create a list of cheeses that can be added to menu
        {
           
            Menu = menu;

            Cheeses = new List<SelectListItem>();
            foreach (var addCheese in cheese)
            {
                Cheeses.Add(new SelectListItem
                {
                    Value = addCheese.ID.ToString(),
                    Text = addCheese.Name
                });
            }
           
        }

    }

    
   

}
