using System.ComponentModel.DataAnnotations;

namespace ASP.NetMVC_LapTrinhWebsiteThuongMaiCoBan.Models
{
    public class Product
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 5)]
        public string Name { get; set; } = string.Empty;
        [Required]
        public decimal Price { get; set; }
        [Url]
        public string? ImgUrl { get; set; }
        public string? Display { get; set; }
        public string? CPU { get; set; }
        public string? RAM { get; set; }
        public string? HardDisk { get; set; }
        public string? GPU { get; set; }
        public string? OS { get; set; }
        public string? Weight { get; set; }
        public string? Size { get; set; }
        public string? Origin { get; set; }
        public string? Debut { get; set; }
        public ProductCategory? Category { get; set; }
        public List<ProductDesc>? Desc { get; set; }
    }
}
