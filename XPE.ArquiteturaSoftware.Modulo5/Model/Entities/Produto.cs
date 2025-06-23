namespace XPE.ArquiteturaSoftware.Modulo5.Model.Entities;

public class Produto
{
    public Produto(string nome, string marca)
    {
        Id = Guid.NewGuid();
        Nome = nome;
        Marca = marca;
    }

    public Guid Id { get; set; }
    public string Nome { get; set; }
    public string Marca { get; set; }
}