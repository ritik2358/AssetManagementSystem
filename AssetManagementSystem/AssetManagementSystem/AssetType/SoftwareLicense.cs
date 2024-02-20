using System;
using System.Collections.Generic;

namespace AssetManagementSystem
{
    public class SoftwareLicense : Asset
    {
        public int SoftwareId { get; set; }
        public DateTime ExpirationDate { get; set; }
        public double Size { get; set; }

        public List<SoftwareLicense> softwareLicenses = new List<SoftwareLicense>();

        public void AddSoftwareLicense()
        {
            SoftwareLicense software = new SoftwareLicense();

            Console.WriteLine("Enter Serial Number:");
            int serialNumber = ValidationMethod.ValidateSerialNumberInput();
            while (softwareLicenses.Exists(s => s.SerialNumber == serialNumber))
            {
                Console.WriteLine("Serial number already exists. Please enter a different serial number:");
                serialNumber = ValidationMethod.ValidateSerialNumberInput();
            }
            software.SerialNumber = serialNumber;

            Console.WriteLine("Enter Name:");
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
            software.Name = name;

            Console.WriteLine("Enter Software ID:");
            int softwareId = ValidationMethod.ValidateHardwareOrSoftwareIdInput();
            while (softwareLicenses.Exists(s => s.SoftwareId == softwareId))
            {
                Console.WriteLine("Software ID already exists. Please enter a different software ID:");
                softwareId = ValidationMethod.ValidateHardwareOrSoftwareIdInput();
            }
            software.SoftwareId = softwareId;

            Console.WriteLine("Enter Expiration Date (YYYY-MM-DD):");
            DateTime expirationDate = ValidationMethod.ValidateDateInput();
            software.ExpirationDate = expirationDate;

            Console.WriteLine("Enter Size (in GB):");
            double size;
            while (!double.TryParse(Console.ReadLine(), out size) || size <= 0)
            {
                Console.WriteLine("Invalid size. Please enter a valid positive number.");
            }
            software.Size = size;

            softwareLicenses.Add(software);
            Console.WriteLine("Software License added successfully!");
        }

        public void SearchSoftwareLicense()
        {
            Console.WriteLine("Enter the serial number of the software to search:");
            int serialNumber = ValidationMethod.ValidateSerialNumberInput();
            SoftwareLicense software = softwareLicenses.Find(s => s.SerialNumber == serialNumber);
            if (software != null)
            {
                Console.WriteLine("Software License found:");
                Console.WriteLine($"Serial Number: {software.SerialNumber}, Name: {software.Name}, Software ID: {software.SoftwareId}, Expiration Date: {software.ExpirationDate.ToShortDateString()}, Size (in GB): {software.Size}");
            }
            else
            {
                Console.WriteLine("Software License not found!");
            }
        }

        public void UpdateSoftwareLicense()
        {
            Console.WriteLine("Enter the serial number of the software license you want to update:");
            int serialNumber;
            while (!int.TryParse(Console.ReadLine(), out serialNumber))
            {
                Console.WriteLine("Invalid input! Please enter a valid serial number.");
            }

            SoftwareLicense softwareToUpdate = softwareLicenses.Find(s => s.SerialNumber == serialNumber);
            if (softwareToUpdate != null)
            {
                int choice;
                do
                {
                    Console.WriteLine("Select the field you want to update: \n1. Name\n2. Software ID\n3. Expiration Date\n4. Size (in GB)\n5. Back to Previous Menu");
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
                                    Console.WriteLine("Invalid name. Please enter Please enter only alphabetic characters.");
                                }
                            } while (!ValidationMethod.IsValidName(newName));
                            softwareToUpdate.Name = newName;
                            Console.WriteLine("Software name updated successfully!");
                            break;
                        case 2:
                            bool newValidSoftwareId = false;
                            do
                            {
                                Console.WriteLine("Enter Software ID:");
                                int newSoftwareId = ValidationMethod.ValidateHardwareOrSoftwareIdInput();
                                if (softwareLicenses.Exists(s => s.SoftwareId == newSoftwareId))
                                {
                                    Console.WriteLine("Software ID already exists. Please enter a different software ID.");
                                }
                                else
                                {
                                    softwareToUpdate.SoftwareId = newSoftwareId;
                                    newValidSoftwareId = true;
                                }
                            } while (!newValidSoftwareId);
                            Console.WriteLine("Software ID updated successfully!");
                            break;
                        case 3:
                            Console.WriteLine("Enter the new expiration date (YYYY-MM-DD):");
                            DateTime newExpirationDate = ValidationMethod.ValidateDateInput();
                            softwareToUpdate.ExpirationDate = newExpirationDate;
                            Console.WriteLine("Software expiration date updated successfully!");
                            break;
                        case 4:
                            Console.WriteLine("Enter the new size (in GB):");
                            double newSize;
                            while (!double.TryParse(Console.ReadLine(), out newSize) || newSize <= 0)
                            {
                                Console.WriteLine("Invalid size. Please enter a valid positive number.");
                            }
                            softwareToUpdate.Size = newSize;
                            Console.WriteLine("Software size updated successfully!");
                            break;
                        case 5:
                            Console.WriteLine("Going back to prev menu..");
                            break;
                        default:
                            Console.WriteLine("Invalid choice! Please select a valid option.");
                            break;
                    }
                } while (choice != 5);
            }
            else
            {
                Console.WriteLine("Software License not found!");
            }
        }

        public void DeleteSoftwareLicense()
        {
            Console.WriteLine("Enter the serial number of the software license you want to delete:");
            int serialNumber = ValidationMethod.ValidateSerialNumberInput();
            SoftwareLicense softwareToDelete = softwareLicenses.Find(s => s.SerialNumber == serialNumber);
            if (softwareToDelete != null)
            {
                softwareLicenses.Remove(softwareToDelete);
                Console.WriteLine("Software License deleted successfully!");
            }
            else
            {
                Console.WriteLine("Software License not found!");
            }
        }
    }
}
