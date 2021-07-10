namespace RecipesApp.Services.Data
{
    using System.Threading.Tasks;

    using RecipesApp.Web.ViewModels.Recipes;

    public interface IRecipeService
    {
        Task CreateAsync(CreateRecipeInputModel input);
    }
}
