using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Wheel
    {
        private string manufacturer;
        private float currentAirPressure;
        private float maxAirPressure;
        public string Manufacturer { get => manufacturer; set => manufacturer = value; }
        public float CurrentAirPressure { get => currentAirPressure; set => currentAirPressure = value; }
        public float MaxAirPressure { get => maxAirPressure; set => maxAirPressure = value; }

        public Wheel(string manufacturer, float currentAirPressure, float maxAirPressure)
        {
            this.manufacturer = manufacturer;
            this.currentAirPressure = currentAirPressure;
            this.maxAirPressure = maxAirPressure;
        }

        public bool Inflate(float airToAdd)
        {
            if (this.currentAirPressure + airToAdd <= this.maxAirPressure)
            {
                this.currentAirPressure += airToAdd;
                return true;
            }
            else
            {
              return false;
            }
        }
    }
}
