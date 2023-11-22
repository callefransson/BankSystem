namespace BankSystem
{
    internal class Exchange
    {
        public double SekToEuro { get; set; }
        public double SekToUsd { get; set; }
        public double SekToGbp { get; set; }
        public double EuroToUsd { get; set; }
        public double EuroToSek { get; set; }
        public double EuroToGbp { get; set; }
        public double UsdToSek { get; set; }
        public double UsdToEuro { get; set; }
        public double UsdToGbp { get; set; }
        public double GbpToSek { get; set; }
        public double GbpToEuro { get; set; }
        public double GbpToUsd { get; set; }


        public Exchange()
        {
            SekToEuro = 0.088;
            SekToUsd = 0.096;
            SekToGbp = 0.076;
            EuroToUsd = 1.09;
            EuroToSek = 11.41;
            EuroToGbp = 0.87;
            UsdToSek = 10.42;
            UsdToEuro = 0.91;
            UsdToGbp = 0.80;
            GbpToEuro = 1.15;
            GbpToSek = 13.11;
            GbpToUsd = 1.25;

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
            Console.WriteLine("1. SEK to Euro: {0}", SekToEuro);
            Console.WriteLine("2. SEK to USD: {0}", SekToUsd);
            Console.WriteLine("3. SEK to GBP: {0}", SekToGbp);
            Console.WriteLine("4. EURO To USD: {0}", EuroToUsd);
            Console.WriteLine("5. EURO to SEK: {0}", EuroToSek);
            Console.WriteLine("6. EURO to GBP: {0}", EuroToGbp);
            Console.WriteLine("7. USD to SEK: {0}", UsdToSek);
            Console.WriteLine("8. USD to EURO: {0}", UsdToEuro);
            Console.WriteLine("9. USD to GBP: {0}", UsdToGbp);
            Console.WriteLine("10. GBP to EURO: {0}", GbpToEuro);
            Console.WriteLine("11. GBP to SEK: {0}", GbpToSek);
            Console.WriteLine("12. GBP to USD: {0}", GbpToUsd);

            Console.ResetColor();

            // Admin choose which of the currency should be updated
            while (true)
            {
                // Låt användaren välja vilken valutakurs de vill uppdatera
                Console.WriteLine("\nEnter the number of the exchange rate you want to update:");
                if (int.TryParse(Console.ReadLine(), out selectedRate))
                {
                    if (selectedRate >= 1 && selectedRate <= 12)
                    {
                        break;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Please pick a number between 1 and 12.");
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
                            SekToEuro = newRateValue;
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("The new exchange rate is {0}", newRateValue);
                            Console.ResetColor();
                            break;
                        case 2:
                            SekToUsd = newRateValue;
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("The new exchange rate is {0}", newRateValue);
                            Console.ResetColor();
                            break;
                        case 3:
                            SekToGbp = newRateValue;
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("The new exchange rate is {0}", newRateValue);
                            Console.ResetColor();
                            break;
                        case 4:
                            EuroToUsd = newRateValue;
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("The new exchange rate is {0}", newRateValue);
                            Console.ResetColor();
                            break;
                        case 5:
                            EuroToSek = newRateValue;
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("The new exchange rate is {0}", newRateValue);
                            Console.ResetColor();
                            break;
                        case 6:
                            EuroToGbp = newRateValue;
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("The new exchange rate is {0}", newRateValue);
                            Console.ResetColor();
                            break;
                        case 7:
                            UsdToSek = newRateValue;
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("The new exchange rate is {0}", newRateValue);
                            Console.ResetColor();
                            break;
                        case 8:
                            UsdToEuro = newRateValue;
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("The new exchange rate is {0}", newRateValue);
                            Console.ResetColor();
                            break;
                        case 9:
                            UsdToGbp = newRateValue;
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("The new exchange rate is {0}", newRateValue);
                            Console.ResetColor();
                            break;
                        case 10:
                            GbpToEuro = newRateValue;
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("The new exchange rate is {0}", newRateValue);
                            Console.ResetColor();
                            break;
                        case 11:
                            GbpToSek = newRateValue;
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("The new exchange rate is {0}", newRateValue);
                            Console.ResetColor();
                            break;
                        case 12:
                            GbpToUsd = newRateValue;
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
        public void ShowExchangeRate(Administrator administrator)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Current Exchange Rates:");
            Console.ResetColor();
            Console.WriteLine("1. SEK to Euro: {0}", SekToEuro);
            Console.WriteLine("2. SEK to USD: {0}", SekToUsd);
            Console.WriteLine("3. SEK to GBP: {0}", SekToGbp);
            Console.WriteLine("4. EURO To USD: {0}", EuroToUsd);
            Console.WriteLine("5. EURO to SEK: {0}", EuroToSek);
            Console.WriteLine("6. EURO to GBP: {0}", EuroToGbp);
            Console.WriteLine("7. USD to SEK: {0}", UsdToSek);
            Console.WriteLine("8. USD to EURO: {0}", UsdToEuro);
            Console.WriteLine("9. USD to GBP: {0}", UsdToGbp);
            Console.WriteLine("10. GBP to EURO: {0}", GbpToEuro);
            Console.WriteLine("11. GBP to SEK: {0}", GbpToSek);
            Console.WriteLine("12. GBP to USD: {0}", GbpToUsd);
            administrator.ReturnToMenu();
        }

    }
}
