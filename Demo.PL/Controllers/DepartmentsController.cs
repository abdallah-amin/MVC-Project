using Demo.BLL.Services;
using Microsoft.AspNetCore.Mvc;

namespace Demo.PL.Controllers
{
    public class DepartmentsController(IDepartmentServices departmentServices) : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            var department = departmentServices.GetAll();
            return View(department);
        }
    }
}
