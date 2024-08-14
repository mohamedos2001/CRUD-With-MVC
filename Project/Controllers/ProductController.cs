using Microsoft.AspNetCore.Mvc;
using Project.Models;
using Project.Repository;

namespace Project.Controllers
{
    public class ProductController : Controller
    {
        ProRep pro= new ProRep();
        public IActionResult Index()
        {
            if (ModelState.IsValid)
            {

                List<Product> Emp = pro.GetAll();
                return View(Emp);
            }

            return Content("isvalid");
        }
        public IActionResult Detail(int id)
        {

            Product emp = pro.GetById(id);
            return View(emp);
        }

        public IActionResult NewPro()
        {
            return View();
        }
        public IActionResult SaveNewPro(Product product)
        {
            pro.Insert(product);

            return RedirectToAction("Index");
        }


        public IActionResult Edit(int id)
        {

            Product product = pro.GetById(id);

            return View(product);

        }

        public IActionResult SaveEdit(int id, Product product)
        {
            Product product1 = pro.GetById(id);
            pro.Update(id, product);

            return RedirectToAction("Index");
        }


        public IActionResult Delete(int id)
        {

            pro.Delete(id);

            return RedirectToAction("Index");
        }
    }
}
