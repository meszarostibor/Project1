using AutotraderApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AutotraderApi.Controllers
{
    [Route("car")]
    [ApiController]
    public class CarByIdController : ControllerBase
    {
        [HttpDelete]
        public ActionResult DeleteCar(Guid id)
        {
            using (var context = new AutotraderContext())
            {
                try
                {
                    Car car = new Car { Id = id };
                    context.Cars.Remove(car);
                    context.SaveChanges();
                    return StatusCode(200, new { result = car, message = "Sikeres törlés" });
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
        }

        [HttpGet]
        public ActionResult GetCarById(Guid id)
        {
            using (var context = new AutotraderContext())
            {
                try
                {
                    Car car = new Car { Id = id };
                    car = context.Cars.FirstOrDefault(x => x.Id == id);
                    return StatusCode(200, new { result = car, message = "Sikeres lekérdezés" });
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
        }

        [HttpPut]

        public ActionResult PutCarById(Guid id, string brand, string type, string color, DateTime myear)
        {
            using (var context = new AutotraderContext())
            {
                try
                {
                    Car car = new Car {};
                    car.Id = id;
                    car.Brand = brand;
                    car.Type = type;
                    car.Color = color;
                    car.Myear = myear;                                      
                    context.Cars.Update(car);
                    context.SaveChanges();
                    return StatusCode(200, new { result = car, message = "Sikeres módosítás" });
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
        }





    }
}
