using AutotraderApi.Models;
using AutotraderApi.Models.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AutotraderApi.Controllers
{
    [Route("cars")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        [HttpDelete("carbyid")]
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


        [HttpPost]
        public ActionResult AddNewCar(CreateCarDto createCarDto)
        {

            var car = new Car
            {
                Id = Guid.NewGuid(),
                Brand = createCarDto.Brand,
                Type = createCarDto.Type,
                Color = createCarDto.Color,
                Myear = createCarDto.Myear
            };

            using (var context = new AutotraderContext())
            {
                try
                {
                    context.Cars.Add(car);
                    context.SaveChanges();
                    return StatusCode(201, new { result = car, message = "Sikeres felvétel" });
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
        }

        [HttpPut("carbyid")]
        public ActionResult UpdateCarById(Guid id, UpdateCarDto updateCarDto)
        {
            using (var context = new AutotraderContext())
            {
                try
                {
                    Car car = new Car { Id = id };
                    car = context.Cars.FirstOrDefault(x => x.Id == id);
                    car.Brand = updateCarDto.Brand;
                    car.Type = updateCarDto.Type;
                    car.Color = updateCarDto.Color;
                    car.Myear = updateCarDto.Myear;
                    car.UpdatedTime = DateTime.Now;
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

        [HttpGet]
        public ActionResult GetCars()
        {
            List<Car> response = new List<Car>();
            using (var context = new AutotraderContext())
            {
                try
                {
                    response = context.Cars.ToList();
                    return StatusCode(200, new { result = response, message = "Sikeres lekérdezés" });
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
        }

        [HttpGet("carbyid")]
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
    }
}
