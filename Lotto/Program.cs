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
                    if (coupon.Count > 0)
                    {
                        int win = Chack(coupon);
                        if (win > 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Wygrałes {0} zł w tym losowaniu", win);
                            Console.ResetColor();
                            money += win;
                        }
                        else
                        {
                            Console.WriteLine(draw);
                            Console.ForegroundColor = ConsoleColor.Red;
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
            int win = 0;
            int[] drawn = new int[6];
            for (int i = 0; i < drawn.Length; i++)
            {
                int draw = rnd.Next(1, 50);
                // check if the number is repeated
                if (!drawn.Contains(draw))
                {
                    drawn[i] = draw;
                }
                else
                {
                    i--;
                }
            }
            Array.Sort(drawn);
            Console.WriteLine("Wylosowane liczby");
            foreach (int number in drawn)
            {
                Console.Write(number + ", ");
            }
            int[] hit = CheckCoupon(coupon, drawn);
            int value = 0;

            Console.WriteLine();

            if (hit[0] > 0)
            {
                if (hit[0] > 0)
                {
                    value = hit[0] * 24;
                    Console.WriteLine("3 Trafione wygrałes : {0}zł", value);
                    win += value;
                }
                if (hit[1] > 0)
                {


                    value = hit[1] * rnd.Next(100, 301);
                    Console.WriteLine("4 Trafione wygrałes : {0}zł", value);
                    win += value;
                }
                if (hit[2] > 0)
                {
                    value = hit[2] * rnd.Next(4000, 8001);
                    Console.WriteLine("5 Trafione wygrałes : {0}zł", value);
                    win += value;
                }
                if (hit[3] > 0)
                {
                    value = (hit[3] * cumulaton) / hit[3] + rnd.Next(0, 5);
                    Console.WriteLine("6 Trafione wygrałes : {0}zł", value);
                }
            }
            return win;
        }

        private static int[] CheckCoupon(List<int[]> coupon, int[] drawn)
        {
            int[] win = new int[4];
            int i = 0;

            Console.WriteLine("\nTwój kupon");

            foreach (int[] los in coupon)
            {
                Console.WriteLine("Wylosowane liczby");
                foreach (int number in drawn)
                {
                    Console.Write(number + ", ");
                }
                i++;
                Console.WriteLine(i + ": ");
                int hit = 0;
                foreach (int number in los)
                {
                    if (drawn.Contains(number))
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(number + ", ");
                        Console.Clear();
                        hit++;
                    }
                    else
                    {
                        Console.WriteLine(number + ", ");
                    }
                }
                switch (hit)
                {
                    case 3:
                        win[0]++;
                        break;
                    case 4:
                        win[1]++;
                        break;
                    case 5:
                        win[2]++;
                        break;
                    case 6:
                        win[3]++;
                        break;
                }
                Console.WriteLine(" - Trafiono {0}/6", hit);
            }

            return win;
        }

        private static int[] BetFate()
        {
            int[] numbers = new int[6];
            int number = -1;
            for (int i = 0; i < numbers.Length; i++)
            {
                number = -1;
                Console.Clear();
                Console.Write("Podstawione liczby");
                foreach (int l in numbers)
                {
                    if (l > 0)
                    {
                        Console.Write(l + ", ");
                    }
                }
                Console.WriteLine("\n\nWybierz liczbe od 1 do 49");
                Console.Write("{0}/6 : ", i + 1);
                bool real = int.TryParse(Console.ReadLine(), out number);
                if (real && number > 0 && number <= 49 && !numbers.Contains(number))
                {
                    numbers[i] = number;
                }
                else
                {
                    Console.WriteLine("Już masz tą liczbe");
                    i--;
                    Console.ReadKey();
                }
            }
            Array.Sort(numbers);
            return numbers;
        }

        private static void SeeCoupon(List<int[]> coupon)
        {
            if (coupon.Count == 0)
            {
                Console.WriteLine("Nic nie postawiłes");
            }
            else
            {
                int i = 0;
                Console.WriteLine("\nTwój kupon");
                foreach (int[] los in coupon)
                {
                    i++;
                    Console.Write(i + ": ");
                    foreach (int number in los)
                    {
                        Console.Write(number + ", ");
                    }
                    Console.WriteLine();

                }
            }
        }
    }
}
