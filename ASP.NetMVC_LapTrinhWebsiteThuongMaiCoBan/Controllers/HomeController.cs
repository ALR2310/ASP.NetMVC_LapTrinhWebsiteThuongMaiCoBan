using ASP.NetMVC_LapTrinhWebsiteThuongMaiCoBan.Data;
using ASP.NetMVC_LapTrinhWebsiteThuongMaiCoBan.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ASP.NetMVC_LapTrinhWebsiteThuongMaiCoBan.Controllers
{
    public class HomeController : Controller
    {
        private readonly MyDbContext _context;
        public HomeController(MyDbContext context)
        {
            _context = context;
        }

        #region Hiển thị sản phẩm lên view và lọc theo danh mục
        public IActionResult Index(string search)
        {
            // Lấy danh sách các danh mục sản phẩm
            var categories = _context.ProductCategory.ToList();

            // Tạo view model từ danh sách các danh mục sản phẩm
            var model = categories.Select(c => new ProductCategorieViewModel
            {
                CategoryId = c.Id,
                CategoryName = c.Name,
                CategoryTitle = c.Title,

                // Truy vấn danh sách sản phẩm theo từng danh mục sản phẩm và tìm kiếm
                Products = _context.Product.Where(p => p.CategoryId == c.Id && (string.IsNullOrEmpty(search) || p.Name.Contains(search)))
                .Select(p => new ProductViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    ImgUrl = p.ImgUrl,
                    Display = p.Display,
                    CPU = p.CPU,
                    RAM = p.RAM,
                    HardDisk = p.HardDisk,
                    GPU = p.GPU,
                    OS = p.OS,
                    Weight = p.Weight,
                    Size = p.Size,
                    Origin = p.Origin,
                    Debut = p.Debut
                }).ToList()
            }).ToList();
            return View(model);
        }
        #endregion
    }
}