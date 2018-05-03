using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;

namespace lab9_studentinfo_wclass_az
{
        /* Program will recognize valid inputs when the user requests information
         * about students in class.
         * 
         * uses a "Student" class.
         * uses lists instead of arrays.
         * provides hometown, favorite food and favorite number about students in a class.
         * prompts the user to retrieve, add, list or quit.
         * added support for more than 20 students.
         * uses LINQ for input validation to reject numbers for non-int data members.
         * students can be listed in an alphabetical profile style order with "list" command.
         * added "profile" method, retrieves all info at once.
         * 
         * TODO: request user response for returning additional profiles while in method. */

    // a class for the student and their info.
    class Student
    {
        public string Name { get; set; }
        public string Hometown { get; set; }
        public string FavFood { get; set; }
        public int FavNumber { get; set; }

        public Student(string Name=null, string Hometown=null, string FavFood=null, int FavNum= 0) 
        {
            this.Name = Name;
            this.Hometown = Hometown;
            this.FavFood = FavFood;
            this.FavNumber = FavNum;
        }
    }

    class Program
    {
        //declares a public list named Students using the Student Class type.
        public static List<Student> Students = new List<Student>();

        static void Main(string[] args)
        {
            Student s0 = new Student("Zarra", "Akron", "Lasagna", 10);
            Student s1 = new Student("Jerry", "Atlana", "Turkey", 3);
            Student s2 = new Student("Bob", "New York", "Tacos", 14);
            Student s3 = new Student("Tim", "Detroit", "Sushi", 19);
            Student s4 = new Student("Bill", "Los Angeles", "Soup", 40);
            Students.Add(s0);
            Students.Add(s1);
            Students.Add(s2);
            Students.Add(s3);
            Students.Add(s4);

            Console.WriteLine("Welcome to our C# class!");

            // RunProgram is set to true, GoAgainAsker() and AddAnotherStudentAsker() can set it to false.
            bool RunProgram = true;
            while (RunProgram == true)
            {
                //asks to retrieve or add
                Console.WriteLine("Type \"retrieve\" to retrieve information about a student.");
                Console.WriteLine("Type \"add\" to add a student and their information.");
                Console.WriteLine("Type \"list\" to the list the students in alphabetical order.");
                Console.WriteLine("Type \"profile\" to view a student's profile.");
                Console.WriteLine("Type \"quit\" to quit the program.");

                //user's response
                string RetrAddOrQuit = Console.ReadLine().ToLower();

                if (RetrAddOrQuit != "retrieve" 
                    && RetrAddOrQuit != "add" 
                    && RetrAddOrQuit != "list"
                    && RetrAddOrQuit != "profile"
                    && RetrAddOrQuit != "quit")
                {
                    continue;
                }

                // use requests student info
                else if (RetrAddOrQuit == "retrieve")
                {
                    StudentRetriever();
                }
                // user wants to add a student
                else if (RetrAddOrQuit == "add")
                {
                    StudentAdder();
                }
                // user requests student info in alphabetical order
                else if (RetrAddOrQuit == "list")
                {
                    Console.WriteLine("");
                    StudentsInAZOrder();
                }
                // user requests student profile
                else if (RetrAddOrQuit == "profile")
                {
                    Console.WriteLine("");
                    StudentProfiler();
                }

                // user wants to quit
                else if (RetrAddOrQuit == "quit")
                {
                    Console.WriteLine("Bye!");
                    RunProgram = false;
                }
            }

        }
  

