using Application._4___Entidades;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Configuration
{
    public class ContextBase : DbContext
    {
        public ContextBase(DbContextOptions<ContextBase> options) : base(options)
        { 
            Database.EnsureCreated(); 
        }

        public DbSet<Product> Product { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Se não estiver configurado no projeto IU pega deginição de chame do json configurado
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer(GetStringConectionConfig(), b => b.MigrationsAssembly("Infrastructure"));
            base.OnConfiguring(optionsBuilder);
        }

        private string GetStringConectionConfig()
        {
            string strCon = "Data Source=HEBER\\SQLEXPRESS;Initial Catalog=Design_Pattern;Integrated Security=False;User ID=sa;Password=123qwe;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False";
            return strCon;
        }
    }
}
