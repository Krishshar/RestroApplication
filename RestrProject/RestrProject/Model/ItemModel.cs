using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestrProject
{
    public class ItemModel
    {
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public float ItemPrice { get; set; }
        public bool IsItemAvailable { get; set; }
        public override string ToString()
        {
            return $"      {ItemId}\t    {ItemName}\t  {ItemPrice}\t\t {GetAvailablityMsg()}";
        }

        private String GetAvailablityMsg()
        {
            return IsItemAvailable ? "Available" : "Not Available";
        }
    }
}
