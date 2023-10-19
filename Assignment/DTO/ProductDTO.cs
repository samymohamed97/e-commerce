namespace Assignment.DTO
{
    public class ProductDTO
    {
        public string ProductName { get; set; }
        public string Cateogey { get; set; }
        public IFormFile Image { get; set; }
        public int Price { get; set; }
        public int MinimunQuentity { get; set; }
        public int DiscountRate { get; set; }
    }
}
