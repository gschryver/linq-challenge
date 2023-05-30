using System;
using System.Collections.Generic;
using System.Linq;

public class Bank
{
    public string Symbol { get; set; }
    public string Name { get; set; }
}

public class Customer
{
    public string Name { get; set; }
    public double Balance { get; set; }
    public string Bank { get; set; }
}

public class ReportItem
{
    public string CustomerName { get; set; }
    public string BankName { get; set; }
}

public class Program
{
    public static void Main()
    {
        List<Bank> banks = new List<Bank>() {
            new Bank(){ Name="First Tennessee", Symbol="FTB"},
            new Bank(){ Name="Wells Fargo", Symbol="WF"},
            new Bank(){ Name="Bank of America", Symbol="BOA"},
            new Bank(){ Name="Citibank", Symbol="CITI"},
        };

        List<Customer> customers = new List<Customer>() {
            new Customer(){ Name="Bob Lesman", Balance=80345.66, Bank="FTB"},
            new Customer(){ Name="Joe Landy", Balance=9284756.21, Bank="WF"},
            new Customer(){ Name="Meg Ford", Balance=487233.01, Bank="BOA"},
            new Customer(){ Name="Peg Vale", Balance=7001449.92, Bank="BOA"},
            new Customer(){ Name="Mike Johnson", Balance=790872.12, Bank="WF"},
            new Customer(){ Name="Les Paul", Balance=8374892.54, Bank="WF"},
            new Customer(){ Name="Sid Crosby", Balance=957436.39, Bank="FTB"},
            new Customer(){ Name="Sarah Ng", Balance=56562389.85, Bank="FTB"},
            new Customer(){ Name="Tina Fey", Balance=1000000.00, Bank="CITI"},
            new Customer(){ Name="Sid Brown", Balance=49582.68, Bank="CITI"}
        };

/*
            You will need to use the `Where()`
            and `Select()` methods to generate
            instances of the following class.

            public class ReportItem
            {
                public string CustomerName { get; set; }
                public string BankName { get; set; }
            }
        */

        var millionaireReport = customers
        .Where(c => c.Balance >= 1000000) // filter customers with balance >= 1 million
        .Select(c => new ReportItem // create a new ReportItem instance for each filtered customer
        {
            CustomerName = c.Name,
            BankName = banks.Single(b => b.Symbol == c.Bank).Name // get the bank name for the customer using Single() method
        })
        .OrderBy(item => item.CustomerName.Split(' ').Last()); // sort by last name of customer

    foreach (var item in millionaireReport)
    {
        Console.WriteLine($"{item.CustomerName} at {item.BankName}");
    }
    }
}