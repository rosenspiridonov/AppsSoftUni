namespace RecipesApp.Services.Data
{
    using System.Linq;

    using RecipesApp.Data.Common.Repositories;
    using RecipesApp.Data.Models;
    using RecipesApp.Services.Data.Models;

    public class GetCountsService : IGetCountsService
    {
        private readonly IDeletableEntityRepository<Category> categoriesRepository;
        private readonly IRepository<Image> imagesRepository;
        private readonly IDeletableEntityRepository<Recipe> recipesRepository;
        private readonly IDeletableEntityRepository<Ingredient> ingredientsRepository;

        public GetCountsService(
                IDeletableEntityRepository<Category> categoriesRepository,
                IRepository<Image> imagesRepository,
                IDeletableEntityRepository<Recipe> recipesRepository,
                IDeletableEntityRepository<Ingredient> ingredientsRepository)
        {
            this.categoriesRepository = categoriesRepository;
            this.imagesRepository = imagesRepository;
            this.recipesRepository = recipesRepository;
            this.ingredientsRepository = ingredientsRepository;
        }

        public CountsDto GetCounts()
            => new CountsDto
            {
                RecipesCount = this.recipesRepository.All().Count(),
                CategoriesCount = this.categoriesRepository.All().Count(),
                IngredientsCount = this.ingredientsRepository.All().Count(),
                ImagesCount = this.imagesRepository.All().Count(),
            };
    }
}
