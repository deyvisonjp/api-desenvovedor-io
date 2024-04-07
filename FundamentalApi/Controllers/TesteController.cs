using FundamentalApi.Model;
using Microsoft.AspNetCore.Mvc;

namespace FundamentalApi.Controllers
{
    [ApiController]
    [Route("api/demo")]
    public class TesteController : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(typeof(Teste), StatusCodes.Status200OK)]
        public IActionResult Get() 
        {
            return Ok(new Teste { Id = 1, Nome = "Batata"});    
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(Teste), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Get(int id)
        {
            return Ok(new Teste { Id = id, Nome = "Batata" });
        }

        [HttpPost]
        [ProducesResponseType(typeof(Teste), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Post([FromBody] Teste produto) 
        {
            // 201
            return CreatedAtAction("Get", new {id = produto.Id}, produto);
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(typeof(Teste), StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Put(int id, [FromBody] Teste produto)
        {
            if (id != produto.Id) return BadRequest();
            // 204 - Tudo certo, porem nada para mostrar
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(typeof(Teste), StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Delete(int id, [FromBody] Teste produto)
        {
            if (id != produto.Id) return BadRequest();
            // 204 - Tudo certo, porem nada para mostrar
            return NoContent();
        }


    }
}