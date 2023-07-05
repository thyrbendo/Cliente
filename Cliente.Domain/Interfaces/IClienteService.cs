using Cliente.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cliente.Interfaces
{
    public interface IClienteService
    {
        bool Cadastrar(ClienteDto clienteDto);
        ClienteDto ConsultarCliente(string ddd, string telefone);
        List<ClienteDto> ConsultarClientes(string telefone, string email);
        bool Atualizar(ClienteDto clienteDto);
        bool Deletar(int id);
    }
}
