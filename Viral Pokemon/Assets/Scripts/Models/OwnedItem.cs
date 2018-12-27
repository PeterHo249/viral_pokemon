using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Models
{
    public class OwnedItem
    {
        public Item sampleItem;
        public int amount;

        public OwnedItem(Item item, int amt)
        {
            this.sampleItem = item;
            this.amount = amt;
        }
    }
}
