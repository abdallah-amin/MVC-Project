global using Demo.BLL.DataTransferObjects.Employees;
global using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;

namespace Demo.PL.Controllers;
public class EmployeesController(IEmployeeServices employeeService,
        ILogger<EmployeesController> logger,
        IWebHostEnvironment env, IMapper mapper,
        IDepartmentServices departmentServices) : Controller
{
    [HttpGet]
    public async Task<IActionResult> Index(string? searchValue)
    {
        if (string.IsNullOrWhiteSpace(searchValue))
            return View(await employeeService.GetAllAsync());
        return View(await employeeService.GetAllAsync(searchValue));

    }
    [HttpGet]
    public async Task<IActionResult> Create()
    {
        var departments = await departmentServices.GetAllAsync();
        var selectList = new SelectList(departments, "Id", "Name");
        ViewBag.Departments = selectList;
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Create(EmployeeRequest request)
    {
        if (!ModelState.IsValid)
            return View(request);

        try
        {
            var result = await employeeService.AddAsync(request);
            if (result > 0)
            {
                TempData["Message"] = $"Employee {request.Name} Created";
                return RedirectToAction(nameof(Index));
            }
            else
                ModelState.AddModelError(string.Empty, "Sorry you can't Add Employee Now");
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
    public async Task<IActionResult> Details(int? id)
    {
        var result = await ValidationEmployeeIdAndFetch(id);

        if (!result.flowControl)
            return result.value;
        return View(result.employee);
    }
    [HttpGet]
    public async Task<IActionResult> Edit(int? id)
    {
        var result = await ValidationEmployeeIdAndFetch(id);

        if (!result.flowControl)
            return result.value;
        var departments = await departmentServices.GetAllAsync();
        var selectList = new SelectList(departments, "Id", "Name", result.employee.DepartmentId);
        ViewBag.Departments = selectList;
        return View(mapper.Map<EmployeeUpdateRequest>(result.employee));
    }
    [HttpPost]
    public async Task<IActionResult> Edit([FromRoute] int? id, EmployeeUpdateRequest request)
    {
        if (!id.HasValue)
            return BadRequest();
        if (id.Value != request.Id)
            return BadRequest();
        if (!ModelState.IsValid)
            return View(request);

        try
        {
            var result = await employeeService.UpdateAsync(request);
            if (result > 0)
                return RedirectToAction(nameof(Index));
            else
                ModelState.AddModelError(string.Empty, "Sorry you can't update Employee Now");
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
        var result = await ValidationEmployeeIdAndFetch(id);

        if (!result.flowControl)
            return result.value;
        return View(result.employee);

    }
    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> ConfirmDelete(int? id)
    {
        if (!id.HasValue)
            return BadRequest();
        EmployeeDetailsResponse? Employee = null;
        try
        {
            Employee = await employeeService.GetByIdAsync(id.Value);
            var isDeleted = await employeeService.DeleteAsync(id.Value);
            if (isDeleted)
                return RedirectToAction(nameof(Index));
            else
                ModelState.AddModelError(string.Empty, "Sorry you can't update Employee Now");
        }
        catch (Exception ex)
        {
            if (env.IsDevelopment())
                ModelState.AddModelError(string.Empty, ex.Message);
            else
                logger.LogError(ex, ex.Message);
        }
        return View(Employee);
    }

    private async Task<(bool flowControl, IActionResult value, EmployeeDetailsResponse? employee)>
        ValidationEmployeeIdAndFetch(int? id)
    {
        if (!id.HasValue)
        {
            return (flowControl: false, value: BadRequest(), null);
        }
        var employee = await employeeService.GetByIdAsync(id.Value);
        if (employee == null)
            return (flowControl: false, value: NotFound(), employee);
        return (flowControl: true, value: null, employee);
    }

}
