using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static Ex03.GarageLogic.EnumsProcedures;

namespace Ex03.GarageLogic
{
    public class Garage
    {
        private readonly Dictionary<string, VehicleOwner> r_VehicleOwnersList;

        public Garage()
        {
            r_VehicleOwnersList = new Dictionary<string, VehicleOwner>();
        }

        public Dictionary<string, VehicleOwner> VehicleOwnersList
        {
            get
            {
                return r_VehicleOwnersList;
            }
        }

        public void InsertNewVehicleOwner(VehicleOwner i_NewVehicleOwner)
        {
            r_VehicleOwnersList.Add(i_NewVehicleOwner.Vehicle.LicenseNumber, i_NewVehicleOwner);
        }

        public bool CheckIfVehicleExistInGarage(string i_LicenseNumber)
        {
            return r_VehicleOwnersList.ContainsKey(i_LicenseNumber);
        }

        public void UpdateVehicleStatus(string i_LicenseNumber, eVehicleStatus i_VehicleStatus)
        {
            if (!(CheckIfVehicleExistInGarage(i_LicenseNumber)))
            {
                throw new ArgumentException(string.Format("License number {0} is not in the garage", i_LicenseNumber));
            }

            r_VehicleOwnersList[i_LicenseNumber].VehicleStatus = i_VehicleStatus;
        }

        public void PrintAllLicenseNumbers()
        {
            List<string> listOfLicenseNumbers = r_VehicleOwnersList.Keys.ToList();

            if (listOfLicenseNumbers.Count == 0)
            {
                Console.WriteLine("Garage is empty");
            }
            else
            {
                foreach (string licenseNumber in listOfLicenseNumbers)
                {
                    Console.WriteLine(licenseNumber);
                }
            }
        }

        public void PrintLicenseNumbersByStatus(eVehicleStatus i_VehicleStatus)
        {
            List<string> listOfLicenseNumbers = r_VehicleOwnersList.Keys.ToList();

            if (listOfLicenseNumbers.Count == 0)
            {
                Console.WriteLine("Garage is empty");
            }
            else
            {
                foreach (string licenseNumber in listOfLicenseNumbers)
                {
                    if (r_VehicleOwnersList[licenseNumber].VehicleStatus.Equals(i_VehicleStatus))
                    {
                        Console.WriteLine(licenseNumber);
                    }
                }
            }
        }

        public void InflateTiresToMaximumAfterCheck(string i_LicenseNumber)
        {
            float currentAirPressure = r_VehicleOwnersList[i_LicenseNumber].Vehicle.WheelsList[0].CurrentAirPressure;
            float maxAirPressure = r_VehicleOwnersList[i_LicenseNumber].Vehicle.WheelsList[0].RecommendedMaxAirPressure;
            try
            {
                foreach (Wheel wheel in r_VehicleOwnersList[i_LicenseNumber].Vehicle.WheelsList)
                {
                    wheel.InflateAction(maxAirPressure - currentAirPressure);
                }

            }
            catch (ValueOutOfRangeException OORExp)
            {
                Console.WriteLine(OORExp.Message);
            }
            
        }

        public void RefuelAFuelBasedVehicleAfterCheck(string i_LicenseNumber, eFuelType i_FuelType, float i_AmountToFill)
        {        
            FuelBasedVehicle fuelBasedVehicle = r_VehicleOwnersList[i_LicenseNumber].Vehicle.EnergySource as FuelBasedVehicle;
            if (fuelBasedVehicle == null)
            {
                throw new ArgumentException(string.Format(
@"Wrong energy type.
Vehicle with license number {0} is an electric vehicle", i_LicenseNumber));
            }

            fuelBasedVehicle.RefuelingOperation(i_FuelType, i_AmountToFill);
            r_VehicleOwnersList[i_LicenseNumber].Vehicle.UpadateEnergyPercent();
        }

        public void ChargeAnElectricBasedVehicleAfterCheck(string i_LicenseNumber, float i_AmountToFill)
        {
            ElectricBasedVehicle electricBasedVehicle = r_VehicleOwnersList[i_LicenseNumber].Vehicle.EnergySource as ElectricBasedVehicle;
            if (electricBasedVehicle == null)
            {
                throw new ArgumentException(string.Format(
@"Wrong energy type.
Vehicle with license number {0} is an fuel vehicle", i_LicenseNumber));
            }

            r_VehicleOwnersList[i_LicenseNumber].Vehicle.EnergySource.Energyfilling(i_AmountToFill);
            r_VehicleOwnersList[i_LicenseNumber].Vehicle.UpadateEnergyPercent();
            
        }
        public void PrintVehicleOwnerInfoAfterCheck(string i_LicenseNumber)
        {
            if (CheckIfVehicleExistInGarage(i_LicenseNumber) == false)
            {
                throw new ArgumentException(string.Format("License number {0} is not in the garage", i_LicenseNumber));
            }

            Console.WriteLine(r_VehicleOwnersList[i_LicenseNumber].ToString());
        }

    }
}
