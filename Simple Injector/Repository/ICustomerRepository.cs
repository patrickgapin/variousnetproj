using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_Injector.Repository
{
    public interface ICustomerRepository
    {
        Customer Add(Customer customer);
    }
}
