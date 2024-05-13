using GestaoProdutosAg.API.Application.DTOs;
using GestaoProdutosAg.API.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GestaoProdutosAg.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FornecedorController : ControllerBase
    {
        private readonly IFornecedorService _fornecedorService;

        public FornecedorController(IFornecedorService fornecedorService)
        {
            _fornecedorService = fornecedorService;
        }


        // GET: api/<FornecedorController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<FornecedorController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<FornecedorController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] FornecedorDTO fornecedorDto)
        {
            try
            {
                await _fornecedorService.AddAsync(fornecedorDto);

                return Ok(new { message = "Fornecedor cadastrado com sucesso." });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // PUT api/<FornecedorController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<FornecedorController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
