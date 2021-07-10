namespace RecipesApp.Services.Data
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using RecipesApp.Data.Common.Repositories;
    using RecipesApp.Data.Models;
    using RecipesApp.Web.ViewModels.Recipes;

    public class RecipeService : IRecipeService
    {
        private readonly IDeletableEntityRepository<Recipe> recipeRepository;
        private readonly IDeletableEntityRepository<Ingredient> ingredientsRepository;

        public RecipeService(
            IDeletableEntityRepository<Recipe> recipesRepository,
            IDeletableEntityRepository<Ingredient> ingredientsRepository)
        {
            this.recipeRepository = recipesRepository;
            this.ingredientsRepository = ingredientsRepository;
        }

        public async Task CreateAsync(CreateRecipeInputModel input)
        {
            var recipe = new Recipe()
            {
                Name = input.Name,
                Instructions = input.Instructions,
                CookingTime = TimeSpan.FromMinutes(input.CookingTime),
                PreparationTime = TimeSpan.FromMinutes(input.PreparationTime),
                PortionsCount = input.PortionsCount,
                CategoryId = input.CategoryId,
            };

            foreach (var item in input.Ingredients)
            {
                var ingredient = this.ingredientsRepository.All()
                    .FirstOrDefault(x => x.Name == item.Ingredient)
                                 ?? new Ingredient() { Name = item.Ingredient };

                recipe.Ingredients.Add(
                    new RecipeIngredient()
                        {
                            Ingredient = ingredient,
                            Quantity = item.Quantity,
                        });
            }

            await this.recipeRepository.AddAsync(recipe);
            await this.recipeRepository.SaveChangesAsync();
        }
    }
}