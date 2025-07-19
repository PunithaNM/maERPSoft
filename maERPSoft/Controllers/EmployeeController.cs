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
    }
}
