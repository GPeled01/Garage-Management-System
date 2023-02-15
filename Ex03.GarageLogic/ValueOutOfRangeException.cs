using System;
namespace Ex03.GarageLogic
{
    public class ValueOutOfRangeException : Exception
    {
        float m_MinValue;
        float m_MaxValue;

        public ValueOutOfRangeException(float i_MinValue, float i_MaxValue)
        {
            m_MinValue = i_MinValue;
            m_MaxValue = i_MaxValue;
        }

        public string ErrorMessage()
        {
            string message = string.Format(
@"Value is out of range, correct values are between {0} and {1}",
            m_MinValue, m_MaxValue);
            return message;
        }
    }
}
