using System;

namespace AssetManagementSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            int choice;
            AssetManager assetManager = new AssetManager();
            Console.WriteLine("*****Welcome to Asset Management System*****\nPlease select the operation you want to perform : ");
            do
            {
                Console.WriteLine("1. Add an asset\n2. Search an asset\n3. Update an asset\n4. Delete an asset\n5. List of all available assets\n6. Exit");
                Console.WriteLine("Enter your choice:");

                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Invalid input! Please enter a number.");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        assetManager.AddAsset();
                        break;
                    case 2:
                        assetManager.SearchAsset();
                        break;
                    case 3:
                        assetManager.UpdateAsset();
                        break;
                    case 4:
                        assetManager.DeleteAsset();
                        break;
                    case 5:
                        assetManager.ListAllAssets();
                        break;
                    case 6:
                        Console.WriteLine("Exiting...");
                        break;
                    default:
                        Console.WriteLine("Invalid choice! Please select a valid option.");
                        break;
                }
            } while (choice != 6);
        }
    }
}