using System;
using System.Runtime.InteropServices;
using System.Threading;
using MySql.Data.MySqlClient;


namespace aye

{

    internal class ZalupaHumana
    {
        public static void Main(string[] args)
        {

            Console.WriteLine("Введите cвоё имя и фамилию: ");
            var fio = Console.ReadLine();
            Console.WriteLine("Введите ваш возраст: ");
            var ages = Console.ReadLine();
            var age = int.Parse(ages ?? string.Empty);
            Console.WriteLine("Введите ваш вес ");
            var weight = Console.ReadLine();
            var weightint = int.Parse(weight ?? String.Empty);
            Console.WriteLine("Введите ваш рост ");
            var height = Console.ReadLine();
            double heightint = int.Parse(height ?? String.Empty);
            double bmi = weightint / (heightint % 100 * heightint % 100);
            Console.WriteLine("Введите id");
            var id = int.Parse(Console.ReadLine());

            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine(
                $" Ваш профиль \n Вас зовут {fio}\n Ваш возраст {age}\n Ваш вес {weightint} \n Ваш рост {heightint} \n Ваше ИМТ {bmi} \n Ваш id {id}  ");

            Console.WriteLine();
            Console.WriteLine("Далее мы узнаем учитесь вы сейчас или работаете и проведем проф ориентационный тест ");
            Console.WriteLine("Для продолжения нажмите любую клавишу...");
            Console.ReadKey();
            Console.WriteLine();


            Console.WriteLine("Происходит загрузка");
            /*
            for (int i = 10; i < 100; i++)
            {

                Thread.Sleep(100);
                Console.WriteLine(i + 1 + "%");

            }
            */

            Console.WriteLine("Загрузка успешно завершена");

            Console.WriteLine();

            var ageStat = age < 10 && age > 5 ? "Школьник" :
                age > 16 ? "Студент колледжа или Старшеклассник" : "выпускник и более старый слой общества";

            Console.WriteLine($"Вы :  {ageStat}");

            Console.WriteLine();
            Console.WriteLine();


            Console.WriteLine("Введите имя вашей базы \n");
            
            
            string Database_name = Console.ReadLine();
            
            Console.WriteLine("Введите логин от вашей базы \n  ");
            
            string db_log = Console.ReadLine();
            
            Console.WriteLine("Пароль от базы данных \n ");
            
            string db_pass = Console.ReadLine();

            Console.WriteLine($"имя базы:{Database_name}; логин от базы:{db_log}, пароль:{db_pass} \n");

            Console.WriteLine();
           

            



            {

                {

                    string constr = $"Server=185.12.94.106;Database ={Database_name};Uid={db_log};pwd={db_pass};charset=utf8";
                    MySqlConnection mycon = new MySqlConnection(constr);



                    string sqlExpression =
                        "INSERT INTO user (id,fio, age, weight , heint, bmi) VALUES(@id,@fio, @age,@weight, @height, @bmi);";

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
                            MySqlParameter nameParam6 = new MySqlParameter("@id", id);
                            command.Parameters.Add(nameParam);
                            command.Parameters.Add(nameParam2);
                            command.Parameters.Add(nameParam3);
                            command.Parameters.Add(nameParam4);
                            command.Parameters.Add(nameParam5);
                            command.Parameters.Add(nameParam6);
                            MySqlDataReader reader = command.ExecuteReader();
                            
                            
                            string constr2 = $"Server=185.12.94.106;Database ={Database_name};Uid={db_log};pwd={db_pass};charset=utf8";                          
                            MySqlConnection conn = new MySqlConnection(constr2);
                            
                            conn.Open();
                            Console.WriteLine();
                            Console.WriteLine();
                            Console.WriteLine();
                            
                            
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
