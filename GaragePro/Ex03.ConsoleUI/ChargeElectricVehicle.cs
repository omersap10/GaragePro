using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    public class ChargeElectricVehicle
    {
        public static void DoChargeElectricVehicle(AllVehicles garage)
        {
            Vehicle vehicle = FindVehicleByLicensePlate.SearchLicensePlate(garage);
            float minutesAmount;

            while (true)
            {
                Console.WriteLine("Please enter number of minutes to charge:");
                string input = Console.ReadLine();

                if (!float.TryParse(input, out minutesAmount))
                {
                    Console.WriteLine("Invalid input. Please enter a valid number of minutes to charge.");
                    continue; 
                }

                switch (vehicle.Wheels.Length)
                {
                    case 2 when (vehicle is ElectricMotorcycle electricMotorcycle):
                        {
                            float maxCharge = electricMotorcycle.RemainingBatteryHours.Value + (minutesAmount / 60);

                            if (maxCharge > 2.8f)
                            {
                                Console.WriteLine($"Charging time exceeds maximum allowed for this vehicle. Please enter a value between 0 and {(2.8f - electricMotorcycle.RemainingBatteryHours.Value) * 60}.");
                                continue; 
                            }

                            electricMotorcycle.ChargeBattery(minutesAmount / 60);
                            break;
                        }
                    case 5 when (vehicle is ElectricCar electricCar):
                        {
                            float maxCharge = electricCar.RemainingBatteryHours.Value + (minutesAmount / 60);

                            if (maxCharge > 4.8f)
                            {
                                Console.WriteLine($"Charging time exceeds maximum allowed for this vehicle. Please enter a value between 0 and {(4.8f - electricCar.RemainingBatteryHours.Value) * 60}.");
                                continue; // Continue to the next iteration of the loop
                            }

                            electricCar.ChargeBattery(minutesAmount / 60);
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Invalid vehicle type.");
                            return;
                        }
                }

                Console.WriteLine("Charge successful!\n");
                break;
            }
        }
    }
}