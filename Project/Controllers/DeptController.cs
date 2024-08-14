using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project.Models;
using Project.Repository;

namespace Project.Controllers
{
    [Authorize]
    public class DeptController : Controller
    {
        AppDbContext context = new AppDbContext();
        EmpRep EmpRep = new EmpRep();
        public IActionResult Index()
        {
            if (ModelState.IsValid)
            {
                
                List<Employee> Emp = EmpRep.GetAll();
                return View(Emp);
            }
            
            return Content("isvalid");
        }
        public IActionResult Detail(int id) {
        
        Employee emp = EmpRep.GetById(id);
            return View(emp);
        }

        public IActionResult NewEmp()
        {
            return View();
        }
        public IActionResult SaveNewEmp(Employee emp)
        {
            EmpRep.Insert(emp);

            return RedirectToAction("Index");
        }


        public IActionResult Edit(int id) { 
        
            Employee employee = EmpRep.GetById(id);

            return View(employee);
        
        }

        public IActionResult SaveEdit(int id,Employee employee)
        {
            Employee employee1 = EmpRep.GetById(id);
            EmpRep.Update(id, employee);

            return RedirectToAction("Index");
        }


        public IActionResult Delete(int id) {

             EmpRep.Delete(id);

            return RedirectToAction("Index");
        }
    }



}
