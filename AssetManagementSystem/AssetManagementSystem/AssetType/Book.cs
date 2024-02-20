using System;
using System.Collections.Generic;

namespace AssetManagementSystem
{
    public class Book : Asset
    {
        public string Author { get; set; }
        public DateTime DateOfPublish { get; set; }

        public List<Book> books = new List<Book>();

        public void AddBook()
        {
            Book book = new Book();

            Console.WriteLine("Enter Serial Number:");
            int serialNumber = ValidationMethod.ValidateSerialNumberInput();
            while (books.Exists(b => b.SerialNumber == serialNumber))
            {
                Console.WriteLine("Serial number already exists. Please enter a different serial number:");
                serialNumber = ValidationMethod.ValidateSerialNumberInput();
            }
            book.SerialNumber = serialNumber;

            Console.WriteLine("Enter Name:");
            string name;
            do
            {
                name = Console.ReadLine();
                if (!ValidationMethod.IsValidName(name))
                {
                    Console.WriteLine("Invalid name. Please enter only alphabetic characters:");
                }
            } while (!ValidationMethod.IsValidName(name));
            book.Name = name;

            Console.WriteLine("Enter Author:");
            string author;
            do
            {
                author = Console.ReadLine();
                if (!ValidationMethod.IsValidName(author))
                {
                    Console.WriteLine("Invalid author. Please enter only alphabetic characters:");
                }
            } while (!ValidationMethod.IsValidName(author));
            book.Author = author;

            Console.WriteLine("Enter Date of Publish (YYYY-MM-DD):");
            book.DateOfPublish = ValidationMethod.ValidateDateInput();

            books.Add(book);
            Console.WriteLine("Book added successfully!");
        }


        public void SearchBook()
        {
            Console.WriteLine("Enter the serial number of the book to search:");
            int serialNumber = ValidationMethod.ValidateSerialNumberInput();
            Book book = books.Find(b => b.SerialNumber == serialNumber);
            if (book != null)
                Console.WriteLine($"Book found :\nSerial Number: {book.SerialNumber}, Name: {book.Name}, Author: {book.Author}, Date of Publish: {book.DateOfPublish.ToShortDateString()}");
            else
                Console.WriteLine("Book not found!");
        }
        public void UpdateBook()
        {
            Console.WriteLine("Enter the serial number of the book you want to update:");
            int serialNumber = ValidationMethod.ValidateSerialNumberInput();
            Book bookToUpdate = books.Find(b => b.SerialNumber == serialNumber);
            if (bookToUpdate != null)
            {
                int choice;
                do
                {
                    Console.WriteLine("Select the field you want to update: \n1. Name\n2. Author\n3. Date of Publish\n4. Back to Previous Menu");
                   choice = ValidationMethod.ValidateChoiceInput();
                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine("Enter the new Name:");
                            string newName;
                            do
                            {
                                newName = Console.ReadLine();
                                if (!ValidationMethod.IsValidName(newName))
                                {
                                    Console.WriteLine("Invalid author. Please enter only alphabetic characters.");
                                }
                            } while (!ValidationMethod.IsValidName(newName));
                            bookToUpdate.Name = newName;
                            Console.WriteLine("Book name updated successfully!");
                            break;
                        case 2:
                            Console.WriteLine("Enter the new author:");
                            string newAuthor;
                            do
                            {
                                newAuthor = Console.ReadLine();
                                if (!ValidationMethod.IsValidName(newAuthor))
                                {
                                    Console.WriteLine("Invalid author. Please enter only alphabetic characters.");
                                }
                            } while (!ValidationMethod.IsValidName(newAuthor));
                            bookToUpdate.Author = newAuthor;
                            Console.WriteLine("Book author updated successfully!");
                            break;
                        case 3:
                            Console.WriteLine("Enter the new date of publish (YYYY-MM-DD):");
                            DateTime newDateOfPublish = ValidationMethod.ValidateDateInput();
                            bookToUpdate.DateOfPublish = newDateOfPublish;
                            Console.WriteLine("Book date of publish updated successfully!");
                            break;
                        case 4:
                            Console.WriteLine("Going back to previous menu..");
                            break;
                        default:
                            Console.WriteLine("Invalid choice! Please select a valid option.");
                            break;
                    }
                } while (choice != 4);
            }
            else
            {
                Console.WriteLine("Book not found!");
            }
        }
        public void DeleteBook()
        {
            Console.WriteLine("Enter the serial number of the book you want to delete:");
            int serialNumber = ValidationMethod.ValidateSerialNumberInput();
            Book bookToDelete = books.Find(b => b.SerialNumber == serialNumber);
            if (bookToDelete != null)
            {
                books.Remove(bookToDelete);
                Console.WriteLine("Book deleted successfully!");
            }
            else
            {
                Console.WriteLine("Book not found!");
            }
        }
    }
}