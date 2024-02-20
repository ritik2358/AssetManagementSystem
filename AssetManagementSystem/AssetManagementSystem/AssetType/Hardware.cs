using System;
using System.Collections.Generic;

namespace AssetManagementSystem
{
    public class Hardware : Asset
    {
        public int HardwareId { get; set; }
        public int NumberOfHardwares { get; set; }
        public List<Hardware> hardwareAssets = new List<Hardware>();

        public void AddHardware()
        {
            Hardware hardware = new Hardware();

            Console.WriteLine("Enter Serial Number:");
            int serialNumber = ValidationMethod.ValidateSerialNumberInput();
            while (hardwareAssets.Exists(h => h.SerialNumber == serialNumber))
            {
                Console.WriteLine("Serial number already exists. Please enter a different serial number:");
                serialNumber = ValidationMethod.ValidateSerialNumberInput();
            }
            hardware.SerialNumber = serialNumber;
            string name;
            Console.WriteLine("Enter Name:");
            do
            {
                name = Console.ReadLine();
                if (!ValidationMethod.IsValidName(name))
                {
                    Console.WriteLine("Invalid name. Please enter only alphabetic characters:");
                }
            } while (!ValidationMethod.IsValidName(name));
            hardware.Name = name;

            Console.WriteLine("Enter Hardware ID:");
            int hardwareId = ValidationMethod.ValidateHardwareOrSoftwareIdInput();
            while (hardwareAssets.Exists(h => h.HardwareId == hardwareId))
            {
                Console.WriteLine("Hardware ID already exists. Please enter a different hardware ID:");
                hardwareId = ValidationMethod.ValidateHardwareOrSoftwareIdInput();
            }
            hardware.HardwareId = hardwareId;

            Console.WriteLine("Enter Number of Hardwares:");
            int numberOfHardwares = ValidationMethod.ValidateChoiceInput();
            hardware.NumberOfHardwares = numberOfHardwares;

            hardwareAssets.Add(hardware);
            Console.WriteLine("Hardware added successfully!");
        }

        public void SearchHardware()
        {
            Console.WriteLine("Enter the serial number of the hardware to search:");
            int serialNumber = ValidationMethod.ValidateSerialNumberInput();
            Hardware hardware = hardwareAssets.Find(h => h.SerialNumber == serialNumber);
            if (hardware != null)
            {
                Console.WriteLine("Hardware found:");
                Console.WriteLine($"Serial Number: {hardware.SerialNumber}, Name: {hardware.Name}, Hardware ID: {hardware.HardwareId}, Number of Hardwares: {hardware.NumberOfHardwares}");
            }
            else
            {
                Console.WriteLine("Hardware not found!");
            }
        }

        public void UpdateHardware()
        {
            Console.WriteLine("Enter the serial number of the hardware you want to update:");
            int serialNumber = ValidationMethod.ValidateSerialNumberInput();
            Hardware hardwareToUpdate = hardwareAssets.Find(h => h.SerialNumber == serialNumber);
            if (hardwareToUpdate != null)
            {
                int choice;
                do
                {
                    Console.WriteLine("Select the field you want to update: \n1. Name\n2. Hardware ID\n3. Number of Hardwares\n4. Back to Previous Menu");
                    choice = ValidationMethod.ValidateChoiceInput();
                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine("Enter the new name:");
                            string newName;
                            do
                            {
                                newName = Console.ReadLine();
                                if (!ValidationMethod.IsValidName(newName))
                                {
                                    Console.WriteLine("Invalid name. Please enter a non-empty name.");
                                }
                            } while (!ValidationMethod.IsValidName(newName));
                            hardwareToUpdate.Name = newName;
                            Console.WriteLine("Hardware name updated successfully!");
                            break;
                        case 2:
                            bool newValidHardwareId = false;
                            do
                            {
                                Console.WriteLine("Enter Hardware ID:");
                                int newHardwareId = ValidationMethod.ValidateHardwareOrSoftwareIdInput();
                                if (hardwareAssets.Exists(h => h.HardwareId == newHardwareId))
                                {
                                    Console.WriteLine("Hardware ID already exists. Please enter a different hardware ID.");
                                }
                                else
                                {
                                    hardwareToUpdate.HardwareId = newHardwareId;
                                    newValidHardwareId = true;
                                }
                            } while (!newValidHardwareId);
                            Console.WriteLine("Hardware ID updated successfully!");
                            break;
                        case 3:
                            Console.WriteLine("Enter the new number of hardwares:");
                            int newNumberOfHardwares = ValidationMethod.ValidateChoiceInput();
                            hardwareToUpdate.NumberOfHardwares = newNumberOfHardwares;
                            Console.WriteLine("Number of hardwares updated successfully!");
                            break;
                        case 4:
                            Console.WriteLine("Going back to prev menu..");
                            break;
                        default:
                            Console.WriteLine("Invalid choice! Please select a valid option.");
                            break;
                    }
                } while (choice != 4);
            }
            else
            {
                Console.WriteLine("Hardware not found!");
            }
        }

        public void DeleteHardware()
        {
            Console.WriteLine("Enter the serial number of the hardware you want to delete:");
            int serialNumber = ValidationMethod.ValidateSerialNumberInput();
            Hardware hardwareToDelete = hardwareAssets.Find(h => h.SerialNumber == serialNumber);
            if (hardwareToDelete != null)
            {
                hardwareAssets.Remove(hardwareToDelete);
                Console.WriteLine("Hardware deleted successfully!");
            }
            else
            {
                Console.WriteLine("Hardware not found!");
            }
        }
    }
}
