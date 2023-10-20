using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using lab2rpm;

namespace lab2rpm
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Bankomat
    {
        private string atmId;
        private Money availableMoney;
        private decimal minWithdrawal;
        private decimal maxWithdrawal;

        public Bankomat(string atmId, decimal minWithdrawal, decimal maxWithdrawal)
        {
            this.atmId = atmId;
            this.minWithdrawal = minWithdrawal;
            this.maxWithdrawal = maxWithdrawal;
            availableMoney = new Money();
        }
        public void LoadMoney(Money money)
        {
            foreach (var denomination in money.denominations.Keys.ToList())
            {
                int count = money.denominations[denomination];
                availableMoney.AddDenomination(denomination, count);
            }
        }
        public bool WithdrawMoney(decimal amount, out Money withdrawnMoney)
        {
            if (amount >= minWithdrawal && amount <= maxWithdrawal && availableMoney.TotalAmount() >= amount)
            {
                withdrawnMoney = new Money();

                var remainingAmount = amount;
                foreach (var denomination in availableMoney.denominations.Keys.ToList())
                {
                    while (remainingAmount >= denomination && availableMoney.denominations[denomination] > 0)
                    {
                        withdrawnMoney.AddDenomination(denomination, 1);
                        availableMoney.RemoveDenomination(denomination, 1);
                        remainingAmount -= denomination;
                    }
                }

                if (remainingAmount == 0)
                    return true;
            }

            withdrawnMoney = null;
            return false;
        }

        public override string ToString()
        {
            return $"{atmId} - Доступные купюры: {availableMoney} \r\nВсего денег: {availableMoney.TotalAmount()}, Минимальное снятие: {minWithdrawal}, Максимальное снятие: {maxWithdrawal}";
        }
    }
}