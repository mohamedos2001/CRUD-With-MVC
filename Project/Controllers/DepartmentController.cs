using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project.Models;
using Project.Repository;
using System.Security.Claims;

namespace Project.Controllers
{
    [Authorize]
    public class DepartmentController : Controller
    {
        AppDbContext context = new AppDbContext();
        DeptRep deptRep = new DeptRep();
        public IActionResult Index()
        {
            string name = User.Identity.Name;
            User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name);
            if (ModelState.IsValid)
            {

                List<Department> dept = deptRep.GetAll();
                return View(dept);
            }
            return Content("is valid");
        }
        public IActionResult Detail(int id)
        {

            Department emp = deptRep.GetById(id);
            return View(emp);
        }

        public IActionResult NewDept()
        {
            return View();
        }
        public IActionResult SaveNewDept(Department emp)
        {
            deptRep.Insert(emp);

            return RedirectToAction("Index");
        }


        public IActionResult Edit(int id)
        {

            Department dept = deptRep.GetById(id);

            return View(dept);

        }

        public IActionResult SaveEdit(int id, Department dept)
        {
            Department dept1= deptRep.GetById(id);
            deptRep.Update(id, dept);

            return RedirectToAction("Index");
        }


        public IActionResult Delete(int id)
        {

            deptRep.Delete(id);

            return RedirectToAction("Index");
        }
    }
}
