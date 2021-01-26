using System;
using System.Collections.Generic;

namespace GameMarketSimulation
{
    class Program
    {
        static List<Customer> customers = new List<Customer>();
        static List<Game> games = new List<Game>();
        static GameManager gameManager;
        static void Main(string[] args)
        {
            gameManager = new GameManager();
            
            customers.Add(new Customer { IdNumber = "1", Name = "Jack", SurName = "Costanza", BirthYear = "1962" });
            customers.Add(new Customer { IdNumber = "2", Name = "Jery", SurName = "Cucco", BirthYear = "1987" });
            customers.Add(new Customer { IdNumber = "3", Name = "Enes", SurName = "Biçen", BirthYear = "1999" });

            
            games.Add(new Game { Name = "Dust 2", Price = 20, GameCampain= new Campain { Name = "Christmass", Discount = 0.10, Date =new DateTime(2021,2,5) } });
            games.Add(new Game { Name = "CS", Price = 30, GameCampain = new Campain { Name = "National Day", Discount = 0.15, Date = new DateTime(2021,1,26)} });
            games.Add(new Game { Name = "Red Dead Redemption", Price = 30 });
            loginSignUpOperations();
        }

        private static void loginSignUpOperations()
        {
            while (true)
            {
                Console.WriteLine("Welcome! Do you want sigIn(1) or signUp(2). Press 1 or 2");
                string input = Console.ReadLine().ToString();

                if (input.Equals("1"))
                {
                    Console.WriteLine("please enter the your id number");
                    string idNumber = Console.ReadLine().ToString();
                    Console.WriteLine(idNumber);

                    Customer temp = customers.Find(x => x.IdNumber.Equals(idNumber));
                    if (temp != null)
                    {
                        programMainPage(temp); Console.Clear();
                        break;
                    }
                    else
                    {
                        Console.WriteLine("There is no Customer who has this ID Number.\n Program gone to entrance page...\n\n");
                        continue;
                    }
                    }
                else if(input.Equals("2"))
                {
                    Console.WriteLine("please enter the your id number");
                    string idNumber = Console.ReadLine().ToString();

                    Customer temp = customers.Find(x => x.IdNumber.Equals(idNumber));
                    if (temp != null)
                    {
                        Console.WriteLine("There is a Customer who has this ID Number.\n Program gone to entrance page...\n\n");
                        continue;
                    }
                    else
                    {
                        Console.WriteLine("please enter the your name");
                        string name = Console.ReadLine().ToString();

                        Console.WriteLine("please enter the your surName");
                        string surName = Console.ReadLine().ToString();

                        Console.WriteLine("please enter the your birth year");
                        string birthYear = Console.ReadLine().ToString();

                        Console.WriteLine("Your informations:\nID Number: " + idNumber + "\nName: " + name + "\nSurName: " + surName + "\nBirth Year: " + birthYear+"\n\n");

                        Customer customer = new Customer { IdNumber = idNumber, Name = name, SurName = surName, BirthYear = birthYear };
                        programMainPage(customer);
                        break;
                    }
                }
            }
            
        }

        private static void programMainPage(Customer customer)
        {
            while (true)
            {
                Console.WriteLine("\nWelcome to the games page. You can buy any game with its code. for exit press -1\nGames:\n");

                foreach (var item in games)
                {
                    if (item.GameCampain!=null && item.GameCampain.Date>DateTime.Today)
                    {
                        Console.WriteLine( item.Name +"\tGame code: "+games.IndexOf(item) +"\nprice: " + item.Price + "(X) --> with "+item.GameCampain.Name+" campain price is: "+(item.Price - item.Price*item.GameCampain.Discount));
                    }
                    else
                    {
                        Console.WriteLine( item.Name +"\tGame code: "+games.IndexOf(item) +"\nprice: " + item.Price );
                    }
                    Console.WriteLine("\n------\n");
                }

                try
                {

                    int a = Convert.ToInt32(Console.ReadLine().ToString());

                    switch (a)
                    {
                        case -1:
                            Console.Clear();
                            loginSignUpOperations(); break;
                            break;
                        default:
                            if (a<games.Count && a>=0)
                            {
                                Console.Clear();
                                gameManager.buyAGame(customer, games[a]);
                                Console.ReadLine();
                            }
                            break;
                    }
                }
                catch (Exception)
                {

                    
                }
            }
        }
    }
}
