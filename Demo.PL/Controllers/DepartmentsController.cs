using Demo.BLL.Services;
using Microsoft.AspNetCore.Mvc;

namespace Demo.PL.Controllers
{
    public class DepartmentsController : Controller
    {
        private IDepartmentServices _DepartmentServices;
        public DepartmentsController(IDepartmentServices DepartmentServices)
        {
            _DepartmentServices = DepartmentServices;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
