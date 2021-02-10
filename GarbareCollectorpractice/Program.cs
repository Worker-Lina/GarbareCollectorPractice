using System;
using System.Collections.Generic;
using System.Reflection;

namespace GarbareCollectorpractice
{
    class Program
    {
        static void Main(string[] args)
        {
            int length = new int(), startIndex = new int();
            Type stringType = typeof(String);


            MethodInfo methodSubstr = stringType.GetMethod("Substring", new Type[] { typeof(int), typeof(int) });

            Console.Write($"Строка: ");
            string myString = Console.ReadLine();
            Console.Write("Введите начальный индекс: ");

            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out startIndex) && startIndex >= 0)
                    break;
                else
                {
                    Console.WriteLine("Вы ввели неправильное значение!!!");
                    Console.Clear();
                }
            }
            while (true)
            {
                Console.Write("Введите длину: ");
                if (int.TryParse(Console.ReadLine(), out length) && length + startIndex <= myString.Length && length >= 0)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Вы ввели неправильное значение!!!");
                    Console.Clear();
                }
            }

            Console.WriteLine(methodSubstr.Invoke(myString, new object[] { startIndex, length }));

            Console.ReadLine();
            Console.Clear();


            Type listType = typeof(List<>);
            foreach (ConstructorInfo constructor in listType.GetConstructors())
            {
                if (constructor.IsPublic)
                    Console.Write("Public");
                else if ((constructor.IsPrivate))
                    Console.Write("Private");
                if (constructor.IsStatic)
                    Console.Write(" Static ");
                Console.Write($"{constructor.Name} (");
                foreach (var parametr in constructor.GetParameters())
                {
                    Console.Write($" {parametr.ParameterType} {parametr.Name} ");
                }
                Console.Write(")\n");

            }
        }
    }
}
