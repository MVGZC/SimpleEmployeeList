//Employee list

namespace EmployeeList
{
    class Program
    {
        static void Main()
        {
            
            Dictionary<int, string> employeeList = new Dictionary<int, string>();
            bool exit = false;
            while(!exit)
            {
                int userInput = 0;
                Console.WriteLine("Current employees:\n");
                if(employeeList.Count == 0)
                {
                    Console.WriteLine("There are no employees\n");
                }
                else
                {
                    foreach (var x in employeeList)
                    {
                        Console.WriteLine($"ID: {x.Key} | Name: {x.Value}");
                    }
                }

                Console.WriteLine();
                Console.WriteLine("1. Add employee");
                Console.WriteLine("2. Remove employee");
                Console.WriteLine("3. Exit");
                Console.Write("\nInput: ");
                try
                {
                    userInput = Convert.ToInt16(Console.ReadLine());
                }
                catch(OverflowException)
                {
                    Console.WriteLine("Number too big");
                }
                catch(Exception)
                {
                    Console.Clear();
                    Console.WriteLine("Only numbers are permited" + "\n");
                }
                
                switch(userInput)
                {
                    case 1: AddEmployee(employeeList); break;
                    case 2: RemoveEmployee(employeeList); break;
                    case 3: exit = true; break;
                    default: Console.WriteLine("Invalid input"); break;
                }

            }

        }

        static void AddEmployee(Dictionary<int, string> employeeList)
        {
            Console.Clear();
            int startingID = 100;
            Console.Write("Enter employee name: ");
            string userInput = Console.ReadLine();

            while(employeeList.ContainsKey(startingID))
            {
                startingID++;
            }

            employeeList.Add(startingID, userInput);
            Console.Clear();
            Console.WriteLine($"Employee {userInput} was succesfully added\n");
        }

        static void RemoveEmployee(Dictionary<int, string> employeeList)
        {
            Console.Clear();
            int ID = -1;
            
            while(ID == -1)
            {
                Console.Write("Enter the id of the employee you want to remove: ");
                try
                {
                    ID = Convert.ToInt16(Console.ReadLine());
                }
                catch(OverflowException)
                {
                    Console.WriteLine("Number too big");
                }
                catch(Exception)
                {
                    Console.Clear();
                    Console.WriteLine("Only numbers are permited" + "\n");
                }
            }

            if(employeeList.Remove(ID))
                Console.WriteLine("Employee removed\n");
            else
                Console.WriteLine("User ID doesn't exist\n");
            
        }
    }
}