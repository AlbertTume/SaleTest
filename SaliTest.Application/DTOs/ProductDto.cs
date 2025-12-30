namespace SaliTest.Application.DTOs
{
    public class ProductDto
    {
        public long Id { get; set; }
        public string Code { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int Quantity { get; set; }
    }
}
