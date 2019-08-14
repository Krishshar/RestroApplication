using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestrProject.Classes
{
    public class Panino : Restro
    {
        public Panino()
        {
        }
        public override void AddListOfItem()
        {
            ListOfItem.Add(new ItemModel { ItemId = 1, ItemName = "Patty Burger ", ItemPrice = 69.00F, IsItemAvailable = true });
            ListOfItem.Add(new ItemModel { ItemId = 2, ItemName = "Corn Burger  ", ItemPrice = 99.00F, IsItemAvailable = true });
            ListOfItem.Add(new ItemModel { ItemId = 3, ItemName = "French Fries ", ItemPrice = 69.00F, IsItemAvailable = false });
            ListOfItem.Add(new ItemModel { ItemId = 4, ItemName = "Nachos       ", ItemPrice = 69.00F, IsItemAvailable = true });
            ListOfItem.Add(new ItemModel { ItemId = 5, ItemName = "Mexican Burg ", ItemPrice = 99.00F, IsItemAvailable = true });
            ListOfItem.Add(new ItemModel { ItemId = 6, ItemName = "Jalepano Burg", ItemPrice = 99.00F, IsItemAvailable = false });
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
            base.RestroName = "Panino";
        }

        public override void SetRestroBranchName()
        {
            base.BranchName = "Manish Nagar, Nagpur";
        }
    }
}
