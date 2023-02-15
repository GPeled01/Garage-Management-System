using System;
using System.Threading;
using Ex03.GarageLogic;
using Ex03.GarageLogic.Enums;
using static Ex03.GarageLogic.VehicleInitalizer;

namespace Ex03.ConsoleUI
{
    internal static class VehicleDataCollector
    {
        internal static Client CollectClientData()
        {
            string clientName;
            string clientPhoneNumber = "";
            bool isValidInput = false;

            Console.WriteLine("Please enter client name:");
            clientName = Console.ReadLine();
            while (!isValidInput)
            {
                Console.Clear();
                Console.WriteLine("Please enter client phone number:");
                clientPhoneNumber = Console.ReadLine();
                if (!isDigitsOnly(clientPhoneNumber))
                {
                    Console.WriteLine("Invalid phone number, try again");
                    Thread.Sleep(800);
                }

                isValidInput = true;
            }

            return new Client(clientName, clientPhoneNumber);
        }

        private static bool isDigitsOnly(string str)
        {
            bool isOnlyDigits = false;
            foreach (char c in str)
            {
                if (c >= '0' || c <= '9')
                    isOnlyDigits = true;
            }

            return isOnlyDigits;
        }

        // $G$ DSN-001 (-20) The UI must not know specific types and their properties concretely!
        // It means that when adding a new type you'll have to change the code here too!
        internal static Vehicle CollectMotorcycleData(string i_LicensePlate, string i_ModelName, float i_CurrentEnergy,
            bool i_IsFuelBased, string i_WheelsManufacturer, float i_CurrentAirPressure)
        {
            Vehicle vehicle;
            eLicenseType licenseType;
            int engineCapacity;
            string message = @"Please provide license type:
1. A
2. B1
3. AA
4. BB";
            licenseType = (eLicenseType) UserInputHelper.RecieveMenuInput(message, 1, 4);
            Console.Clear();
            message = "Please provide engine capacity";
            engineCapacity = UserInputHelper.RecieveInputAndConvertToInt(message);
            if (i_IsFuelBased)
            {
                vehicle = VehicleInitalizer.InitFuelMotorcycle(i_ModelName, i_LicensePlate, licenseType, engineCapacity,
                    i_WheelsManufacturer, i_CurrentEnergy, i_CurrentAirPressure);
            }
            else
            {
                vehicle = VehicleInitalizer.InitElectricMotorcycle(i_ModelName, i_LicensePlate, licenseType,
                    engineCapacity, i_WheelsManufacturer, i_CurrentEnergy, i_CurrentAirPressure);
            }

            return vehicle;
        }

        internal static Truck CollectTruckData(string i_LicensePlate, string i_ModelName, float i_CurrentEnergy,
            string i_WheelsManufacturer, float i_CurrentAirPressure)
        {
            bool hasRefrigeratedContent;
            string message;
            float trunkVolume;
            int hasRefrigeratedContentInt;

            Console.Clear();
            message = @"Does the truck contains refrigerated content?:
0. No
1. Yes";
            hasRefrigeratedContentInt = UserInputHelper.RecieveMenuInput(message, 0, 1);
            if (hasRefrigeratedContentInt == 0)
            {
                hasRefrigeratedContent = false;
            }
            else
            {
                hasRefrigeratedContent = true;
            }

            Console.Clear();
            message = "Enter trunk volume:";
            trunkVolume = UserInputHelper.RecieveInputAndConvertToFloat(message);
            return VehicleInitalizer.InitTruck(i_ModelName, i_LicensePlate, i_CurrentEnergy, hasRefrigeratedContent,
                trunkVolume, i_WheelsManufacturer, i_CurrentAirPressure);

        }

        internal static Vehicle CollectCarData(string i_LicensePlate, string i_ModelName, float i_CurrentEnergy,
            bool i_IsFuelBased, string i_WheelsManufacturer, float i_CurrentWheelAirPressure)
        {
            Vehicle vehicle;
            eColor color;
            eDoorsNum doorsNum;
            string message;
            message = @"Please provide car color:
1. Red
2. White
3. Green
4. Blue";
            color = (eColor) UserInputHelper.RecieveMenuInput(message, 1, 4);
            Console.Clear();
            message = @"Please provide car doors number:
1. One
2. Two
3. Three
4. Four";
            doorsNum = (eDoorsNum) UserInputHelper.RecieveMenuInput(message, 1, 4);
            Console.Clear();
            if (i_IsFuelBased)
            {
                vehicle = VehicleInitalizer.InitFuelCar(i_ModelName, i_LicensePlate, i_CurrentEnergy, color, doorsNum,
                    i_WheelsManufacturer, i_CurrentWheelAirPressure);
            }
            else
            {
                vehicle = VehicleInitalizer.InitElectricCar(i_ModelName, i_LicensePlate, i_CurrentEnergy, color,
                    doorsNum, i_WheelsManufacturer, i_CurrentWheelAirPressure);
            }

            return vehicle;
        }

        internal static Vehicle CollectVehicleData(eVehicleKind i_VehicleKind, string i_LicensePlate)
        {
            string modelName, tank, message, licensePlate, wheelsManufacturer;
            float currentEnergy = 0f, currentWheelAirPressure = 0f;
            licensePlate = i_LicensePlate;
            Vehicle vehicle = null;

            Console.WriteLine("Please enter vehicle model:");
            modelName = Console.ReadLine();
            if (i_VehicleKind == eVehicleKind.FuelCar || i_VehicleKind == eVehicleKind.FuelMotorcycle ||
                i_VehicleKind == eVehicleKind.Truck)
            {
                tank = "liters";
            }
            else
            {
                tank = "hours";
            }

            Console.Clear();
            Console.WriteLine("Please enter wheels manufacturer:");
            wheelsManufacturer = Console.ReadLine();
            Console.Clear();
            message = "Please enter wheels current air pressure:";
            currentWheelAirPressure = UserInputHelper.RecieveInputAndConvertToFloat(message);
            Console.Clear();
            message = string.Format("Please enter current amount in {0}:", tank);
            currentEnergy = UserInputHelper.RecieveInputAndConvertToFloat(message);
            Console.Clear();

            switch (i_VehicleKind)
            {
                case eVehicleKind.ElectricCar:
                    vehicle = CollectCarData(licensePlate, modelName, currentEnergy, false, wheelsManufacturer,
                        currentWheelAirPressure);
                    break;
                case eVehicleKind.ElectricMotorcycle:
                    vehicle = CollectMotorcycleData(licensePlate, modelName, currentEnergy, false, wheelsManufacturer,
                        currentWheelAirPressure);
                    break;
                case eVehicleKind.FuelCar:
                    vehicle = CollectCarData(licensePlate, modelName, currentEnergy, true, wheelsManufacturer,
                        currentWheelAirPressure);
                    break;
                case eVehicleKind.FuelMotorcycle:
                    vehicle = CollectMotorcycleData(licensePlate, modelName, currentEnergy, true, wheelsManufacturer,
                        currentWheelAirPressure);
                    break;
                case eVehicleKind.Truck:
                    vehicle = CollectTruckData(licensePlate, modelName, currentEnergy, wheelsManufacturer,
                        currentWheelAirPressure);
                    break;
            }

            return vehicle;
        }
    }
}
