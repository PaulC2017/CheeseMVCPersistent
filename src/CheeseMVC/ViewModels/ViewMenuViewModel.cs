using CheeseMVC.Models;
using System.Collections.Generic;


namespace CheeseMVC.ViewModels
{
    public class ViewMenuViewModel
    {
        public Menu Menu { get; set; }
        public IList<CheeseMenu> Items { get; set; }

        //default constructor
        public ViewMenuViewModel()  // default constructor needed to make model binding work in the EntityFramework 
        {

        }
        public ViewMenuViewModel(Menu name, IList<CheeseMenu> items)
        {
            Menu = name;
            Items = items;
        }
    }


}
