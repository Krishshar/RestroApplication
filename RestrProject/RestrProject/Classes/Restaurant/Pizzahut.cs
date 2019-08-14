using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestrProject.Classes
{
    public class Pizzahut : Restro 
    {
        public Pizzahut()
        {
        }
        public override void AddListOfItem()
        {
            ListOfItem.Add(new ItemModel { ItemId = 1, ItemName = "Hawaiian    ", ItemPrice = 290.00F, IsItemAvailable = true });
            ListOfItem.Add(new ItemModel { ItemId = 2, ItemName = "Curry       ", ItemPrice = 280.00F, IsItemAvailable = true });
            ListOfItem.Add(new ItemModel { ItemId = 3, ItemName = "Veggie      ", ItemPrice = 220.00F, IsItemAvailable = false });
            ListOfItem.Add(new ItemModel { ItemId = 4, ItemName = "Arrabiata   ", ItemPrice = 219.00F, IsItemAvailable = true });
            ListOfItem.Add(new ItemModel { ItemId = 5, ItemName = "Alfredo     ", ItemPrice = 199.00F, IsItemAvailable = true });
            ListOfItem.Add(new ItemModel { ItemId = 6, ItemName = "Caesar Salad", ItemPrice = 279.00F, IsItemAvailable = false });
        }
        public override void AddListOfTable()
        {
            ListOfTable.Add(new TableModel { TableId = 1, IsTableAvailable = true });
            ListOfTable.Add(new TableModel { TableId = 2, IsTableAvailable = true });
            ListOfTable.Add(new TableModel { TableId = 3, IsTableAvailable = false });
            ListOfTable.Add(new TableModel { TableId = 4, IsTableAvailable = true });
            ListOfTable.Add(new TableModel { TableId = 5, IsTableAvailable = true });
            ListOfTable.Add(new TableModel { TableId = 6, IsTableAvailable = false });
        }

        public override void SetRestroName()
        {
            base.RestroName = "Pizza Hut";
        }

        public override void SetRestroBranchName()
        {
            base.BranchName = "Manish Nagar, Nagpur";
        }
    }
}
