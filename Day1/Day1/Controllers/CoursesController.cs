using Day1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Day1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        ITIdbContext dbcontext;
        public CoursesController(ITIdbContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }
        [HttpGet]
        public ActionResult<List<Course>> getAll()
        {
            List<Course> crss = dbcontext.Courses.ToList();
            if (crss == null) return NotFound();

            return crss;
        }
        [HttpGet("{id:int}")]
        public ActionResult<Course> getById(int id)
        {
            var crs = dbcontext.Courses.FirstOrDefault(c => c.CrsId == id);
            if (crs == null) return NotFound(); 
            return crs;
        }
        [HttpGet("{name}")]
        public ActionResult<List<Course>> getByName(string name)
        {
            var crss = dbcontext.Courses.Where(c => c.CrsName == name).ToList();
            if (crss == null) return NotFound();
            return crss;
        }
        [HttpDelete("{id}")]
        public ActionResult<Course> deleteById(int id)
        {
            var crs = dbcontext.Courses.FirstOrDefault(c => c.CrsId == id);
            if (crs == null) return NotFound();
            dbcontext.Courses.Remove(crs);
            dbcontext.SaveChanges();
            return Ok(crs);
        }
        [HttpPost]
        public ActionResult addCourse(Course crs)
        {
            if (!ModelState.IsValid) return BadRequest();
            dbcontext.Courses.Add(crs);
            dbcontext.SaveChanges();
            return CreatedAtAction("getById", new { id = crs.CrsId }, crs);

        }
        [HttpPut("{id}")]
        public ActionResult Edit(int id,Course crs)
        {
            if (!ModelState.IsValid) return BadRequest();
            if(id != crs.CrsId) return BadRequest();

            dbcontext.Entry(crs).State =Microsoft.EntityFrameworkCore.EntityState.Modified;
            dbcontext.SaveChanges();
            return NoContent(); 

        }

    }
}
