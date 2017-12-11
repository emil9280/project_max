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




        private string Brugernavn;
        public void Login()
        {
            Console.WindowHeight = 15;
            Console.WindowWidth = 40;
            int screenHeight = Console.WindowHeight;
            int screenWidth = Console.WindowWidth;
            
            string Password;
            int screenheight = Console.WindowHeight;
            int screenwidth = Console.WindowWidth;



            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.Clear();
            Screen1();
            Console.WriteLine("     Welcome to Bank Of TechCollege");
            Console.WriteLine(" ");
            Console.WriteLine(" ");
            Console.WriteLine(" ");
            Console.WriteLine(" ");
            Console.WriteLine("       press any button to login");
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
            #region connect
            MySQLConnect mysql = new MySQLConnect();
            List<string>[] list = mysql.SelectLogin();
            if (UserCheck(list[0], list[1], Brugernavn, Password))
            {
                Console.WriteLine("You have logged in");
                Thread.Sleep(1000);
                Console.Clear();
                Menu();

            }
            else
            {
                Console.WriteLine("Login or password was incorrect");
                Thread.Sleep(5000);

            }
            #endregion            
        }

        #region check connection
        public bool UserCheck(List<string> user, List<string> password, string userInput, string passInput)
        {
            bool returnvalue = false;
            for (int i = 0; i < user.Count; i++)
            {
                if (user[i] == userInput)
                {
                    if (password[i] == passInput)
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

            try
            {
                Console.WriteLine("Please choose where to go");
                Console.WriteLine("");
                Console.WriteLine("press 1 for account");
                Console.WriteLine("press 2 for transfere");
                resultat = Console.ReadLine();
                try
                {
                    switch (resultat)
                    {
                        case "1":
                            Console.Clear();
                            Account();
                            break;

                        case "2":
                            Console.Clear();
                            Transfere();
                            break;

                        default:
                            Console.Clear();
                            Screen1();
                            Console.WriteLine("          wrong input try again");
                            Console.WriteLine("          press any key to try again");
                            Screen2();
                            Console.ReadKey();
                            Console.Clear();
                            Menu();
                            break;
                    }
                }
                catch
                {

                }
            }
            catch
            { }
            Console.ReadKey();
        }




        public void Account()
        {
            double balance = 0;
            double balance2 = 0;
            int accounts = 0;
            string resultat;
            MySQlbalance mysql = new MySQlbalance();
            List<string>[] list = mysql.balanc();
            balancecheck(list[0], Brugernavn);

            Screen1();
            Console.WriteLine(" ");
            Console.WriteLine(" ");
            Console.WriteLine("             1. account: " + balance);
            if (accounts == 1)
            {
                Console.WriteLine("             2. account: " + balance2);
            }

            Console.WriteLine(" ");
            Console.WriteLine(" ");
            Console.WriteLine("       press 1 to enter transfere");
            Console.WriteLine("       press 2 to exit");
            Screen2();
            Console.WriteLine(" ");
            resultat = Console.ReadLine();
            switch (resultat)
            {
                case "1":
                    Console.Clear();
                    Transfere();
                    break;

                case "2":
                    Environment.Exit(0);
                    break;

                default:
                    Console.Clear();
                    Screen1();
                    Console.WriteLine("           error wrong input");
                    Screen2();
                    Console.ReadKey();
                    Console.Clear();
                    Account();
                    break;

            }
            Console.ReadKey();
        }

        public double balancecheck(List<string> user, List<string> bruger2, List<string> balance, List<string> balance2, List<string> accounts)
        {
            List<string> bruger2 = ;
            double returnvaule = 500;
            for (int i = 0; i < user.Count; i++)
            {
                if (user == bruger2)
                {
                    returnvaule = 1000;
                }
            }
            return returnvaule;
        }
        




        public void Transfere()
        {
            int accounts = 0;
            
            Screen1();
            Console.WriteLine("    choose account to transfer from");
            Console.WriteLine("           1. for account 1");
            if (accounts == 1)                
            {
                Console.WriteLine("           2. for account 2");
                Screen2();
                Thread.Sleep(5000);
                transfere2();
            }
            Screen2();
            Thread.Sleep(5000);
            transfere2();
        }
        private void transfere2()
        {
            string resultat;            
            Console.WriteLine(" ");
            resultat = Console.ReadLine();
            Console.Clear();
            switch (resultat)
            {
                case "1":
                    Console.WriteLine("      you have choosen account 1");
                    Thread.Sleep(3000);
                    Console.Clear();
                    account1();
                    break;

                case "2":
                    Console.WriteLine("     you have choosen account 2");
                    Console.Clear();
                    Thread.Sleep(3000);
                    account2();
                    break;

                default:
                    Console.WriteLine("wrong input try again");
                    Console.ReadKey();
                    Transfere();
                    break;
            }

        }
          private void account1()
          {
            Console.WriteLine("hello account 1");
            Console.ReadKey();
                
          }

        private void account2()
        {
            Console.WriteLine("hello account 2");
            Console.ReadKey();
        }





        static void Main(string[] args)
        {
            new Program().Loading();
        }
    }
}