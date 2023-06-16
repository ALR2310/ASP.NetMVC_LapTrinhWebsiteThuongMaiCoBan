using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ASP.NetMVC_LapTrinhWebsiteThuongMaiCoBan.Data;
using ASP.NetMVC_LapTrinhWebsiteThuongMaiCoBan.Models;

namespace ASP.NetMVC_LapTrinhWebsiteThuongMaiCoBan.Controllers
{
    public class ProductController : Controller
    {
        private readonly MyDbContext _context;

        public ProductController(MyDbContext context)
        {
            _context = context;
        }

        // GET: Hiển thị sản phẩm lên view và lọc theo danh mục
        public async Task<IActionResult> Index(int? categoryId, string search)
        {
            // Lấy danh sách sản phẩm bao gồm cả thông tin danh mục sản phẩm(Category)
            IQueryable<Product> products = _context.Product.Include(p => p.Category);

            // Nếu có lọc theo danh mục sản phẩm
            if (categoryId != null)
            {
                // Lọc sản phẩm theo mã danh mục
                products = products.Where(p => p.CategoryId == categoryId);
            }

            // Nếu có từ khóa tìm kiếm
            if (!string.IsNullOrEmpty(search))
            {
                // Lọc sản phẩm theo tên chứa từ khóa tìm kiếm
                products = products.Where(p => p.Name.Contains(search));
            }

            // Thêm thông tin danh mục sản phẩm vào kết quả trả về
            products = products.Include(p => p.Category);

            // Lấy danh sách các danh mục sản phẩm để hiển thị lên giao diện
            var categories = await _context.ProductCategory.ToListAsync();

            // Trả về view kèm theo danh sách sản phẩm
            return View(await products.ToListAsync());
        }

        // GET: Product/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Product == null)
            {
                return NotFound();
            }

            var product = await _context.Product
                .Include(p => p.Category)
                .Include(p => p.Desc) // Thêm vào để lấy thông tin ProductDesc
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Tạo Sản Phẩm Mới
        public IActionResult Create(int? categoryId)
        {
            // Lấy CategoryId từ ViewBag
            var categories = _context.ProductCategory.ToList();

            // Tạo SelectList từ danh sách các mục
            ViewData["CategoryId"] = new SelectList(categories, "Id", "Name", categoryId);
            return View();
        }

        // POST: Product/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CategoryId,Name,Price,ImgUrl,Display,CPU,RAM,HardDisk,GPU,OS,Weight,Size,Origin,Debut")] Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.ProductCategory, "Id", "Id", product.CategoryId);
            return View(product);
        }

