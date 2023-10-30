using Microsoft.EntityFrameworkCore;
using venda_app.Models;

namespace venda_app.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions option) : base(option) {}

        public DbSet<Venda> Vendas { get; set; }
    }
}