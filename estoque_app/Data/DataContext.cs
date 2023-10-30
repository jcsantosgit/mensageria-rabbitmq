using estoque_app.Models;
using Microsoft.EntityFrameworkCore;

namespace estoque_app.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Estoque> Estoques { get; set; }
        public DbSet<Produto> Produtos { get; set; }
    }
}