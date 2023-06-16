namespace ASP.NetMVC_LapTrinhWebsiteThuongMaiCoBan.Models
{
    public class ProductDesc
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string? Title { get; set; }
        public string? Details { get; set; }
        public string? ImgUrl { get; set; }
        public Product? Product { get; set; }
    }
}