        // GET: Chỉnh Sửa Sản Phẩm
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Product == null)
            {
                return NotFound();
            }

            var product = await _context.Product.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.ProductCategory, "Id", "Id", product.CategoryId);
            return View(product);
        }

        // POST: Lưu Cập Nhật Sản Phẩm
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CategoryId,Name,Price,ImgUrl,Display,CPU,RAM,HardDisk,GPU,OS,Weight,Size,Origin,Debut")] Product product)
        {
            if (id != product.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.ProductCategory, "Id", "Id", product.CategoryId);
            return View(product);
        }

        // GET: Product/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Product == null)
            {
                return NotFound();
            }

            var product = await _context.Product
                .Include(p => p.Category)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Product == null)
            {
                return Problem("Entity set 'MyDbContext.Product'  is null.");
            }
            var product = await _context.Product.FindAsync(id);
            if (product != null)
            {
                _context.Product.Remove(product);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        //Thêm Dữ Liệu Vào Desc
        public async Task<IActionResult> CreateDesc(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Product.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            var productDesc = new ProductDesc { ProductId = product.Id };

            var viewModel = new ProductAndDescViewModel
            {
                Product = product,
                ProductDesc = productDesc
            };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult SaveProductDesc(ProductDescViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Tạo ra các đối tượng ProductDesc với giá trị từ các trường nhập trong form
                ProductDesc desc1 = new ProductDesc();
                ProductDesc desc2 = new ProductDesc();
                ProductDesc desc3 = new ProductDesc();
                ProductDesc desc4 = new ProductDesc();
                ProductDesc desc5 = new ProductDesc();
                ProductDesc desc6 = new ProductDesc();
                ProductDesc desc7 = new ProductDesc();
                ProductDesc desc8 = new ProductDesc();
                ProductDesc desc9 = new ProductDesc();
                ProductDesc desc10 = new ProductDesc();


                //Kiểm tra xem ProductId có dữ liệu hay không và các trường Title, Details, ImgUrl phải có dữ liệu mới được thêm vào CSDL
                if (model.ProductId != 0 && (!string.IsNullOrEmpty(model.Title) || !string.IsNullOrEmpty(model.Details) || !string.IsNullOrEmpty(model.ImgUrl)))
                {
                    desc1.ProductId = model.ProductId;
                    desc1.Title = model.Title;
                    desc1.Details = model.Details;
                    desc1.ImgUrl = model.ImgUrl;

                    _context.ProductDesc.Add(desc1);
                }

                //Kiểm tra xem ProductId có dữ liệu hay không và các trường Title, Details, ImgUrl phải có dữ liệu mới được thêm vào CSDL
                if (model.ProductId2 != 0 && (!string.IsNullOrEmpty(model.Title2) || !string.IsNullOrEmpty(model.Details2) || !string.IsNullOrEmpty(model.ImgUrl2)))
                {
                    desc2.ProductId = model.ProductId2;
                    desc2.Title = model.Title2;
                    desc2.Details = model.Details2;
                    desc2.ImgUrl = model.ImgUrl2;

                    _context.ProductDesc.Add(desc2);
                }

                //Kiểm tra xem ProductId có dữ liệu hay không và các trường Title, Details, ImgUrl phải có dữ liệu mới được thêm vào CSDL
                if (model.ProductId3 != 0 && (!string.IsNullOrEmpty(model.Title3) || !string.IsNullOrEmpty(model.Details3) || !string.IsNullOrEmpty(model.ImgUrl3)))
                {
                    desc3.ProductId = model.ProductId3;
                    desc3.Title = model.Title3;
                    desc3.Details = model.Details3;
                    desc3.ImgUrl = model.ImgUrl3;

                    _context.ProductDesc.Add(desc3);
                }

                //Kiểm tra xem ProductId có dữ liệu hay không và các trường Title, Details, ImgUrl phải có dữ liệu mới được thêm vào CSDL
                if (model.ProductId4 != 0 && (!string.IsNullOrEmpty(model.Title4) || !string.IsNullOrEmpty(model.Details4) || !string.IsNullOrEmpty(model.ImgUrl4)))
                {
                    desc4.ProductId = model.ProductId4;
                    desc4.Title = model.Title4;
                    desc4.Details = model.Details4;
                    desc4.ImgUrl = model.ImgUrl4;

                    _context.ProductDesc.Add(desc4);
                }

                //Kiểm tra xem ProductId có dữ liệu hay không và các trường Title, Details, ImgUrl phải có dữ liệu mới được thêm vào CSDL
                if (model.ProductId5 != 0 && (!string.IsNullOrEmpty(model.Title5) || !string.IsNullOrEmpty(model.Details5) || !string.IsNullOrEmpty(model.ImgUrl5)))
                {
                    desc5.ProductId = model.ProductId5;
                    desc5.Title = model.Title5;
                    desc5.Details = model.Details5;
                    desc5.ImgUrl = model.ImgUrl5;

                    _context.ProductDesc.Add(desc5);
                }

                //Kiểm tra xem ProductId có dữ liệu hay không và các trường Title, Details, ImgUrl phải có dữ liệu mới được thêm vào CSDL
                if (model.ProductId6 != 0 && (!string.IsNullOrEmpty(model.Title6) || !string.IsNullOrEmpty(model.Details6) || !string.IsNullOrEmpty(model.ImgUrl6)))
                {
                    desc6.ProductId = model.ProductId6;
                    desc6.Title = model.Title6;
                    desc6.Details = model.Details6;
                    desc6.ImgUrl = model.ImgUrl6;

                    _context.ProductDesc.Add(desc6);
                }

                //Kiểm tra xem ProductId có dữ liệu hay không và các trường Title, Details, ImgUrl phải có dữ liệu mới được thêm vào CSDL
                if (model.ProductId7 != 0 && (!string.IsNullOrEmpty(model.Title7) || !string.IsNullOrEmpty(model.Details7) || !string.IsNullOrEmpty(model.ImgUrl7)))
                {
                    desc7.ProductId = model.ProductId7;
                    desc7.Title = model.Title7;
                    desc7.Details = model.Details7;
                    desc7.ImgUrl = model.ImgUrl7;

                    _context.ProductDesc.Add(desc7);
                }

                //Kiểm tra xem ProductId có dữ liệu hay không và các trường Title, Details, ImgUrl phải có dữ liệu mới được thêm vào CSDL
                if (model.ProductId8 != 0 && (!string.IsNullOrEmpty(model.Title8) || !string.IsNullOrEmpty(model.Details8) || !string.IsNullOrEmpty(model.ImgUrl8)))
                {
                    desc8.ProductId = model.ProductId8;
                    desc8.Title = model.Title8;
                    desc8.Details = model.Details8;
                    desc8.ImgUrl = model.ImgUrl8;

                    _context.ProductDesc.Add(desc8);
                }

                //Kiểm tra xem ProductId có dữ liệu hay không và các trường Title, Details, ImgUrl phải có dữ liệu mới được thêm vào CSDL
                if (model.ProductId9 != 0 && (!string.IsNullOrEmpty(model.Title9) || !string.IsNullOrEmpty(model.Details9) || !string.IsNullOrEmpty(model.ImgUrl9)))
                {
                    desc9.ProductId = model.ProductId9;
                    desc9.Title = model.Title9;
                    desc9.Details = model.Details9;
                    desc9.ImgUrl = model.ImgUrl9;

                    _context.ProductDesc.Add(desc9);
                }

                //Kiểm tra xem ProductId có dữ liệu hay không và các trường Title, Details, ImgUrl phải có dữ liệu mới được thêm vào CSDL
                if (model.ProductId10 != 0 && (!string.IsNullOrEmpty(model.Title10) || !string.IsNullOrEmpty(model.Details10) || !string.IsNullOrEmpty(model.ImgUrl10)))
                {
                    desc10.ProductId = model.ProductId10;
                    desc10.Title = model.Title10;
                    desc10.Details = model.Details10;
                    desc10.ImgUrl = model.ImgUrl10;

                    _context.ProductDesc.Add(desc10);
                }

                _context.SaveChanges();

                return RedirectToAction("Details", "Product", new { id = model.ProductId });
            }

            return View(model);
        }



        private bool ProductExists(int id)
        {
            return (_context.Product?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
