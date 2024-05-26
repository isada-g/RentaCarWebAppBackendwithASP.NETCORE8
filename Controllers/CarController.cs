using CarRental.Dtos.Car;
using CarRental.Entities;
using CarRental.Repositores;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.Controllers
{
    [Route("api/[controller]/")]
    [ApiController]
    public class CarController : ControllerBase
    {
        CarRepository _carRepository;

        public CarController(CarRepository CarRepository)
        {
            _carRepository = CarRepository;
        }

        [HttpGet("list")]
        public List<Car> GetCars()
        {
            return _carRepository.GetCars();
        }

        [HttpGet("{id:int}")]
        public Car GetCar(int id)
        {
            return _carRepository.GetCar(id);
        }

        [HttpPost("add")]
        public IActionResult AddCar([FromBody] CreateCarDto carDto)
        {
            if (ModelState.IsValid)
            {
                var result = _carRepository.AddCar(carDto);
                if (result)
                {
                    return Ok();
                }
                return StatusCode(500, "A problem happened while handling your request.");
            }
            return BadRequest(ModelState);
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteCar(int id)
        {
            var result = _carRepository.DeleteCar(id);
            if (result)
            {
                return Ok();
            }
            return StatusCode(500, "A problem happened while handling your request.");
        }

        [HttpPut("{id:int}")]
        public IActionResult UpdateCar(int id, [FromBody] CreateCarDto carDto)
        {
            if (ModelState.IsValid)
            {
                var car = new Car
                {
                    ID = id,
                    License = carDto.License,
                    Km = carDto.Km,
                    ModelId = carDto.ModelId,
                    // Diğer alanlar...
                };

                var result = _carRepository.UpdateCar(id, car);
                if (result)
                {
                    return Ok();
                }
                return StatusCode(500, "A problem happened while handling your request.");
            }
            return BadRequest(ModelState);
        }
    }
}
