using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestrProject
{
    public class ItemOrderd : ItemModel
    {
        public int Quantity { get; set; }

        public float TotalAmount { get; set; }

        public void setItem(ItemModel item, int quantity,bool Availiability )
        {
            ItemId = item.ItemId;
            ItemName = item.ItemName;
            ItemPrice = item.ItemPrice;
            Quantity = quantity;
            TotalAmount = quantity * ItemPrice;
            IsItemAvailable = Availiability;
        }

        public override string ToString()
        {
            return $"        {ItemId}.   {ItemName}\t{Quantity}       *      {ItemPrice}   =    {TotalAmount}\n";
        }
    }
}
