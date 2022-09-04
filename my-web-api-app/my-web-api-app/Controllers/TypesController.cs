using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using my_web_api_app.Data;
using my_web_api_app.Models;

namespace my_web_api_app.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypesController : ControllerBase
    {
        private readonly MyDbContext _context;

        public TypesController(MyDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var typeList = _context.Types.ToList();
                return Ok(typeList);
            }
            catch
            {
                return BadRequest();
            }

        }

        [HttpGet("id")]
        public IActionResult GetById(int id)
        {
            var type = _context.Types.SingleOrDefault(type => type.TypeCode == id);
            if (type != null)
            {
                return Ok(type);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult CreateNew(TypeModel model)
        {
            try
            {
                var type = new Type
                {
                    TypeName = model.TypeName
                };
                _context.Add(type);
                _context.SaveChanges();
                return StatusCode(StatusCodes.Status201Created, type);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("id")]
        public IActionResult UpdateTypeById(int id, TypeModel model)
        {
            var type = _context.Types.SingleOrDefault(type => type.TypeCode == id);
            if (type != null)
            {
                type.TypeName = model.TypeName;
                _context.SaveChanges();
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete("id")]
        public IActionResult DeleteTypeById(int id)
        {
            var type = _context.Types.SingleOrDefault(type => type.TypeCode == id);
            if (type != null)
            {
                _context.Remove(type);
                _context.SaveChanges();
                return StatusCode(StatusCodes.Status200OK);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
