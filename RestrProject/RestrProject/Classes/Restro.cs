using System;
using System.Collections.Generic;
using System.Threading;
using System.Linq;
using RestrProject.Interface;
using RestrProject.Events;

namespace RestrProject
{
    public abstract class Restro : IRestro
    {
        public List<ItemModel> ListOfItem = new List<ItemModel>();
        public List<TableModel> ListOfTable = new List<TableModel>();
        public List<Customer> ListOfCustomer = new List<Customer>();

        public string RestroName = "";
        public string BranchName = "";

        private NotificationEvent _emailEvent;

        public Restro()
        {
            _emailEvent = new NotificationEvent();
            AddListOfItem();
            AddListOfTable();
            SetRestroName();
            SetRestroBranchName();
        }
        private void PrintTable(bool IsAvailable)
        {
            Console.WriteLine("  -----------------------------");
            Console.WriteLine($"    TableId   Availability ");
            Console.WriteLine("  -----------------------------");
            foreach (TableModel table in ListOfTable)
            {
                if (IsAvailable)
                {
                    if (table.IsTableAvailable)
                        Console.WriteLine(table.ToString());
                }
                else
                    Console.WriteLine(table.ToString());
            }
            Console.WriteLine("  -----------------------------");
        }
        public int ShowTables()
        {
            PrintTable(true);
            Console.WriteLine("Enter your TableId to book :");
            return Convert.ToInt32(Console.ReadLine());
        }

        public void PerformRestroAction()
        {
             PerformAction(ShowRestroActionMenu());
        }

        private void PerformAction(int choice)
        {
            switch (choice)
            {
                case 1:
                    PrintItemList(false);
                    break;
                case 2:
                    PrintItemList(true);
                    break;
                case 3:
                    PrintTable(false);
                    break;
                case 4:
                    PrintTable(true);
                    break;
                case 5:
                    if (ListOfCustomer.Count() != 0)
                        PrintAllCustomers();    
                    else
                        Console.WriteLine("\nNo Customer Visited\n");
                    break;
                case 6:
                    break;
            }
        }

        private void PrintAllCustomers()
        {
            Console.WriteLine("  ------------------------------------------------------------");
            Console.WriteLine($"    CustomerId      Customer Name    Table No   GrandTotal  ");
            Console.WriteLine("  ------------------------------------------------------------");

            foreach (Customer customer in ListOfCustomer)
                    Console.WriteLine(customer.ToString());

            Console.WriteLine("  ------------------------------------------------------------");
        }

        private int ShowRestroActionMenu()
        {
            Console.WriteLine("Enter Your Choice");
            Console.WriteLine("1. Show All Items");
            Console.WriteLine("2. Show All Available Items");
            Console.WriteLine("3. Show All Table");
            Console.WriteLine("4. Show All Available Items");
            Console.WriteLine("5. Show All Customer Visited");
            Console.WriteLine("6. Exit");
            return Convert.ToInt32(Console.ReadLine());
        }

        private void PrintItemList(bool IsAvailable)
        {
            Console.WriteLine("  ------------------------------------------------------");
            Console.WriteLine($"    ItemId  ItemName\t ItemPrice       Availability ");
            Console.WriteLine("  ------------------------------------------------------");

            foreach (ItemModel item in ListOfItem)
            {
                if (IsAvailable)
                {
                    if (item.IsItemAvailable)
                        Console.WriteLine($"{item.ToString()}");
                }
                else
                    Console.WriteLine($"{item.ToString()}");

            }
            Console.WriteLine("  ------------------------------------------------------");
        }

        public Customer RegisterCustomer()
        {
            PrintWelcomeMessage();
            Console.WriteLine("Please Enter your name :");
            string CustomerName = Console.ReadLine();
            Customer Cust = new Customer { CustomerId = Guid.NewGuid().GetHashCode(), CustomerName = CustomerName };
            ListOfCustomer.Add(Cust);
            Console.WriteLine($"\n-------** Welcome {CustomerName} to {RestroName} **-------\n\n");
            return Cust;
        }

        public TableModel BookTable(int TableId)
        {
            TableModel tableModel = null;
            foreach (TableModel table in ListOfTable)
            {
                if (table.TableId == TableId && table.IsTableAvailable)
                {
                    table.IsTableAvailable = false;
                    tableModel = table;
                    break;
                }
            }
            if (tableModel !=null)
                Console.WriteLine($"Table No.: {TableId} is Booked for you.\n");
            else
                Console.WriteLine("Table is not Availble.");

            return tableModel;
        }

        public int ShowItem()
        {
            PrintItemList(true);
            Console.WriteLine("Enter your ItemId to book :");
            return Convert.ToInt32(Console.ReadLine());
        }

        public ItemOrderd BookItem(int ItemId)
        {
            ItemOrderd itemOrderd = new ItemOrderd();
            foreach (ItemModel item in ListOfItem)
            {
                if (item.ItemId == ItemId)
                {
                    if (!item.IsItemAvailable)
                    {
                        Console.WriteLine("Item not Available Please try anather item.\n");
                        return null;
                    }

                    Quantity:
                        Console.WriteLine($"Enter Quantity for {item.ItemName}");
                        int Quantity = Convert.ToInt32(Console.ReadLine());

                        if (Quantity > 0)
                        {
                            itemOrderd.setItem(item, Quantity, true);
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Quantity should be greater than 0");
                            goto Quantity;
                        }
                }
            }
            return itemOrderd;
        }

        public void SetOrderedItemToCustomer(int customerId, List<ItemOrderd> itemList)
        {
            ListOfCustomer.Where(customer => customer.CustomerId == customerId)
                .SingleOrDefault()
                .ItemOrdered = itemList;
        }

        public abstract void AddListOfTable();

        public abstract void AddListOfItem();

        public void PrintWelcomeMessage()
        {
            Console.WriteLine("-------------------------------------------------------------------------------------");
            Console.WriteLine("*********************************** W E L C O M E ***********************************");
            Console.WriteLine("-------------------------------------------------------------------------------------");
        }

        public abstract void SetRestroName();
        public abstract void SetRestroBranchName();
    }
}
