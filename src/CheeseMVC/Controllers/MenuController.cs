using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CheeseMVC.Data;
using CheeseMVC.Models;
using CheeseMVC.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace CheeseMVC.Controllers
{
    public class MenuController : Controller
    {
        private readonly CheeseDbContext context;

        public MenuController(CheeseDbContext dbContext)
        {
            context = dbContext;
        }

        
        public IActionResult Index()
        {
             List<Menu> menus = context.Menu.ToList();
             return View(menus);
        }
        public IActionResult Add()
        {
            AddMenuViewModel addMenuViewModel = new AddMenuViewModel();
            return View(addMenuViewModel);
        }

        [HttpPost]
        public IActionResult Add(AddMenuViewModel addMenuViewModel)
        {
            if (ModelState.IsValid)
            {
                // Add the new menu to my existing menus
                Menu newMenu = new Menu
                {
                    Name = addMenuViewModel.Name
                  };

                context.Menu.Add(newMenu);
                context.SaveChanges();

                return Redirect("/Menu");
            }
            return View(addMenuViewModel);
        }
        public IActionResult ViewMenu(int id)
        {

           
            Menu menu  = context.Menu.Single(m => m.ID == id);  // get the menu to be displayed

            List<CheeseMenu> items = context     // get the cheeses associated with the menu
                .CheeseMenus
                .Include(item => item.Cheese)
                .Where(cm => cm.MenuID == id)
                .ToList();

            ViewMenuViewModel viewMenuViewModel = new ViewMenuViewModel(menu, items);  // create the ViewMenuViewModel object and pass it to the View
            
            return View(viewMenuViewModel );
        }
        public IActionResult AddItem(int id)
        {
            
            List<Cheese> cheeses = context.Cheeses.ToList();
            
            Menu menu = context.Menu.Single(m => m.ID == id);
            
           return View(new AddMenuItemViewModel(menu,cheeses));

        }
        [HttpPost]
        public IActionResult AddItem(AddMenuItemViewModel addMenuItem)
        {
            if (!ModelState.IsValid) return View(addMenuItem);

            // check to see if the item already exists on the menu
            IList<CheeseMenu> existingItems = context.CheeseMenus
            .Where(cm => cm.CheeseID == addMenuItem.Cheese)
            .Where(cm => cm.MenuID == addMenuItem.menuID).ToList();

            if (existingItems.Count == 0)
            {
                CheeseMenu newMenuItem = new CheeseMenu()
                {
                    CheeseID = addMenuItem.Cheese,
                    MenuID = addMenuItem.menuID
                };
                context.CheeseMenus.Add(newMenuItem);
                context.SaveChanges();
                
            }
            
                return RedirectToAction("ViewMenu" , new { id = addMenuItem.menuID });  //  just display the menu to the user
            
        }


    }
}