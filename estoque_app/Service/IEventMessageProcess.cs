using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace estoque_app.Service
{
    public interface IEventMessageProcess
    {
        void IncreaseStock(string messsage);
    }
}