using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace weather_1
{
    class Program
    {
        #region Вывод, можно удалить

        public const string OutputFormat = "{0} {1,4}";

        public static string ArrayToString(int[] array)
        {
            string output = String.Empty;
            if (array.Length == 0)
                output = " Пустой массив";
            else
                foreach (int item in array)
                    output = String.Format(OutputFormat, output, item);
            output = output + "\n";

            return output;
        }

        public static string ArrayToString(int[][] array)
        {
            string output = String.Empty;

            if (array.Length == 0)
                output = " Пустой массив\n";
            else
                foreach (var item in array)
                {
                    output = output + ArrayToString(item);
                }
            return output;
        }

        #endregion

        #region Filling

        private static int[][][] Years = new int[2016][][];

        private static void NullAll(ref int[][][] yearsData)
        {
            for (int i = 0; i < yearsData.Length; i++)
                yearsData[i] = null;
        }

        private static void FillEmptyYear(ref int[][][] yearsData, int year)
        {
            if (yearsData[year] == null)
                yearsData[year] = RandomiseYear();
        }

        private static int[][] RandomiseYear()
        {
            int[][] array = new int[12][];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = RandomiseMonth(i + 1);
            }
            return array;
        }

        private static readonly Random Rand = new Random();

        private static int[] RandomiseMonth(int month)
        {
            int[] array = null;

            #region declaration

            switch (month)
            {
                case 1:
                case 3:
                case 5:
                case 7:
                case 8:
                case 10:
                case 12:
                    array = new int[31];
                    break;
                case 4:
                case 6:
                case 9:
                case 11:
                    array = new int[30];
                    break;
                case 2:
                    array = new int[28];
                    break;
            }

            #endregion

            #region Temperatures

            int RMin = -50, RMax = 50;

            switch (month)
            {
                case 12:
                case 1:
                case 2:
                    RMin = -50;
                    RMax = 0;
                    break;
                case 3:
                case 4:
                case 5:
                    RMin = -5;
                    RMax = 25;
                    break;
                case 6:
                case 7:
                case 8:
                    RMin = 15;
                    RMax = 50;
                    break;
                case 9:
                case 10:
                case 11:
                    RMin = -20;
                    RMax = 15;
                    break;
            }

            #endregion


            for (int i = 0; i < array.Length; i++)
                array[i] = Rand.Next(RMin, RMax + 1);

            return array;
        }

        #endregion

        static void Main(string[] args)
        {
            NullAll(ref Years);

            int year;
            int.TryParse(Console.ReadLine(), out year);

            int[] month = new int[28];
            {
                int begin = -1, end = -1;
                bool cold = false;
                int oldbegin = -1, oldend = -1;
                bool old = false;

                for (int i = 0; i < month.Length; i++)
                {
                    if (month[i] > 0)
                        cold = false;
                    else if (cold && month[i] < 0)
                        end = i;
                    else if (!cold && month[i] < 0)
                    {
                        cold = true;
                        begin = i;
                        end = i;
                    }


                }

            }



            FillEmptyYear(ref Years, year);

            Console.Write(ArrayToString(Years[year]));

            Console.ReadKey(true);
        }
    }
}
