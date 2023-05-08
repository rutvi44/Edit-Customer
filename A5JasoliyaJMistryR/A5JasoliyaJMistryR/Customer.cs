/* Project file name : Assignment 5
 * Purpose of program : Add, Edit and Display Customer Information
 * 
 * Revision History:
 *     Created bt Jay Jasoliya, 05-04-2023, 
                  Rutvi Mistry, 12-04-2023.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A5JasoliyaJMistryR
{
    internal class Customer
    {
        public int id , age;
        public string email, name;
    
        public Customer()
        {
        }
        public Customer(int id, string email, string name, int age)
        {
            this.id = id;
            this.email = email;
            this.name = name;
            this.age = age;
        }

        // To Edit Customer Detail
        public void EditCustomerInformation(string field, string value)
        {
            switch (field)
            {
                case "email":
                    email = value;
                    break;
                case "name":
                    name = value;
                    break;
                case "age":
                    age = int.Parse(value);
                    break;
                default:
                    throw new ArgumentException("Invalid Field");
            }
        }

        // To Display Customer's detail
        public void DisplayCustomerInformation()
        {
            Console.WriteLine($"\nId: {id}");
            Console.WriteLine($"Email: {email}");
            Console.WriteLine($"Name: {name}");
            Console.WriteLine($"Age: {age}");
        }
    }
}

