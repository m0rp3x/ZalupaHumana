using System;
using System.Threading;
using MySql.Data.MySqlClient;


namespace aye

{

    internal class ZalupaHumana
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

            Console.WriteLine(
                $" Ваш профиль \n Вас зовут {fio}\n Ваш возраст {age}\n Ваш вес {weightint} \n Ваш рост {heightint} \n Ваше ИМТ {bmi}  ");

            Console.WriteLine();
            Console.WriteLine("Далее мы узнаем учитесь вы сейчас или работаете и проведем проф ориентационный тест ");
            Console.WriteLine("Для продолжения нажмите любую клавишу...");
            Console.ReadKey();
            Console.WriteLine();


            Console.WriteLine("Происходит загрузка");

            for (int i = 10; i < 100; i++)
            {

                Thread.Sleep(100);
                Console.WriteLine(i + 1 + "%");

            }

            Console.WriteLine("Загрузка успешно завершена");

            Console.WriteLine();

            var ageStat = age < 10 && age > 5 ? "Школьник" :
                age > 16 ? "Студент колледжа или Старшеклассник" : "выпускник и более старый слой общества";

            Console.WriteLine($"Вы :  {ageStat}");

            Console.WriteLine();
            Console.WriteLine();




            {

                {

                    string constr = "Server=185.12.94.106;Database =2p2s10;Uid=2p2s10;pwd=231-429-617;charset=utf8";
                    MySqlConnection mycon = new MySqlConnection(constr);



                    string sqlExpression =
                        "INSERT INTO user (fio, age, weight , heint, bmi) VALUES(@fio, @age,@weight, @height, @bmi);";

                    MySqlCommand command = new MySqlCommand(sqlExpression, mycon);
                    using (MySqlConnection connection = new MySqlConnection(constr))
                    {
                        using (command = new MySqlCommand(sqlExpression, connection))
                        {
                            connection.Open();
                            MySqlParameter nameParam = new MySqlParameter("@fio", fio);
                            MySqlParameter nameParam2 = new MySqlParameter("@age", age);
                            MySqlParameter nameParam3 = new MySqlParameter("@height", heightint);
                            MySqlParameter nameParam4 = new MySqlParameter("@weight", weightint);
                            MySqlParameter nameParam5 = new MySqlParameter("@bmi", bmi);
                            command.Parameters.Add(nameParam);
                            command.Parameters.Add(nameParam2);
                            command.Parameters.Add(nameParam3);
                            command.Parameters.Add(nameParam4);
                            command.Parameters.Add(nameParam5);
                            MySqlDataReader reader = command.ExecuteReader();
                            
                            
                            string constr2 = "Server=185.12.94.106;Database =2p2s10;Uid=2p2s10;pwd=231-429-617;charset=utf8";
                          
                            MySqlConnection conn = new MySqlConnection(constr2);
                            
                            conn.Open();
                            
                            string sql = "SELECT * FROM user";
                            
                            command = new MySqlCommand(sql, conn);
                            
                            reader = command.ExecuteReader();
                            
                            while (reader.Read())
                            {
                               
                                Console.WriteLine(reader[0].ToString() + " " + reader[1].ToString());
                            }
                            reader.Close(); 
                            conn.Close();
                            
                            
                                
                        }
                    }
                }
            }
        }
    }
}
