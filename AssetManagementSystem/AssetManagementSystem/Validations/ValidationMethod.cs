using System;
using System.Linq;

namespace AssetManagementSystem
{
    public static class ValidationMethod
    {
        public static bool IsValidName(string input)
        {
            return !string.IsNullOrWhiteSpace(input) && input.All(char.IsLetter);
        }

        public static int ValidateSerialNumberInput()
        {
            int serialNumber;
            while (!int.TryParse(Console.ReadLine(), out serialNumber))
            {
                Console.WriteLine("Invalid input! Please enter a valid serial number.");
            }
            return serialNumber;
        }

        public static int ValidateChoiceInput()
        {
            int choice;
            while (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Invalid input! Please enter a number.");
            }
            return choice;
        }

        public static int ValidateHardwareOrSoftwareIdInput()
        {
            int id;
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Invalid input! Please enter a valid ID.");
            }
            return id;
        }

        public static DateTime ValidateDateInput()
        {
            DateTime date;
            while (!DateTime.TryParse(Console.ReadLine(), out date))
            {
                Console.WriteLine("Invalid date format. Please try again.");
            }
            return date;
        }
    }
}
