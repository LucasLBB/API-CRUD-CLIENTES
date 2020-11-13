using Microsoft.EntityFrameworkCore;

namespace apiCliente.Models
{
    public class ClienteDbContext : DbContext
    {
        public ClienteDbContext(DbContextOptions<ClienteDbContext> options)
            : base(options)
        { }
        //Recebe a tabela do cliente
        public DbSet<Cliente> tb_cliente { get; set; }
    }
}