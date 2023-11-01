using venda_app.Models;

namespace venda_app.Service
{
    public interface IRabbitMqClient
    {
        void PublicarReduzirEstoque(IncreaseStock model);
    }
}