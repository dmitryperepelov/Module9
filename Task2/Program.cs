using System;
using System.Collections.Generic;
using System.Linq;

namespace Task2
{
    internal class Program
    {
        static List<string> list = new List<string> { "Иванов", "Петров", "Сидоров", "Федоров", "Макаров"};

        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Введите число 1 или 2: ");
                var number = Console.ReadLine();
                if (number != "1" && number != "2")
                    throw new MyException("Необходимо указать число 1 или 2!");

                var sort = new SortClass(list);

                sort.SortAscending += SortAscending;
                sort.SortDescending += SortDescending;
                var sortedItems = sort.Sort(number);
                foreach (string s in sortedItems)
                {
                    Console.WriteLine(s);
                }
            }
            catch(MyException exception)
            {
                Console.WriteLine(exception.Message);
            }

            Console.ReadKey();
        }

        static List<string> SortAscending(List<string> items)
        {
            return items.OrderBy(i => i).ToList();
        }

        static List<string> SortDescending(List<string> items)
        {
            return items.OrderByDescending(i => i).ToList();
        }
    }

    public delegate List<string> Notify(List<string> items);

    public class SortClass
    {
        public SortClass(List<string> items)
        {
            this.items = items;
        }

        private List<string> items;

        public event Notify SortAscending;

        public event Notify SortDescending;

        public List<string> Sort(string order)
        {
            Console.WriteLine($"Сортировка по {(order == "1" ? "возрастанию" : "убыванию")}");
            switch (order)
            {
                case "1":
                    return SortAscending?.Invoke(items);
                case "2":
                    return SortDescending?.Invoke(items);
            }
            return null;
        }
    }

    public class MyException : Exception 
    {
        public MyException(string message) : base(message) { }
    }
}
