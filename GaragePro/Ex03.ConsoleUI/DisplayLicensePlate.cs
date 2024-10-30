using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Ex03.GarageLogic;
using Ex03.GarageLogic.eCarColor;
using Ex03.GarageLogic.eVehicleStatus;

namespace Ex03.ConsoleUI
{
    public class DisplayLicensePlate
    {
        public static void DisplayLicensePlatesByStatus(AllVehicles garage)
        {
            string answer;

            while (true)
            {
                Console.WriteLine("Would you like to filter by vehicle status? (Y/N)");
                answer = Console.ReadLine();

                try
                {
                    if (answer.Equals("y") && answer.Equals("Y") && answer.Equals("N") && answer.Equals("n"))
                    {
                        throw new FormatException("Invalid input. Please enter 'Y' or 'N'.");
                    }

                    break; 
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            if (answer.Equals("y") || answer.Equals("Y"))
            {
                while (true)
                {
                    Console.WriteLine("What vehicle status would you like to filter? (InRepair, Repaired, Paid)");
                    string status = Console.ReadLine();

                    try
                    {
                        if (status != "InRepair" && status != "Repaired" && status != "Paid")
                        {
                            throw new FormatException("Invalid status entered.");
                        }

                        PrintLicensePlatesByStatus(status, garage);
                        break; 
                    }
                    catch (FormatException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
            else
            {
                PrintLicensePlatesByStatus("InRepair", garage);
                PrintLicensePlatesByStatus("Repaired", garage);
                PrintLicensePlatesByStatus("Paid", garage);
            }
        }

        public static void PrintLicensePlatesByStatus(string status, AllVehicles garage)
        {
            foreach (Vehicle vehicle in garage.VehiclesInGarage)
            {
                if (vehicle.Status.ToString().Equals(status))
                {
                    Console.WriteLine(vehicle.LicensePlate);
                }
            }
            Console.WriteLine();
        }
    }
}
