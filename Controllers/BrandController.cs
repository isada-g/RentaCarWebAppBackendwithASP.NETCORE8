using CarRental.Entities;
using CarRental.Repositores;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.Controllers
{
    [Route("api/[controller]/")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        BrandRepository _brandRepository;

        public BrandController(BrandRepository brandRepository)
        {
            _brandRepository = brandRepository;
        }

        [HttpGet("list")]
        public List<Brand> GetBrands()
        {
            return _brandRepository.GetBrands();
        }

        [HttpGet("{id:int}")]
        public Brand GetBrand(int id)
        {
            return _brandRepository.GetBrand(id);
        }

        [HttpPost("add")]
        public bool AddBrand([FromBody] Brand brand)
        {
            return _brandRepository.AddBrand(brand);
        }

        [HttpDelete("{id:int}")]
        public bool DeleteBrand(int id)
        {
            return _brandRepository.DeleteBrand(id);
        }

        [HttpPut("{id:int}")]
        public bool UpdateBrand(int id, [FromBody] Brand brand)
        {
            return _brandRepository.UpdateBrand(id, brand);
        }
    }
}
