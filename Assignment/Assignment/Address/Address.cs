using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment.Address
{
    public class Address
    {
        // FIELDS
        private int addressNum;
        private string street;
        private string city;
        private string country;

        // CONSTRUCTORS 
        public Address() { } // Not use in our program
        public Address(int addressNum, string street, string city, string country)
        {
            AddressNum = addressNum;
            Street = street;
            City = city;
            Country = country;
        }

        // PROPERTIES
        public int AddressNum
        {
            get { return addressNum; }
            set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException("Address number must be greater than 0!");
                else
                    addressNum = value;
            }
        }

        public string Street
        {
            get { return street; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentNullException("Street cannot be null or empty!");
                else if (value.Length > 200)
                    throw new ArgumentOutOfRangeException("Street cannot be more than 200 characters!");
                else
                    street = value;
            }
        }

        public string City
        {
            get { return city; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentNullException("City cannot be null or empty!");
                else if (value.Length > 100)
                    throw new ArgumentOutOfRangeException("City cannot be more than 100 characters!");
                else
                    city = value;
            }
        }

        public string Country
        {
            get { return country; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentNullException("Country cannot be null or empty!");
                else if (value.Length > 50)
                    throw new ArgumentOutOfRangeException("Country cannot be more than 50 characters!");
                else
                    country = value;
            }
        }
    }
}
