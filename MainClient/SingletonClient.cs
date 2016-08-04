using Design_Patterns;
using Design_Patterns.Singleton;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainClient
{
    class SingletonClient
    {
        static void Start(string[] args)
        {
            IList<string> strings = new string[5];
            strings[0] = "Hierd";

            //ManageCars();
            Console.ReadLine();
        }

        private static void ManageCars()
        {
            var carManager = CarManager.Instance;
            carManager.AddCar("QA12", "Eric");
            carManager.AddCar("WE45", "Mike");
            carManager.AddCar("POL", "Frank");

            //carManager.RemoveCar("WE45");

            Console.WriteLine( carManager.DisplayCars());

        }

    }
}
