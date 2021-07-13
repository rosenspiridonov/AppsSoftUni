namespace CarRentingSystem.Controllers
{
    using System.Collections.Generic;
    using Data;
    using Microsoft.AspNetCore.Mvc;
    using Models.Cars;
    using System.Linq;

    public class CarsController : Controller
    {
        private readonly ApplicationDbContext db;

        public CarsController(ApplicationDbContext db)
        {
            this.db = db;
        }

        public IActionResult Add() => View(new AddCarFormModel()
        {
            Categories = GetCarCategories(),
        });

        [HttpPost]
        public IActionResult Add(AddCarFormModel input)
        {
            if (!db.Categories.Any(x => x.Id == input.CategoryId))
            {
                ModelState.AddModelError(nameof(input.CategoryId), "Category does not exist");
            }

            if (!ModelState.IsValid)
            {
                input.Categories = GetCarCategories();

                return View(input);
            }

            return Redirect("/");
        }

        private IEnumerable<CategoryViewModel> GetCarCategories()
            => db
                .Categories
                .Select(x => new CategoryViewModel()
                {
                    Id = x.Id,
                    Name = x.Name
                }).ToList();
    }
}