        // method to request user Y or N for more student info retrieval.
        static bool MoreInfoAsker()
        {
            Console.WriteLine("Would you like to know more about this student?  Type y for yes or anything else for no.");
            string input = Console.ReadLine().ToLower();
            if (input == "y")
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        // method to request user Y or N for more student info retrieval.
        static bool AddAnotherStudentAsker()
        {
            Console.WriteLine("Would you like to add information about another student?  Type y for yes or anything else for no.");
            string input = Console.ReadLine().ToLower();
            if (input == "y")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // method for adding students.
        static void StudentAdder()
        {
            //declaring data member variables
            string sname ="";
            string shometown="";
            string sfavfood="";
            int sfavnum=0;

            bool AddingInfo = true;
            while (AddingInfo)
            {
                // adding name
                bool AskingName = true;
                while (AskingName)
                {
                    Console.WriteLine("What is the student's name?");
                    string NewStudent = Console.ReadLine();

                    bool numbersuccess = NewStudent.Any(char.IsDigit);

                    if (String.IsNullOrEmpty(NewStudent) || numbersuccess == true)
                    {
                        Console.WriteLine("Please enter a valid name.");
                        continue;
                    }
                    sname = NewStudent;
                    Student newstudent = new Student(Name:sname);
                    AskingName = false;

                }

                bool AskingHomeTown = true;
                while (AskingHomeTown)
                {
                    // addding hometown
                    Console.WriteLine("What is the student's hometown?");
                    String NewHometown = Console.ReadLine();

                    bool numbersuccess = NewHometown.Any(char.IsDigit);

                    if (String.IsNullOrEmpty(NewHometown) || numbersuccess == true)
                    {
                        Console.WriteLine("Please enter a valid hometown.");
                        continue;
                    }
                    shometown = NewHometown;
                    Student newstudent = new Student(Hometown:shometown);
                    AskingHomeTown = false;
                }

                bool AskingFavFood = true;
                while (AskingFavFood)
                {
                    // adding favorite food
                    Console.WriteLine("What is the student's favorite food?");
                    String NewFavFood = Console.ReadLine();

                    bool numbersuccess = NewFavFood.Any(char.IsDigit);

                    if (String.IsNullOrEmpty(NewFavFood) || numbersuccess == true)
                    {
                        Console.WriteLine("Please enter a valid favorite food.");
                        continue;
                    }
                    sfavfood = NewFavFood;
                    Student newstudent = new Student(FavFood:sfavfood);
                    AskingFavFood = false;
                }

                bool AskingFavNum = true;
                while (AskingFavNum)
                {
                    // adding favorite number
                    Console.WriteLine("What is the student's favorite number?");
                    String NewFavNumber = Console.ReadLine();

                    bool numbersuccess = NewFavNumber.All(char.IsDigit);

                    if (String.IsNullOrEmpty(NewFavNumber) || numbersuccess == false)
                    {
                        Console.WriteLine("Please enter a valid favorite number.");
                        continue;
                    }
                    int num;
                    int.TryParse(NewFavNumber, out num);
                    sfavnum = num;
                    Student newstudent = new Student(FavNum:num);
                    AskingFavNum = false;

                }
                //adds student
                Student newStudent = new Student(sname, shometown, sfavfood, sfavnum);
                Students.Add(newStudent);
                // ask to add another student
                AddingInfo = AddAnotherStudentAsker();
            }
        }

        // method that returns student in alphabetical order
        static void StudentsInAZOrder()
        {
            var pull = from student in Students
                        orderby student.Name
                        select student;

            foreach (var item in pull)
            {
                Console.WriteLine($"Student Name: {item.Name}");
                Console.WriteLine($"Hometown: {item.Hometown}");
                Console.WriteLine($"Favorite Food: {item.FavFood}");
                Console.WriteLine($"Favorite Number: {item.FavNumber}");
                Console.WriteLine("");
            }
        }

        // method for student profiler
        static void StudentProfiler()         {
            bool RetrievingProfile = true;
            while (RetrievingProfile == true)
            {
                {
                    bool askforname = true;
                    while (askforname)
                    {
                        Console.WriteLine("Which student would you like a profile for?");
                        string choicer = Console.ReadLine().ToLower();

                        var individualstudent = Students.Where(x => x.Name.ToLower() == choicer);
                        if (Students.Exists(x => x.Name.ToLower() == choicer))
                        {
                            foreach (var item in individualstudent)
                            {
                                Console.WriteLine($"Student Name: { item.Name}");
                                Console.WriteLine($"Hometown: { item.Hometown}");
                                Console.WriteLine($"Favorite Food: { item.FavFood}");
                                Console.WriteLine($"Favorite Number: { item.FavNumber}");
                                Console.WriteLine("");
                            }
                            askforname = false;
                            RetrievingProfile = false;
                        }
                        else
                        {
                            Console.WriteLine($"Student {choicer} doesn't exist.");
                        }
                    }

                }
            }
        } 
        //method for retrieving student info
        static void StudentRetriever()
        {
            bool RetrievingInfo = true;
            while (RetrievingInfo == true)
            {
                Console.WriteLine($"Enter a student number up to {Students.Count}");
                string userchoice;
                userchoice = Console.ReadLine();
                int studentnum;
                int.TryParse(userchoice, out studentnum);
                studentnum = studentnum - 1;

                //input validation for student number.
                if (studentnum < 0 || studentnum >= Students.Count)
                {
                    Console.WriteLine("That student does not exist.  Please try again.");
                    continue;
                }
                else
                {
                    Console.WriteLine($"Student {studentnum + 1} is {Students[studentnum].Name}. What would you like to know about {Students[studentnum].Name}?");
                    while (RetrievingInfo == true)
                    {
                        Console.WriteLine("Enter 'hometown', 'favorite food' or 'favorite number'.");
                        string infochoice = Console.ReadLine().ToLower();

                        // input validation for student's info selection.
                        if (infochoice != "hometown" && infochoice != "favorite food" && infochoice != "favorite number")
                        {
                            Console.WriteLine("That data does not exist.  Please try again.");
                            continue;
                        }
                        else if (infochoice == "hometown")
                        {
                            Console.WriteLine($"{Students[studentnum].Name} is from {Students[studentnum].Hometown}.");
                            RetrievingInfo = MoreInfoAsker();
                        }
                        else if (infochoice == "favorite food")
                        {
                            Console.WriteLine($"{Students[studentnum].Name}'s favorite food is {Students[studentnum].FavFood}.");
                            RetrievingInfo = MoreInfoAsker();
                        }
                        else if (infochoice == "favorite number")
                        {
                            Console.WriteLine($"{Students[studentnum].Name}'s favorite number is {Students[studentnum].FavNumber}.");
                            RetrievingInfo = MoreInfoAsker();
                        }
                    }
                }
            }
        }
    }
}
