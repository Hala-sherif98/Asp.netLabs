
using Microsoft.AspNetCore.Mvc;
using AspLabDay1.Models;


namespace AspLabDay1.Controllers
{

    public enum Type
    {
        list,
        table
    }
    public class CarsController : Controller
    {
        public IActionResult GetAll()
        {
            var cars = Car.GetCars();
            return View(cars);
            
        }
        public IActionResult GetDetails(string Carmodel, Type? type )
        {
            var car = Car.GetCars().First(c=> c.Model == Carmodel);
            return View(car);

        }
    }
}
