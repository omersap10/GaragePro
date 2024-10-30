using System;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Garage app!");
            Console.WriteLine();
            AllVehicles? garage = new AllVehicles();

            while (true)
            {
                Console.WriteLine("Garage Menu:");
                Console.WriteLine("1. Add a new vehicle to the garage");
                Console.WriteLine("2. Display license plates of vehicles in the garage by status");
                Console.WriteLine("3. Change vehicle status");
                Console.WriteLine("4. Inflate tires of a vehicle");
                Console.WriteLine("5. Refuel a vehicle");
                Console.WriteLine("6. Charge an electric vehicle");
                Console.WriteLine("7. Display full details of a vehicle");
                Console.WriteLine("8. Exit\n");

                int choice;
                Console.Write("Enter your choice: ");
                try
                {
                    choice = int.Parse(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid choice. Please enter a number.");
                    continue;
                }

                if (choice < 1 || choice > 8)
                {
                    Console.WriteLine("Invalid choice. Please enter a number between 1 and 8.\n");
                    continue;
                }

                Vehicle? cuurentVehicle = null;

                switch (choice)
                {
                    case 1:
                        {
                            Console.Clear();
                            cuurentVehicle = AddVehicle.AddVehicleToGarage(garage);
                            break;
                        }
                    case 2:
                        {
                            Console.Clear();
                            DisplayLicensePlate.DisplayLicensePlatesByStatus(garage);
                            break;
                        }
                    case 3:
                        {
                            Console.Clear();
                            ChangeVehicleStatus.SetVehicleStatus(garage);
                            break;
                        }
                    case 4:
                        {
                            Console.Clear();
                            InflateTires.DoInflateTires(garage);
                            break;
                        }
                    case 5:
                        {
                            Console.Clear();
                            RefuelVehicle.DoRefuelVehicle(garage);
                            break;
                        }
                    case 6:
                        {
                            Console.Clear();
                            ChargeElectricVehicle.DoChargeElectricVehicle(garage);
                            break;
                        }
                    case 7:
                        {
                            Console.Clear();
                            DisplayFullVehicleDetails.DisplayVehicleDetails(garage);
                            break;
                        }
                    case 8:
                        Console.WriteLine("Exiting program. Goodbye!");
                        return;
                }
            }
        }
    }
}
