global using AutoMapper;
global using Demo.BLL.DataTransferObjects.Departments;
global using Demo.BLL.Services;
global using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Demo.PL.Controllers
{
    public class DepartmentsController(IDepartmentServices departmentServices,
        ILogger<DepartmentsController> logger,
        IWebHostEnvironment env, IMapper mapper) : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var department = await departmentServices.GetAllAsync();
            return View(department);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(DepartmentRequest request)
        {
            // validation => Server side validation
            if (!ModelState.IsValid)
                return View(request);

            try
            {
                var result = await departmentServices.AddAsync(request);
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
        public async Task<IActionResult> Details(int? id)
        {
            if (!id.HasValue)
                return BadRequest();
            var department = await departmentServices.GetByIdAsync(id.Value);
            if (department == null)
                return NotFound();
            return View(department);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (!id.HasValue)
                return BadRequest();
            var department = await departmentServices.GetByIdAsync(id.Value);
            if (department == null)
                return NotFound();
            return View(mapper.Map<DepartmentUpdateRequest>(department));
        }
        [HttpPost]
        public async Task<IActionResult> Edit([FromRoute] int? id, DepartmentUpdateRequest request)
        {
            if (!id.HasValue)
                return BadRequest();
            if (id.Value != request.Id)
                return BadRequest();
            if (!ModelState.IsValid)
                return View(request);

            try
            {
                var result = await departmentServices.UpdateAsync(request);
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
        public async Task<IActionResult> Delete(int? id)
        {
            if (!id.HasValue)
                return BadRequest();
            var department = await departmentServices.GetByIdAsync(id.Value);
            if (department == null)
                return NotFound();
            return View(department);

        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> ConfirmDelete(int? id)
        {
            if (!id.HasValue)
                return BadRequest();
            DepartmentDetailsResponse? department = null;
            try
            {
                department = await departmentServices.GetByIdAsync(id.Value);
                var isDeleted = await departmentServices.DeleteAsync(id.Value);
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
