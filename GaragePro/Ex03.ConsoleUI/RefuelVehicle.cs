using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex03.GarageLogic;
using Ex03.GarageLogic.eFuelType;

namespace Ex03.ConsoleUI
{
    public class RefuelVehicle
    {
         public static void DoRefuelVehicle(AllVehicles garage)
        {
            Vehicle vehicle = FindVehicleByLicensePlate.SearchLicensePlate(garage);

            Console.WriteLine("Please enter fuel type (Soler, Octan95, Octan96, Octan98):");
            FuelType fuelType;
            while (true)
            {
                string fuelInput = Console.ReadLine();
                try
                {
                    fuelType = Enum.Parse<FuelType>(fuelInput);
                    if ((vehicle is FuelMotorcycle && fuelType != FuelType.Octan98) ||
                        (vehicle is FuelCar && fuelType != FuelType.Octan95) ||
                        (vehicle is Truck && fuelType != FuelType.Soler))
                    {
                        throw new ArgumentException("Invalid fuel type for the vehicle.");
                    }
                    break; 
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("Please enter a valid fuel type.");
                }
            }

            Console.WriteLine("Please enter fuel amount to add:");
            float fuelAmount;
            while (true)
            {
                try
                {
                    if (float.TryParse(Console.ReadLine(), out fuelAmount))
                    {
                        if (fuelAmount <= 0)
                        {
                            throw new ArgumentException("Fuel amount must be greater than zero.");
                        }

                        float? maxFuelAmount;
                        if (vehicle is FuelMotorcycle)
                        {
                            FuelMotorcycle fuelMotorcycle = vehicle as FuelMotorcycle;
                            maxFuelAmount = fuelMotorcycle.MaxFuelCapacityLiters - fuelMotorcycle.CurrentFuelAmountLiters;
                        }
                        else if (vehicle is FuelCar)
                        {
                            FuelCar fuelCar = vehicle as FuelCar;
                            maxFuelAmount = fuelCar.MaxFuelCapacityLiters - fuelCar.CurrentFuelAmountLiters;
                        }
                        else if (vehicle is Truck)
                        {
                            Truck truck = vehicle as Truck;
                            maxFuelAmount = truck.MaxFuelCapacityLiters - truck.CurrentFuelAmountLiters;
                        }
                        else
                        {
                            maxFuelAmount = float.MaxValue;
                        }

                        if (fuelAmount > maxFuelAmount)
                        {
                            throw new ValueOutOfRangeException(0, (float)maxFuelAmount);
                        }
                        break;
                    }
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("Invalid input. Please enter a valid number for fuel amount.");
                }
                catch (ValueOutOfRangeException ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine($"Valid range: 0 to {ex.MaxValue}.");
                    Console.WriteLine("Please enter a valid fuel amount.");
                }
            }

            switch (vehicle.Wheels.Length)
            {
                case 2:
                    {
                        FuelMotorcycle fuelMotorcycle = vehicle as FuelMotorcycle;
                        fuelMotorcycle.Refuel(fuelAmount, fuelType);
                        break;
                    }
                case 5:
                    {
                        FuelCar fuelCar = vehicle as FuelCar;
                        fuelCar.Refuel(fuelAmount, fuelType);
                        break;
                    }
                case 12:
                    {
                        Truck truck = vehicle as Truck;
                        truck.Refuel(fuelAmount, fuelType);
                        break;
                    }
                default:
                    {
                        break;
                    }
            }

            Console.WriteLine("Refuel successful!\n");
         }
    }
}
