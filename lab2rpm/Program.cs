using lab2rpm;
using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        Bankomat atm = new Bankomat("ATM001", minWithdrawal: 10, maxWithdrawal: 5000);
        Money initialMoney = new Money();
        initialMoney.AddDenomination(100, 10);
        initialMoney.AddDenomination(500, 5);
        initialMoney.AddDenomination(1000, 3);
        atm.LoadMoney(initialMoney);

        Console.WriteLine(atm.ToString());

        Console.Write("Введите сумму для снятия: ");
        if (decimal.TryParse(Console.ReadLine(), out decimal withdrawalAmount))
        {
            Money withdrawnMoney;

            if (atm.WithdrawMoney(withdrawalAmount, out withdrawnMoney))
            {
                Console.WriteLine($"Снятие: {withdrawnMoney}");
            }
            else
            {
                Console.WriteLine("Снятие отклонено.");
            }

            Console.WriteLine(atm.ToString());
        }
    }
}