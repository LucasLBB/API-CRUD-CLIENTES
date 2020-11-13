using System.Collections.Generic;
using apiCliente.Models;

namespace apiCliente.Repositorio
{
    public interface IClienteRepository
    {
        //Define os métodos na interface
         void Add(Cliente cliente);

         IEnumerable<Cliente> GetAll();

         Cliente Find(int id);

         void Remove(int id);

         void Update(Cliente cliente);
    }
}