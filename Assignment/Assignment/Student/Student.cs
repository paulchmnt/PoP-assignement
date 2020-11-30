using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment.Student
{
    public class Student : Person.Person
    {
        // FIELDS
        private string studentNumber;
        private int age;
        private Address.Address addressInfos;
        private int[] scores; // from 0 to 100 (%), just integers

        // CONSTRUCTORS
        public Student() { } // Not use in our program
        public Student(string firstName, string lastName, string studentNumber, int age)
        {
            SetFirstName(firstName);
            SetLastName(lastName);
            StudentNumber = studentNumber;
            Age = age;
        }

        // PROPERTIES
        // Non-dynamic properties
        public string StudentNumber
        {
            get { return studentNumber; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentNullException("Student number cannot be null!");
                else if (value.Length > 15) // No rules about studentNumber's length, I added this one by myself
                    throw new ArgumentOutOfRangeException("Student number cannot be more than 15 characters!");
                else
                    studentNumber = value;
            }
        }
        public int Age
        {
            get { return age; }
            set // Need to check before if "value" is an integer
            {
                if (value <= 0 || value > 100)
                    throw new ArgumentOutOfRangeException("Error! Student age must be between 1 & 100 years old.");
                else
                    age = value;
            }
        }
        public Address.Address AddressInfos
        {
            get { return addressInfos; }
            set { addressInfos = value; } // Don't need to put conditions on the set, the adress is already verified before
        }                                 // (see class Address)
        public int[] Scores
        {
            get { return scores; }
            set { scores = value; } // Dont need to put conditions on the set, the scores array is already
        }                           // verified in his creating functions (see class StudentTester)
        // Dynamic properties
        public string FullName
        {
            get // Just a get, we don't nee a set for this property
            {
                return FirstName + " " + LastName;
            }
        }
        public float AverageScore
        {
            get // Just a get, we don't nee a set for this property
            {
                int tot = 0;
                for (int i = 0; i < scores.Length; i++)
                    tot += scores[i];
                return (float) tot / scores.Length;
            }
        }
        public string FullAddress
        {
            get // Just a get, we don't nee a set for this property
            {
                return $"{addressInfos.Street}, {addressInfos.AddressNum}\n{addressInfos.City}, {addressInfos.Country}";
            }
        }

        // METHODS
        public void DisplayAverageScore()
        {
            Console.WriteLine($"Student {FullName} score is {AverageScore}.");
        }
        public void DisplayCity()
        {
            Console.WriteLine($"Student {FullName} is living in {addressInfos.City}.");
        }
        public void DisplayAddress()
        {
            Console.WriteLine($"Student {FullName} address is:\n{FullAddress}");
        }
        public override string ToString()
        {
            string info = $"Student {FullName} informations:\n" +
                $"First name: {FirstName}\n" +
                $"Last name: {LastName}\n" +
                $"Student number: {StudentNumber}\n" +
                $"Age: {Age}\n" +
                $"Address:\n{FullAddress}\n" +
                $"List of all scores: {DisplayAllScores()}\n" +
                $"Average score: {AverageScore}";
            return info;
        }
        public string DisplayAllScores() // Method added to display all marks obtained by the student
        {                                // Method used in the override ToString() method
            string listScore = null;
            for (int i = 0; i < scores.Length; i++)
                listScore += " " + scores[i] + " ";
            return listScore;
        }
    }
}
