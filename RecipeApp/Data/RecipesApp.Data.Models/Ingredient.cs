﻿namespace RecipesApp.Data.Models
{
    using System.Collections.Generic;

    using RecipesApp.Data.Common.Models;

    public class Ingredient : BaseDeletableModel<int>
    {
        public Ingredient()
        {
            this.Recipes = new HashSet<RecipeIngredient>();
        }

        public string Name { get; set; }

        public virtual ICollection<RecipeIngredient> Recipes { get; set; }
    }
}
