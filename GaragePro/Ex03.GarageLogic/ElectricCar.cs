using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex03.GarageLogic.eCarColor;
using Ex03.GarageLogic.eNumberOfDoors;

namespace Ex03.GarageLogic
{
    public class ElectricCar : Car
    {
        private float? remainingBatteryHours;
        private float maxBatteryChargeHours;

        public float? RemainingBatteryHours { get => remainingBatteryHours; set => remainingBatteryHours = value; }
        public float MaxBatteryChargeHours { get => maxBatteryChargeHours; set => maxBatteryChargeHours = value; }

        public ElectricCar(string model, string licensePlate, string ownerName, string ownerPhone, CarColor? color, NumberOfDoors? doors, string[]? manufacturer, float[]? currentAirPressure, float? remainingBatteryHours)
            : base(model, licensePlate, ownerName, ownerPhone, color, doors, manufacturer, currentAirPressure)
        {
            this.remainingBatteryHours = remainingBatteryHours;
            this.maxBatteryChargeHours = (float)4.8;
            this.EnergyRemainingPercentage = (this.RemainingBatteryHours.HasValue && this.MaxBatteryChargeHours != 0) ? (this.RemainingBatteryHours.Value / this.MaxBatteryChargeHours) * 100 : 0;
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

