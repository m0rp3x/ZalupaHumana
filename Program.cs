using System;
using System.Threading;
using MySql.Data.MySqlClient;

namespace ConsoleApp10

{

    internal static class ZalupaHumana
    {
        public static void Main(string[] args)
        {

            Console.WriteLine("Введите cвоё имя и фамилию: ");
            var fio = (Console.ReadLine());
            Console.WriteLine("Введите ваш возраст: ");
            var age = int.Parse(Console.ReadLine() ?? string.Empty );
            Console.WriteLine("Введите ваш вес ");
            var weightint = int.Parse(Console.ReadLine() ?? String.Empty);
            Console.WriteLine("Введите ваш рост ");
            double heightint = int.Parse(Console.ReadLine() ?? String.Empty);
            double bmi = weightint / (heightint % 100 * heightint % 100);
            Console.WriteLine("Введите id");
            var id = int.Parse(Console.ReadLine() ?? String.Empty);
            

            Console.WriteLine();

            Console.WriteLine(
                $" Ваш профиль \n Вас зовут {fio}\n Ваш возраст {age}\n Ваш вес {weightint} \n Ваш рост {heightint} \n Ваше ИМТ {bmi} \n Ваш id {id}  ");

            Console.WriteLine();
            Console.WriteLine("Далее мы узнаем учитесь вы сейчас или работаете и проведем проф ориентационный тест ");
            Console.WriteLine("Для продолжения нажмите любую клавишу...");
            while (Console.ReadKey().Key != ConsoleKey.Spacebar){}
            

              
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


            Console.WriteLine("Введите имя вашей базы \n");
            
            
            string databaseName = Console.ReadLine();
            
            Console.WriteLine("Введите логин от вашей базы \n  ");
            
            string dblog = Console.ReadLine();
            
            Console.WriteLine("Пароль от базы данных \n ");
            
            string dbPass = Console.ReadLine();

            Console.WriteLine($"имя базы:{databaseName}; логин от базы:{dblog}, пароль:{dbPass} \n");

            Console.WriteLine();
           

            



            {

                {
                    MySqlConnectionStringBuilder constr = new MySqlConnectionStringBuilder($"Server=185.12.94.106;Database ={databaseName};Uid={dblog};pwd={dbPass};charset=utf8");


                    string sqlExpression =
                        "INSERT INTO user (id,fio, age, weight , heint, bmi, age_stat) VALUES(@id,@fio, @age,@weight, @height, @bmi,@age_stat);";

                    MySqlCommand command;
                    using (MySqlConnection connection = new MySqlConnection(constr.ToString()))
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
                            MySqlParameter nameParam7 = new MySqlParameter("@age_stat", ageStat);
                            command.Parameters.Add(nameParam);
                            command.Parameters.Add(nameParam2);
                            command.Parameters.Add(nameParam3);
                            command.Parameters.Add(nameParam4);
                            command.Parameters.Add(nameParam5);
                            command.Parameters.Add(nameParam6);
                            command.Parameters.Add(nameParam7);
                            MySqlDataReader reader;
                            command.ExecuteReader();


                            MySqlConnection conn = new MySqlConnection(constr.ToString());
                            
                            conn.Open();    
                            Console.WriteLine();
                            Console.WriteLine();
                            Console.WriteLine();
                            
                            
                            string sql = "SELECT * FROM user";
                            
                            command = new MySqlCommand(sql, conn);
                            
                            reader = command.ExecuteReader();
                            
                            while (reader.Read())
                            {
                               
                                Console.WriteLine(reader[0] + " " + reader[1]);
                            }
                            reader.Close(); 
                            conn.Close();

                            Console.WriteLine("Вас соскамили в базу хихихаха");
                                
                            






                        }
                    }
                }
            }
        }
    }
}
