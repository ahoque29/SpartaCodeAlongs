using System;
using System.Collections.Generic;
using System.Text;

namespace MoqExampleBackEnd
{
    public interface IExchangeRateService
    {
        string GetLatestRates();
        public decimal GetRateFor(string baseCurrency, string targetCurrency);
    }
}
