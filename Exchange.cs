namespace BankSystem
{
    internal class Exchange
    {
        public double sekToEuro { get; set; }
        public double sekToUsd { get; set; }
        public double sekToGbp { get; set; }
        public double euroToUsd { get; set; }
        public double euroToSek { get; set; }
        public double euroToGbp { get; set; }
        public double usdToSek { get; set; }
        public double usdToEuro { get; set; }
        public double usdToGbp { get; set; }

        public Exchange()
        {
            sekToEuro = 0.088;
            sekToUsd = 0.096;
            sekToGbp = 0.076;
            euroToUsd = 1.09;
            euroToSek = 11.41;
            euroToGbp = 0.87;
            usdToSek = 10.42;
            usdToEuro = 0.91;
            usdToGbp = 0.80;
        }
        public void UpdateExchangeRate(Administrator administrator)
        {
            int selectedRate;
            double newRateValue;
            Console.Clear();
            // Current exhange rate
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Current Exchange Rates:");
            Console.WriteLine("");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("1. SEK to Euro: {0}", sekToEuro);
            Console.WriteLine("2. SEK to USD: {0}", sekToUsd);
            Console.WriteLine("3. SEK to GBP: {0}", sekToGbp);
            Console.WriteLine("4. EURO To USD: {0}", euroToUsd);
            Console.WriteLine("5. EURO to SEK: {0}", euroToSek);
            Console.WriteLine("6. EURO to GBP: {0}", euroToGbp);
            Console.WriteLine("7. USD to SEK: {0}", usdToSek);
            Console.WriteLine("8. USD to EURO: {0}", usdToEuro);
            Console.WriteLine("9. USD to GBP: {0}", usdToGbp);
            Console.ResetColor();

            // Admin choose which of the currency should be updated
            while (true)
            {
                // Låt användaren välja vilken valutakurs de vill uppdatera
                Console.WriteLine("\nEnter the number of the exchange rate you want to update:");
                if (int.TryParse(Console.ReadLine(), out selectedRate))
                {
                    if (selectedRate >= 1 && selectedRate <= 9)
                    {
                        break;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Please pick a number between 1 and 9.");
                        Console.ResetColor();
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid input. Please enter a number.");
                    Console.ResetColor();
                }
            }

            while (true)
            {
                // Admin changing value for exchange rate
                Console.WriteLine("Enter the new value for the exchange rate:");
                if (double.TryParse(Console.ReadLine(), out newRateValue))
                {
                    // Update the new exchange rate
                    switch (selectedRate)
                    {
                        case 1:
                            sekToEuro = newRateValue;
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("The new exchange rate is {0}", newRateValue);
                            Console.ResetColor();
                            break;
                        case 2:
                            sekToUsd = newRateValue;
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("The new exchange rate is {0}", newRateValue);
                            Console.ResetColor();
                            break;
                        case 3:
                            sekToGbp = newRateValue;
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("The new exchange rate is {0}", newRateValue);
                            Console.ResetColor();
                            break;
                        case 4:
                            euroToUsd = newRateValue;
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("The new exchange rate is {0}", newRateValue);
                            Console.ResetColor();
                            break;
                        case 5:
                            euroToSek = newRateValue;
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("The new exchange rate is {0}", newRateValue);
                            Console.ResetColor();
                            break;
                        case 6:
                            euroToGbp = newRateValue;
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("The new exchange rate is {0}", newRateValue);
                            Console.ResetColor();
                            break;
                        case 7:
                            usdToSek = newRateValue;
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("The new exchange rate is {0}", newRateValue);
                            Console.ResetColor();
                            break;
                        case 8:
                            usdToEuro = newRateValue;
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("The new exchange rate is {0}", newRateValue);
                            Console.ResetColor();
                            break;
                        case 9:
                            usdToGbp = newRateValue;
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("The new exchange rate is {0}", newRateValue);
                            Console.ResetColor();
                            break;

                        default:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Invalid selection.");
                            Console.ResetColor();
                            break;
                    }
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Exchange rate updated successfully!");
                    Console.ResetColor();
                    administrator.ReturnToMenu();
                    return;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid input for the new exchange rate.");
                    Console.ResetColor();
                }
            }
        }

    }
}
