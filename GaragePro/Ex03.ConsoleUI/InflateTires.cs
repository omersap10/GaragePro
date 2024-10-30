using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex03.GarageLogic;
using Ex03.GarageLogic.eVehicleStatus;

namespace Ex03.ConsoleUI
{
    public class InflateTires
    {
        public static void DoInflateTires(AllVehicles garage)
        {
            Vehicle vehicle = FindVehicleByLicensePlate.SearchLicensePlate(garage);
            InflateToMax(vehicle);
        }

        public static void InflateToMax(Vehicle vehicle)
        {
            foreach (Wheel wheel in vehicle.Wheels)
            {
                wheel.CurrentAirPressure = wheel.MaxAirPressure;
            }
        }
    }
}
