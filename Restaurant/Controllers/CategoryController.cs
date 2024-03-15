using Microsoft.AspNetCore.Mvc;
using Restaurant.Models;
using Restaurant.Data;
using Microsoft.EntityFrameworkCore;
using System.Numerics;
using Microsoft.CodeAnalysis.FlowAnalysis.DataFlow;
using Restaurant.Repository.Base;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;
using Microsoft.AspNetCore.Authorization;

namespace Restaurant.Controllers
{
    [Authorize(Roles = clsRoles.roleAdmin)]
    public class CategoryController : Controller
    {

        public CategoryController(IUnitOfWork _myUnit)
        {
            myUnit = _myUnit;
        }

        //private IRepository<Category> _repository;
        private readonly IUnitOfWork myUnit;
        //private readonly AppDBContext _dbContext;
        //public CategoryController(AppDBContext DbContext)
        //{
        //    _dbContext = DbContext;
        //}
        //public IActionResult Index()
        //{
        //    return View(_repository.FindAll());
        //}

        public async Task<IActionResult> Index()
        {
            var oneCat = myUnit.categories.SelectOne(x => x.CategoryName == "الوجبات");

            var allCat = await myUnit.categories.FindAllAsync("Items");
            return View(allCat);
        }

        public IActionResult New()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult New(Category category)
        {
            if (ModelState.IsValid) 
            {
                if (category.clientFile != null)
                {
                    MemoryStream stream = new MemoryStream();
                    category.clientFile.CopyTo(stream);
                    category.dbImage = stream.ToArray();
                }
                myUnit.categories.AddOne(category);
                TempData["successData"] = "Category has been Added successfully";
                return RedirectToAction("Index");
            }
            else
            {
                return View(category );
            }
        }
        public IActionResult Edit(int? Id) 
        {
            if(Id == null || Id == 0)
            {
                return NotFound();
            }
            var category = myUnit.categories.FindById(Id.Value);
            if(category == null)
            {
                return NotFound();
            }
            return View(category);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category category)
        {
            if(ModelState.IsValid) 
            {
                if (category.clientFile != null)
                {
                    MemoryStream stream = new MemoryStream();
                    category.clientFile.CopyTo(stream);
                    category.dbImage = stream.ToArray();
                }
                myUnit.categories.UpdateOne(category);
                TempData["successData"] = "Category has been Edited successfully";
                return RedirectToAction("Index");
            }
            else
            {
                return View(category);
            }
        }
        public IActionResult Delete(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            var category = myUnit.categories.FindById(Id.Value);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Category category)
        {
            myUnit.categories.DeleteOne(category);
            TempData["successData"] = "Category has been deleted successfully";
            return RedirectToAction("Index");
        }
        //public IActionResult New()
        //{

        //    return View();
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult New(Category categories)
        //{
        //    if(categories.CategoryName == "100")
        //    {
        //        ModelState.AddModelError("CategoryName", "Name can't equal 100");
        //    }
        //    if(ModelState.IsValid)
        //    {
        //        _dbContext.Add(categories);
        //        _dbContext.SaveChanges();
        //        TempData["successData"] = "Category has been added successfully";
        //        return RedirectToAction("Index");
        //    }
        //    else
        //    {
        //        return View(categories);
        //    }
        //}

        //public IActionResult Edit(int? Id)
        //{
        //    if(Id == null || Id <= 0)
        //    {
        //        return NotFound();
        //    }
        //    var category = _dbContext.Category.Find(Id);
        //    if (category == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(category);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult Edit(Category categories)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _dbContext.Update(categories);
        //        _dbContext.SaveChanges();
        //        TempData["successData"] = "Category has been Edited successfully";
        //        return RedirectToAction("Index");
        //    }
        //    else
        //    {
        //        return View(categories);
        //    }
        //}


        //public IActionResult Delete(int? Id)
        //{
        //    if (Id == null || Id <= 0)
        //    {
        //        return NotFound();
        //    }
        //    var category = _dbContext.Category.Find(Id);
        //    if (category == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(category);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult DeleteCategory(int? Id)
        //{
        //    var category = _dbContext.Category.Find(Id);
        //    if(category == null)
        //    {
        //        return NotFound();
        //    }
        //    _dbContext.Remove(category);
        //    _dbContext.SaveChanges();
        //    TempData["successData"] = "Category has been deleted successfully";
        //    return RedirectToAction("Index");
        //}
    }
}
