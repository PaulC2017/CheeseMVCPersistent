using System.Collections.Generic;
using System;



namespace CheeseMVC.Models
{
    public class Cheese
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        //public Cheese Type { get; set; } 
        //replaces Type property - replacing use of Enum for cheese types with 
        // CheeseCategory Model/Table
        public int CategoryID { get; set; }
        public CheeseCategory Category { get; set; }

        public IList<CheeseMenu> CheeseMenus{ get; set; }

    }
}
