using System.Net.Mail;

namespace ATM_SoftWare
{
    class Program
    {
        public static int correct_amount = 0;
        
        
        static int SelectAmount()
        {
            int amount = int.Parse(Console.ReadLine());
            return amount;
        }

        static void AtmWork(int amount)
        {
            if (amount % 100 == 0 && amount <= 150000)
            {
                int[] denominations = { 5000, 2000, 1000, 500, 200, 100 };//массив с номиналоми купюр
                Dictionary<int, int> result = new Dictionary<int, int>();//Dictionary (словарь) - это коллекция, которая хранит пары "ключ-значение".P.S посмотрел в инете
                
                correct_amount = amount;
                foreach (int denomination in denominations)
                {
                    if (correct_amount >= denomination)
                    {
                        int count = correct_amount / denomination;
                        result[denomination] = count;
                        correct_amount %= denomination;
                    }
                }
                Console.WriteLine($"для снятия {amount} ден.единиц потребуется:");
                bool hasBanknotes = false;
                foreach (int denomination in denominations)
                {
                    if (result.ContainsKey(denomination) && result[denomination] > 0)
                    {
                        Console.WriteLine($"{result[denomination]} по {denomination} рублей");
                        hasBanknotes = true;
                    }
                }
            }
            else
            {
                Console.WriteLine("Введите корректное значение по указанным ниже критериям:\n 1)сумма для снятия должна быть не более 150 000 ден.единиц\n 2)сумма должна быть кратна 100");
            }
            
        }

        static void Main()
        {
            Console.WriteLine("МОЙ БАНКОМАТ");
            Console.WriteLine("Доступные номиналы: 100, 200, 500, 1000, 2000, 5000");
            Console.WriteLine("Пожалуйста введите сумму, которую хотите снять:\nВнимание,она должна быть кратна 100 и не больше 150 000!");
            int number = SelectAmount();
            AtmWork(number);
        }
    }
}