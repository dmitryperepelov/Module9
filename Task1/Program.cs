using System;

namespace Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var exceptions = new Exception[] { new MyException(), new ArgumentOutOfRangeException(), new StackOverflowException(), new ArgumentNullException(), new AccessViolationException() };
            foreach (var item in exceptions)
            {
                try
                {
                    throw new Exception(item.GetType().ToString());
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                }
            }

            Console.ReadKey();
        }
    }

    public class MyException : Exception
    {

    }
}
