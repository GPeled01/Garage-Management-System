using System;
using System.Text;
using Ex03.GarageLogic.Enums;

namespace Ex03.GarageLogic
{
    public class ElectricCar : ElectricVehicle
    {
        private readonly eColor m_Color;
        private readonly eDoorsNum m_Doors;
        private const float k_MaximalAirPressure = 29;
        private const int k_NumOfWheels = 4;

        public ElectricCar(string i_ModelName,
            string i_LicensePlate,
            float i_BatteryLifeRemaining,
            eColor i_Color,
            eDoorsNum i_Doors,
            string i_WheelsManufacturer,
            float i_CurrentAirPressure)
            : base(i_ModelName, i_LicensePlate, i_BatteryLifeRemaining)
        {
            m_Color = i_Color;
            m_Doors = i_Doors;
            m_MaximalBatteryLife = 3.3f;
            addWheelToElectricCar(i_WheelsManufacturer, i_CurrentAirPressure);
            CalcEnergyPrecentage();
        }

        private void addWheelToElectricCar(string i_WheelsManufacturer, float i_CurrentAirPressure)
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
@"Color: {0}
Number of doors: {1}",
               m_Color,
               m_Doors));
            return description.ToString();
        }
    }
}
