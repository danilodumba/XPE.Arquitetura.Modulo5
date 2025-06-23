using XPE.ArquiteturaSoftware.Modulo5.Model.Entities;

namespace XPE.ArquiteturaSoftware.Modulo5.Model.Services;

public class ProdutoService
{
    private readonly ProdutoContext _repository;

    public ProdutoService()
    {
        _repository = new ProdutoContext();
    }

    public void Create(Produto produto)
    {
        _repository.Produtos.Add(produto);
        _repository.SaveChanges();
    }
    
    public void Edit(Produto produto)
    {
        _repository.Produtos.Update(produto);
        _repository.SaveChanges();
    }
    
    public Produto? GetById(Guid id)
    {
        return _repository.Produtos.FirstOrDefault(x => x.Id == id);
    }
    
    public int Count()
    {
        return _repository.Produtos.Count();
    }
    
    public List<Produto> ListAll()
    {
        return _repository.Produtos.ToList();
    }
    
    public void Remove(Produto produto)
    {
        _repository.Produtos.Remove(produto);
        _repository.SaveChanges();
    }
}