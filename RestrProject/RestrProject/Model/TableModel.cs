using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestrProject
{
    public class TableModel
    {
        public int TableId { get; set; }
        public bool IsTableAvailable { get; set; }
        public override string ToString()
        {
            return $"       {TableId}      {GetAvailabilityMsg()}";
        }

        private string GetAvailabilityMsg()
        {
            return IsTableAvailable ? $"Available " : $"UnAvailable";
        }
    }
}
