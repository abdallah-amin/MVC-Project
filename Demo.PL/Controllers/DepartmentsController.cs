global using AutoMapper;
global using Demo.BLL.DataTransferObjects.Departments;
global using Demo.BLL.Services;
global using Microsoft.AspNetCore.Mvc;

namespace Demo.PL.Controllers
{
    public class DepartmentsController(IDepartmentServices departmentServices,
        ILogger<DepartmentsController> logger,
        IWebHostEnvironment env, IMapper mapper) : Controller
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
        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (!id.HasValue)
                return BadRequest();
            var department = departmentServices.GetById(id.Value);
            if (department == null)
                return NotFound();
            return View(department);
        }
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (!id.HasValue)
                return BadRequest();
            var department = departmentServices.GetById(id.Value);
            if (department == null)
                return NotFound();
            return View(mapper.Map<DepartmentUpdateRequest>(department));
        }
        [HttpPost]
        public IActionResult Edit([FromRoute] int? id, DepartmentUpdateRequest request)
        {
            if (!id.HasValue)
                return BadRequest();
            if (id.Value != request.Id)
                return BadRequest();
            if (!ModelState.IsValid)
                return View(request);

            try
            {
                var result = departmentServices.Update(request);
                if (result > 0)
                    return RedirectToAction(nameof(Index));
                else
                    ModelState.AddModelError(string.Empty, "Sorry you can't update Department Now");
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
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (!id.HasValue)
                return BadRequest();
            var department = departmentServices.GetById(id.Value);
            if (department == null)
                return NotFound();
            return View(department);

        }
        [HttpPost, ActionName("Delete")]
        public IActionResult ConfirmDelete(int? id)
        {
            if (!id.HasValue)
                return BadRequest();
            DepartmentDetailsResponse? department = null;
            try
            {
                department = departmentServices.GetById(id.Value);
                var isDeleted = departmentServices.Delete(id.Value);
                if (isDeleted)
                    return RedirectToAction(nameof(Index));
                else
                    ModelState.AddModelError(string.Empty, "Sorry you can't update Department Now");
            }
            catch (Exception ex)
            {
                if (env.IsDevelopment())
                    ModelState.AddModelError(string.Empty, ex.Message);
                else
                    logger.LogError(ex, ex.Message);
            }
            return View(department);
        }

    }
}
