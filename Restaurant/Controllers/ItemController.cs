using Microsoft.AspNetCore.Mvc;
using Restaurant.Models;
using Restaurant.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;
using Microsoft.AspNetCore.Authorization;


namespace Restaurant.Controllers
{
    [Authorize]
    public class ItemController : Controller
    {
        private readonly IHostingEnvironment _host;
        private readonly AppDBContext _dbContext;
        public ItemController(AppDBContext DbContext, IHostingEnvironment host)
        {
            _host = host;
            _dbContext = DbContext;
        }
        public IActionResult Index()
        { 
            IEnumerable<Item> itemlist = _dbContext.Item.Include(item => item.Category).ToList();
            return View(itemlist);
        }

        public IActionResult New()
        {
            var categories = _dbContext.Category.ToList();
            ViewBag.CategoryList = new SelectList(categories, "Id", "CategoryName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult New(Item item)
        {
            if (item.ItemName == "100")
            {
                ModelState.AddModelError("ItemName", "Name can't equal 100");
            }
            if (ModelState.IsValid)
            {
                string fileName = string.Empty;
                if(item.clientFile != null)
                {
                    string myUpload = Path.Combine(_host.WebRootPath, "images");
                    fileName = item.clientFile.FileName;
                    string fullPath = Path.Combine(myUpload, fileName);
                    item.clientFile.CopyTo(new FileStream(fullPath,FileMode.Create));
                    item.ImagePath = fileName;
                }
                _dbContext.Add(item);
                _dbContext.SaveChanges();
                TempData["successData"] = "Item has been added successfully";
                return RedirectToAction("Index");
            }
            else
            {
                return View(item);
            }
        }

        public IActionResult Edit(int? Id)
        {
            if (Id == null || Id <= 0)
            {
                return NotFound();
            }
            var item = _dbContext.Item.Find(Id);
            if (item == null)
            {
                return NotFound();
            }
            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Item item)
        {
            if (ModelState.IsValid)
            {
                string fileName = string.Empty;
                if (item.clientFile != null)
                {
                    string myUpload = Path.Combine(_host.WebRootPath, "images");
                    fileName = item.clientFile.FileName;
                    string fullPath = Path.Combine(myUpload, fileName);
                    item.clientFile.CopyTo(new FileStream(fullPath, FileMode.Create));
                    item.ImagePath = fileName;
                }
                _dbContext.Update(item);
                _dbContext.SaveChanges();
                TempData["successData"] = "Item has been Edited successfully";
                return RedirectToAction("Index");
            }
            else
            {
                return View(item);
            }
        }

        public IActionResult Delete(int? Id)
        {
            if (Id == null || Id <= 0)
            {
                return NotFound();
            }
            var item = _dbContext.Item.Find(Id);
            if (item == null)
            {
                return NotFound();
            }
            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteItem(int? Id)
        {
            var item = _dbContext.Item.Find(Id);
            if(item == null)
            { 
                return NotFound();
            }
            _dbContext.Remove(item);
            _dbContext.SaveChanges();
            TempData["successData"] = "Item has be Deleted successfully";
            return RedirectToAction("Index");

        }

    }
}
