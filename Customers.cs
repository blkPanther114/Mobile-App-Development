using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace CustomerApp
{
    public class Customers
    {
        public string Name { get; set; }
        public static int IdCustomer = 0;

        public Customers(string inName)
        {
            Name = inName;
            CustomerList = new ObservableCollection<Customer>();
        }

        public ObservableCollection<Customer> CustomerList;

        public static Customers MakeTestCustomers()
        {
            string[] firstNames = new string[] { "Rob", "Jim", "Joe", "Nigel", "Sally", "Tim" };
            string[] lastsNames = new string[] { "Smith", "Jones", "Bloggs", "Miles", "Wilkinson", "Brown" };
            string[] imageNames = new string[] { "business.png", "composer.png", "doctor.png", "farmer.png", "patrol.png", "student.png"};

            Customers result = new Customers("Test Customers");
            
            int imgIndex = 0;

            // Use a fixed squence of random numbers to make the same data each time
            Random sessionRand = new Random(1);

            foreach (string lastName in lastsNames)
            {
                foreach (string firstname in firstNames)
                {
                    //Construct a customer name
                    string name = firstname + " " + lastName;

                    // Make a new customer
                    Customer newCustomer = new Customer(name, name + "'s House", IdCustomer, imageNames[imgIndex]);
                    imgIndex++;
                    if (imgIndex == imageNames.Length)
                    {
                        imgIndex = 0;
                    }
                    //Add the new customer to the list
                    result.CustomerList.Add(newCustomer);
                    // Increase the ID for the next customer
                    IdCustomer++;
                }
            }
            return result;
        }
    }

}
