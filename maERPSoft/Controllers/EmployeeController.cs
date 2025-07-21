using maERPSoft.Data;
using Microsoft.AspNetCore.Mvc;
using maERPSoft.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace maERPSoft.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly AppDbContext _context;
        public EmployeeController(AppDbContext context)
        {
            _context = context; //Getting the ApplicationDbContext that has already been registered in application
        }

        public IActionResult Index()
        {
            IEnumerable<Employee> objEmployeesList = _context.Employee;
            return View(objEmployeesList);
        }
        
        //GET
        public IActionResult Create()
        {
            return View();
        }

        //POST
        // Called when we post the create form
        [HttpPost]
        [ValidateAntiForgeryToken] // Helps in preventing cross site request forgery attacks
        public IActionResult Create(Employee obj)
        {
            //Custom Validations
            var objEmpList = _context.Employee.ToList();
            if (objEmpList.Any(e => e.Name == obj.Name))
            {
                ModelState.AddModelError("Name", "Employee name already exists...!!!");
            }

            //Validate the object received
            if (ModelState.IsValid)
            {

                //Add the emp object to database
                _context.Employee.Add(obj);
                _context.SaveChanges(); // Saved to database

                //Using TempData for alerts
                TempData["success"] = "Employee Created Successfully!";
                //After saving data redirect to index action of category
                return RedirectToAction("Index");
            }
            else
            {
                return View(obj);
            }
        }

        //Get
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var categoryFromDB = _context.Employee.Find(id);
            if (categoryFromDB == null)
            {
                return NotFound();
            }

            return View(categoryFromDB);
        }

        //Post
        // Called when we post the edit category form
        [HttpPost]
        [ValidateAntiForgeryToken] // Helps in preventing cross site request forgery attacks
        public IActionResult Edit(Employee obj)
        {
            //Custom Validations
            var objEmpList = _context.Employee.ToList();
            if (objEmpList.Any(e => e.Name == obj.Name))
            {
                ModelState.AddModelError("Name", "Employee name already exists...!!!");
            }

            //Validate the object received
            if (ModelState.IsValid)
            {

                //Update the category object 
                _context.Employee.Update(obj);
                _context.SaveChanges(); // Saved to database
                                   //Using TempData for alerts
                TempData["success"] = "Employee Edited Successfully!";
                //After saving data redirect to index action of category
                return RedirectToAction("Index");
            }
            else
            {
                return View(obj);
            }
        }



        //Get
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var categoryFromDB = _context.Employee.Find(id);
            if (categoryFromDB == null)
            {
                return NotFound();
            }

            return View(categoryFromDB);
        }

        //Post

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken] // Helps in preventing cross site request forgery attacks
        public IActionResult DeletePOST(int? id)
        {
            var obj = _context.Employee.Find(id);
            if (obj == null)
            {
                return NotFound();
            }


            //Update the category object 
            _context.Employee.Remove(obj);
            _context.SaveChanges(); // Saved to database
                               //Using TempData for alerts
            TempData["success"] = "Category Deleted Successfully!";

            //After saving data redirect to index action of category
            return RedirectToAction("Index");

        }
    }
}
