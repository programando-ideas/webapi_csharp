using Microsoft.AspNetCore.Mvc;
using webapi_csharp.Modelos;
using webapi_csharp.Repositorios;

namespace webapi_csharp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            RPClientes rpCli = new RPClientes();
            return Ok(rpCli.ObtenerClientes());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            RPClientes rpCli = new RPClientes();

            var cliRet = rpCli.ObtenerCliente(id);

            if (cliRet == null)
            {
                var nf = NotFound("El cliente " + id.ToString() + " no existe.");
                return nf;
            }

            return Ok(cliRet);
        }

        [HttpPost("agregar")]
        public IActionResult AgregarCliente(Cliente nuevoCliente)
        {
            RPClientes rpCli = new RPClientes();
            rpCli.Agregar(nuevoCliente);
            return CreatedAtAction(nameof(AgregarCliente), nuevoCliente);
        }
    }
}