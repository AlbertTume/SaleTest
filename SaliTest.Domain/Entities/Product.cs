namespace SaliTest.Domain.Entities
{
    public class Product
    {
        public long Id { get; set; }
        public string Code { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int Quantity { get; set; }
    }
}