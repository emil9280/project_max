using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Threading;

namespace bank
{
    class Program
    {
        public void Screen1()
        {
            int screenwidth = Console.WindowWidth;

            for (int i = 0; i < screenwidth; i++)
            {
                Console.SetCursorPosition(i, 0);
                Console.WriteLine("#");
            }
        }
        public void Screen2()
        {
            int screenheight = Console.WindowHeight;
            int screenwidth = Console.WindowWidth;

            for (int i = 0; i < screenwidth; i++)
            {
                Console.SetCursorPosition(i, screenheight - 1);
                Console.Write("#");
            }
            for (int i = 0; i < screenheight - 1; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.Write("#");
            }
            for (int i = 0; i < screenheight - 1; i++)
            {
                Console.SetCursorPosition(screenwidth - 1, i);
                Console.Write("#");
            }
        }
        public void Loading()
        {
            Console.WindowHeight = 3;
            Console.WindowWidth = 20;
            int screenHeight = Console.WindowHeight;
            int screenWidth = Console.WindowWidth;
            string[] loadingImg = { "|", "/", "-", "\\", "|", "/", "-", "\\", "|", "/", "-", "\\", "|", "/", "-", "\\", "|", "/", "-", "\\", "|", "/", "-", "\\" };
            string[] loadingDots = { ".", "..", "...", "....", ".....", "......", ".......", "", "" };
            int loadingImgPos = 0;
            int loadingDotsPos = 0;

            try
            {
                for (int i = 0; i < 30; i++)
                {
                    Console.WriteLine(loadingImg[loadingImgPos] + " Loading " + loadingDots[loadingDotsPos]);
                    Thread.Sleep(150);
                    Console.Clear();

                    if (loadingImgPos > 23)
                    {
                        loadingDotsPos = 0;
                    }
                    else
                    {
                        loadingImgPos++;
                    }

                    if (loadingDotsPos > 6)
                    {
                        loadingDotsPos = 0;
                    }
                    else
                    {
                        loadingDotsPos++;
                    }
                }

            }
            catch { }

            Console.WriteLine("Files okay");
            Thread.Sleep(500);
            Console.Clear();
            Login();
        }




        public void Login()
        {
            Console.WindowHeight = 15;
            Console.WindowWidth = 40;
            int screenHeight = Console.WindowHeight;
            int screenWidth = Console.WindowWidth;
            string Brugernavn;
            string BRugernavn = "test";
            string BrugerNavn;
            string BRugerNavn = "emil9280";
            string Password;
            string PAssword = "1234";
            string PAssWord = "hello";
            int screenheight = Console.WindowHeight;
            int screenwidth = Console.WindowWidth;



            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.Clear();
            Screen1();
            Console.WriteLine("#    Welcome to Bank Of TechCollege");
            Console.WriteLine(" ");
            Console.WriteLine(" ");
            Console.WriteLine(" ");
            Console.WriteLine(" ");
            Console.WriteLine("#      press any button to login       #");
            Screen2();
            Console.ReadKey();
            Console.Clear();
            Screen1();
            Console.WriteLine("Please enter login data");
            Thread.Sleep(300);
            Console.Write("username: ");
            Brugernavn = Console.ReadLine();
            Console.Write("password: ");
            Password = Console.ReadLine();
            #region Lars
            MySQLConnect mysql = new MySQLConnect();
            List<string>[] list = mysql.SelectLogin();
            if (UserCheck(list[0], list[1], Brugernavn, Password))
            {
                Console.WriteLine("You have logged in");
                Thread.Sleep(10000);
                //you have loged in
            }
            else
            {
                Console.WriteLine("Login or password was incorrect");
                Thread.Sleep(5000);
                //password or username was wrong
            }
            #endregion
            /*
            string MyconnectionString = "Server=localhost:3306;Database=users;uid=" + Brugernavn + ";pwd=" + Password + ";";
            MySqlConnection connection = new MySqlConnection(MyconnectionString);
            connection.Open();
            Console.WriteLine("Hello " + Brugernavn);
            Thread.Sleep(500);
            */
        }

        #region check
        public bool UserCheck(List<string> user, List<string> password, string userInput, string passInput)
        {
            bool returnvalue = false;
            for(int i = 0; i < user.Count; i++)
            {
                if(user[i] == userInput)
                {
                    if(password[i] == passInput)
                    {
                        returnvalue = true;
                    }
                }
            }

            return returnvalue;
        }
        #endregion


        public void Menu()
        {
            string resultat;
            int resultat2;

            try
            {
                Console.WriteLine("Please choose where to go to");
                Console.WriteLine("");
                Console.WriteLine("press 1 for account");
                Console.WriteLine("press 2 for transfere");
                resultat = Console.ReadLine();
                resultat2 = Convert.ToInt16(resultat);
                if (resultat2 == 1)
                {
                    Console.Clear();
                    Account();
                }
                else
                {
                    if (resultat2 == 2)
                    {
                        Console.Clear();
                        Transfere();
                    }
                }
            }
            catch
            { }
            Console.ReadKey();
        }




        public void Account()
        {
            Console.WriteLine("hello");
            Console.ReadKey();
        }




        public void Transfere()
        {
            Console.WriteLine("hello2");
            Console.ReadKey();
        }




        static void Main(string[] args)
        {
            new Program().Loading();
        }
    }
}
