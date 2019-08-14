using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestrProject.Interface
{
    public interface IRestro
    {
        int ShowTables();
        int ShowItem();
        TableModel BookTable(int TableId);
        ItemOrderd BookItem(int ItemId);
        Customer RegisterCustomer();
        void PerformRestroAction();
        void SetRestroName();
        void SetRestroBranchName();
        void SetOrderedItemToCustomer(int customerId, List<ItemOrderd> itemList);
    }
}
