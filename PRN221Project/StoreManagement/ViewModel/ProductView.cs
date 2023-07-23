namespace StoreManagement.ViewModel
{
    public class ProductView
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Supplier { get; set; }
        public int SupplierId { get; set; }
        public string Category { get; set; }
        public int CategoryId { get; set; }
        public decimal? Price { get; set; }
        public short? UnitInStock { get; set; }
    }
}
