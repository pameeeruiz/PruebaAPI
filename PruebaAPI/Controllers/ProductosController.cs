using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using PruebaAPI.Modelos;

namespace PruebaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {

        public static readonly List<Producto> Listproductos = new List<Producto>
        {
            new Producto {
                Id = 1,
                Nombre = "Producto 1",
                Precio = 10.99m,
                Existencia = 5,
                Disponible = true
            },
            new Producto {
                Id = 2,
                Nombre = "Producto 2",
                Precio = 19.99m,
                Existencia = 3,
                Disponible = true
            },
            new Producto {
                Id = 3,
                Nombre = "Producto 3",
                Precio = 5.99m,
                Existencia = 10,
                Disponible = false
            }
        };

        [HttpGet("RespuestaOK")]
        public IActionResult RespuestaOK()
        {
            return Ok();
        }

        [HttpGet("RespuestaOKObjeto")]
        public IActionResult RespuestaOKObjeto()
        {
            Producto objproducto = new Producto();
            objproducto.Nombre = "Producto nuevo";
            return Ok(new { Mensaje = " Objeto Producto", producto = objproducto });
        }

        [HttpGet("RespuestaOKMensaje")]
        public IActionResult RespuestaOKMensaje()
        {
            return Ok(new { Mensaje = "¡Mensaje OK desde API!" });

        }

        [HttpGet("ObtenPorId/{id}")]
        public IActionResult ObtenProductoPorId(int id)
        {
            Producto? consulta = Listproductos.FirstOrDefault(p => p.Id.Equals(id));
            if (consulta is null)
            {
                return NotFound(new { Mensaje = "Producto no encontrado" });
            }
            return Ok(consulta);
        }

        [HttpGet("regresarTodaLista")]
        public ActionResult<List<Producto>> regresarTodaLista()
        {
            return Listproductos;
        }

        [HttpPost("RespuestaCreated")]
        public ActionResult RespuestaCreated(Producto producto)
        {
            Listproductos.Add(producto);
            return Created();
        }

        [HttpPost("RespuestaCreatedAtAction")]
        public ActionResult RespuestaCreatedAtAction(Producto producto)
        {
            Listproductos.Add(producto);
            return Created(nameof(regresarTodaLista), producto);
        }

        [HttpDelete("eliminarRegistro/{id}")]
        public IActionResult eliminarRegistro(int id)
        {
            Producto consulta = Listproductos.FirstOrDefault(x => x.Id.Equals(id));
            if (consulta is null)
            {
                return NotFound(new
                {
                    mensaje = "Producto no encontrado",
                    productoId = id
                });
            }

            Listproductos.Remove(consulta);
            return NoContent();
        }


        [HttpPost("respuestaBadRequestObjeto")]
        public IActionResult respuestaBadRequestObjeto(Producto producto)
        {
            return BadRequest(new { Mensaje = "Error al procesar la solicitud" });
        }

        [HttpPost("respuestaBadRequestOK")]
        public IActionResult respuestaBadRequestOK(Producto producto)
        {

            return Ok(new { Mensaje = "Todo Ok desde BadRequest" });
        }

        [HttpGet("respuestaNotFound")]
        public IActionResult respuestaNotFound(int id)
        {
            Producto consulta = Listproductos.FirstOrDefault(x => x.Id.Equals(id));

            if (consulta is null)
            {
                return NotFound(new 
                { Mensaje = "Producto no encontrado",
                    productoId = id 
                });

            }
            return Ok(consulta);
        }

        [HttpPost("respuestaConflict")]
        public IActionResult respuestaConflict(Producto objproducto)
        {
            Producto consulta = Listproductos.FirstOrDefault(x => x.Id.Equals(objproducto.Id));

            if (consulta is not null)
            {
                Listproductos.Add(objproducto);
            }
            else
            {
                return Conflict(new { Mensaje = "Producto ya existe, no se puede agregar" });
            }
            return Ok(new { Mensaje = "Producto agregado correctamente", producto = objproducto});
        }
    }


}

        
