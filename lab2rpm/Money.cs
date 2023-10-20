using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2rpm
{
    class Money
    {
        public Dictionary<int, int> denominations;

        public Money()
        {
            denominations = new Dictionary<int, int>
        {
            {1, 0},
            {2, 0},
            {5, 0},
            {10, 0},
            {50, 0},
            {100, 0},
            {500, 0},
            {1000, 0},
            {5000, 0}
        };
        }

        public void AddDenomination(int denomination, int count)
        {
            if (denominations.ContainsKey(denomination))
            {
                denominations[denomination] += count;
            }
        }

        public void RemoveDenomination(int denomination, int count)
        {
            if (denominations.ContainsKey(denomination))
            {
                if (denominations[denomination] >= count)
                {
                    denominations[denomination] -= count;
                }
            }
        }

        public decimal TotalAmount()
        {
            decimal total = 0;
            foreach (var pair in denominations)
            {
                total += pair.Key * pair.Value;
            }
            return total;
        }

        public void Divide(decimal divisor)
        {
            if (divisor <= 0)
            {
                Console.WriteLine("Делитель должен быть больше 0");
                return;
            }

            foreach (var denomination in denominations.Keys.ToList())
            {
                int count = denominations[denomination];
                int newCount = (int)Math.Floor(count / divisor);
                denominations[denomination] = newCount;
            }
        }

        public void Multiply(decimal multiplier)
        {
            if (multiplier <= 0)
            {
                Console.WriteLine("Множитель должен быть больше 0.");
                return;
            }

            foreach (var denomination in denominations.Keys.ToList())
            {
                int count = denominations[denomination];
                int newCount = (int)Math.Floor(count * multiplier);
                denominations[denomination] = newCount;
            }
        }

        public override string ToString()
        {
            return string.Join(", ", denominations.Select(pair => $"{pair.Value}x{pair.Key}")) + " рублей";
        }
    }

}
