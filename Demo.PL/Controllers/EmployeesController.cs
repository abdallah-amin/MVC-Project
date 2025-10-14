global using Demo.BLL.DataTransferObjects.Employees;
global using Microsoft.AspNetCore.Mvc.Rendering;

namespace Demo.PL.Controllers;
public class EmployeesController(IEmployeeServices employeeService,
        ILogger<EmployeesController> logger,
        IWebHostEnvironment env, IMapper mapper,
        IDepartmentServices departmentServices) : Controller
{
    [HttpGet]
    public IActionResult Index(string? searchValue)
    {
        if (string.IsNullOrWhiteSpace(searchValue))
            return View(employeeService.GetAll());
        return View(employeeService.GetAll(searchValue));

    }
    [HttpGet]
    public IActionResult Create()
    {
        var departments = departmentServices.GetAll();
        var selectList = new SelectList(departments, "Id", "Name");
        ViewBag.Departments = selectList;
        return View();
    }
    [HttpPost]
    public IActionResult Create(EmployeeRequest request)
    {
        if (!ModelState.IsValid)
            return View(request);

        try
        {
            var result = employeeService.Add(request);
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
    public IActionResult Details(int? id)
    {
        EmployeeDetailsResponse? employee;
        (bool flowControl, IActionResult value) = ValidationEmployeeIdAndFetch(id, out employee);

        if (!flowControl)
            return value;
        return View(employee);
    }
    [HttpGet]
    public IActionResult Edit(int? id)
    {
        EmployeeDetailsResponse? employee;
        (bool flowControl, IActionResult value) = ValidationEmployeeIdAndFetch(id, out employee);

        if (!flowControl)
            return value;
        var departments = departmentServices.GetAll();
        var selectList = new SelectList(departments, "Id", "Name", employee.DepartmentId);
        ViewBag.Departments = selectList;
        return View(mapper.Map<EmployeeUpdateRequest>(employee));
    }
    [HttpPost]
    public IActionResult Edit([FromRoute] int? id, EmployeeUpdateRequest request)
    {
        if (!id.HasValue)
            return BadRequest();
        if (id.Value != request.Id)
            return BadRequest();
        if (!ModelState.IsValid)
            return View(request);

        try
        {
            var result = employeeService.Update(request);
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
    public IActionResult Delete(int? id)
    {
        EmployeeDetailsResponse? employee;
        (bool flowControl, IActionResult value) = ValidationEmployeeIdAndFetch(id, out employee);

        if (!flowControl)
            return value;
        return View(employee);

    }
    [HttpPost, ActionName("Delete")]
    public IActionResult ConfirmDelete(int? id)
    {
        if (!id.HasValue)
            return BadRequest();
        EmployeeDetailsResponse? Employee = null;
        try
        {
            Employee = employeeService.GetById(id.Value);
            var isDeleted = employeeService.Delete(id.Value);
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

    private (bool flowControl, IActionResult value) ValidationEmployeeIdAndFetch(int? id,
    out EmployeeDetailsResponse? employee)
    {
        if (!id.HasValue)
        {
            employee = default;
            return (flowControl: false, value: BadRequest());
        }
        employee = employeeService.GetById(id.Value);
        if (employee == null)
            return (flowControl: false, value: NotFound());
        return (flowControl: true, value: null);
    }

}
