using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CheeseMVC.ViewModels
{
    public class AddCategoryViewModel
    {

        [Required(ErrorMessage ="You must enter a name")]
        [Display(Name = "Category Name")]
        public string Name { get; set; }

    }
}
