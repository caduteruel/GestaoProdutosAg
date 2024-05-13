using GestaoProdutosAg.API.Application.DTOs;
using GestaoProdutosAg.API.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GestaoProdutosAg.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoService _produtoService;
        public ProdutoController(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        // GET: api/<ProdutoController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProdutoDTO>>> Get([FromQuery] int page = 1, [FromQuery] int pageSize = 5)
        {
            try
            {
                var produtos = await _produtoService.GetAllAsync(page, pageSize);
                return Ok(produtos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Não foi possível obter os produtos devido a um erro interno: " + ex.Message);
            }
        }

        // GET api/<ProdutoController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            try
            {
                var produto = await _produtoService.GetByIdAsync(id);
                return Ok(produto);
            }
            catch(Exception ex)
            {
                return StatusCode(500, "Não foi possível obter o produto devido a um erro interno: " + ex.Message);
            }
        }

        // POST api/<ProdutoController>
        [HttpPost]
        public async Task <IActionResult> Post([FromBody] ProdutoDTO produtoDto)
        {
            try
            {
                produtoDto.Validate();

                await _produtoService.AddAsync(produtoDto);

                return Ok(new { message = "Produto cadastrado com sucesso." }); 
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

        // PUT api/<ProdutoController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] ProdutoDTO produtoDTO)
        {
            if (produtoDTO == null)
            {
                return BadRequest("Dados inválidos.");
            }

            try
            {
                produtoDTO.Validate();
                await _produtoService.UpdateAsync(id, produtoDTO);
                return Ok("Produto atualizado com sucesso.");
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

        // DELETE api/<ProdutoController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var delete = await _produtoService.DeleteAsync(id);
                if(delete == true)
                    return Ok("Produto deletado com sucesso.");
                return BadRequest("Não foi possivel deletar o produto. Verifique.");
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
