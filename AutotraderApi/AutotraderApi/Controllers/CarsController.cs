﻿using AutotraderApi.Models;
using AutotraderApi.Models.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AutotraderApi.Controllers
{
    [Route("cars")]
    [ApiController]
    public class CarsController : ControllerBase
    {
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

    }
}
