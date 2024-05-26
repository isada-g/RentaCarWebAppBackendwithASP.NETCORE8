using CarRental.Dtos.Model;
using CarRental.Entities;
using CarRental.Repositores;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModelController : ControllerBase
    {
        private readonly ModelRepository _modelRepository;

        public ModelController(ModelRepository modelRepository)
        {
            _modelRepository = modelRepository;
        }

        [HttpGet("list")]
        public ActionResult<List<Model>> GetModels()
        {
            return _modelRepository.GetModels();
        }

        [HttpGet("{id:int}")]
        public ActionResult<Model> GetModel(int id)
        {
            var model = _modelRepository.GetModel(id);
            if (model == null)
            {
                return NotFound();
            }
            return model;
        }

        [HttpPost("add")]
        public ActionResult AddModel([FromBody] CreateModelDto modelDto)
        {
            if (_modelRepository.AddModel(modelDto))
            {
                return Ok();
            }
            return BadRequest("Model could not be added.");
        }

        [HttpDelete("{id:int}")]
        public ActionResult DeleteModel(int id)
        {
            if (_modelRepository.DeleteModel(id))
            {
                return Ok();
            }
            return NotFound();
        }

        [HttpPut("{id:int}")]
        public ActionResult UpdateModel(int id, [FromBody] Model model)
        {
            if (_modelRepository.UpdateModel(id, model))
            {
                return Ok();
            }
            return BadRequest("Model could not be updated.");
        }
    }
}
