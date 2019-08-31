using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedLib;

namespace StockServiceLib
{
    public class ClientContainer
    {
        public IStockCallback ClientCallback;   //Reference to a client callback object (ie. handle to a client project)
        public bool IsActive;                   //Indicates if the given client is set to receive callback messages

        public ClientContainer()
        {
            this.ClientCallback = default;
            this.IsActive = default;
        }

        public ClientContainer(IStockCallback clientCallBack, bool isActive)
        {
            this.ClientCallback = clientCallBack;
            this.IsActive = isActive;
        }
    }
}
