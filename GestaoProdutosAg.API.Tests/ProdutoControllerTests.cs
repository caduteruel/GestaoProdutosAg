using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;
using Newtonsoft.Json;

using GestaoProdutosAg.API.Application.DTOs;

namespace GestaoProdutosAg.API.Test
{
    public class ProdutoControllerTests : IClassFixture<WebApplicationFactory<GestaoProdutosAg.API.Controllers.ProdutoController>>
    {
        private readonly HttpClient _client;

        public ProdutoControllerTests(WebApplicationFactory<GestaoProdutosAg.API.Controllers.ProdutoController> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task GetAll_ReturnsSuccessStatusCode()
        {
            var response = await _client.GetAsync("/api/produto");
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task GetById_ReturnsSuccessStatusCode()
        {
            var response = await _client.GetAsync("/api/produto/1");
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task Post_ReturnsSuccessStatusCode()
        {
            var novoProduto = new ProdutoDTO { Descricao = "Novo Produto Teste", Situacao = true };
            var jsonContent = JsonConvert.SerializeObject(novoProduto);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            var response = await _client.PostAsync("/api/produto", content);
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
        }

        [Fact]
        public async Task Put_ReturnsSuccessStatusCode()
        {
            var produtoAtualizado = new ProdutoDTO { Codigo = 1, Descricao = "Produto Atualizado 1", Situacao = true };
            var jsonContent = JsonConvert.SerializeObject(produtoAtualizado);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            var response = await _client.PutAsync("/api/produto/1", content);
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task Delete_ReturnsSuccessStatusCode()
        {
            var response = await _client.DeleteAsync("/api/produto/1");
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
        }
    }
}
