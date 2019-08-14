using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestrProject.Classes
{
    public class Kfc : Restro
    {
        public Kfc()
        {
        }
        public override void AddListOfItem()
        {
            ListOfItem.Add(new ItemModel { ItemId = 1, ItemName = "Rice Bowl     ", ItemPrice = 169.00F, IsItemAvailable = true });
            ListOfItem.Add(new ItemModel { ItemId = 2, ItemName = "Smocky Grilled", ItemPrice = 460.00F, IsItemAvailable = true });
            ListOfItem.Add(new ItemModel { ItemId = 3, ItemName = "Zinger        ", ItemPrice = 200.00F, IsItemAvailable = false });
            ListOfItem.Add(new ItemModel { ItemId = 4, ItemName = "Rocklin       ", ItemPrice = 170.00F, IsItemAvailable = true });
            ListOfItem.Add(new ItemModel { ItemId = 5, ItemName = "Krusher       ", ItemPrice = 109.00F, IsItemAvailable = true });
            ListOfItem.Add(new ItemModel { ItemId = 6, ItemName = "Meal Box      ", ItemPrice = 189.00F, IsItemAvailable = false });
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
            base.RestroName = "KFC";
        }

        public override void SetRestroBranchName()
        {
            base.BranchName = "Manish Nagar, Nagpur";
        }
    }
}
