using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services.DomainObjects;

namespace Services
{
    public class CheckoutService : ICheckoutService
    {
        private readonly IList<Item> items = new List<Item>();

        public long CalculateTotal()
        {
            int total = 0;
            var itemGroups = items.GroupBy(g => g.Name);

            foreach (var itemGroup in itemGroups)
            {
               total += itemGroup.Sum(x => x.Price);
            }

            return total;
        }

        public void AddItem(Item item)
        {
            if (string.IsNullOrWhiteSpace(item.Name))
            {
                throw new ArgumentException("Item name cannot be null or whitespace.");
            }

            items.Add(item);
        }
    }
}
