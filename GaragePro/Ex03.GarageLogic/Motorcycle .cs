using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex03.GarageLogic.eLicenseType;

namespace Ex03.GarageLogic
{
    public class Motorcycle : Vehicle
    {
        private LicenseType? type;
        private int? engineVolume;
        public LicenseType? Type { get => type; set => type = value; }
        public int? EngineVolume { get => engineVolume; set => engineVolume = value; }

        public Motorcycle(string model, string licensePlate, string ownerName, string ownerPhone, LicenseType? licenseType, int? engineVolume, string[]? manufacturer, float[]? currentAirPressure)//in the UI, ask user 2 manufacturer and currentAirPressure
             : base(model, licensePlate, ownerName, ownerPhone)
        {
            this.type = licenseType;
            this.engineVolume = engineVolume;

            this.Wheels = new Wheel[2];
            for (int i = 0; i < 2; i++)
            {
                this.Wheels[i] = new Wheel(manufacturer[i], currentAirPressure[i], 29);
            }
        }
    }
}
