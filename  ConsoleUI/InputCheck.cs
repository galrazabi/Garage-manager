using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex03.GarageLogic;
using static Ex03.ConsoleUI.UI;
using static Ex03.GarageLogic.EnumsProcedures;


namespace Ex03.ConsoleUI
{
    internal class InputCheck
    {
        public static string GetStringInput(string i_Msg, eStrOrNum i_StrOrNum)
        {
            string newStringInput = "";
            bool isValidInput = false;

            while (!isValidInput)
            {
                try
                {
                    Console.WriteLine(i_Msg);
                    newStringInput = ReadAndClearString();

                    if (i_StrOrNum == eStrOrNum.Num)
                    {
                        isNumeric(newStringInput);
                    }
                    else
                    {
                        isAlpha(newStringInput);
                    }

                    isValidInput = true;
                }

                catch (FormatException fe)
                {
                    Console.WriteLine(fe.Message);
                }
            }

            return newStringInput;
        }

        public static string ReadAndClearString()
        {
            string newInput = Console.ReadLine();
            Console.Clear();

            return newInput;
        }


        private static bool isAlpha(string i_Word)
        {
            foreach (char c in i_Word)
            {
                if (!char.IsLetter(c))
                {
                    throw new FormatException("The input is not an alpha based.");
                }
            }

            return true;
        }

        private static bool isNumeric(string i_Number)
        {
            foreach (char digit in i_Number)
            {
                if (!char.IsDigit(digit))
                {
                    throw new FormatException("The input is not an numeric based.");
                }
            }

            return true;
        }

        private static float checkAndReturnFloatValue(string i_StringToFloat, float i_MaxValue)
        {
            bool isValidInput = float.TryParse(i_StringToFloat, out float floatInput);
            if (isValidInput == false || floatInput < 0 || floatInput > i_MaxValue)
            {
                throw new ValueOutOfRangeException(0, i_MaxValue);
            }
            return floatInput;
        }
        public static int CheckIfIntBetweenMinAndMax(int i_MinValue, int i_MaxValue)
        {
            string numStr = ReadAndClearString();

            if (int.TryParse(numStr, out int intNumber) == false || intNumber < i_MinValue || intNumber > i_MaxValue)
            {
                throw new FormatException(String.Format("Bad choice. Not a number between {0} and {1}", i_MinValue, i_MaxValue));
            }

            return intNumber;
        }
        public static int CheckAndReturnPositiveInt(string i_StringToInt)
        {
            bool isValidInput = int.TryParse(i_StringToInt, out int intInput);
            if (isValidInput == false || intInput < 0)
            {
                throw new FormatException(String.Format("You should enter a positive int number, please try again."));
            }
            return intInput;
        }
        public static float CheckAndReturnPositiveFloat(string i_StringToFloat)
        {
            bool isValidInput = float.TryParse(i_StringToFloat, out float floatInput);
            if (isValidInput == false || floatInput < 0)
            {
                throw new FormatException(String.Format("You should enter a positive float number, please try again."));
            }
            return floatInput;
        }

        public static float GetPositiveFloat(string i_Msg)
        {
            string stringInput = "";
            bool isValidInput = false;
            float stringToFloat = 0f;

            while (!isValidInput)
            {
                try
                {
                    Console.WriteLine(i_Msg);
                    stringInput = ReadAndClearString();
                    stringToFloat = CheckAndReturnPositiveFloat(stringInput);
                    isValidInput = true;
                }
                catch (FormatException fe)
                {
                    Console.WriteLine(fe.Message);
                }
            }

            return stringToFloat;
        }

        public static int GetEnumOption(string i_Msg, string[] i_ListOfEnumTypes)
        {
            bool isValidInput = false;
            int inputUserchoiceNumber = 0;

            Console.WriteLine(i_Msg);
            while (!isValidInput)
            {
                try
                {
                    int idx = 1;
                    foreach (string enumType in i_ListOfEnumTypes)
                    {
                        Console.WriteLine("{0}: {1}", idx++, enumType);
                    }
                    inputUserchoiceNumber = CheckIfIntBetweenMinAndMax(1, idx - 1);
                    isValidInput = true;
                }

                catch (FormatException fe)
                {
                    Console.WriteLine(fe.Message);
                }
            }

            return inputUserchoiceNumber;
        }

 

