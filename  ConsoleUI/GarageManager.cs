using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex03.GarageLogic;
using static Ex03.ConsoleUI.UI;
using static Ex03.ConsoleUI.InputCheck;
using static Ex03.GarageLogic.EnumsProcedures;
using static Ex03.GarageLogic.NewVehicleCreator;








namespace Ex03.ConsoleUI
{
    public class GarageManager
    {
        private readonly static Garage r_Garage = new Garage();

        public static void LandingPageDisplay()
        {

            string landingPage = string.Format(
 @"╔═════════════════════════════════════════════════╗
║           Choose a number between 1-8           ║
║            to perform the desired action        ║
╠═════════════════════════════════════════════════╣
║ 1. Insert a new vehicle to the garage           ║
║ 2. Display the license numbers of all vehicles  ║
║    in the garage                                ║
║ 3. Display the license numbers of specific      ║
║    vehicles in the garage based on their status ║
║ 4. Update the status of a particular vehicle    ║
║ 5. Inflate the tire air pressure of a vehicle   ║
║    to its recommended capacity                  ║
║ 6. Refuel a fuel energy-based vehicle           ║
║ 7. Charge an electric vehicle                   ║
║ 8. Display information on a vehicle             ║
╚═════════════════════════════════════════════════╝");
            int action;
            bool isExited = false;
            string exitStr;

            while (!isExited)
            {
                Console.Clear();
                try
                {
                    Console.WriteLine(landingPage);
                    action = CheckIfIntBetweenMinAndMax(1, 8);
                    switch (action)
                    {
                        case 1:
                            insertNewVehicle(r_Garage);
                            break;
                        case 2:
                            r_Garage.PrintAllLicenseNumbers();
                            break;
                        case 3:
                            r_Garage.PrintLicenseNumbersByStatus(GetStatus());
                            break;
                        case 4:
                            changeVehicleStatus(r_Garage);
                            break;
                        case 5:
                            inflateTiresToMaximum(r_Garage);
                            break;
                        case 6:                           
                            refuelAFuelBasedVehicle(r_Garage, GetFuelType(), GetPositiveFloat(AskForAmountOfEnergyToFillMsg()));
                            break;
                        case 7:
                            chargeAnElectricBasedVehicle(r_Garage, GetPositiveFloat(AskForAmountOfEnergyToFillMsg()));
                            break;
                        case 8:
                            printVehicleOwnerInfo(r_Garage);
                            break;
                    }

                    AskToExitMsg();
                    exitStr = ReadAndClearString();
                    exitStr = exitStr.ToUpper();

                    if (exitStr.Equals("Q"))
                    {
                        isExited = true;
                    }
                }

                catch (FormatException fe)
                {
                    Console.WriteLine($"{fe.Message}{Environment.NewLine}Press any key to go back to menu..");
                    ReadAndClearString();
                }
            }
        }

        private static void insertNewVehicle(Garage i_Garage)
        {
            string licenseNumber = GetStringInput(AskForLicenseNumberMsg(), eStrOrNum.Num);
            bool isVehicleExistInGarage = i_Garage.CheckIfVehicleExistInGarage(licenseNumber);

            if (isVehicleExistInGarage == false)
            {
                string ownerName = GetStringInput(AskForOwnerNameMsg(), eStrOrNum.Str);
                string ownerPhoneNumber = GetStringInput(AskForOwnerPhoneNumberMsg(), eStrOrNum.Num);

                eVehicleType vehicleType = GetVehicleType();
                eFuelOrElectric fuelOrElectric;
                if (vehicleType == eVehicleType.Truck)
                {
                    fuelOrElectric = eFuelOrElectric.Fuel;
                }
                else
                {
                    fuelOrElectric = GetFuelOrElectric();
                }
                float vehicleMaxEnergy = getVehicleMaxEnergy(vehicleType, fuelOrElectric);
                string modelName = GetStringInput(AskForVehicleModelNameMsg(), eStrOrNum.Str);

                float remainingEnergyPercentage = GetPercentageOfFloatSmallerThanMax(vehicleMaxEnergy, AskForVehicleRemainingEnergyMsg());
                string wheelManufacturerName = GetStringInput(AskForWheelManufacturerNameMsg(), eStrOrNum.Str);
                Vehicle vehicle = createNewVehicle(licenseNumber, vehicleType, fuelOrElectric, modelName, remainingEnergyPercentage, vehicleMaxEnergy, wheelManufacturerName);
                VehicleOwner vehicleOwner = new VehicleOwner(ownerName, ownerPhoneNumber, vehicle);
                i_Garage.InsertNewVehicleOwner(vehicleOwner);
                InsertNewVehicleSucceededMsg();
            }
            else
            {
                i_Garage.UpdateVehicleStatus(licenseNumber, eVehicleStatus.InRepair);
                VehicleIsExistMsg();
            }
        }        

        private static void initWheelParams(Vehicle i_Vehicle, string i_WheelManufacturerName)
        {
            string stringWheelCurrentAirPressure = "";
            bool isValidWheelCurrentAirPressure = false;
            float floatValidWheelCurrentAirPressure = 0f;

            while (!isValidWheelCurrentAirPressure)
            {
                try
                {
                    AskForCurrentAirPressureMsg();
                    stringWheelCurrentAirPressure = ReadAndClearString();
                    floatValidWheelCurrentAirPressure = CheckAndReturnPositiveFloat(stringWheelCurrentAirPressure);
                    i_Vehicle.AddAndCreateWheels(i_WheelManufacturerName, floatValidWheelCurrentAirPressure);
                    isValidWheelCurrentAirPressure = true;
                }
                catch (FormatException fe)
                {
                    Console.WriteLine(fe.Message);
                }
                catch (ValueOutOfRangeException OORExp)
                {
                    Console.WriteLine(OORExp.Message);
                }
            }
        }

        private static Vehicle createNewVehicle(string i_LicenseNumber, eVehicleType i_VehicleType, eFuelOrElectric i_FuelOrElectric, string i_ModelName, float i_RemainingEnergyPercentage, float i_VehicleMaxEnergy, string i_WheelManufacturerName)
        {
            Vehicle newVehicle = null;
            float currVehicleEnergy = i_RemainingEnergyPercentage * i_VehicleMaxEnergy / 100;
            switch (i_VehicleType)
            {
                case eVehicleType.Car:
                    eColor carColor = GetCarColor();
                    eNumberOfDoors carNumberOfDoors = GetNumberOfDoors();
                    newVehicle = CarCreator(i_ModelName, i_LicenseNumber, i_RemainingEnergyPercentage, carColor, carNumberOfDoors);
                    break;

                case eVehicleType.Truck:
                    bool isContainsDangerousMaterials = isTruckContainsDangerousMaterials();
                    float cargoTankVolume = GetPositiveFloat(AskForCargoTankVolumeMsg());
                    newVehicle = TruckCreator(i_ModelName, i_LicenseNumber, i_RemainingEnergyPercentage, cargoTankVolume, isContainsDangerousMaterials);
                    break;

                case eVehicleType.Motorcycle:
                    eLicenseType motorcycleLicenseType = GetLicenseType();
                    int motorcycleEngineVolume = getMotorcycleEngineVolume();
                    newVehicle = MotorcycleCreator(i_ModelName, i_LicenseNumber, i_RemainingEnergyPercentage, motorcycleLicenseType, motorcycleEngineVolume);
                    break;
            }

            initWheelParams(newVehicle, i_WheelManufacturerName);
            newVehicle.InitializeEnergySource(i_FuelOrElectric, currVehicleEnergy);
            return newVehicle;
        }

        private static int getMotorcycleEngineVolume()
        {
            string stringMotorcycleEngineVolume = "";
            bool isValidMotorcycleEngineVolume = false;
            int intMotorcycleEngineVolume = 0;

            while (!isValidMotorcycleEngineVolume)
            {
                try
                {
                    AskForMotorcycleEngineVolumeMsg();
                    stringMotorcycleEngineVolume = ReadAndClearString();
                    intMotorcycleEngineVolume = CheckAndReturnPositiveInt(stringMotorcycleEngineVolume);
                    isValidMotorcycleEngineVolume = true;
                }
                catch (FormatException fe)
                {
                    Console.WriteLine(fe.Message);
                }
            }

            return intMotorcycleEngineVolume;
        }

        private static bool isTruckContainsDangerousMaterials()
        {
            string stringIsContainsDangerousMaterials = "";
            bool isContainsDangerousMaterials = false;
            bool isValidInput = false;

            while (!isValidInput)
            {
                try
                {
                    AskIfContainsDangerousMaterialsMsg();
                    stringIsContainsDangerousMaterials = ReadAndClearString();
                    stringIsContainsDangerousMaterials.ToUpper();

                    if (stringIsContainsDangerousMaterials == "Y")
                    {
                        isContainsDangerousMaterials = true;
                    }
                    else if (stringIsContainsDangerousMaterials == "N")
                    {
                        isContainsDangerousMaterials = false;
                    }
                    else
                    {
                        throw new FormatException("The input is not a valid.");
                    }
                    isValidInput = true;
                }
                catch (FormatException fe)
                {
                    Console.WriteLine(fe.Message);
                }
            }

            return isContainsDangerousMaterials;
        }

        private static void inflateTiresToMaximum(Garage i_Garage)
        {
            List<string> listOfLicenseNumbers = i_Garage.VehicleOwnersList.Keys.ToList();

            if (listOfLicenseNumbers.Count == 0)
            {
                GarageIsEmptyMsg();
            }
            else
            {
                string licenseNumber = GetAndCheckIfLiecenseNumberInGarage(i_Garage);
                i_Garage.InflateTiresToMaximumAfterCheck(licenseNumber);
                UpdateDoneMsg();
            }
            
        }

        private static void refuelAFuelBasedVehicle(Garage i_Garage, eFuelType i_FuelType, float i_AmounEnergyToFill)
        {
            List<string> listOfLicenseNumbers = i_Garage.VehicleOwnersList.Keys.ToList();

            if (listOfLicenseNumbers.Count == 0)
            {
                GarageIsEmptyMsg();
            }
            else
            {
                bool isValid = false;
                while (isValid == false)
                {
                    try
                    {
                        string licenseNumber = GetAndCheckIfLiecenseNumberInGarage(i_Garage);
                        i_Garage.RefuelAFuelBasedVehicleAfterCheck(licenseNumber, i_FuelType, i_AmounEnergyToFill);
                        UpdateDoneMsg();
                        isValid = true;
                    }
                    catch (FormatException fe)
                    {
                        Console.WriteLine(fe.Message);
                        break;
                    }
                    catch (ValueOutOfRangeException OORExp)
                    {
                        Console.WriteLine(OORExp.Message);
                        break;
                    }
                    catch(ArgumentException argExp)
                    {
                        Console.WriteLine(argExp.Message);
                        break;
                    }
                }
            }            
        }

        private static void chargeAnElectricBasedVehicle(Garage i_Garage, float i_AmounEnergyToFill)
        {
            List<string> listOfLicenseNumbers = i_Garage.VehicleOwnersList.Keys.ToList();

            if (listOfLicenseNumbers.Count == 0)
            {
                UI.GarageIsEmptyMsg();
            }
            else
            {
                bool isValid = false;
                while (isValid == false)
                {
                    try
                    {
                        string licenseNumber = GetAndCheckIfLiecenseNumberInGarage(i_Garage);
                        i_Garage.ChargeAnElectricBasedVehicleAfterCheck(licenseNumber, i_AmounEnergyToFill);
                        UpdateDoneMsg() ;   
                        isValid = true;
                    }
                    catch (FormatException fe)
                    {
                        Console.WriteLine(fe.Message);
                        break;
                    }
                    catch (ValueOutOfRangeException OORExp)
                    {
                        Console.WriteLine(OORExp.Message);
                        break;
                    }
                    catch (ArgumentException argExp)
                    {
                        Console.WriteLine(argExp.Message);
                        break;
                    }
                }
            }
        }

        private static void printVehicleOwnerInfo(Garage i_Garage)
        {
            List<string> listOfLicenseNumbers = i_Garage.VehicleOwnersList.Keys.ToList();

            if (listOfLicenseNumbers.Count == 0)
            {
                GarageIsEmptyMsg();
            }
            else
            {
                try
                {
                    string licenseNumber = GetAndCheckIfLiecenseNumberInGarage(i_Garage);
                    i_Garage.PrintVehicleOwnerInfoAfterCheck(licenseNumber);
                }
                catch (ArgumentException argExp)
                {
                    Console.WriteLine(argExp.Message);
                }
                
            }
        }

        private static void changeVehicleStatus(Garage i_Garage)
        {
            List<string> listOfLicenseNumbers = i_Garage.VehicleOwnersList.Keys.ToList();

            if (listOfLicenseNumbers.Count == 0)
            {
                GarageIsEmptyMsg();
            }
            else
            {
                string licenseNumber = GetAndCheckIfLiecenseNumberInGarage(i_Garage);
                eVehicleStatus vehicleStatus = GetStatus();
                i_Garage.UpdateVehicleStatus(licenseNumber, vehicleStatus);
            }            
        }

        private static float getVehicleMaxEnergy(eVehicleType i_VehicleType, eFuelOrElectric i_FuelOrElectric)
        {
            float maxEnergy = 0f;
            if (i_VehicleType == eVehicleType.Motorcycle && i_FuelOrElectric == eFuelOrElectric.Electric)
            {
                maxEnergy = 2.6f;
            }
            else if (i_VehicleType == eVehicleType.Motorcycle && i_FuelOrElectric == eFuelOrElectric.Fuel)
            {
                maxEnergy = 6.4f;
            }
            else if (i_VehicleType == eVehicleType.Car && i_FuelOrElectric == eFuelOrElectric.Electric)
            {
                maxEnergy = 5.2f;
            }
            else if (i_VehicleType == eVehicleType.Car && i_FuelOrElectric == eFuelOrElectric.Fuel)
            {
                maxEnergy = 46f;
            }
            else
            {
                maxEnergy = 135f;
            }
            return maxEnergy;
        }
    }
}
