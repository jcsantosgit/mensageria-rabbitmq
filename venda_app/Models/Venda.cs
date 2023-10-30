namespace venda_app.Models
{
    public class Venda
    {
        public int Id { get; set; }
        public int IdProduto { get; set; }
        public int Quantidade { get; set; }
        public DateTime Data { get; set; }
    }
}