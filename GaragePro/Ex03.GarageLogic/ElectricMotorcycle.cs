using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex03.GarageLogic.eLicenseType;

namespace Ex03.GarageLogic
{
    public class ElectricMotorcycle : Motorcycle
    {
        public float? remainingBatteryHours;
        public float maxBatteryChargeHours;

        public float? RemainingBatteryHours { get => remainingBatteryHours; set => remainingBatteryHours = value; }
        public float MaxBatteryChargeHours { get => maxBatteryChargeHours; set => maxBatteryChargeHours = value; }

        public ElectricMotorcycle(string model, string licensePlate, string ownerName, string ownerPhone, LicenseType? licenseType, int? engineVolume, string[]? manufacturer, float[]? currentAirPressure, float? remainingBatteryHours)
            : base(model, licensePlate, ownerName, ownerPhone, licenseType, engineVolume, manufacturer, currentAirPressure)
        {
            this.remainingBatteryHours = remainingBatteryHours;
            this.maxBatteryChargeHours = (float)2.8;
            this.EnergyRemainingPercentage = (this.RemainingBatteryHours.HasValue && this.MaxBatteryChargeHours!=0) ? (this.RemainingBatteryHours.Value / this.MaxBatteryChargeHours) * 100 : 0;
        }

        public bool ChargeBattery(float hoursToAdd)
        {
            if (hoursToAdd <= 0)
            {
                return false;
            }

            if (hoursToAdd + this.remainingBatteryHours > this.maxBatteryChargeHours)
            {
                return false;
            }
            else
            {
                this.remainingBatteryHours += hoursToAdd;
                return true;
            }
        }
    
    }
}
