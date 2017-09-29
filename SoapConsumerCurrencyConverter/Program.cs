using System;
using SoapConsumerCurrencyConverter.ServiceReference1;

namespace SoapConsumerCurrencyConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            string endpoint = "BasicHttpBinding_ICurrencyService"; // from the App.config file
            // This service has more than one endpoint (http + https)
            // You must specify which endpoint to use
            using (CurrencyServiceClient client = new CurrencyServiceClient(endpoint))
            {
                double rate = client.GetRate(CurrencyCode.EUR, CurrencyCode.DKK);
                Console.WriteLine(rate);

                Currency[] allCurrencies = client.GetAllCurrencyInfos();
                foreach (var curr in allCurrencies)
                {
                    Console.WriteLine(curr.Code + " " + curr.Name);
                }
            }
        }
    }
}
