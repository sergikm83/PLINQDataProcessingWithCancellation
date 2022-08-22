using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PLINQDataProcessingWithCancellation
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Start any key to start processing");
            Console.ReadKey();

            Console.WriteLine("Processing");
            Task.Factory.StartNew(() => ProcessIntData());
            Console.ReadLine();
        }

        static void ProcessIntData()
        {
            // Получить очень большой массив целых чисел.
            int[] source = Enumerable.Range(1, 10_000_000).ToArray();
            // Найти числа, для которых истинно условие num % 3 ==0,
            // и возвратить их в убывающем порядке.
            int[] modThreeIsZero = (from num in source
                                    where num % 3 == 0
                                    orderby num descending
                                    select num).ToArray();
            // Вывести количество найденных чисел.
            Console.WriteLine($"Found {modThreeIsZero.Count()} numbers that match query!");
        }
    }
}
