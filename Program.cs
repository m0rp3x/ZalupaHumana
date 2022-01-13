using System;


namespace aye

{

    internal static class ZalupaHumana
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Введите Фамилию:");
            var f = Console.ReadLine();
            Console.WriteLine("Введите Имя");
            var n = Console.ReadLine();
            Console.WriteLine("Введите ваш возраст");
            var ages = Console.ReadLine();

            var age = int.Parse(ages ?? string.Empty);

            Console.WriteLine();
            
            Console.WriteLine();
            
            
            
        

            

            Console.WriteLine($"Ваша Фамилия: {f}");
            Console.WriteLine($"Ваше Имя: {n}");
            Console.WriteLine($"Вам: {age}");
            Console.WriteLine("Вы: " + (age > 50 ? "Старый" : "Молодой"));

          

        }
    }
}