using FundamentalApi.Model;
using Microsoft.EntityFrameworkCore;

namespace FundamentalApi.Data
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
        { }
        
        public DbSet<Produto> Produtos { get; set; }
    }
}
