using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Ex03.GarageLogic.EnumsProcedures;

namespace Ex03.GarageLogic
{
    public class NewVehicleCreator
    {
        public static Car CarCreator (string i_ModelName, string i_LicenseNumber, float i_RemainingEnergyPercentage, eColor i_CarColor, eNumberOfDoors i_NumberOfDoors)
        {
            return new Car(i_ModelName, i_LicenseNumber, i_RemainingEnergyPercentage, i_CarColor, i_NumberOfDoors);
        }

        public static Truck TruckCreator (string i_ModelName, string i_LicenseNumber, float i_RemainingEnergyPercentage, float i_CargoTankVolume, bool i_IsContainsDangerousMaterials)

        {
            return new Truck(i_ModelName, i_LicenseNumber, i_RemainingEnergyPercentage, i_CargoTankVolume, i_IsContainsDangerousMaterials);
        }        

        public static Motorcycle MotorcycleCreator (string i_ModelName, string i_LicenseNumber, float i_RemainingEnergyPercentage, eLicenseType i_LicenseType, int i_EngineVolume)

        {
            return new Motorcycle(i_ModelName, i_LicenseNumber, i_RemainingEnergyPercentage, i_LicenseType, i_EngineVolume);
        }
    }
}
