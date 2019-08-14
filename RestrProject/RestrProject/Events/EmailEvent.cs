using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestrProject.Events
{
    public delegate string SendEmail(Customer customer);
    public class NotificationEvent
    {
        event SendEmail MySendEmail;

        public NotificationEvent()
        {
            this.MySendEmail += new SendEmail(this.SendEmailToCustomer);
        }

        public string SendEmailToCustomer(Customer customer)
        {
            return $"\n\tBill is generated of Rs.{customer.GrandTotal} /- \n\tThank you {customer.CustomerName}!!";
        }
    }
}