        public static eVehicleType GetVehicleType()
        {
            string[] enumVehicleTypeList = GetListOfVehicleType();
            int numberOfVehicleType = GetEnumOption(AskForVehicleTypeMsg(), enumVehicleTypeList);
            eVehicleType enumVehicleType = (eVehicleType)numberOfVehicleType;

            return enumVehicleType;

        }

        public static eFuelOrElectric GetFuelOrElectric()
        {
            string[] enumFuelOrElectricList = GetListOfEnergyType();
            int numberOfFuelOrElectric = GetEnumOption(AskForFuelOrElectricMsg(), enumFuelOrElectricList);
            eFuelOrElectric enumFuelOrElectric = (eFuelOrElectric)numberOfFuelOrElectric;

            return enumFuelOrElectric;
        }

        public static eVehicleStatus GetStatus()
        {
            string[] enumVehicleStatusList = GetListOfStatus();
            int numberOfStatus = GetEnumOption(AskForStatusMsg(), enumVehicleStatusList);
            eVehicleStatus enumVehicleStatus = (eVehicleStatus)numberOfStatus;

            return enumVehicleStatus;

        }

        public static eFuelType GetFuelType()
        {
            string[] enumFuelTypeList = GetListOfFuelType();
            int numberOfFuelType = GetEnumOption(AskForFuelTypeMsg(), enumFuelTypeList);
            eFuelType enumFuelType = (eFuelType)numberOfFuelType;

            return enumFuelType;

        }

        public static eColor GetCarColor()
        {
            string[] enumCarColorList = GetListOfCarColor();
            int numberOfCarColors = GetEnumOption(AskForCarColorMsg(), enumCarColorList);
            eColor enumCarColor = (eColor)numberOfCarColors;

            return enumCarColor;
        }

        public static eLicenseType GetLicenseType()
        {
            string[] enumLicenseTypeList = GetListOfLicenseType();
            int numberOfLicenseType = GetEnumOption(AskForMotorcycleLicenseTypeMsg(), enumLicenseTypeList);
            eLicenseType enumLicenseType = (eLicenseType)numberOfLicenseType;

            return enumLicenseType;
        }

        public static eNumberOfDoors GetNumberOfDoors()
        {
            string[] enumNumberOfDoorsList = GetListOfNumOfDoors();
            int desiredNumberOfDoors = GetEnumOption(AskForCarNumberOfDoorsMsg(), enumNumberOfDoorsList);
            eNumberOfDoors enumNumberOfDoors = (eNumberOfDoors)desiredNumberOfDoors;

            return enumNumberOfDoors;

        }

        public static float GetPercentageOfFloatSmallerThanMax(float i_MaxFloat, string i_Msg)
        {
            string stringInputFromUser = "";
            bool isValidInput = false;
            float floatInput = 0f;

            while (!isValidInput)
            {
                try
                {
                    Console.WriteLine(i_Msg);
                    stringInputFromUser = ReadAndClearString();
                    floatInput = checkAndReturnFloatValue(stringInputFromUser, i_MaxFloat);
                    isValidInput = true;
                }
                catch (ValueOutOfRangeException OORExp)
                {
                    Console.WriteLine(OORExp.Message);
                }
            }

            return (floatInput / i_MaxFloat) * 100;
        }

        public static string GetAndCheckIfLiecenseNumberInGarage(Garage i_Garage)
        {
            bool isExist = false;
            string licenseNumber = "";

            while (isExist == false)
            {
                try
                {
                    licenseNumber = GetStringInput(AskForLicenseNumberMsg(), eStrOrNum.Num);
                    if (i_Garage.CheckIfVehicleExistInGarage(licenseNumber) == false)
                    {
                        throw new ArgumentException(string.Format("License number {0} is not in the garage", licenseNumber));
                    }
                    isExist = true;
                }

                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                    break;
                }
            }

            return licenseNumber;
        }

    }
}
