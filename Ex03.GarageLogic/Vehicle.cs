using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        private readonly string m_ModelName;
        private readonly string m_LicensePlate;
        protected float m_RemainingEnergyPrecentage;
        protected readonly List<Wheel> m_Wheels;

        public Vehicle(string i_ModelName, string i_LicensePlate)
        {
            m_ModelName = i_ModelName;
            m_LicensePlate = i_LicensePlate;
            m_Wheels = new List<Wheel>();
        }

        public string LicensePlate
        {
            get { return m_LicensePlate; }
        }

        public List<Wheel> Wheels
        {
            get { return m_Wheels; }
        }

        // $G$ CSS-013 (-3) Bad parameter name (should be in the form of i_PascalCase).
        internal void AddWheel(Wheel i_wheel)
        {
            m_Wheels.Add(i_wheel);
        }

        public override string ToString()
        {
            StringBuilder description = new StringBuilder();

            description.Append(string.Format(
@"Model name: {0}
License number: {1}
Remaining Energy Precentage: {2}",
               m_ModelName,
               m_LicensePlate,
               m_RemainingEnergyPrecentage));
            description.Append(wheelsDescription());
            return description.ToString();
        }

        private string wheelsDescription()
        {
            StringBuilder description = new StringBuilder(Environment.NewLine);
            int wheelIdx = 0;

            foreach (Wheel wheel in m_Wheels)
            {
                description.Append(string.Format(
"Wheel {0}: ",
                wheelIdx++));
                description.Append(wheel.ToString());
                description.Append(Environment.NewLine);
            }
            return description.ToString();
        }
    }
}
