using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurchaseOrderConsole
{
    interface IReceiptable
    {
        void MarkAsReceipted(int orderNumber);
    }
}
