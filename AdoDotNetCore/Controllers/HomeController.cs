using AdoDotNetCore.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AdoDotNetCore.Controllers
{
    public class HomeController : Controller
    {
        private readonly EmployeeDataAccessLayer dal;

        public HomeController()
        {
            dal = new EmployeeDataAccessLayer();
        }

        public IActionResult Index()
        {
            List<Employee> emp = dal.getAllEmployee();
            return View(emp);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Employee emp)
        {
            try
            {
                dal.AddEmployee(emp);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public IActionResult Edit(int id)
        {
            Employee emp = dal.getEmployeeById(id);
            return View(emp);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Employee emp)
        {
            try
            {
                dal.UpdateEmployee(emp);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public IActionResult Details(int id)
        {
            Employee emp = dal.getEmployeeById(id);
            return View(emp);
        }

        public IActionResult Delete(int id)
        {
            Employee emp = dal.getEmployeeById(id);
            return View(emp);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Employee emp)
        {
            try
            {
                dal.DeleteEmployee(emp.Id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
