using Microsoft.AspNetCore.Mvc;
using CheeseMVC.Models;
using System.Collections.Generic;
using CheeseMVC.ViewModels;
using CheeseMVC.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace CheeseMVC.Controllers
{
    public class CheeseController : Controller
    {
        private readonly CheeseDbContext context;

        public CheeseController(CheeseDbContext dbContext)
        {
            context = dbContext;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            //List<Cheese> cheeses = context.Cheeses.ToList();  // added the include & IList to retrieve the category along with the cheese
            IList<Cheese> cheeses = context.Cheeses.Include(c => c.Category).ToList();

            return View(cheeses);
        }
        // MainViewNodel vm = new MainViewModel(Variable);
        public IActionResult Add()
        {
            AddCheeseViewModel addCheeseViewModel = new AddCheeseViewModel(context.Categories.ToList());  //create the ViewModel with the list of cheese types 
            
            return View(addCheeseViewModel);
        }

        [HttpPost]
        public IActionResult Add(AddCheeseViewModel addCheeseViewModel)
        {
            if (ModelState.IsValid)
            {
                // Add the new cheese to my existing cheeses

                //first get the CheeseCategory
                CheeseCategory newCheeseCategory = context.Categories.Single(c => c.ID == addCheeseViewModel.CategoryID);
               
                Cheese newCheese = new Cheese
                {
                    Name = addCheeseViewModel.Name,
                    Description = addCheeseViewModel.Description,
                    //Type = addCheeseViewModel.Type
                    Category = newCheeseCategory
                };
                
                context.Cheeses.Add(newCheese);
                context.SaveChanges();

                return Redirect("/Cheese");
            }

            return View(addCheeseViewModel);
        }

        public IActionResult Remove()
        {
            ViewBag.title = "Remove Cheeses";
            ViewBag.cheeses = context.Cheeses.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Remove(int[] cheeseIds)
        {
            foreach (int cheeseId in cheeseIds)
            {
                Cheese theCheese = context.Cheeses.Single(c => c.ID == cheeseId);
                context.Cheeses.Remove(theCheese);
            }

            context.SaveChanges();

            return Redirect("/");
        }

        public IActionResult Category(int id)
        {
         if (id == 0)
            {
                return Redirect("/Category");
            }
            CheeseCategory theCategory = context.Categories
                   .Include(cat => cat.Cheeses)
                   .Single(cat => cat.ID == id);

            //the above query gets the cheese category first and then referencing 
            // its cheeses property.

            // another way to do the samer thing, would be to query for the cheeses from the other side
            // of the relationship:
            /*
             IList<heese> theCheeses = context.Cheeses
                  .Include(c => c.Category)
                  .Where(c => c.CategoryID == ID)
                  .ToList();
             
             However, to get the category name is not as easy as the first method.  Using this method, we have to get teh cheese 
             // out of the list, then get the category from the cheese and then get the name of thw category
             
             */


            ViewBag.title = "Cheeses in Category: " + theCategory.Name;
            return View("Index", theCategory.Cheeses);
        }
       
    }
}
