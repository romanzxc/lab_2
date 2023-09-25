using System;

namespace Laba_2_V_6
{
    class Program
    {
        /// <summary>
        /// Variant 6
        ///38, 45, 64, 101, 162, 
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Console.WriteLine("Задание 38:");
            Task_38();
            Console.WriteLine();

            Console.WriteLine("Задание 45:");
            Task_45();
            Console.WriteLine();

            Console.WriteLine("Задание 64:");
            Task_64();
            Console.WriteLine();

            Console.WriteLine("Задание 101:");
            Task_101();
            Console.WriteLine();

            Console.WriteLine("Задание 162:");
            Task_162();
            Console.WriteLine();
        }
        /// <summary>
        /// В заданном одномерном массиве поменять местами соседние элементы, стоящие на четных местах, с элементами, стоящими на нечетных местах.
        /// </summary>
        private static void Task_38()
        {
            int size = 11;
            int[] array = new int[size];
            Random random = new Random();
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(100) + 1;
            }
            Console.WriteLine("Массив:");
            Console.WriteLine(String.Join(" ; ", array));
            for (int i = 0; i < array.Length; i+=2)
            {
                if (i + 1 < array.Length)
                {
                    int evenNumber = array[i];
                    array[i] = array[i + 1];
                    array[i + 1] = evenNumber;
                }
            }
            Console.WriteLine("Массив после:");
            Console.WriteLine(String.Join(" ; ", array));
        }
        /// <summary>
        /// Задана последовательность из N вещественных чисел. Определить, сколько среди них чисел, меньших К, равных К и больших К.
        /// </summary>
        private static void Task_45()
        {
            Random random = new Random();
            int n = random.Next(10)+1 ;

            double[] array = new double[n];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.NextDouble()*100;
            }
            Console.WriteLine("N=" + n);
            Console.WriteLine("Массив:");
            Console.WriteLine(String.Join(" ; ", array));

            double k = random.NextDouble() * 100;
            Console.WriteLine("K=" + k);

            int countNumbersMoreConstValue = 0, countNumbersEqualsConstValue = 0, countNumbersLessConstValue=0;
            foreach (float number in array)
            {
                if (number > k)
                {
                    countNumbersMoreConstValue++;
                    continue;
                }
                else if (number < k)
                {
                    countNumbersLessConstValue++;
                }
                else
                {
                    countNumbersEqualsConstValue++;
                }
            }
            Console.WriteLine("Количество чисел больше чем K:" + countNumbersMoreConstValue);
            Console.WriteLine("Количество чисел меньше чем K:" + countNumbersLessConstValue);
            Console.WriteLine("Количество чисел равные  K:" + countNumbersEqualsConstValue);
        }
        /// <summary>
        /// Найти сумму элементов массива вещественных чисел, имеющих нечетные номера.
        /// </summary>
        private static void Task_64()
        {
            Random random = new Random();
            int n = random.Next(20) + 1;
            double[] array = new double[n];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.NextDouble() * 100;
            }
            Console.WriteLine("N=" + n);
            Console.WriteLine("Массив:");
            Console.WriteLine(String.Join(" ; ", array));
            double sum = 0;
            for (int i = 0; i < array.Length; i += 2)
            {
                sum += array[i];
            }
            Console.WriteLine("Сумма элементов, имеющих нечетные номера= "+sum);
        }
        /// <summary>
        /// Удалить элемент одномерного массива вещественных чисел, который меньше среднего арифметического элементов массива. 
        /// Если таких элементов несколько, удалить последний из найденных.
        /// !!!!
        /// Здесь и в других задачах под удалением понимать исключение этого элемента из массива путем смещения всех следующих 
        /// за ним элементов влево на 1 позицию и присваивание последнему элементу массива значения 0, если нет других оговорок.
        /// </summary>
        private static void Task_101()
        {
            int size = 10;
            Random random = new Random();
            double[] array = new double[size];
            double sumElements = 0;
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.NextDouble() * 100;
                sumElements += array[i];
            }
            double average = sumElements / array.Length;
            Console.WriteLine("Массив:");
            Console.WriteLine(String.Join(" ; ", array));
            double[] arrayElemenentLessAverage = new double[size];
            int index = 0;
            foreach (double number in array)
            {
                if (number < average)
                {
                    arrayElemenentLessAverage[index] = number;
                    index++;
                }
            }
            if(index != 0)
            {
                Console.WriteLine("Среднеее значение="+ average);
                Array.Resize(ref arrayElemenentLessAverage, index);
                int indexLastElement = Array.IndexOf(array, arrayElemenentLessAverage[arrayElemenentLessAverage.Length-1]);
                for (int i = indexLastElement; i < array.Length-1; i++)
                {
                        array[i] = array[i + 1];
                }
                array[array.Length - 1] = 0;
                Console.WriteLine("Массив после:");
                Console.WriteLine(String.Join(" ; ", array));
            }
            else
            {
                Console.WriteLine("В массиве нет элементов меньше среднего("+average+")");
            }
        }
        /// <summary>
        /// При диспансеризации школьников определялись их рост и вес. В результате были получены массивы значений роста R(n) и веса W(n). 
        /// Написать алгоритм и программу определения школьников с максимальным и минимальным ростом и их номеров в таблице, 
        /// а также номер школьника с наибольшим дефицитом веса (наименьшим отношением веса к росту). Кроме того, следует упорядочить 
        /// по возрастанию массив весов. Вывести результаты работы программы.
        /// </summary>
        private static void Task_162()
        {
            Random random = new Random();
            int n = random.Next(20) + 1;
            double[] arrayWeight = new double[n];
            for (int i = 0; i < arrayWeight.Length; i++)
            {
                arrayWeight[i] = Math.Round(random.NextDouble() * 80 +20,1);
            }
            int[] arrayHeight = new int[n];
            for (int i = 0; i < arrayHeight.Length; i++)
            {
                arrayHeight[i] = random.Next(120,180) ;
            }
            Console.WriteLine("Номер|Рост|Вес");
            for (int i = 0; i < n; i++)
            {
                Console.Write(" "+i + " |" + arrayHeight[i] + " | " + arrayWeight[i]+"\n");

            }
            int maxHeight = arrayHeight[0];
            int minHeight = arrayHeight[0];
            double lessWeightToHeightRatio = arrayWeight[0] / arrayHeight[0];
            int indexLessWeightToHeightRatio = 0;

            for (int i = 0; i < n; i++)
            {
                if(arrayWeight[i] / arrayHeight[i] < lessWeightToHeightRatio)
                {
                    lessWeightToHeightRatio = arrayWeight[i] / arrayHeight[i];
                    indexLessWeightToHeightRatio = i;
                }
                if (arrayHeight[i] > maxHeight)
                {
                    maxHeight = arrayHeight[i];
                    continue;
                }
                if (arrayHeight[i] < minHeight)
                {
                    minHeight = arrayHeight[i];
                }
            }

            int[] arrayIndexsMinHeight = new int[n];
            int indexMin = 0;

            int[] arrayIndexsMaxHeight = new int[n];
            int indexMax = 0;

            for (int i = 0; i < arrayHeight.Length; i++)
            {
                if (arrayHeight[i] == minHeight)
                {
                    arrayIndexsMinHeight[indexMin] = i;
                    indexMin++;
                    continue;
                }
                if(arrayHeight[i] == maxHeight){
                    arrayIndexsMaxHeight[indexMax] = i;
                    indexMax++;
                }
            }
            Array.Resize(ref arrayIndexsMinHeight, indexMin);
            Array.Resize(ref arrayIndexsMaxHeight, indexMax);

            Console.WriteLine("Номера школьника с максимальным ростом=" + String.Join(" ; ", arrayIndexsMaxHeight));
            Console.WriteLine("Номера школьника с минимальным ростом="+ String.Join(" ; ", arrayIndexsMinHeight));
            Console.WriteLine("Номер школьника с наибольшим дефицитом веса=" + indexLessWeightToHeightRatio);

            Array.Sort(arrayWeight);
            Console.WriteLine("Упорядочный массив весов по возрастанию:");
            Console.WriteLine(String.Join(" ; ", arrayWeight));

        }
    }
}
