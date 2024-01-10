﻿using Ardalis.GuardClauses;
using Haskap.DddBase.Domain;
using MoneyValueObject.DomainShared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace MoneyValueObject.Domain;

public class Money : ValueObject
{
    public decimal Value { get; private set; }
    public Currency Currency { get; private set; }

    public Money(decimal value, Currency currency = Currency.TRY)
    {
        Value = value;
        Currency = currency;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
        yield return Currency;
    }

    public Money Convert(ICurrencyConverter currencyConverter, Currency toCurrency)
    {
        var convertedAmount = currencyConverter.Convert(Value, Currency, toCurrency);
        return new Money(convertedAmount, toCurrency);
    }

    public static Money operator +(Money a, Money b)
    {
        if (a.Currency != b.Currency)
        {
            throw new InvalidOperationException("Para birimleri aynı değil!");
        }

        return new Money(a.Value + b.Value, a.Currency);
    }

    public static Money operator -(Money a, Money b)
    {
        if (a.Currency != b.Currency)
        {
            throw new InvalidOperationException("Para birimleri aynı değil!");
        }

        return new Money(a.Value - b.Value, a.Currency);
    }

    public static Money operator *(decimal a, Money b)
    {
        return new Money(a * b.Value, b.Currency);
    }

    public static Money operator *(Money a, decimal b)
    {
        return b * a;
    }

    public static Money operator /(Money a, decimal b)
    {
        return new Money(a.Value / b, a.Currency);
    }
}
