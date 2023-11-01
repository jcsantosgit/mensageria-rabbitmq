using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using estoque_app.Data;
using estoque_app.Models;

namespace estoque_app.Service
{
    public class EventMessageProcess : IEventMessageProcess
    {
        private readonly DataContext _context;
        
        public EventMessageProcess(DataContext context)
        {
            _context = context;
        }

        public void IncreaseStock(string messsage)
        {
            IncreaseStock model = JsonSerializer.Deserialize<IncreaseStock>(messsage);
            
            var estoque = _context.Estoques.Where(e=>e.IdProduto == model.Produto).FirstOrDefault();

            estoque.Quantidade = model.Quantidade;

            _context.SaveChanges();
        }
    }
}