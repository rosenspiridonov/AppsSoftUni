namespace CarRentingSystem.Models.Cars
{
    using System.ComponentModel.DataAnnotations;
    using System.Collections.Generic;

    using static Data.DataConstants;

    public class AddCarFormModel
    {
        [Required]
        [StringLength(CarBrandMaxLength, MinimumLength = CarBrandMinLength)]
        public string Brand { get; set; }

        [Required]
        [StringLength(CarModelMaxLength, MinimumLength = CarModelMinLength)]
        public string Model { get; set; }

        [Display(Name="Image Url")]
        [Required]
        [Url]
        public string ImageUrl { get; set; }    

        [StringLength(10000, MinimumLength = CarDescriptionMinLength)]
        public string Description { get; set; }

        [Range(CarYearMinValue, CarYearMaxValue)]
        public int Year { get; set; }

        [Display(Name="Category")]
        public int CategoryId { get; set; }

        public IEnumerable<CategoryViewModel> Categories { get; set; }
    }
}
