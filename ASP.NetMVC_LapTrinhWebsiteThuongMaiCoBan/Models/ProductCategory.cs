namespace ASP.NetMVC_LapTrinhWebsiteThuongMaiCoBan.Models
{
    public class ProductCategory
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Title { get; set; }
        public List<Product>? Products { get; set; }
    }
}
