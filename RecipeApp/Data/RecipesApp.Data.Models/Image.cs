namespace RecipesApp.Data.Models
{
    using System;

    using RecipesApp.Data.Common.Models;

    public class Image : BaseModel<string>
    {
        public Image()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public int RecipeId { get; set; }

        public virtual Recipe Recipe { get; set; }

        public string Extension { get; set; }

        public string AddedByUserId { get; set; }

        public virtual ApplicationUser AddedByUser { get; set; }
    }
}
