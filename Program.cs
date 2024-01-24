using System;
using System.Globalization;
using desafio_composicao1_csharp.Entities;
using desafio_composicao1_csharp.Entities.Enums;

namespace desafio_composicao1_csharp
{
    class Program
    {
        static void Main(string[] args)
        {



            Console.Write("Enter department's name: ");
            string departamentName = Console.ReadLine();
            Console.WriteLine("Enter worker data: ");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Level (Junior/MidLevel/Senior): ");
            WorkerLevel level = Enum.Parse<WorkerLevel>(Console.ReadLine());
            Console.Write("Base salary: ");
            double baseSalary = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Departament dept = new Departament(departamentName);
            Worker worker = new Worker(name, level, baseSalary, dept);

            Console.Write("How many contracts to this worker? ");
            int numberContacts = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberContacts; i++)
            {
                Console.WriteLine($"Enter #{i + 1} contract data: ");
                Console.Write("Date (DD/MM/YYYY): ");
                DateTime date = DateTime.Parse(Console.ReadLine());
                Console.Write("Value per hour: ");
                double valuePerHour = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.Write("Duration (hours): ");
                int hours = int.Parse(Console.ReadLine());
                HourContract contract = new HourContract(date, valuePerHour, hours);
                worker.AddContract(contract);
            }

            Console.WriteLine();

            Console.Write("Enter month and year to calculate income (MM/YYYY): ");
            string monthAndYear = Console.ReadLine();
            int month = int.Parse(monthAndYear.Substring(0, 2));
            int year = int.Parse(monthAndYear.Substring(3));
            Console.WriteLine($"Name: {worker.Name}");
            Console.WriteLine($"Department: {worker.Departament.Name}");
            Console.WriteLine($"Income for {monthAndYear} : R$ {worker.Income(year, month).ToString("F2", CultureInfo.InvariantCulture)}");




        }
    }
}





