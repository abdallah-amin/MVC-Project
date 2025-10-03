using Demo.BLL.DataTransferObjects;
using Demo.BLL.Services;
using Microsoft.AspNetCore.Mvc;

namespace Demo.PL.Controllers
{
    public class DepartmentsController(IDepartmentServices departmentServices,
        ILogger<DepartmentsController> logger,
        IWebHostEnvironment env) : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            var department = departmentServices.GetAll();
            return View(department);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(DepartmentRequest request)
        {
            // validation => Server side validation
            if (!ModelState.IsValid)
                return View(request);

            try
            {
                var result = departmentServices.Add(request);
                if (result > 0)
                    return RedirectToAction(nameof(Index));
                else
                    ModelState.AddModelError(string.Empty, "Sorry you can't Add Department Now");
            }
            catch (Exception ex)
            {
                if (env.IsDevelopment())
                    ModelState.AddModelError(string.Empty, ex.Message);
                else
                    logger.LogError(ex, ex.Message);
            }
            return View(request);
        }

    }
}
