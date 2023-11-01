using System.Runtime.Intrinsics.Arm;
using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace estoque_app.Service
{
    public class RabbitMqSubscribe : BackgroundService
    {
        private readonly IConfiguration _configuration;
        private readonly string _queueName;
        private readonly IConnection _connection;
        private readonly IModel _channel;
        private IEventMessageProcess _eventProcess;

        public RabbitMqSubscribe()
        {
        }

        public RabbitMqSubscribe(IConfiguration configuration, IEventMessageProcess eventProcess)
        {
            _configuration = configuration;
            _eventProcess = eventProcess;
            
            _connection = new ConnectionFactory()
            {
                HostName = "localhost",
                Port = 8200
            }.CreateConnection();

            _channel = _connection.CreateModel();
            _channel.ExchangeDeclare(exchange: "trigger", type: ExchangeType.Fanout);
            _queueName = _channel.QueueDeclare().QueueName;
            _channel.QueueBind(queue: _queueName, exchange: "trigger", routingKey: "");
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var consumer = new EventingBasicConsumer(_channel);

            consumer.Received += (ModuleHandle, ea) => 
            {
                //var body = ea.Body;
                ReadOnlyMemory<byte> body = ea.Body;
                string? message = Encoding.UTF8.GetString(body.ToArray());
                _eventProcess.IncreaseStock(message);
            };

            _channel.BasicConsume(queue: _queueName, autoAck: true, consumer: consumer);

            return Task.CompletedTask;
        }
    }
}