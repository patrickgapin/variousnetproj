using Model.Entities;
using Simple_Injector.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_Injector
{
    public class CustomerHandler: ICustomerHandler
    {
        private ICustomerRepository customerRepository;

        public CustomerHandler(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        public Customer AddCustomer(Customer customer)
        {
            var newCustomer = this.customerRepository.Add(customer);
            return newCustomer;
        }
    }
}
