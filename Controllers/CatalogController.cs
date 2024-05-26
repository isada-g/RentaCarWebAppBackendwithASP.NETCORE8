using CarRental.Dtos.Catalog;
using CarRental.Entities;
using CarRental.Repositores;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.Controllers
{
    [Route("api/[controller]/")]
    [ApiController]
    public class CatalogController : ControllerBase
    {
        CatalogRepository _CatalogRepository;

        public CatalogController(CatalogRepository CatalogRepository)
        {
            _CatalogRepository = CatalogRepository;
        }

        [HttpGet("list")]
        public List<Catalog> GetCatalogs()
        {
            return _CatalogRepository.GetCatalogs();
        }

        [HttpGet("{id:int}")]
        public Catalog GetCatalog(int id)
        {
            return _CatalogRepository.GetCatalog(id);
        }

        [HttpPost("add")]
        public bool AddCatalog([FromBody] CreateCatalogDto catalog)
        {
            return _CatalogRepository.AddCatalog(catalog);
        }

        [HttpDelete("{id:int}")]
        public bool DeleteCatalog(int id)
        {
            return _CatalogRepository.DeleteCatalog(id);
        }

        [HttpPut("{id:int}")]
        public bool UpdateCatalog(int id, [FromBody] Catalog Catalog)
        {
            return _CatalogRepository.UpdateCatalog(id, Catalog);
        }
    }
}
