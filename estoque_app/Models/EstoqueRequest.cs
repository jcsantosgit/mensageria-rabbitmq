using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace estoque_app.Models
{
    public class EstoqueRequest
    {
        public int Produto { get; set; }
        public int Quantidade { get; set; }
    }
}