using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PruebaAPI.Modelos;

namespace PruebaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogoColoresController : ControllerBase
    {
        [HttpPost("insertaColor")]
        public IActionResult InsertaColor( CatalolgoColores color)
        {
            using (var db = new Data.AppDbContext())
            {
                db.CatalogoColores.Add(color);
                db.SaveChanges();
            }
            return Ok(new { Mensaje = "Color dado de alta" });
        }
    }
}
