using System;

namespace MoqExampleBackEnd
{
    public class SaleCreator : ISaleCreator
    {
        private ICatalogItemManager _catalogItemManager;
        private IExchangeRateService _exchangeRateService;

        public SaleCreator(ICatalogItemManager cim, IExchangeRateService ers)
        {
            if (cim == null)
            { 
                throw new ArgumentException("CatalogItemManager cannot be null"); 
            }
            _catalogItemManager = cim;
            if (ers == null)
            { 
                throw new ArgumentException("ExchangeRateService cannot be null"); 
            }
            _exchangeRateService = ers;
        }

        public string CalculateTotal(string itemName, string currency, int quantity)
        {
            var price = _catalogItemManager.GetPrice(itemName);
            decimal exchangeRate = 1.00m;
            currency = currency.Trim().ToUpper();
            if (!currency.Equals("GBP")) {
                try
                {
                    exchangeRate = _exchangeRateService.GetRateFor("GBP", currency);
                }
                catch (TimeoutException)
                {
                    return "Sorry there was a problem obtaining an exchange rate";
                }
            }
            var convertedPrice = price * exchangeRate;
            var totalPrice = convertedPrice * quantity;
            return $"Total price: { totalPrice:f2} {currency} at {exchangeRate} per GBP";
        }
    }
}