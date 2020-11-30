using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment.Person
{
    public class Person
    {
        // FIELDS
        private string firstName;
        private string lastName;

        // CONSTRUCTOR
        public Person() { } // Not use in our program

        // PROPERTIES
        public string FirstName
        {
            get { return firstName; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentNullException("First name cannot be null or empty!");
                else if (value.Length > 100)
                    throw new ArgumentOutOfRangeException("First name cannot be more than 100 characters!");
                else
                    firstName = value;
            }
        }

        public string LastName
        {
            get { return lastName; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentNullException("Last name cannot be null!");
                else if (value.Length > 100)
                    throw new ArgumentOutOfRangeException("Last name cannot be more than 100 characters!");
                else
                    lastName = value;
            }
        }
        
        // METHODS
        public void SetFirstName(string firstName)
        {
            FirstName = firstName;
        }

        public void SetLastName(string lastName)
        {
            LastName = lastName;
        }
    }
}
