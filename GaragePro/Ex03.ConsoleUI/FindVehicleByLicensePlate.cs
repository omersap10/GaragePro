using Ex03.GarageLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.ConsoleUI
{
    public class FindVehicleByLicensePlate
    {
        public static Vehicle SearchLicensePlate(AllVehicles garage)
        {
            Console.WriteLine("Enter the vehicle's license plate number:");
            String licensePlate = Console.ReadLine();
            Console.WriteLine();

            Vehicle wantedVehicle = null;
            do
            {
                foreach (Vehicle vehicle in garage.VehiclesInGarage)
                {
                    if (vehicle.LicensePlate.Equals(licensePlate))
                    {
                        wantedVehicle = vehicle;
                        break;
                    }
                }

                if (wantedVehicle == null)
                {
                    try
                    {
                        throw new ArgumentException("Vehicle not found in the garage.");
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine(ex.Message);
                        Console.WriteLine("Enter the vehicle's license plate number again:\n");
                        licensePlate = Console.ReadLine();
                    }
                }
            }
            while (wantedVehicle == null);

            return wantedVehicle;
        }
    }
}
