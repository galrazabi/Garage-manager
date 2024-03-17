using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Ex03.GarageLogic.EnumsProcedures;

namespace Ex03.GarageLogic
{
    public class Motorcycle: Vehicle
    {
        private readonly eLicenseType r_LicenseType;
        private readonly int r_EngineVolume;
        private const float k_ElectricEnergyCapacity = 2.6f;
        private const float k_FuelEnergyCapacity = 6.4f;
        private const float k_WheelMaxAirPressure = 31f;
        private const int k_NumOfWheels = 2;
        private const eFuelType k_FuelType = eFuelType.Octane98;

        public Motorcycle(string i_ModelName, string i_LicenseNumber, float i_RemainingEnergyPercentage, eLicenseType i_LicenseType, int i_EngineVolume)
            : base(i_ModelName, i_LicenseNumber, i_RemainingEnergyPercentage)
        {
            r_LicenseType = i_LicenseType;
            r_EngineVolume = i_EngineVolume;
        }

        public eLicenseType LicenseType
        {
            get
            {
                return r_LicenseType;
            }
        }

        public int EngineVolume
        {
            get
            {
                return r_EngineVolume;
            }
        }

        public float ElectricEnergyCapacity
        {
            get
            {
                return k_ElectricEnergyCapacity;
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
            if (i_FuelOrElectric.Equals(eFuelOrElectric.Electric))
            {
                m_EnergySource = new ElectricBasedVehicle(k_ElectricEnergyCapacity, i_CurrentAmountOfEnergyInVehicle);
            }
            else if (i_FuelOrElectric.Equals(eFuelOrElectric.Fuel))
            {
                m_EnergySource = new FuelBasedVehicle(k_FuelType, k_FuelEnergyCapacity, i_CurrentAmountOfEnergyInVehicle);
            }
        }

        public override string ToString()
        {
            return string.Format(
@"Vehicle type: Motorcycle
License type: {0}
Engine volume: {1}
{2}", r_LicenseType, r_EngineVolume, base.ToString());
        }

    }
}
