// See https://aka.ms/new-console-template for more information
using MoneyValueObject.Domain;

Console.WriteLine("Hello, World!");


var m = new Money(1.3m);
var m1 = new Money(1.333333m);
var m2 = new Money(1.3888888m);
var m3 = new Money(0.3m);
var m4 = new Money(1345.3324m);
var m5 = new Money(1345.335m);
var m6 = new Money(1345.3324m, MoneyValueObject.DomainShared.Currency.EUR);

Console.WriteLine(m.ToString());
Console.WriteLine(m1.ToString());
Console.WriteLine(m2.ToString());
Console.WriteLine(m3.ToString());
Console.WriteLine(m4.ToString());
Console.WriteLine(m5.ToString());
Console.WriteLine(m6.ToString());