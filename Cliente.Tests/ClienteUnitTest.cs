using Cliente.Entities;
using Newtonsoft.Json;
using System.Net;
using System.Text;

namespace Cliente.Tests
{
    public class ClienteUnitTest
    {
        private readonly HttpClient _httpClient;
        private readonly string _url;

        public ClienteUnitTest()
        {
            _httpClient = new HttpClient();
            _url = "http://localhost:5269/Cliente";
        }

        [Fact]
        public async Task TestCadastrarAsync()
        {
            var email = "thyrbendo@gmail.com";
            var nomeCompleto = "Thyago Romagna Bendo";
            var ddd = "45";
            var numero = "999452691";
            var tipo = 0;
            var content = $@"{{
              ""nomeCompleto"": ""{nomeCompleto}"",
              ""email"": ""{email}"",
              ""telefones"": [
                {{
                  ""ddd"": ""{ddd}"",
                  ""numero"": ""{numero}"",
                  ""tipo"": {tipo}
                }}
              ]
            }}";
            HttpContent httpContent = new StringContent(content, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(_url, httpContent);

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task TestAtualizarAsync()
        {
            var id = 4;
            var email = "thyrbendo@gmail.com";
            var nomeCompleto = "Thyago Romagna Bendo";
            var ddd = "45";
            var numero = "999452691";
            var tipo = 0;
            var content = $@"{{
              ""id"": ""{id}"",
              ""nomeCompleto"": ""{nomeCompleto}"",
              ""email"": ""{email}"",
              ""telefones"": [
                {{
                  ""ddd"": ""{ddd}"",
                  ""numero"": ""{numero}"",
                  ""tipo"": {tipo}
                }}
              ]
            }}";
            HttpContent httpContent = new StringContent(content, Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync(_url, httpContent);

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task TestConsultarAsync()
        {
            var ddd = "45";

            var numero = "999452691";

            var response = await _httpClient.GetAsync(_url + $"?ddd={ddd}&telefone={numero}");

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task TestDeletarAsync()
        {
            var id = 6;

            var response = await _httpClient.DeleteAsync(_url + $"?id={id}");

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}