using Simple_Injector.Repository;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_Injector.IoC
{
    public class SimpleInjectorInitializer
    {
        private static Container container;

        public  static void Initialize()
        {
            container = new Container();

            container.Register<ICustomerRepository, HappyCustomerRepository>(Lifestyle.Transient);
            container.Register<ICustomerHandler, CustomerHandler>(Lifestyle.Transient);


            container.Verify();
        }

        public static Container Container
        {
            get { return Container; }
        }
    }
}
