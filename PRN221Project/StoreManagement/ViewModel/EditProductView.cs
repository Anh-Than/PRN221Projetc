namespace StoreManagement.ViewModel
{
    public class EditProductView
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Supplier { get; set; }
        public int? SupplierId { get; set; }
        public string Category { get; set; }
        public int? CategoryId { get; set; }
        public decimal? UnitPrice { get; set; }
        public short? UnitsInStock { get; set; }
    }
}
