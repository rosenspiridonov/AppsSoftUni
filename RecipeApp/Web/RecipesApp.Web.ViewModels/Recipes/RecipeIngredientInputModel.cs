namespace RecipesApp.Web.ViewModels.Recipes
{
    using System.ComponentModel.DataAnnotations;

    public class RecipeIngredientInputModel
    {
        [Required]
        [MinLength(2)]
        public string Ingredient { get; set; }

        [Required]
        [MinLength(2)]
        public string Quantity { get; set; }
    }
}
