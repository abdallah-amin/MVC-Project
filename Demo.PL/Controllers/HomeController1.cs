namespace Demo.PL.Controllers;
public class EmployeesController(IEmployeeServices employeeService,
        ILogger<EmployeesController> logger,
        IWebHostEnvironment env, IMapper mapper) : Controller
{
    [HttpGet]
    public IActionResult Index()
    {
        var Employees = employeeService.GetAll();
        ViewData["Hello"] = "Hello From Employee Index";
        return View(Employees);
    }
}
