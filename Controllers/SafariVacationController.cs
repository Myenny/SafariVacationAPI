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
    [HttpPost]
    public ActionResult<SeenAnimals> Post([FromBody] SeenAnimals animals)
    {
      var db = new SafariVacationContext();
      db.SeenAnimals.Add(animals);
      db.SaveChanges();
      return animals;
    }
    [HttpPut]
    public ActionResult<SeenAnimals> Put([FromBody] SeenAnimals location)
    {
      var db = new SafariVacationContext();
      db.SeenAnimals.Add(location);
      db.SaveChanges();
      return location;
    }
  }
}