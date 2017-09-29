using System;
using SoapConsumerCurrencyConverter.ServiceReference1;

namespace SoapConsumerCurrencyConverter
{
    class Program
    {
        // I added a service reference to the WSDL file of the service provider
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
                foreach (Currency currency in allCurrencies)
                {
                    Console.WriteLine(currency.Code + " " + currency.Name);
                    // Methods are not transported by SOAP from the provider to the consumer
                    // so no ToString method on Currency objects
                }
            }
        }
    }
}
