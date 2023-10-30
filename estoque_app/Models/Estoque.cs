namespace estoque_app.Models
{
    public class Estoque
    {
        public int Id { get; set; }      
        public int IdProduto { get; set; }
        public int Quantidade { get; set; }
        public int QuantidadeMinima { get; set; }
    }
}