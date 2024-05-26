using CarRental.Dtos.Comment;
using CarRental.Entities;
using CarRental.Repositores;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.Controllers
{
    [Route("api/[controller]/")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        CommentRepository _commentRepository;

        public CommentController(CommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        [HttpGet("list")]
        public List<CatalogComment> GetComments()
        {
            return _commentRepository.GetComments();
        }

        [HttpGet("{id:int}")]
        public CatalogComment GetComment(int id)
        {
            return _commentRepository.GetComment(id);
        }

        [HttpPost("add")]
        public bool AddComment([FromBody] CreateCommentDto comment)
        {
            return _commentRepository.AddComment(comment);
        }

        [HttpDelete("{id:int}")]
        public bool DeleteComment(int id)
        {
            return _commentRepository.DeleteComment(id);
        }

        [HttpPut("{id:int}")]
        public bool UpdateComment(int id, [FromBody] CatalogComment comment)
        {
            return _commentRepository.UpdateComment(id, comment);
        }
    }
}
