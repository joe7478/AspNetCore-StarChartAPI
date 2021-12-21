using System.Linq;
using Microsoft.AspNetCore.Mvc;
using StarChart.Data;

namespace StarChart.Controllers
{
    [Route("")]
    [ApiController]
    public class CelestialObjectController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public CelestialObjectController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("{id:int}", Name ="GetById")]
        public IActionResult GetById(int id)
        {
            var maybeObject = _context.CelestialObjects.Find(id);

            if (maybeObject == null)
                return NotFound();

            return Ok(maybeObject);
        }

        [HttpGet("{name}")]
        public IActionResult GetByName(string name)
        {
            var maybeObject = _context.CelestialObjects.Where(x => x.Name == name).ToList();

            if (maybeObject.Count() == 0)
                return NotFound();

            return Ok(maybeObject);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var objects = _context.CelestialObjects.ToList();

            return Ok(objects);
        }
    }
}
