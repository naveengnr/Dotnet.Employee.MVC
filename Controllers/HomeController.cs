using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using demoproject.Models;

namespace demoproject.Controllers;

public class HomeController : Controller
{
    private readonly Context _dbContext;

    public HomeController(Context dbContext)
    {
        _dbContext = dbContext;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult GetEmployees(){

        var emp = _dbContext.employee.ToList();

        return View(emp);
    }
public IActionResult GetById(int? id)
{
    if (id == null)
    {
        return View(); 
    }

    var emp = _dbContext.employee.SingleOrDefault(e => e.id == id);

    if (emp == null)
    {
        ViewBag.ErrorMessage = $"Employee with ID {id} is not found.";
        return View("Error");
    }

    return View(emp);
}


    public IActionResult OnPost(Employee employee){

        if(ModelState.IsValid){

        _dbContext.employee.Add(employee);
        _dbContext.SaveChanges();

        return Ok("insertion successfull");
    }
    else{
        return View();
    }
    }

    
}
