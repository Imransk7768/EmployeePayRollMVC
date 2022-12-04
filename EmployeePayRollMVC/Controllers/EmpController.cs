using BusinessLayer.Services;
using Microsoft.AspNetCore.Mvc;
using ModelLayer.Services;
using System.Collections.Generic;
using System.Linq;

namespace EmployeePayRollMVC.Controllers
{
    public class EmpController : Controller
    {
        IUserBL iUserBl;
        public EmpController(IUserBL iuserBl)
        {
            this.iUserBl = iuserBl;
        }

        public IActionResult Index()
        {
            List<EmployeeModel> lstEmp = new List<EmployeeModel>();
            lstEmp = iUserBl.GetAllEmployees().ToList();

            return View(lstEmp);

        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind] EmployeeModel model)
        {
            if (ModelState.IsValid)
            {
                iUserBl.AddEmployee(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            EmployeeModel model = iUserBl.GetEmpDataById(id);

            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind] EmployeeModel model)
        {
            if (id != model.EmpId)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                iUserBl.UpdateEmployee(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            EmployeeModel model = iUserBl.GetEmpDataById(id);

            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int? id)
        {
            //var emp = iUserBl.GetEmpDataById(id);

            //iUserBl.DeleteEmployee(emp);
            //return RedirectToAction("Index");

            iUserBl.DeleteEmployee(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            EmployeeModel model = iUserBl.GetEmpDataById(id);

            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }
    }
}
