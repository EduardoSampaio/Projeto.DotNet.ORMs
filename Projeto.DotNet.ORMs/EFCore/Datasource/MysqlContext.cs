using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Projeto.ORM.Test.Entities;
using Projeto.ORM.Test.Map;
using System.IO;

namespace Projeto.ORM.Test.Datasource
{
    public class MysqlContext : DbContext
    {
        public static IConfigurationRoot Configuration { get; set; }
        public DbSet<Produto> Produto { get; set; }
        public MysqlContext()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json");

            Configuration = builder.Build();

            var connection = Configuration["ConnectionStrings:DefaultConnection"];
            optionsBuilder.UseMySQL(connection);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProdutoMap());
        }
    }
}
