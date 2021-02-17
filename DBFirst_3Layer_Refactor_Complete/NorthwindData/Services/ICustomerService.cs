using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindData.Services
{
    public interface ICustomerService
    {
        List<Customer> GetCustomerList();
        Customer GetCustomerById(string customId);
        void SaveCustomerChanges();
        public void Delete(string customerId);
        public void Add(Customer c);
    }
}
