using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Ex03.GarageLogic.EnumsProcedures;

namespace Ex03.GarageLogic
{
    public class Truck: Vehicle
    {
        private readonly float r_CargoTankVolume;
        private const float k_FuelEnergyCapacity = 135f;
        private const float k_WheelMaxAirPressure = 26f;
        private const int k_NumOfWheels = 14;
        private readonly bool r_IsContainsDangerousMaterials;
        private const eFuelType k_FuelType = eFuelType.Soler;

        public Truck(string i_ModelName, string i_LicenseNumber, float i_RemainingEnergyPercentage, float i_CargoTankVolume, bool i_IsContainsDangerousMaterials)
            : base(i_ModelName, i_LicenseNumber, i_RemainingEnergyPercentage)
        {
            r_CargoTankVolume = i_CargoTankVolume;           
            r_IsContainsDangerousMaterials = i_IsContainsDangerousMaterials;
        }

        public float CargoTankVolume
        {
            get
            {
                return r_CargoTankVolume;
            }
        }

        public float FuelEnergyCapacity
        {
            get
            {
                return k_FuelEnergyCapacity;
            }
        }

        public float WheelMaxAirPressure
        {
            get
            {
                return k_WheelMaxAirPressure;
            }
        }

        public float NumOfWheels
        {
            get
            {
                return k_NumOfWheels;
            }
        }

        public bool IsContainsDangerousMaterials
        {
            get
            {
                return r_IsContainsDangerousMaterials;
            }
        }

        public static float GetMaxEnergy()
        {
            return k_FuelEnergyCapacity;
        }

        public override void AddAndCreateWheels(string i_ManufacturerName, float i_CurrentAirPressure)
        {
            for (int i = 0; i < k_NumOfWheels; i++)
            {
                r_WheelsList.Add(new Wheel(i_ManufacturerName, i_CurrentAirPressure, k_WheelMaxAirPressure));
            }
        }

        public override void UpadateEnergyPercent()
        {
            m_RemainingEnergyPercentage = (m_EnergySource.CurrentAmountOfEnergyInVehicle / m_EnergySource.MaxAmountOfEnergyInVehicle) * 100;
        }

        public override void InitializeEnergySource(eFuelOrElectric i_FuelOrElectric, float i_CurrentAmountOfEnergyInVehicle)
        {           
            if (i_FuelOrElectric.Equals(eFuelOrElectric.Fuel))
            {
                m_EnergySource = new FuelBasedVehicle(k_FuelType, k_FuelEnergyCapacity, i_CurrentAmountOfEnergyInVehicle);
            }
        }

        public override string ToString()
        {
            return string.Format(
@"Vehicle type: Truck
Cargo tank volume: {0}
Is the truck contains dangerous materials: {1}
{2}", r_CargoTankVolume, r_IsContainsDangerousMaterials, base.ToString());
        }

    }
}
