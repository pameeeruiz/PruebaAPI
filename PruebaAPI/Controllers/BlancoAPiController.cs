using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PruebaAPI.Modelos;

namespace PruebaAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class BlancoAPiController : ControllerBase
    {
        public static List<CatalolgoColores> listcolores = new List<CatalolgoColores>();


        [HttpGet("ObtenSaludo/{nombre}/{edad}")]
        public string ObtenSaludo(string nombre, int edad)
        {
            return $"Holiii {nombre} desde la API <3, tu edad es {edad} años";
        }

        [HttpGet("ObtenColores")]
        public List<CatalolgoColores> ObtenerColores()
        {
            return listcolores;
        }

        [HttpPost("AgregarColor")]
        public IActionResult AgregarColor([FromBody] CatalolgoColores color)
        {
            listcolores.Add(color);
            return Ok();
        }

        [HttpDelete("EliminarColor/{id}")]
        public IActionResult EliminarColor(int id)
        {
            var color = listcolores.FirstOrDefault(c => c.id == id);
            if (color == null)
            {
                return NotFound();
            }
            listcolores.Remove(color);
            return Ok();
        }

        [HttpPut("ActualizarColor/{id}")]
        public IActionResult ActualizarColor(int id, [FromBody] CatalolgoColores colorActualizado)
        {
            var color = listcolores.FirstOrDefault(c => c.id == id);
            if (color == null)
            {
                return NotFound();
            }
            color.NombreColor = colorActualizado.NombreColor;
            return Ok();
        }

    }
}
