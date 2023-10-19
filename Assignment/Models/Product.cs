namespace Assignment.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string Cateogey { get; set; }
        public byte[]? Image { get; set; }
        public int Price { get; set; }
        public int MinimunQuentity { get; set; }
        public int DiscountRate { get; set; }
    }
}
