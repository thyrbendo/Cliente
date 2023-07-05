using Cliente.Entities;
using Cliente.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Cliente.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly ILogger<ClienteController> _logger;
        private readonly IClienteService _service;

        public ClienteController(ILogger<ClienteController> logger, IClienteService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpPost(Name = "Cadastrar")]
        public bool Cadastrar(ClienteDto clienteDto)
        {
            return _service.Cadastrar(clienteDto);
        }

        [HttpGet(Name = "ConsultarCliente")]
        public ClienteDto ConsultarCliente(string ddd, string telefone)
        {
            return _service.ConsultarCliente(ddd, telefone);
        }

        [HttpGet("Clientes",Name = "ConsultarClientes")]
        public List<ClienteDto> ConsultarClientes(string telefone, string email)
        {
            return _service.ConsultarClientes(telefone,email);
        }

        [HttpPut(Name = "Atualizar")]
        public bool Atualizar(ClienteDto clienteDto)
        {
            return _service.Atualizar(clienteDto);
        }

        [HttpDelete(Name = "Deletar")]
        public bool Deletar(int id)
        {
            return _service.Deletar(id);
        }
    }
}