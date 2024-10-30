using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex03.GarageLogic;
using Ex03.GarageLogic.eCarColor;
using Ex03.GarageLogic.eVehicleStatus;

namespace Ex03.ConsoleUI
{
    public class ChangeVehicleStatus
    {
        public static void SetVehicleStatus(AllVehicles garage)
        {
            Vehicle vehicle = FindVehicleByLicensePlate.SearchLicensePlate(garage);

            Console.WriteLine("Enter the vehicle's new status (InRepair, Repaired, Paid):");
            String newStatus = Console.ReadLine();
            while (true)
            {
                try
                {
                    ValidateStatus(newStatus);
                    break; 
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid status format. Please enter a valid status (InRepair, Repaired, Paid).");
                    newStatus = Console.ReadLine();
                }
            }

            ChangeStatus(newStatus, vehicle);
            Console.WriteLine("Change status successful!\n");
        }

        public static void ValidateStatus(string status)
        {
            if (!status.Equals("InRepair") && !status.Equals("Repaired") && !status.Equals("Paid"))
            {
                throw new FormatException();
            }
        }

        public static void ChangeStatus(String status, Vehicle vehicle)
        {
            switch (status)
            {
                case "InRepair":
                    vehicle.Status = VehicleStatus.InRepair;
                    break;
                case "Repaired":
                    vehicle.Status = VehicleStatus.Repaired;
                    break;
                case "Paid":
                    vehicle.Status = VehicleStatus.Paid;
                    break;
                default:
                    throw new ArgumentException("Invalid vehicle status");
            }
        }
    }
}
