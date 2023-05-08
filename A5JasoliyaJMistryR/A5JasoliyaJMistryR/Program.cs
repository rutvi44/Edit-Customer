
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A5JasoliyaJMistryR
{
    internal class Program
    {
        static List<Customer> customers = new List<Customer>();
        static void Main(string[] args)
        {
            string choice;

            Console.WriteLine("Welcome to Our Store!");


            while (true)
            {
                Console.WriteLine("\nMain Menu");
                Console.WriteLine("1. Add New Customer");
                Console.WriteLine("2. Edit Existing Customer");
                Console.WriteLine("3. Display Customer");
                Console.WriteLine("4. Exit");
                Console.Write("\nEnter your choice: ");

                choice = Console.ReadLine();

                Console.Clear();

                switch (choice)
                {
                    case "1":
                        AddNewCustomer();
                        break;
                    case "2":
                        EditExistingCustomer();
                        break;
                    case "3":
                        DisplayCustomer();
                        break;
                    case "4":
                        Console.WriteLine("\nThank You... Have a Good Day... Visit Again...!");
                        return;
                    default:
                        Console.WriteLine("Invalid Input Please Pick Enter a Number 1-4");
                        break;

                }
            }
        }

        // Add new Customer's Information
        static void AddNewCustomer()
        {
            string email, name;
            int age, id;
            bool validAge = false;

            Console.WriteLine("\nAdd New Customer:");

            Console.Write("Enter Email which contains '@' and '.' (xx@xx.xx): ");
            email = Console.ReadLine();

            while (email.IndexOf('@') == -1 || email.IndexOf('.') == -1)
            {
                Console.WriteLine("Invalid Email Address Please Try Again(xx@xx.xx): ");
                Console.Write("Enter Email which contains '@' and '.' (xx@xx.xx): ");
                email = Console.ReadLine();
            }

            foreach (Customer customer in customers)
            {
                if (customer.email == email)
                {
                    Console.WriteLine("Customer Record Already Exists");
                    return;
                }
            }

            Console.Write("Enter Name: ");
            name = Console.ReadLine();

            do
            {
                Console.Write("Enter an Age Between 13 and 100: ");
                if (int.TryParse(Console.ReadLine(), out age))
                {
                    if (age >= 13 && age <= 100)
                    {
                        validAge = true;
                    }
                    else
                    {
                        Console.WriteLine("\nInvalid Age Please Try Again");
                    }
                }
                else
                {
                    Console.WriteLine("\nInvalid Age Please Try Again");
                }
            } while (!validAge);

            id = customers.Count + 1;
            Console.WriteLine($"\nYour ID is: {id}");

            Customer newCustomer = new Customer(id, email, name, age);
            customers.Add(newCustomer);

            Console.WriteLine("New Customer Record Added!");
        }

        //This Method will allow user to find their ID and make changes by customer's choice.
        static void EditExistingCustomer()
        {
            string input, newEmail, newName;
            int newAge;

            //Console.WriteLine("\nEdit Existing Customer:");

            Console.Write("\nEnter Customer ID: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("\nInvalid ID Please Try Again");
                return;
            }

            Customer editCustomer = null;

            foreach (Customer customer in customers)
            {
                if (customer.id == id)
                {
                    editCustomer = customer;
                    break;
                }
            }

            if (editCustomer == null)
            {
                Console.WriteLine("\nCustomer Record Doesn't Exist");
                return;
            }

            Console.WriteLine("\nCurrent Customer Information");
            editCustomer.DisplayCustomerInformation();

            bool cancel = false;
            bool changeMade = false;
            do
            {

                Console.WriteLine("\nWhat would you like to change?");
                Console.WriteLine("1. Email");
                Console.WriteLine("2. Name");
                Console.WriteLine("3. Age");
                Console.WriteLine("4. Cancel");
                Console.WriteLine("Enter your choice : ");
                input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        Console.Write("\nEnter New Email which contains '@' and '.' (xx@xx.xx): ");
                        newEmail = Console.ReadLine();
                        while (newEmail.IndexOf('@') == -1 || newEmail.IndexOf('.') == -1)
                        {
                            Console.WriteLine("\nInvalid Email Address Please Try Again(xx@xx.xx): ");
                            Console.Write("\nEnter Email which contains '@' and '.' (xx@xx.xx): ");
                            newEmail = Console.ReadLine();
                        }

                        foreach (Customer customer in customers)
                        {
                            if (customer.email == newEmail)
                            {
                                Console.WriteLine("Customer Record Already Exists");
                                return;
                            }
                        }

                        editCustomer.EditCustomerInformation("email", newEmail);

                        Console.WriteLine("Customer Information Updated!");
                        editCustomer.DisplayCustomerInformation();
                        changeMade = true;
                        break;

                    case "2":
                        Console.Write("\nNew Name: ");
                        newName = Console.ReadLine();

                        editCustomer.EditCustomerInformation("name", newName);

                        Console.WriteLine("Customer Information Updated!");
                        editCustomer.DisplayCustomerInformation();
                        changeMade = true;
                        break;

                    case "3":

                        bool validAge = false;
                        do
                        {
                            Console.Write("Enter an Age Between 13 and 100: ");
                            if (int.TryParse(Console.ReadLine(), out newAge))
                            {
                                if (newAge >= 13 && newAge <= 100)
                                {
                                    validAge = true;
                                }
                                else
                                {
                                    Console.WriteLine("\nInvalid Age Please Try Again");
                                }
                            }
                            else
                            {
                                Console.WriteLine("\nInvalid Age Please Try Again");
                            }
                        } while (!validAge);

                        editCustomer.age = newAge;
                        editCustomer.DisplayCustomerInformation();
                        changeMade = true;
                        break;

                    case "4":
                        Console.WriteLine("\nReturning to Main Menu...");
                        Console.ReadKey();
                        changeMade= true;
                        break;
                }

                if (changeMade)
                {
                    break;
                }

            } while (!cancel);
        }

        /* To Dislpay Added Customer by their allocated ID*/
        static void DisplayCustomer()
        {
            if (customers.Count == 0)
            {
                Console.WriteLine("No customer exist..Press any key to return to the main menu");
                Console.ReadLine();
                return;
            }

            Console.Write("\nEnter Customer ID: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("\nInvalid ID Please Try Again");
                return;
            }

            Customer editCustomer = null;

            foreach (Customer customer in customers)
            {
                if (customer.id == id)
                {
                    editCustomer = customer;
                    customer.DisplayCustomerInformation();
                    return;
                }
            }

            if (editCustomer == null)
            {
                Console.WriteLine("\nCustomer Record Doesn't Exist");
                return;
            }

        }
    }
}
