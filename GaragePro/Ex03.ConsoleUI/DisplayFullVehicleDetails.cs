using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using Ex03.GarageLogic;
using Ex03.GarageLogic.eCarColor;
using Ex03.GarageLogic.eFuelType;
using Ex03.GarageLogic.eLicenseType;
using Ex03.GarageLogic.eNumberOfDoors;
using Microsoft.VisualBasic.FileIO;

namespace Ex03.ConsoleUI
{
    public class DisplayFullVehicleDetails
    {
        public static void DisplayVehicleDetails(AllVehicles garage)
        {
            Vehicle vehicle = FindVehicleByLicensePlate.SearchLicensePlate(garage);
            Console.WriteLine("Model: " + vehicle.Model + "\n");
            Console.WriteLine("License Plate: " + vehicle.LicensePlate + "\n");
            Console.WriteLine("Energy Remaining Percentage: " + vehicle.EnergyRemainingPercentage + "\n");
            Console.WriteLine("Status: " + vehicle.Status + "\n");
            int numberOfWheels = vehicle.Wheels.Length;
            for(int i = 0; i < numberOfWheels; i++)
            {
                Console.WriteLine("Data of wheel number " + (i+1) + ":");
                Console.WriteLine("Manufacturer: " + vehicle.Wheels[i].Manufacturer);
                Console.WriteLine("Current Air Pressure: " + vehicle.Wheels[i].CurrentAirPressure);
                Console.WriteLine("Max Air Pressure: " + vehicle.Wheels[i].MaxAirPressure);
                Console.WriteLine();
            }
            Console.WriteLine("Owner Name: " + vehicle.OwnerName + "\n");
            Console.WriteLine("Owner Phone: " + vehicle.OwnerPhone + "\n");

            switch (numberOfWheels)
            {
                case 2:
                    {
                        Motorcycle motorcycle = vehicle as Motorcycle;
                        Console.WriteLine("Type: " + motorcycle.Type + "\n");
                        Console.WriteLine("Engine Volume: " + motorcycle.EngineVolume + "\n");

                        if (motorcycle is ElectricMotorcycle)
                        {
                            ElectricMotorcycle electricMotorcycle = motorcycle as ElectricMotorcycle;
                            Console.WriteLine("Remaining Battery Hours: " + electricMotorcycle.RemainingBatteryHours + "\n");
                            Console.WriteLine("Max Battery Charge Hours: " + electricMotorcycle.MaxBatteryChargeHours + "\n");
                        }
                        else if (motorcycle is FuelMotorcycle)
                        {
                            FuelMotorcycle fuelMotorcycle = motorcycle as FuelMotorcycle;
                            Console.WriteLine("Current Fuel Type: " + fuelMotorcycle.CurrentFuelType + "\n");
                            Console.WriteLine("Current Fuel Amount Liters: " + fuelMotorcycle.CurrentFuelAmountLiters + "\n");
                            Console.WriteLine("Max Fuel Capacity Liters: " + fuelMotorcycle.MaxFuelCapacityLiters + "\n");
                        }
                        break;
                    }
                case 5:
                    {
                        Car car = vehicle as Car;
                        Console.WriteLine("Color: " + car.Color + "\n");
                        Console.WriteLine("Doors: " + car.Doors + "\n");

                        if (car is ElectricCar)
                        {
                            ElectricCar electricCar = car as ElectricCar;
                            Console.WriteLine("Remaining Battery Hours: " + electricCar.RemainingBatteryHours + "\n");
                            Console.WriteLine("Max Battery Charge Hours: " + electricCar.MaxBatteryChargeHours + "\n");
                        }
                        else if (car is FuelCar)
                        {
                            FuelCar fuelCar = car as FuelCar;
                            Console.WriteLine("Current Fuel Type: " + fuelCar.CurrenFuelType + "\n");
                            Console.WriteLine("Current Fuel Amount Liters: " + fuelCar.CurrentFuelAmountLiters + "\n");
                            Console.WriteLine("Max Fuel Capacity Liters: " + fuelCar.MaxFuelCapacityLiters + "\n");
                        }
                        break;
                    }
                case 12:
                    {
                        Truck truck = vehicle as Truck;
                        Console.WriteLine("Carries Hazardous Materials (Y/N): " + truck.CarriesHazardousMaterials + "\n");
                        Console.WriteLine("Cargo Volume: " + truck.CargoVolume + "\n");
                        Console.WriteLine("Current Fuel Type: " + truck.CurrentFuelType + "\n");
                        Console.WriteLine("Current Fuel Amount Liters: " + truck.CurrentFuelAmountLiters + "\n");
                        Console.WriteLine("Max Fuel Capacity Liters: " + truck.MaxFuelCapacityLiters + "\n");
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }
    }   
}
