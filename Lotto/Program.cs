﻿namespace Lotto
{
    class Program
    {
        static int cumulaton;

        static int start = 40;

        static Random rnd = new Random();

        public static void Main(string[] args)
        {

            int money = start;
            int day = 0;

            do
            {
                money = start;
                ConsoleKey choice;
                day = 0;
                do
                {
                    cumulaton = rnd.Next(2, 37) * 1000000;
                    day++;
                    int draw = 0;
                    List<int[]> coupon = new List<int[]>();
                    do
                    {
                        Console.Clear();
                        Console.WriteLine("Dzień : {0}", day);
                        Console.WriteLine("Witaj w grze lotto dziś do wygrania jest {0} zł", cumulaton);
                        Console.WriteLine("\n Stan konta : {0}", money);
                        SeeCoupon(coupon);
                        //Menu
                        Console.WriteLine("1 - Postaw nowy los - 3zl [{0}/8]", draw + 1);
                        if (money >= 3 && draw < 9)
                        {

                        }
                        Console.WriteLine("2 - Sprawdź kupon - losowanie");
                        Console.WriteLine("3 - Koniec gry");
                        //Menu
                        choice = Console.ReadKey().Key;
                        if (choice == ConsoleKey.D1 && money >= 3 && draw < 9)
                        {
                            coupon.Add(BetFate());
                            money -= 3;
                            draw++;
                        }
                    } while (choice == ConsoleKey.D1);
                    Console.Clear();
                    if(coupon.Count > 0)
                    {
                        int win = Chack(coupon);
                        if(win > 0)
                        {
                            Console.ForegroundColor= ConsoleColor.Green;
                            Console.WriteLine("Wygrałes {0} zł w tym losowaniu",win);
                            Console.ResetColor();
                            money += win;
                        }
                        else
                        {
                            Console.ForegroundColor= ConsoleColor.Red;
                            Console.WriteLine("Niestety nic nie wygrałeś spróbuj jeszcze raz !! ");
                            Console.ResetColor();
                        }
                    }
                    else
                    {
                        Console.WriteLine("Nie miałeś losów w tym losowaniu");
                    }
                    Console.WriteLine("Kontynuuj - Enter");
                    Console.ReadKey();

                } while (money >= 3 && choice != ConsoleKey.D3);
                Console.Clear();
                Console.WriteLine("Dzien : {0}, Twój wynik to : {1}zł ", day, money - start);
                Console.WriteLine("Graj od nowa - Enter");
            }
            while (Console.ReadKey().Key == ConsoleKey.Enter);
        }

        private static int Chack(List<int[]> coupon)
        {
            throw new NotImplementedException();
        }

        private static int[] BetFate()
        {
            throw new NotImplementedException();
        }

        private static void SeeCoupon(List<int[]> coupon)
        {
            throw new NotImplementedException();
        }
    }
}
