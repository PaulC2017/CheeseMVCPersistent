using CheeseMVC.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using CheeseMVC.Data;
using Microsoft.EntityFrameworkCore;

namespace CheeseMVC.ViewModels
{
    public class AddCheeseViewModel
    {
        [Required]
        [Display(Name = "Cheese Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "You must give your cheese a description")]
        public string Description { get; set; }

        /*public CheeseType Type { get; set; }

        public List<SelectListItem> CheeseTypes { get; set; }

            these two properties are replaced by the CheeseCategory Model
        */

        [Required]
        [Display(Name = "Category")]
        public int CategoryID { get; set; }

      
        public List<SelectListItem> CheeseTypes { get; set; }


       





         public AddCheeseViewModel()  // default consstructor needed to make model binding work in the EntityFramework 
         {

         }
         
        public AddCheeseViewModel(IEnumerable<CheeseCategory> categories) {

           


           CheeseTypes = new  List<SelectListItem>();

            foreach (CheeseCategory category in categories.ToList())
          
            {
               

                CheeseTypes.Add(new SelectListItem
                {
                    Value = (category.ID.ToString()),
                    Text = category.Name.ToString()
                   
                });
                
            }
            
            /* foreach (CheeseCategory category in categories)
             

             {
                 new SelectListItem
                 {

                     Value = (category.ID.ToString()),
                     Text = category.Name
                 };
             }
             */

            // This was the code for using the Enum hardcoded cheese types/categories

            /*CheeseTypes = new List<SelectListItem>();

            // <option value="0">Hard</option>
            CheeseTypes.Add(new SelectListItem {
                Value = ((int) CheeseType.Hard).ToString(),
                Text = CheeseType.Hard.ToString()
            });

            CheeseTypes.Add(new SelectListItem
            {
                Value = ((int)CheeseType.Soft).ToString(),
                Text = CheeseType.Soft.ToString()
            });

            CheeseTypes.Add(new SelectListItem
            {
                Value = ((int)CheeseType.Fake).ToString(),
                Text = CheeseType.Fake.ToString()
            });
            */
        }
    }
}
