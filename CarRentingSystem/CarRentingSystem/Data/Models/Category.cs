namespace CarRentingSystem.Data.Models
{
    using System.Collections.Generic;

    public class Category
    {
        public Category()
        {
            this.Cars = new HashSet<Car>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public virtual IEnumerable<Car> Cars { get; set; }
    }
}
