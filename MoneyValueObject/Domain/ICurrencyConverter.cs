using MoneyValueObject.DomainShared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyValueObject.Domain;

public interface ICurrencyConverter
{
    decimal Convert(decimal fromAmount, Currency fromCurrency, Currency toCurrency);
}
