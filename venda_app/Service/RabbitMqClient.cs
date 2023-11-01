using System.Text;
using System.Text.Json;
using RabbitMQ.Client;
using venda_app.Models;

namespace venda_app.Service
{
    public class RabbitMqClient : IRabbitMqClient
    {
        private readonly IConfiguration _configuration;
        private readonly IConnection _connection;
        private readonly IModel _channel;

        public RabbitMqClient(IConfiguration configuration)
        {
            _configuration = configuration;
            
            _connection = new ConnectionFactory() 
            {
                HostName = _configuration.GetSection("RabbitMqHost").Value, 
                Port = int.Parse(_configuration.GetSection("RabbitMqPort").Value)
            }.CreateConnection();

            _channel = _connection.CreateModel();
            _channel.ExchangeDeclare("trigger", ExchangeType.Fanout);
        }

        public void PublicarReduzirEstoque(IncreaseStock model)
        {
            string mensagem = JsonSerializer.Serialize(model);
            var body = Encoding.UTF8.GetBytes(mensagem);

            _channel.BasicPublish(
                exchange: "trigger",
                routingKey: "",
                basicProperties: null,
                body: body   
            );
        }
    }
}