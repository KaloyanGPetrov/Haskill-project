using System.ComponentModel.DataAnnotations.Schema;

namespace Haskill_project.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateOnly ExperationDate { get; set; }
        public bool Expired { get; set; }
        public float Quantity { get; set; }
        public float Remaining { get; set; }

        
        public int FoodId { get; set; }


    }
}
