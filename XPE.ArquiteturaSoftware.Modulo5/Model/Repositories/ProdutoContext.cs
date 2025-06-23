using Microsoft.EntityFrameworkCore;
using XPE.ArquiteturaSoftware.Modulo5.Model.Entities;

namespace XPE.ArquiteturaSoftware.Modulo5.Model;

public class ProdutoContext: DbContext
{
    public DbSet<Produto> Produtos { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseInMemoryDatabase("ProdutoDataBase");
    }
}