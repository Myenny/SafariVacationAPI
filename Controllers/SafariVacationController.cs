using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SafariVacationAPI.Models;

namespace SafariVacationAPI.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class SafariVacationController : ControllerBase
  {
    [HttpGet]
    public ActionResult<IEnumerable<SeenAnimals>> Get()
    {
      var db = new SafariVacationContext();
      return db.SeenAnimals;
    }
    [HttpPost("{id}")]
    public ActionResult<SeenAnimals> Post([FromBody] SeenAnimals animals)
    {
      var db = new SafariVacationContext();
      db.SeenAnimals.Add(animals);
      db.SaveChanges();
      return animals;
    }
    [HttpPut("{id}")]
    public ActionResult<SeenAnimals> Put([FromRoute] int id, [FromBody] SeenAnimals updatedData)
    {
      var db = new SafariVacationContext();
      var newData = db.SeenAnimals.FirstOrDefault(animal => animal.Id == id);

      newData.Species = updatedData.Species;
      newData.CountOfTimesSeen = updatedData.CountOfTimesSeen;
      newData.LocationOfLastSeen = updatedData.LocationOfLastSeen;
      db.SaveChanges();
      return newData;
    }
  }
}