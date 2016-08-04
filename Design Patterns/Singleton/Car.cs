
namespace Design_Patterns.Singleton
{
    public abstract class Vehicle
    {
        public string LicensePlate { get; set; }
        public string DriverFullName { get; set; }

        public Vehicle(string plate, string driverFullName)
        {
            LicensePlate = plate;
            DriverFullName = driverFullName;
        }
    }

    public class Car: Vehicle
    {
        public Car(string plate, string driverName): base(plate, driverName){
        }
    }
}
