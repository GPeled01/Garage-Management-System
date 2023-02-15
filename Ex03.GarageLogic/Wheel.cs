using System;
namespace Ex03.GarageLogic
{
    public class Wheel
    {
        private readonly string m_Manufacturer;
        private float m_CurrentAirPressure;
        private readonly float m_MaximalAirPressure;

        public Wheel(string i_Manufacturer, float i_CurrentAirPressure, float i_MaximalAirPressure)
        {
            m_Manufacturer = i_Manufacturer;
            m_CurrentAirPressure = i_CurrentAirPressure;
            m_MaximalAirPressure = i_MaximalAirPressure;
        }

        public float CurrentAirPressure
        {
            get { return m_CurrentAirPressure; }
        }

        public float MaximalAirPressure
        {
            get { return m_MaximalAirPressure; }
        }

        public void Inflate(float i_AirToAdd)
        {
            float remainingAirToAdd = m_MaximalAirPressure - m_CurrentAirPressure;
            if (i_AirToAdd > remainingAirToAdd)
            {
                throw new ValueOutOfRangeException(0, remainingAirToAdd);
            }
            else
            {
                m_CurrentAirPressure += i_AirToAdd;
            }
        }

        public override string ToString()
        {
            string description;

            description = string.Format(
                "Manufacturer: {0}, Current air pressure: {1}, Max air pressure: {2}",
                m_Manufacturer,
                m_CurrentAirPressure,
                m_MaximalAirPressure);
            return description;
        }
    }
}
