using System;
using Ex03.GarageLogic.Enums;

namespace Ex03.GarageLogic
{
    public static class VehicleInitalizer
    {
        public static ElectricMotorcycle InitElectricMotorcycle(string i_ModelName,
            string i_LicensePlate,
            eLicenseType i_LicenseType,
            int i_EngineCapacity,
            string i_WheelsManufacturer,
            float i_BatteryLifeRemaining,
            float i_CurrentAirPressure)
        {
            return new ElectricMotorcycle(i_ModelName,
                i_LicensePlate,
                i_LicenseType,
                i_EngineCapacity,
                i_WheelsManufacturer,
                i_BatteryLifeRemaining,
                i_CurrentAirPressure);
        }

        public static ElectricCar InitElectricCar(string i_ModelName,
            string i_LicensePlate,
            float i_BatteryLifeRemaining,
            eColor i_Color,
            eDoorsNum i_Doors,
            string i_WheelsManufacturer,
            float i_CurrentAirPressure)
        {
            return new ElectricCar(i_ModelName,
                i_LicensePlate,
                i_BatteryLifeRemaining,
                i_Color,
                i_Doors,
                i_WheelsManufacturer,
                i_CurrentAirPressure);
        }

        public static FuelCar InitFuelCar(string i_ModelName,
            string i_LicensePlate,
            float i_CurrentFuelCapacity,
            eColor i_Color,
            eDoorsNum i_Doors,
            string i_WheelsManufacturer,
            float i_CurrentAirPressure)
        {
            return new FuelCar(i_ModelName,
                i_LicensePlate,
                i_CurrentFuelCapacity,
                i_Color,
                i_Doors,
                i_WheelsManufacturer,
                i_CurrentAirPressure);
        }

        public static FuelMotorcycle InitFuelMotorcycle(string i_ModelName,
            string i_LicensePlate,
            eLicenseType i_LicenseType,
            int i_EngineCapacity,
            string i_WheelsManufacturer,
            float i_CurrentFuelCapacity,
            float i_CurrentAirPressure)
        {
            return new FuelMotorcycle(i_ModelName,
                i_LicensePlate,
                i_LicenseType,
                i_EngineCapacity,
                i_WheelsManufacturer,
                i_CurrentFuelCapacity,
                i_CurrentAirPressure);
        }

        public static Truck InitTruck(string i_ModelName,
            string i_LicensePlate,
            float i_CurrentFuelCapacity,
            bool i_HasRefrigerateContents,
            float i_TrunkVolume,
            string i_WheelsManufacturer,
            float i_CurrentAirPressure)
        {
            return  new Truck(i_ModelName,
                i_LicensePlate,
                i_CurrentFuelCapacity,
                i_HasRefrigerateContents,
                i_TrunkVolume,
                i_WheelsManufacturer,
                i_CurrentAirPressure);
        }

        public enum eVehicleKind
        {
            ElectricCar = 1,
            ElectricMotorcycle = 2,
            FuelCar = 3,
            FuelMotorcycle = 4,
            Truck = 5,
        }
    }
}
