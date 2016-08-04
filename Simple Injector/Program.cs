using Model.Entities;
using Simple_Injector.IoC;
using Simple_Injector.Repository;
using SimpleInjector;
using System;

namespace Simple_Injector
{
    class Program
    {
        static void Main(string[] args)
        {
            SimpleInjectorInitializer.Initialize(); 
            var customer = AddCustomer();

            Console.WriteLine("SimpleInjector Testing completed");
            Console.WriteLine(string.Format("Customer Status is: {0}", customer.Status));
            Console.ReadLine();
        }



        private static Customer AddCustomer()
        {
            var customer = new Customer { FirstName = "pablo", LastName = "tio" };

            var handler = SimpleInjectorInitializer.Container.GetInstance<ICustomerHandler>();
            var newCustomer = handler.AddCustomer(customer);

            return newCustomer;
        }
    }
}
