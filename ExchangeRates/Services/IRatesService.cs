using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExchangeRates.Services
{
    public interface IRatesService
    {
        public double GetRateByDate(DateTime date, string currencyCode);
    }
}
