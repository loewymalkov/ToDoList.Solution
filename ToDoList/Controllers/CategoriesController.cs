using Microsoft.AspNetCore.Mvc;
using ToDoList.Models;
using System.Collections.Generic;
using System.Linq;

namespace ToDoList.Controllers
{
  public class CategoriesController : Controller
  {
    private readonly ToDoListContext _db;

    public CategoriesController(ToDoListContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Category> model = _db.Categories.ToList();
      return View(model);
    }
    public ActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public ActionResult Create(Category category)
    {
        _db.Categories.Add(category);
        _db.SaveChanges();
        return RedirectToAction("Index");
    }
    public ActionResult Details(int id)
    {
        Category thisCategory = _db.Categories.FirstOrDefault(categories => categories.CategoryId == id);
        return View(thisCategory);
    }

    public ActionResult Delete(int id)
    {
        var thisCategory = _db.Categories.FirstOrDefault(categories => categories.CategoryId == id);
        return View(thisCategory);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
        var thisCategory = _db.Categories.FirstOrDefault(categories => categories.CategoryId == id);
        _db.Categories.Remove(thisCategory);
        _db.SaveChanges();
        return RedirectToAction("Index");
    }
  }
}