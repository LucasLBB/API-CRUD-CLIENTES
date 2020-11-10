using System.Collections.Generic;
using System.Linq;
using apiCliente.Models;

namespace apiCliente.Repositorio
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly ClienteDbContext _contexto;

        public ClienteRepository(ClienteDbContext ctx)
        {
            _contexto = ctx;
        }

        public void Add(Cliente cliente)
        {
            _contexto.tb_cliente.Add(cliente);
            _contexto.SaveChanges();
        }

        public Cliente Find(int id)
        {
            return _contexto.tb_cliente.FirstOrDefault(c => c.id_cliente == id);
        }

        public IEnumerable<Cliente> GetAll()
        {
            return _contexto.tb_cliente.ToList();
        }

        public void Remove(int id)
        {
            var entity = _contexto.tb_cliente.First(c => c.id_cliente == id);
            _contexto.tb_cliente.Remove(entity);
            _contexto.SaveChanges();
        }

        public void Update(Cliente cliente)
        {
            _contexto.tb_cliente.Update(cliente);
            _contexto.SaveChanges();
        }
    }
}