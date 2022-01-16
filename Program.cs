using System;
using System.ComponentModel.Design;
using System.Net.Mail;


namespace ConsoleApp2

{

    internal static class ZalupaHumana
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Введите cвоё имя и фамилию:");
            var fio = Console.ReadLine();
            Console.WriteLine("Введите ваш возраст");
            var ages = Console.ReadLine();
            var age = int.Parse(ages ?? string.Empty);
            Console.WriteLine("Введите ваш вес");
            var weight = Console.ReadLine();
            var weightint = int.Parse(weight ?? String.Empty);
            Console.WriteLine("Введите ваш рост");
            var height = Console.ReadLine();
            double heightint = int.Parse(height ?? String.Empty);
            double bmi = weightint / (heightint % 100 * heightint % 100);

            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine($" Ваш профиль \n Вас зовут {fio}\n Ваш возраст {age}\n Ваш вес {weightint} \n Ваш рост {heightint} \n Ваше ИМТ {bmi}  ");

            Console.WriteLine();
            Console.WriteLine();


            if (age < 5)
            {
                Console.WriteLine("хаха младенец");
            }
            else if (age > 10)
            {
                Console.WriteLine("хуйлуша");
            }
            else if (age >= 6)
            {
                Console.WriteLine("хаха шкила");
            }
            else if (age > 20)
            {
                Console.WriteLine("морген");
            }
            else if (age > 50)
            {
                Console.WriteLine("старое хуйло");
            }
            else
            {
                Console.WriteLine("молодое хуйло");
            }
        }
    }
}









