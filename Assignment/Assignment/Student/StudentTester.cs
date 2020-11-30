using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment.Student
{
    class StudentTester
    {
        /// <summary>
        /// Main program; user creates a student and after choose some actions on the menu
        /// </summary>
        public void Main()
        {
            Console.WriteLine("Hi and welcome to the program of this assignement!");
            Console.WriteLine("First, you will have to enter informations about a student.");
            Student student = CreateStudent();
            Console.WriteLine($"The student {student.FullName} has been created successfully!");
            int choice = 0; // Creating this variable here to not create new ones at each loop
            while (true)
            {
            
                Console.WriteLine("\n---------------------------------------");
                Console.WriteLine("Menu:\n\t" +
                    "1. Display the student's average score\n\t" +
                    "2. Display the student's city\n\t" +
                    "3. Display the student's full address\n\t" +
                    "4. Display all the informations about the student\n\t" +
                    "5. Create a new student (that's remove the ancient) \n\t" +
                    "6. Exit the program\n" +
                    "---------------------------------------");
                string choiceString = Console.ReadLine();
                if (int.TryParse(choiceString, out int result) && int.Parse(choiceString) > 0 && int.Parse(choiceString) < 7)
                    choice = result;
                else
                    Console.WriteLine("This is not a correct choice, please enter 1, 2, 3, 4, 5 or 6.");
                switch (choice)
                {
                    case 1:
                        student.DisplayAverageScore();
                        Console.ReadKey();
                        break;
                    case 2:
                        student.DisplayCity();
                        Console.ReadKey();
                        break;
                    case 3:
                        student.DisplayAddress();
                        Console.ReadKey();
                        break;      
                    case 4:
                        Console.WriteLine(student.ToString());
                        Console.ReadKey();
                        break;
                    case 5:
                        student = CreateStudent();
                        Console.WriteLine($"The student {student.FullName} has been created successfully!");
                        Console.ReadKey();
                        break;
                    case 6:
                        goto breakOut;
                }
                
            }
        breakOut:;
        }
        
        /// <summary>
        /// Create a new instance of class Student by asking all the required fields to the user
        /// </summary>
        /// <returns>student</returns>
        public Student CreateStudent()
        {
            Student student;
        breakOutStud: // Going back to this line if one of the student's information has not a correct format/value.

            // Required fields to create a student (part 1) //
            // First name
            Console.WriteLine("Please enter the student's first name:");
            string firstName = Console.ReadLine();
            
            // Last name
            Console.WriteLine("Please enter the student's last name:");
            string lastName = Console.ReadLine();
            
            // Student number
            Console.WriteLine("Please enter the student number:");
            string studentNumber = Console.ReadLine();
            
            // Age
            int age;
            while (true)
            {
                Console.WriteLine("Please enter the student's age:");
                string ageString = Console.ReadLine();
                if (int.TryParse(ageString, out int result))
                {
                    age = result;
                    break;
                }
                else
                    Console.WriteLine("Error! This is not an integer number. Please try again.");
            }
            // Every mandatory fields is filled, we can try to create an instance of Student
            try
            {
                student = new Student(firstName, lastName, studentNumber, age);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message); // In case of problem diplay the error message
                goto breakOutStud; // And go back to the beginning of this method
            }
            // End of part 1 //
            // Address part //
            Address.Address addressInfos;
        breakOutAddress: // Going back to this line if one of the address information has not a correct format/value.
            
            // Address number
            int addressNum;
            while (true)
            {
                Console.WriteLine("Please enter the student's address number:");
                string addressNumString = Console.ReadLine();
                if (int.TryParse(addressNumString, out int result))
                {
                    addressNum = result;
                    break;
                }
                else
                    Console.WriteLine("Error! This is not an integer number. Please try again.");
            }
            
            // Street
            Console.WriteLine("Please enter the student's street name:");
            string street = Console.ReadLine();
            
            // City
            Console.WriteLine("Please enter the student's city name:");
            string city = Console.ReadLine();
            
            // Country
            Console.WriteLine("Please enter the student's country:");
            string country = Console.ReadLine();
            
            // Try to create address instance with all the infos
            try
            {
                addressInfos = new Address.Address(addressNum, street, city, country);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message); // In case of problem, display the error message
                goto breakOutAddress; // And go back to the beginning of address part
            }

            student.AddressInfos = addressInfos;
            // End of address part //

            // Scores array part //
            int choice; int[] scores;
            while (true)
            {  
                Console.WriteLine("You have 2 options to enter the student's score array:\n\t" +
                    "1. Entering the scores one by one in the array manually (max 25 values)\n\t" +
                    "2. Create an array with x random scores inside (you just choose 'x' value, max 25)");
                Console.Write("Please choose an option (1 or 2) > ");
                string choiceString = Console.ReadLine();
                if (int.TryParse(choiceString, out int result) && (int.Parse(choiceString) == 1 || int.Parse(choiceString) == 2))
                {
                    choice = result;
                    break;
                }
                else
                    Console.WriteLine("Error! It's not a valid choice, please choose 1 or 2.");
            }
            if (choice == 1)
                scores = ScoresManual();
            else
                scores = ScoresAuto();
            student.Scores = scores;
            // End of scores array part //
            // Every fields is filled, we can return the student
            return student;
        }

        /// <summary>
        /// Create an array of 25 (or less) integers between 0 and 100 that have to be entered by the user
        /// </summary>
        /// <returns>scores</returns>
        public int[] ScoresManual()
        {
            // Creating different variables needed
            int[] scores; int size; string val;
            // Asking for size of the array
            while (true)
            {
                Console.WriteLine("How many scores do you want to enter (25 max)?");
                val = Console.ReadLine();
                if (int.TryParse(val, out int result) && int.Parse(val) > 0 && int.Parse(val) <= 25) // Conditions
                {
                    size = result;
                    break;
                }
                else
                    Console.WriteLine("Error! Please enter a valid integer number (from 1 to 25).");
            }
            scores = new int[size];
            // Filling the array
            for(int i = 0; i<size; i++)
            {
                while (true)
                {
                    Console.Write($"Please enter score {i+1} > ");
                    val = Console.ReadLine();
                    if (int.TryParse(val, out int result) && int.Parse(val) >= 0 && int.Parse(val) <= 100) // Conditions
                    {
                        scores[i] = result;
                        break;
                    }
                    else
                        Console.WriteLine("Error! Please enter an integer number between 0 and 100.");
                }
            }
            // When it's finished we can return the array
            return scores;
        }

        /// <summary>
        /// Create an array of 25 (or less) integers between 0 and 100 that are randomly generated
        /// </summary>
        /// <returns>scores</returns>
        public int[] ScoresAuto()
        {
            // Creating different variables needed
            int[] scores; int size; string val;
            // Asking for size of the array
            while (true)
            {
                Console.WriteLine("How many scores do you want to enter (25 max)?");
                val = Console.ReadLine();
                if (int.TryParse(val, out int result) && int.Parse(val) > 0 && int.Parse(val) <= 25) // Conditions
                {
                    size = result;
                    break;
                }
                else
                    Console.WriteLine("Error! Please enter a valid integer number (from 1 to 25).");
            }
            scores = new int[size];
            // Filling the array
            Random r = new Random();
            for (int i = 0; i < size; i++)
                scores[i] = r.Next(0, 101); // Random value generated between 0 and 100
            // When it's finished we can return the array
            return scores;
        }
    }
}
