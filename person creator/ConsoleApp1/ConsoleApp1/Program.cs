using System;
using System.IO.Pipes;

class Program
{
    static void Main(string[] args)
    {
        int count;
        int step;
        bool running = true;
        while (running)
        {
            Console.WriteLine("How many people you want to create?");
            try
            {
                count = int.Parse(TryReadLine());
                List<Person> peopleList = new List<Person>();
                step = 1;
                while (step <= count)
                {
                    Console.WriteLine($"{step} / {count}");

                    Console.WriteLine("Enter first name");
                    string firstName = TryReadLine();

                    Console.WriteLine("Enter last name");
                    string lastName = TryReadLine();

                    Console.WriteLine("Enter age");
                    int age = int.Parse(TryReadLine());

                    Person person = new Person(firstName, lastName, age);
                    peopleList.Add(person);
                    step++;
                    Console.WriteLine("\n");
                }
                foreach (Person person in peopleList)
                {
                    Console.WriteLine($"{person.FirstName} {person.LastName} {person.Age} \n");
                }

                running = false;
            }
            catch (FormatException)
            {
                Console.WriteLine("You shold enter number!");
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("You should enter valid data!");
            }
            catch (OverflowException)
            {
                Console.WriteLine("You should enter valid length of numbers!");
            }
        }
        Console.WriteLine("Press any key to exit ...");
        Console.ReadKey();
        
    }
    static public string TryReadLine() 
    {
        string input = Console.ReadLine();
        if (string.IsNullOrEmpty(input))
        {
            throw new NullReferenceException("You should enter valid data!");
        }
        return input;
    }
}