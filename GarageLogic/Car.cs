using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Ex03.GarageLogic.EnumsProcedures;


namespace Ex03.GarageLogic
{
    public class Car: Vehicle
    {      
        private readonly eColor r_CarColor;
        private readonly eNumberOfDoors r_NumberOfDoors;
        private const float k_ElectricEnergyCapacity = 5.2f;
        private const float k_FuelEnergyCapacity = 46f;
        private const float k_WheelMaxAirPressure = 33f;
        private const int k_NumOfWheels = 5;
        private const eFuelType k_FuelType = eFuelType.Octane95;

        public Car(string i_ModelName, string i_LicenseNumber, float i_RemainingEnergyPercentage, eColor i_CarColor, eNumberOfDoors i_NumberOfDoors)
            : base(i_ModelName, i_LicenseNumber, i_RemainingEnergyPercentage)
        {         
            r_CarColor = i_CarColor;
            r_NumberOfDoors = i_NumberOfDoors;
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

        public eColor CarColor
        {
            get
            {
                return r_CarColor;
            }
        }
        
        public eNumberOfDoors NumberOfDoors
        {
            get
            {
                return r_NumberOfDoors;
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
@"Vehicle type: Car
Color: {0}
Number of doors: {1}
{2}", r_CarColor, r_NumberOfDoors, base.ToString());
        }
    }
}
