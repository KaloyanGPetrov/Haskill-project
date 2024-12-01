namespace Haskill_project.Models
{
    public class Food
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string TypeFood { get; set; }
        public int Quantity { get; set; }
        public string UnitOfMeasurment { get; set; }
        public int Sold { get; set; }
        public int Wasted { get; set; }
        public int Bought { get; set; }
        public string Month { get; set; }

    }
}
