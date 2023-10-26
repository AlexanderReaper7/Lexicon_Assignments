using System;

class Program
{
    static void Main()
    {
        bool isRunning = true;

        while (isRunning)
        {
            Console.WriteLine("Huvudmeny:");
            Console.WriteLine("1. Ungdom eller pensionär");
            Console.WriteLine("2. Räkna ut priset för ett sällskap");
            Console.WriteLine("3. Upprepa tio gånger");
            Console.WriteLine("4. Det tredje ordet");
            Console.WriteLine("0. Avsluta programmet");

            Console.Write("Välj ett alternativ: ");
            string userInput = Console.ReadLine();

            switch (userInput)
            {
                case "1":
                    CheckAgeCategory();
                    break;

                case "2":
                    CalculateGroupPrice();
                    break;

                case "3":
                    RepeatTenTimes();
                    break;

                case "4":
                    GetThirdWord();
                    break;

                case "0":
                    isRunning = false;
                    break;

                default:
                    Console.WriteLine("Felaktig input. Försök igen.");
                    break;
            }
        }
    }

    static void CheckAgeCategory()
    {
        Console.Write("Ange ålder: ");
        if (int.TryParse(Console.ReadLine(), out int age))
        {
            int price = 0;

            if (age < 5 || age > 100)
            {
                price = 0;
                Console.WriteLine("Gratis för barn under 5 och pensionärer över 100.");
            }
            else if (age < 20)
            {
                price = 80;
                Console.WriteLine($"Ungdomspris: {price}kr");
            }
            else if (age >= 65)
            {
                price = 90;
                Console.WriteLine($"Pensionärspris: {price}kr");
            }
            else
            {
                price = 120;
                Console.WriteLine($"Standardpris: {price}kr");
            }
        }
        else
        {
            Console.WriteLine("Ogiltig ålder. Försök igen.");
        }
    }

    static void CalculateGroupPrice()
    {
        Console.Write("Ange antal personer i sällskapet: ");
        if (int.TryParse(Console.ReadLine(), out int numPeople) && numPeople > 0)
        {
            int totalCost = 0;

            for (int i = 0; i < numPeople; i++)
            {
                Console.Write($"Ange ålder för person {i + 1}: ");
                if (int.TryParse(Console.ReadLine(), out int age))
                {
                    int price = 0;

                    if (age < 5 || age > 100)
                    {
                        price = 0; // Gratis för barn under 5 och pensionärer över 100.
                    }
                    else if (age < 20)
                    {
                        price = 80;
                    }
                    else if (age >= 65)
                    {
                        price = 90;
                    }
                    else
                    {
                        price = 120;
                    }

                    totalCost += price;
                }
                else
                {
                    Console.WriteLine("Ogiltig ålder. Försök igen.");
                    i--; // Upprepa frågan om ogiltig ålder.
                }
            }

            Console.WriteLine($"Antal personer: {numPeople}");
            Console.WriteLine($"Totalkostnad för sällskapet: {totalCost} kr");
        }
        else
        {
            Console.WriteLine("Ogiltigt antal personer. Ange ett positivt heltal.");
        }
    }

    static void RepeatTenTimes()
    {
        Console.Write("Ange en text: ");
        string input = Console.ReadLine();

        for (int i = 1; i <= 10; i++)
        {
            Console.Write($"{i}. {input}, ");
        }
    }

    static void GetThirdWord()
    {
        Console.Write("Ange en mening med minst 3 ord: ");
        string input = Console.ReadLine();

        string[] words = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        if (words.Length >= 3)
        {
            string thirdWord = words[2];
            Console.WriteLine($"Det tredje ordet är: {thirdWord}");
        }
        else
        {
            Console.WriteLine("Meningen måste innehålla minst 3 ord.");
        }
    }
}
