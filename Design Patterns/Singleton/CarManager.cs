
using System.Collections.Generic;
using System.Linq;

namespace Design_Patterns.Singleton
{
    public class CarManager
    {


        /*
        // This way of doing it works, but is not necessary because Static Initializers already provide Thread-safety in .NET
        private static readonly object mutex = new object();
        private static volatile CarManager instance;
        
        
        public static CarManager Instance
        {
            get
            {
                if (instance == null)   // Extra "security"
                {
                    lock (mutex)
                    {
                        if (instance == null) { instance = new CarManager(); }

                    }
                }
                return instance;
            }
        }
        */

        private List<Car> parkingLotCars;
        private static readonly CarManager instance = new CarManager();
        private CarManager() { parkingLotCars = new List<Car>(); }

        // Forces laziness.
        // static CarManager() { }
        public static CarManager Instance { get { return instance; } }


        public void AddCar(string plate, string driverName)
        {
            if (!IsCarInLot(plate)) parkingLotCars.Add(new Car(plate, driverName));
        }

        public void RemoveCar(string plate)
        {
            if (IsCarInLot(plate)) { parkingLotCars.RemoveAll(car => car.LicensePlate.ToLower().Equals(plate.ToLower())); }

        }

        private bool IsCarInLot(string plate)
        {
            return parkingLotCars.Any(car => car.LicensePlate.ToLower().Equals(plate.ToLower()));
        }

        public string DisplayCars()
        {
            var parkingContent = string.Format("PLATE - DRIVER\nTOTAL CARS: {0}\n\n", parkingLotCars.Count);

            parkingLotCars.ForEach(car => parkingContent += string.Format("{0} - {1}\n", car.LicensePlate, car.DriverFullName));

            return parkingContent;
        }
    }
}
