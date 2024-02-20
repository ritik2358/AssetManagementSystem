using System;

namespace AssetManagementSystem
{
    public class AssetManager
    {
        Book book = new Book();
        SoftwareLicense softwareLicense = new SoftwareLicense();
        Hardware hardware = new Hardware();
        public void AddAsset()
        {
            int assetType1;
            do
            {
                Console.WriteLine("Enter the type of asset:\n1. Book\n2. Software License\n3. Hardware\n4. Back to Previous Menu");
                

                if (!int.TryParse(Console.ReadLine(), out assetType1))
                {
                    Console.WriteLine("Invalid input! Please enter a number.");
                    return;
                }

                switch (assetType1)
                {
                    case 1:
                        book.AddBook();
                        break;
                    case 2:
                        softwareLicense.AddSoftwareLicense();
                        break;
                    case 3:
                        hardware.AddHardware();
                        break;
                    case 4:
                        Console.WriteLine("Going back to Prev Menu..");
                        break;
                    default:
                        Console.WriteLine("Invalid asset type! Please select a valid option.");
                        break;
                }
            }while (assetType1!=4);
        }

        public void SearchAsset()
        {
            int assetType2;
            do
            {
                Console.WriteLine("Enter the type of asset:\n1. Book\n2. Software License\n3. Hardware\n4. Back to Previous Menu");
                assetType2=0;
                if (!int.TryParse(Console.ReadLine(), out assetType2))
                {
                    Console.WriteLine("Invalid input! Please enter a number.");
                    return;
                }

                switch (assetType2)
                {
                    case 1:
                        book.SearchBook();
                        break;
                    case 2:
                        softwareLicense.SearchSoftwareLicense();
                        break;
                    case 3:
                        hardware.SearchHardware();
                        break;
                    case 4:
                        Console.WriteLine("Going back to prev menu..");
                        break;

                    default:
                        Console.WriteLine("Invalid asset type! Please select a valid option.");
                        break;
                }
            }while(assetType2!= 4);
        }

        public void UpdateAsset()
        {
            int assetType3;
            do
            {
                Console.WriteLine("Enter the type of asset:\n1. Book\n2. Software License\n3. Hardware\n4. Back to Previous Menu");
                assetType3 = ValidationMethod.ValidateChoiceInput();

                switch (assetType3)
                {
                    case 1:
                        book.UpdateBook();
                        break;
                    case 2:
                        softwareLicense.UpdateSoftwareLicense();
                        break;
                    case 3:
                        hardware.UpdateHardware();
                        break;
                    case 4:
                        Console.WriteLine("Going back to prev menu..");
                        break;
                    default:
                        Console.WriteLine("Invalid asset type! Please select a valid option.");
                        break;
                }
            }while (assetType3!=4);
        }
        public void DeleteAsset()
        {
            int assetType4;
            do
            {
                Console.WriteLine("Enter the type of asset:\n1. Book\n2. Software License\n3. Hardware\n4. Back to Previous Menu");
                if (!int.TryParse(Console.ReadLine(), out assetType4))
                {
                    Console.WriteLine("Invalid input! Please enter a number.");
                    return;
                }

                switch (assetType4)
                {
                    case 1:
                        book.DeleteBook();
                        break;
                    case 2:
                        softwareLicense.DeleteSoftwareLicense();
                        break;
                    case 3:
                        hardware.DeleteHardware();
                        break;
                    case 4:
                        Console.WriteLine("Going back to prev menu..");
                        break;
                    default:
                        Console.WriteLine("Invalid asset type! Please select a valid option.");
                        break;
                }
            }while(assetType4!=4);
        }
        public void ListAllAssets()
        {
            if (book.books.Count != 0 || softwareLicense.softwareLicenses.Count != 0 || hardware.hardwareAssets.Count != 0)
            {
                Console.WriteLine("List of all available assets:");
                if (book.books.Count > 0)
                {
                    Console.WriteLine("Books:");
                    foreach (var book in book.books)
                    {
                        Console.WriteLine($"Serial Number: {book.SerialNumber}, Name: {book.Name}, Author: {book.Author}, Date of Publish: {book.DateOfPublish.ToShortDateString()}");
                    }
                }
                if (softwareLicense.softwareLicenses.Count > 0)
                {
                    Console.WriteLine("Software Licenses:");
                    foreach (var software in softwareLicense.softwareLicenses)
                    {
                        Console.WriteLine($"Serial Number: {software.SerialNumber}, Name: {software.Name}, Software ID: {software.SoftwareId}, Expiration Date: {software.ExpirationDate.ToShortDateString()}, Size (in GB): {software.Size}");
                    }
                }
                if (hardware.hardwareAssets.Count > 0)
                {
                    Console.WriteLine("Hardware Assets:");
                    foreach (var hardware in hardware.hardwareAssets)
                    {
                        Console.WriteLine($"Serial Number: {hardware.SerialNumber}, Name: {hardware.Name}, Hardware ID: {hardware.HardwareId}, Number of Hardwares: {hardware.NumberOfHardwares}");
                    }
                }
            }
            else
            {
                Console.WriteLine("No Assets Found");
            }
        }
    }
}