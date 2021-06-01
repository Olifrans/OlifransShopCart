using Microsoft.EntityFrameworkCore;
using OlifransShopCart.DataAcsess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlifransShopCart.Repo.Data
{
    public class OlifransDbContext : DbContext
    {
        public OlifransDbContext(DbContextOptions<OlifransDbContext> options) : base(options)
        {
                
        }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Produto> Produtos { get; set; }
    }
}
