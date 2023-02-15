using System;
using System.Threading;

namespace Ex03.ConsoleUI
{
    internal static class UserInputHelper
    {
        internal static float RecieveInputAndConvertToFloat(string message)
        {
            bool isValidInput = false;
            string userInputStr;
            float userInput = -1.0f;

            while (!isValidInput)
            {
                Console.Clear();
                Console.WriteLine(message);
                userInputStr = Console.ReadLine();
                isValidInput = float.TryParse(userInputStr, out userInput);
                if (!isValidInput || userInput < 0)
                {
                    message = string.Format(
@"Invalid input, please enter a decimal number");
                    Console.WriteLine(message);
                    Thread.Sleep(800);
                }
            }

            return userInput;
        }

        internal static int RecieveInputAndConvertToInt(string message)
        {
            bool isValidInput = false;
            string userInputStr;
            int userInput = -1;

            while (!isValidInput)
            {
                Console.Clear();
                Console.WriteLine(message);
                userInputStr = Console.ReadLine();
                isValidInput = int.TryParse(userInputStr, out userInput);
                if (!isValidInput || userInput < 0)
                {
                    message = string.Format(
@"Invalid input, please enter a positive whole number");
                    Console.WriteLine(message);
                    Thread.Sleep(800);
                }
            }

            return userInput;
        }

        internal static int RecieveMenuInput(string i_Messege, int i_minValue, int i_maxValue)
        {
            int userInput = -1;
            bool isInputValid = false;
            string message;

            while (!isInputValid)
            {
                userInput = RecieveInputAndConvertToInt(i_Messege);
                if ((userInput < i_minValue) || (userInput > i_maxValue))
                {
                    message = string.Format(
@"Invalid input, please enter a number between {0} and {1}",
                    i_minValue, i_maxValue);
                    Console.WriteLine(message);
                    Thread.Sleep(800);
                    Console.Clear();
                }
                else
                {
                    isInputValid = true;
                }
            }

            return userInput;
        }

        internal static bool AskForExit()
        {
            string userInputStr;
            bool exitFlag = false;

            Console.WriteLine("To exit the garage, press q. To return to the Main Menu, press any other key.");
            userInputStr = Console.ReadLine();
            if (userInputStr.Equals("q") || userInputStr.Equals("Q"))
            {
                exitFlag = true;
            }

            return exitFlag;
        }
    }
}
