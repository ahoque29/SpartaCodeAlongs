using System;
using System.Collections.Generic;
using System.Text;

namespace MoqExampleBackEnd
{
    public class ExchangeRateService : IExchangeRateService
    {
        public string GetLatestRates()
        {
            throw new NotImplementedException();
        }

        public decimal GetRateFor(string baseCurrency, string targetCurrency)
        {
            throw new NotImplementedException();
        }
    }
}
