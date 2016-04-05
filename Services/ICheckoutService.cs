using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services.DomainObjects;

namespace Services
{
    public interface ICheckoutService
    {
        long CalculateTotal();
        void AddItem(Item item);
    }
}
