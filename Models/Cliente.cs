using System;
using System.ComponentModel.DataAnnotations;

namespace apiCliente.Models
{
    public class Cliente
    {
        [Key]
        public int id_cliente { get; set; }       
        public string nome { get; set; }       
        public int telefone { get; set; }       
        public DateTime dt_nasc { get; set; }       
        public string endereco { get; set; }       
        public string bairro { get; set; }       
        public int cep { get; set; }       
        public string referencia { get; set; }       
        public string email { get; set; }       
    }
}