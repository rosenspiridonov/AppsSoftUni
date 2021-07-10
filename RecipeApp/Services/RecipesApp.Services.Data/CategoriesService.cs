namespace RecipesApp.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;

    using RecipesApp.Data.Common.Repositories;
    using RecipesApp.Data.Models;

    public class CategoriesService : ICategoriesService
    {
        private readonly IDeletableEntityRepository<Category> categoriesRepository;

        public CategoriesService(IDeletableEntityRepository<Category> categoriesRepository)
        {
            this.categoriesRepository = categoriesRepository;
        }

        public IEnumerable<KeyValuePair<string, string>> GetAllAsKeyValuePairs() 
            => this.categoriesRepository.All().Select(
                    x => new
                    {
                        x.Id,
                        x.Name,
                    })
                .ToList()
                .Select(
                x => new KeyValuePair<string, string>(x.Id.ToString(), x.Name));
    }
}