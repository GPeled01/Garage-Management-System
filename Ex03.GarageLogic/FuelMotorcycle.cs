using System;
using System.Text;
using Ex03.GarageLogic.Enums;

namespace Ex03.GarageLogic
{
    public class FuelMotorcycle : FuelVehicle
    {
        private readonly eLicenseType m_LicenseType;
        private readonly int m_EngineCapacity;
        private const float k_MaximalAirPressure = 31;
        private const int k_NumOfWheels = 2;

        public FuelMotorcycle(string i_ModelName,
            string i_LicensePlate,
            eLicenseType i_LicenseType,
            int i_EngineCapacity,
            string i_WheelsManufacturer,
            float i_CurrentFuelCapacity,
            float i_CurrentAirPressure)
            : base(i_ModelName, i_LicensePlate, i_CurrentFuelCapacity)
        {
            m_LicenseType = i_LicenseType;
            m_EngineCapacity = i_EngineCapacity;
            m_MaximumFuelCapacity = 6.2f;
            addWheelToFuelMotorcycle(i_WheelsManufacturer, i_CurrentAirPressure);
            CalcEnergyPrecentage();
        }

        private void addWheelToFuelMotorcycle(string i_WheelsManufacturer, float i_CurrentAirPressure)
        {
            for (int i = 0; i < k_NumOfWheels; i++)
            {
                AddWheel(new Wheel(i_WheelsManufacturer, i_CurrentAirPressure, k_MaximalAirPressure));
            }
        }

        public override string ToString()
        {
            StringBuilder description = new StringBuilder();

            description.Append(base.ToString());
            description.Append(string.Format(
@"License Type: {0}
Engine Capacity: {1}",
                m_LicenseType,
                m_EngineCapacity));
            return description.ToString();
        }
    }
}
