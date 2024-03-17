using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Ex03.GarageLogic.EnumsProcedures;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        private readonly string r_ModelName;
        private readonly string r_LicenseNumber;
        protected float m_RemainingEnergyPercentage;
        protected EnergySource m_EnergySource;
        protected readonly List<Wheel> r_WheelsList;
    
        public Vehicle(string i_ModelName, string i_LicenseNumber, float i_RemainingEnergyPercentage)
        {
            r_ModelName = i_ModelName;
            r_LicenseNumber = i_LicenseNumber;
            m_RemainingEnergyPercentage = i_RemainingEnergyPercentage;
            r_WheelsList = new List<Wheel>();

        }

        public string ModelName
        {
            get
            {
                return r_ModelName;
            }
        }

        public string LicenseNumber
        {
            get
            {
                return r_LicenseNumber;
            }
        }

        public float RemainingEnergyPercentage
        {
            get
            {
                return m_RemainingEnergyPercentage;
            }
        }

        public List<Wheel> WheelsList
        {
            get
            {
                return r_WheelsList;
            }
        }

        public EnergySource EnergySource
        {
            get
            {
                return m_EnergySource;
            }
        }

        public abstract void UpadateEnergyPercent();

        public abstract void AddAndCreateWheels(string i_ManufacturerName, float i_CurrentAirPressure);       

        public abstract void InitializeEnergySource(eFuelOrElectric i_FuelOrElectric, float i_CurrentAmountOfEnergyInVehicle);

        public override string ToString()
        {
            return string.Format(
@"License number: {0}
Model name: {1}

Wheels info:
{2}

Energy info:
{3}
Remaining energy percentage: {4}
",
r_LicenseNumber, r_ModelName, r_WheelsList[0].ToString(), m_EnergySource.ToString(), m_RemainingEnergyPercentage);
        }

    }
}
