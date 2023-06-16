namespace ASP.NetMVC_LapTrinhWebsiteThuongMaiCoBan.Models
{
    public class ProductCategorieViewModel
    {
        public int CategoryId { get; set; }
        public string? CategoryName { get; set; }
        public string? CategoryTitle { get; set; }
        public List<ProductViewModel> Products { get; set; } = new List<ProductViewModel>();
    }
}
