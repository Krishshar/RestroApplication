using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestrProject.Classes
{
    public class Crostino : Restro
    {

        public Crostino()
        {
        }
        public override void AddListOfItem()
        {
            ListOfItem.Add(new ItemModel { ItemId = 1, ItemName = "Margherita   ", ItemPrice = 195.00F, IsItemAvailable = true });
            ListOfItem.Add(new ItemModel { ItemId = 2, ItemName = "Peppy Paneer ", ItemPrice = 385.00F, IsItemAvailable = true });
            ListOfItem.Add(new ItemModel { ItemId = 3, ItemName = "Farmhouse    ", ItemPrice = 385.00F, IsItemAvailable = false });
            ListOfItem.Add(new ItemModel { ItemId = 4, ItemName = "Cheese & Corn", ItemPrice = 305.00F, IsItemAvailable = true });
            ListOfItem.Add(new ItemModel { ItemId = 5, ItemName = "Fresh Veggie ", ItemPrice = 305.00F, IsItemAvailable = true });
            ListOfItem.Add(new ItemModel { ItemId = 6, ItemName = "Extravaganza ", ItemPrice = 450.00F, IsItemAvailable = false });
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
            base.RestroName = "Crostino";
        }
        public override void SetRestroBranchName()
        {
            base.BranchName = "Manish Nagar, Nagpur";
        }
    }
}
