using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Ex03.GarageLogic.EnumsProcedures;
namespace Ex03.GarageLogic
{
    public class Wheel
    {
        private readonly string r_ManufacturerName;
        private float m_CurrentAirPressure;
        private readonly float r_RecommendedMaxAirPressure;

        public Wheel(string i_ManufacturerName, float i_CurrentAirPressure, float i_RecommendedMaxAirPressure)
        {
            if (i_CurrentAirPressure > i_RecommendedMaxAirPressure || i_CurrentAirPressure < 0)
            {
                throw new ValueOutOfRangeException(0, i_RecommendedMaxAirPressure);
            }

            r_ManufacturerName = i_ManufacturerName;
            m_CurrentAirPressure = i_CurrentAirPressure;
            r_RecommendedMaxAirPressure = i_RecommendedMaxAirPressure;
        }

        public string ManufacturerName
        {
            get
            {
                return r_ManufacturerName;
            }
        }

        public float CurrentAirPressure
        {
            get
            {
                return m_CurrentAirPressure;
            }
            set
            {
                m_CurrentAirPressure = value;
            }
        }

        public float RecommendedMaxAirPressure
        {
            get
            {
                return r_RecommendedMaxAirPressure;
            }
        }


        public void InflateAction (float i_AirToAdd)
        {
            if (r_RecommendedMaxAirPressure < (i_AirToAdd + m_CurrentAirPressure))
            {
                throw new ValueOutOfRangeException(0, r_RecommendedMaxAirPressure - m_CurrentAirPressure);
                
            }
            m_CurrentAirPressure += i_AirToAdd;
        }

        public override string ToString()
        {
            return string.Format(
@"Manufacturer name: {0}
Current air pressure: {1}
Recommended max air pressure: {2}", r_ManufacturerName, m_CurrentAirPressure, r_RecommendedMaxAirPressure);
        }
    }
}
