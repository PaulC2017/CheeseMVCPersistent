namespace CheeseMVC.Models
{
    public class Cheese
    {
        public string Name { get; set; }
        public string Description { get; set; }
        //public Cheese Type { get; set; } 
        public CheeseCategory Category { get; set; } //replaces Type property - replacing use of Enum for cheese types with 
                                                     // CheeseCategory Model/Table
        public int CategoryID { get; set; }
        
        public int ID { get; set; }
    }
}
