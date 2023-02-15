using System;
using System.Threading;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    internal class GarageManager
    {
        private readonly GarageLogic.Garage m_Garage;

        internal GarageManager(Garage i_Garage)
        {
            m_Garage = i_Garage;
        }

        private int mainMenu()
        {
            string message;
            int userInput;

            message =
@"Please enter the desired service:
1. Add a new vehicle to the garage.
2. Show a list of all license plates in the garage.
3. Change a vehicle's state.
4. Inflate vehicle's wheels.
5. Refuel a vehicle.
6. Charge a vehicle's battery.
7. Show full vehicles description.
";
            userInput = UserInputHelper.RecieveMenuInput(message, 1, 7);
            return userInput;
        }

        internal void StartGarage()
        {
            bool isExit = false;
            int userInput = -1;

            welcomeMessage();
            while (!isExit)
            {
                userInput = mainMenu();
                switch (userInput)
                {
                    case 1:
                        Console.Clear();
                        GarageFunctionality.InsertNewVehicleUI(m_Garage);
                        break;
                    case 2:
                        Console.Clear();
                        GarageFunctionality.FilterVehiclesLicesnsePlateUI(m_Garage);
                        break;
                    case 3:
                        Console.Clear();
                        GarageFunctionality.ChangeVehicleStateUI(m_Garage);
                        break;
                    case 4:
                        Console.Clear();
                        GarageFunctionality.InflateWheelsToFullUI(m_Garage);
                        break;
                    case 5:
                        Console.Clear();
                        GarageFunctionality.RefuelUI(m_Garage);
                        break;
                    case 6:
                        Console.Clear();
                        GarageFunctionality.ChargeBatteryUI(m_Garage);
                        break;
                    case 7:
                        Console.Clear();
                        GarageFunctionality.GetDescriptionUI(m_Garage);
                        break;
                }
                isExit = UserInputHelper.AskForExit();
                Console.Clear();
            }

            Console.WriteLine("See you next time!");
            Console.ReadLine();
        }

        private void welcomeMessage()
        {
            Console.WriteLine(
@"Welcome To Raz & Peled GARAGE!");
            Thread.Sleep(1500);
        }
    }
}
