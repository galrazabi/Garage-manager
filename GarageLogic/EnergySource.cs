using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Ex03.GarageLogic.EnumsProcedures;

namespace Ex03.GarageLogic
{
    public abstract class EnergySource
    {
        private readonly eFuelOrElectric r_FuelOrElectric;
        private float m_CurrentAmountOfEnergyInVehicle;
        private readonly float r_MaxAmountOfEnergyInVehicle;

        public EnergySource(float i_CurrentAmountOfEnergyInVehicle, float i_MaxAmountOfEnergyInVehicle)
        {
            m_CurrentAmountOfEnergyInVehicle = i_CurrentAmountOfEnergyInVehicle;
            r_MaxAmountOfEnergyInVehicle = i_MaxAmountOfEnergyInVehicle;
        }

        public eFuelOrElectric FuelOrElectric
        {
            get
            {
                return r_FuelOrElectric;
            }
        }        

        public float CurrentAmountOfEnergyInVehicle
        {
            get
            {
                return m_CurrentAmountOfEnergyInVehicle;
            }
            set
            {
                m_CurrentAmountOfEnergyInVehicle = value;
            }
        }

        public float MaxAmountOfEnergyInVehicle
        {
            get
            {
                return r_MaxAmountOfEnergyInVehicle;
            }
        }


        public void Energyfilling(float i_AmountOfEnergyToAdd)
        {
            if (r_MaxAmountOfEnergyInVehicle >= m_CurrentAmountOfEnergyInVehicle + i_AmountOfEnergyToAdd)
            {
                m_CurrentAmountOfEnergyInVehicle += i_AmountOfEnergyToAdd;
            }
            else
            {
                throw new ValueOutOfRangeException(0, r_MaxAmountOfEnergyInVehicle);
            }
        }


        public override string ToString()
        {
            return "";
        }
    }
}
