using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestrProject.Interface;
using RestrProject.Events;

namespace RestrProject
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public static int MaxLimitOfOrder = 2;  
        public List<ItemOrderd> ItemOrdered { get; set; }
        public TableModel TableAlloted { get; set; }
        public float GrandTotal { get; set; }

        public IRestro restro = null;

        NotificationEvent emailEvent;
        public Customer()
        {
            emailEvent = new NotificationEvent();

        }

        public override string ToString()
        {
            return $"    {CustomerId}      {CustomerName}  \t\t{TableAlloted.TableId}\t    {GrandTotal}";
        }
        private void BookTable()
        {
        BookTable:
            TableModel table = restro.BookTable(restro.ShowTables());
            if (table != null)
            {
                TableAlloted = table;
            }
            else
                goto BookTable;
        }

        public void PerformCustomerAction(IRestro crostino)
        {
            this.restro = crostino; //Restraunt is assigned to Customer

            BookTable();

            OrderItem();
        }

        private void OrderItem()
        {
            int Choice = 0;
            List<ItemOrderd> itemOrderds = new List<ItemOrderd>();
            int LimitOfItem = MaxLimitOfOrder;
            while (LimitOfItem != 0)
            {
                OrderItem:
                    ItemOrderd item = restro.BookItem(restro.ShowItem());
                    if (item != null)
                        itemOrderds.Add(item);
                    else
                        goto OrderItem;

                LimitOfItem--;
                if (LimitOfItem != 0)
                {
                    Choice = GetYesNoChoice("Do you want to order more Item ?");

                    if (Choice == 2)
                        break;
                }
                else
                    break;
            }
            restro.SetOrderedItemToCustomer(CustomerId,itemOrderds);

            while (true)
            {
                Choice = GetYesNoChoice("Do you want to Print Bill ?");

                if (Choice == 1)
                {
                    UpdateGrandTotal();
                    Console.WriteLine("   -------------------------------------------------------------------");
                    Console.WriteLine($"       Customer Name : {CustomerName}");
                    Console.WriteLine("   -------------------------------------------------------------------");
                    Console.WriteLine($"      ItemId  ItemName\tItemQuantity  ItemPrice   TotalAmount\n");

                    foreach (ItemOrderd item in itemOrderds)
                        Console.WriteLine(item.ToString());

                    Console.WriteLine("   -------------------------------------------------------------------");
                    Console.WriteLine($"  \t\t\tGrand Total : {GrandTotal}");
                    Console.WriteLine("   -------------------------------------------------------------------");
                    Console.WriteLine($"  \t**************Thank You !! Visit Again**************");
                    Console.WriteLine("   -------------------------------------------------------------------");

                    Console.WriteLine($"\nEvent Triggerd :\n\t{emailEvent.SendEmailToCustomer(this)}");
                    break;
                }
            }
        }

        private void UpdateGrandTotal()
        {
            if (ItemOrdered.Count() != 0 || ItemOrdered !=null)
            {
                GrandTotal = ItemOrdered.Sum(item => item.TotalAmount);
            }
        }
        private int GetYesNoChoice(string msg)
        {
            Console.WriteLine(msg);
            Console.WriteLine("1 - Yes");
            Console.WriteLine("2 - No");
            return Convert.ToInt32(Console.ReadLine());
        }
    }
}
