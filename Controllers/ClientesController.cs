using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using apiCliente.Models;
using apiCliente.Repositorio;
using apiCliente.Controllers;

namespace apiCliente.Controllers
{
    //Define a url da API
    [Route("api/[Controller]")]
    public class ClientesController : Controller
    {

        private readonly IClienteRepository _clienteRepositorio;
        
        public ClientesController(IClienteRepository _clienteRepo)
        {
            _clienteRepositorio = _clienteRepo;
        }

        //Retorna todos os usuários
        [HttpGet]
        public IEnumerable<Cliente> GetAll()
        {
            return _clienteRepositorio.GetAll();
        }

        //Retorna um usuário
        [HttpGet("{id}", Name="GetCliente")]
        public IActionResult GetById(int id)
        {
            var cliente = _clienteRepositorio.Find(id);
            if(cliente == null)
            return NotFound();

            return new ObjectResult(cliente);
        }

        //Cria um novo usuário
        [HttpPost]
        public IActionResult Create([FromBody] Cliente cliente) {
            if(cliente == null)
            return BadRequest();

            _clienteRepositorio.Add(cliente);

            return CreatedAtRoute("GetCliente", new {id=cliente.id_cliente}, cliente);
        }

        //Atualiza um usuário existente pelo id
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Cliente cliente)
        {
            if(cliente == null || cliente.id_cliente != id)
                return BadRequest(); //Retorna um erro de má requisição

            var _cliente = _clienteRepositorio.Find(id);

            if(cliente == null )
                return NotFound(); //Retorna um erro 404 - Not found

                _cliente.nome = cliente.nome;
                _cliente.telefone = cliente.telefone;
                _cliente.dt_nasc = cliente.dt_nasc;
                _cliente.endereco = cliente.endereco;
                _cliente.bairro = cliente.bairro;
                _cliente.cep = cliente.cep;
                _cliente.email = cliente.email;

                _clienteRepositorio.Update(_cliente);
                    return new NoContentResult();
        }

        //Deleta um usuário existente pelo id
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var cliente = _clienteRepositorio.Find(id);

             if(cliente == null )
                return NotFound();

                _clienteRepositorio.Remove(id);
                return new NoContentResult();
        }

    }
}