
using Model.Entities;

namespace Simple_Injector.Repository
{
    public class HappyCustomerRepository : ICustomerRepository
    {
        public Customer Add(Customer customer)
        {
            var newCustomer = new Customer { FirstName = "New " + customer.FirstName, Status = "Happy" };
            newCustomer.IsNew = true;

            return newCustomer;
        }

        public bool IsHappy
        {
            get { return true; }
        }
    }
}
