using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace oopLab2
{
    class Program
    {
        class students
        {
            public string name;
            public int roll_No;
            public float cgpa;
        }
        class products
        {
            public int ID;
            public string name;
            public float price;
            public string category;
            public string brandName;
            public string country;
        }
        class students1
        {
            public string name;
            public int roll_No;
            public float cgpa;
            public char isHostelide;
            public string department;
        }
        class userCredetails
        {
            public string userName;
            public string password;
        }
        static void Main(string[] args)
        {
            //task1();
           // task2();
           // task3();
            challenge1();
           // challenge2();
        }
        static void task1()
        {
            students s1 = new students();
            s1.name = "Ahmad";
            s1.roll_No = 1;
            s1.cgpa = 2.5F;
            Console.WriteLine("Name: {0} Roll_No: {1} CGPA: {2} ", s1.name, s1.roll_No, s1.cgpa);
            Console.ReadKey();

        }
        static void task2()
        {
            students s1 = new students();
            students s2 = new students();
            s1.name = "Ahmad";
            s2.name = "Bilal";
            s1.roll_No = 1;
            s2.roll_No = 2;
            s1.cgpa = 2.5F;
            s2.cgpa = 3.8F;
            Console.WriteLine("Name: {0} Roll_No: {1} CGPA: {2} ", s1.name, s1.roll_No, s1.cgpa);
            Console.WriteLine("Name: {0} Roll_No: {1} CGPA: {2} ", s2.name, s2.roll_No, s2.cgpa);
            Console.ReadKey();
        }
        static void task3()
        {
            students s1 = new students();
            Console.WriteLine("Enter your name: ");
            s1.name = Console.ReadLine();
            Console.WriteLine("Enter your Roll No: ");
            s1.roll_No = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter your CGPA: ");
            s1.cgpa = float.Parse(Console.ReadLine());
            Console.WriteLine("Name: {0} Roll_No: {1} CGPA: {2} ", s1.name, s1.roll_No, s1.cgpa);
            Console.ReadKey();



        }
        static char menu()
        {
            Console.Clear();
            char choice;
            Console.WriteLine("Press1 to Add a student ");
            Console.WriteLine("press2 to view student");
            Console.WriteLine("press3 for top three students");
            Console.WriteLine("press4 to exit");
            choice =char.Parse( Console.ReadLine());
            return choice;

        }
        static students1 addstudent()
        {
            Console.Clear();
            students1 s1 = new students1();
            Console.WriteLine("Enter your name: ");
            s1.name = Console.ReadLine();
            Console.WriteLine("Enter your Roll No: ");
            s1.roll_No = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter your CGPA: ");
            s1.cgpa = float.Parse(Console.ReadLine());
            Console.WriteLine("Is hostelide y||n: ");
            s1.isHostelide= char.Parse(Console.ReadLine());
            Console.WriteLine("Enter your department: ");
            s1.department = Console.ReadLine();
            return s1;


        }
        static void viewStudent(students1[] s, int count)
        {
            Console.Clear();
            for( int i=0; i<count; i++)
            {
                Console.WriteLine("Name: {0} Roll No: {1} CGPA: {2} Department: {3} IsHostelide: {4}",s[i].name,s[i].roll_No,s[i].cgpa,s[i].department,s[i].isHostelide);
            }
            Console.WriteLine("press any key to continue...");
            Console.ReadKey();
        }
        static void topStudent(students1[] s,int count)
        {
            Console.Clear();
            if (count == 0)
            {
                Console.WriteLine("No record Present");
            }
            else if (count == 1)
            {
                viewStudent(s, 1);

            }
            else if (count == 2)
            {
                for(int i=0; i < 2; i++)
                {
                    int index = largest(s, i, count);
                    students1 temp = s[index];
                    s[index] = s[i];
                    s[i] = temp;

                }
                viewStudent(s, 2);

            }
            else
            {
                for(int x=0; x < 3; x++)
                {
                    int index = largest(s, x, count);
                    students1 temp = s[index];
                    s[index] = s[x];
                    s[x] = temp;
                }
                viewStudent(s, 3);

            }
        }
        static int largest(students1[] s,int start ,int end)
        {
            int index = start;
            float large = s[start].cgpa;
            for(int x=start; x<end; x++)
            {
                if(large < s[x].cgpa)
                {
                    large = s[x].cgpa;
                    index = x;
                }
            }
            return index;
        }
        static void task4()
        {
            students1[] s = new students1[10];
            char option;
            int count = 0;
            do
            {
                option = menu();
                if (option == '1')
                {
                    s[count] = addstudent();
                    count++;
                }
                else if (option == '2')
                {
                    viewStudent(s, count);
                }
                else if (option == '3')
                {
                    topStudent(s, count);
                }
                else if (option == '4')
                {
                    break;
                }
                else
                {
                    Console.WriteLine("invalid Choice");
                }
            } while (option != '4');
            Console.WriteLine("Press Enter To Exit...");
            Console.Read();
        }
        static int mainMenu()
        {
            int option;
            Console.WriteLine("1- SignIn");
            Console.WriteLine("2- SignUp");
            Console.WriteLine("Enter Option: ");
            option = int.Parse(Console.ReadLine());
            return option;

        }
        static string parseData(string record, int field)
        {
            int comma = 1;
            string item = "";
            for (int x = 0; x < record.Length; x++)
            {
                if (record[x] == ',')
                {
                    comma++;
                }
                else if (comma == field)
                {
                    item = item + record[x];
                }
            }
            return item;
        }
        static void readData(string path, userCredetails[] s)
        {
            int x = 0;
            if (File.Exists(path))
            {
                StreamReader file = new StreamReader(path);
                string record;
                while ((record = file.ReadLine()) != null)
                {
                    s[x].userName = parseData(record, 1);
                    s[x].password = parseData(record, 2);
                    x++;
                    if (x >= 5)
                    {
                        break;
                    }
                }
                file.Close();
            }
            else
            {
                Console.WriteLine("Not Exists");
            }
        }
        static void signUp(string path, string n, string p)
        {
            StreamWriter file = new StreamWriter(path, true);
            file.WriteLine(n + "," + p);
            file.Flush();
            file.Close();
        }
        static void signIn(string n, string p, userCredetails[] s)
        {
            bool flag = false;
            for (int i = 0; i < 5; i++)
            {
                if (n == s[i].userName && p == s[i].password)
                {
                    flag = true;
                    Console.WriteLine("Valid user");

                }
            }
            if (flag == false)
            {
                Console.WriteLine("Invalid User");
            }
            Console.ReadKey();
        }
        static void challenge2()
        {
            string path = "C:\\OOP\\Lab 2\\oopLab2\\Records.txt";
            userCredetails[] records = new userCredetails[5];
            int option;
            do
            {
                readData(path, records);
                Console.Clear();
                option = mainMenu();
                Console.Clear();
                if (option == 1)
                {
                    Console.WriteLine("Enter your name: ");
                    string n = Console.ReadLine();
                    Console.WriteLine("Enter your password: ");
                    string p = Console.ReadLine();
                    signIn(n, p, records);

                }
                else if (option == 2)
                {
                    Console.WriteLine("Enter new name: ");
                    string n = Console.ReadLine();
                    Console.WriteLine("Enter new password: ");
                    string p = Console.ReadLine();
                    signUp(path, n, p);

                }

            } while (option < 3);
            Console.Read();
        }
        static char productMenu()
        {
            Console.Clear();
            char choice;
            Console.WriteLine("Press1 to Add a product ");
            Console.WriteLine("press2 to view products");
            Console.WriteLine("press3 to view total store worth");
            Console.WriteLine("press4 to exit");
            choice = char.Parse(Console.ReadLine());
            return choice;

        }
        static products addProduct()
        {
            Console.Clear();
            products s1 = new products();
            Console.Write("Enter the name: ");
            s1.name = Console.ReadLine();
            Console.Write("Enter the ID: ");
            s1.ID = int.Parse(Console.ReadLine());
            Console.Write("Enter the country: ");
            s1.country = Console.ReadLine();
            Console.Write("Enter the category: ");
            s1.category= Console.ReadLine();
            Console.Write("Enter the brand name: ");
            s1.brandName = Console.ReadLine();
            Console.Write("Enter the price: ");
            s1.price = float.Parse(Console.ReadLine());
            return s1;


        }
        static void viewProducts(products[] s, int count)
        {
            Console.Clear();
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine("Name: {0} ID: {1} Category: {2} Country: {3} Brand Name: {4} Price: {5}", s[i].name, s[i].ID, s[i].category, s[i].country, s[i].brandName, s[i].price);
            }
            Console.WriteLine("press any key to continue...");
            Console.ReadKey();
        }
        static float storeWorth(products[] s, int count)
        {
            float sum=0;
            for(int i=0; i<count; i++)
            {
                sum = sum + s[i].price;
            }
            return sum;
        }
        static void challenge1()
        {
            products[] s = new products[10];
            char option;
            float total;
            int count = 0;
            do
            {
                option = productMenu();
                if (option == '1')
                {
                    s[count] = addProduct();
                    count++;
                }
                else if (option == '2')
                {
                    viewProducts(s, count);
                }
                else if (option == '3')
                {
                    total= storeWorth(s, count);
                    Console.Clear();
                    Console.WriteLine("Total Store Worth: {0}", total);
                    Console.Read();
                }
                else if (option == '4')
                {
                    break;
                }
                else
                {
                    Console.WriteLine("invalid Choice");
                }
            } while (option != '4');
            Console.WriteLine("Press Enter To Exit...");
            Console.Read();
        }
    }
}
