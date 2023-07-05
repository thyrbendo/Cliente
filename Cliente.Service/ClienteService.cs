using Cliente.Data.Contexts;
using Cliente.Entities;
using Cliente.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Cliente.Service
{
    public class ClienteService : IClienteService
    {
        private readonly ClienteContext _context;

        public ClienteService(ClienteContext context)
        {
            _context = context;
        }

        public bool Atualizar(ClienteDto clienteDto)
        {
            var dto = _context.Clientes.Where(c => c.Id == clienteDto.Id).First();
            var telefones = new List<TelefoneDto>();
            for (var i = 0; i < clienteDto.Telefones.Count; i++)
            {
                var telefone = clienteDto.Telefones.ElementAt(i);
                var t = _context.Telefones.Where(x => x.DDD == telefone.DDD && x.Numero == telefone.Numero && x.ClienteId == dto.Id).FirstOrDefault();
                if (t == null)
                {
                    _context.Telefones.Add(telefone);
                    _context.SaveChanges();
                    telefones.Add(telefone);
                }
                else
                {
                    telefones.Add(t);
                }
            }
            clienteDto.Telefones = telefones;
            _context.Clientes.Update(clienteDto);
            return _context.SaveChanges() > 0;
        }

        public bool Cadastrar(ClienteDto clienteDto)
        {
            var telefones = new List<TelefoneDto>();
            for (var i = 0; i < clienteDto.Telefones.Count; i++)
            {
                var telefone = clienteDto.Telefones.ElementAt(i);
                _context.Telefones.Add(telefone);
                _context.SaveChanges();
                telefones.Add(telefone);
            }
            clienteDto.Telefones = telefones;
            _context.Clientes.Add(clienteDto);
            return _context.SaveChanges() > 0;
        }

        public ClienteDto ConsultarCliente(string ddd, string telefone)
        {
            return _context.Clientes.Include(c => c.Telefones).Where(c => c.Telefones.Where(t => t.DDD == ddd && t.Numero == telefone).Count() > 0).First();
        }

        public List<ClienteDto> ConsultarClientes(string telefone, string email)
        {
            return _context.Clientes.Include(c => c.Telefones).Where(c => c.Email == email || c.Telefones.Where(t => t.DDD + t.Numero == telefone).Count() > 0).ToList();
        }

        public bool Deletar(int id)
        {
            var dto = _context.Clientes.Include(c => c.Telefones).Where(c => c.Id == id).First();
            _context.Telefones.RemoveRange(dto.Telefones);
            _context.Clientes.Remove(dto);
            return _context.SaveChanges() > 0;
        }
    }
}