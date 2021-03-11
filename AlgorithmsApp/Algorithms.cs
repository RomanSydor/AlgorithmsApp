using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace AlgorithmsApp
{
    public class Algorithms
    {
        public static void SumOfPreveousElements(int[] array)
        {
            for (int i = 0; i < array.Length - 1; i++)
                array[i + 1] += array[i];

            foreach (var item in array)
                Console.WriteLine(item);
        }

        public static void ReverseStringWithRcurs(string str)
        {
            if (str.Length > 0)
                ReverseStringWithRcurs(str.Substring(1, str.Length - 1));
            else
                return;
            Console.Write(str[0]);
        }

        public static int DigitalRoot(long n)
        {
            bool isRepeat = true;
            int result = 0;
            var collection = n.ToString().ToCharArray();
            while (isRepeat)
            {
                for (int i = 0; i < collection.Length; i++)
                {
                    var number = Convert.ToInt32(collection[i]) - 48;
                    result += number;
                }

                if (result < 10)
                    isRepeat = false;
                else
                {
                    collection = result.ToString().ToCharArray();
                    result = 0;
                }
            }
            return result;
        }

        //22.02.21

        public static IEnumerable<int> GetIntegersFromList(List<object> listOfItems)
        {
            return listOfItems.Where(x => x.GetType() == typeof(int)).Cast<int>();
        }

        public static IEnumerable<string> GetIntegersFromList(int[][] data)
        {
            return data.Select(x => x[0] >= 55 && x[1] > 7 ? "Senior" : "Open");
        }

        public static double[] Tribonacci(double[] signature, int n)
        {
            var result = new double[n];
            if (n == 0)
                return new double[0];

            Array.Copy(signature, result, Math.Min(3, n));

            for (int i = 3; i < result.Length; i++)
            {
                result[i] = result.Skip(i - 3).Take(3).Sum();
            }
            return result;
        }

        public static string Spoonerize(string str)
        {
            var words = str.Split();
            return words[1][0] + words[0][1..] + ' ' + words[0][0] + words[1][1..];
        }

        public static int BinaryArrayToNumber(int[] binaryArray)
        {
            return Convert.ToInt32(string.Join("", binaryArray), 2);
        }

        public static bool ValidBraces(string braces)
        {
            if (string.IsNullOrEmpty(braces))
                return true;

            Stack<char> brackets = new Stack<char>();

            foreach (var c in braces)
            {
                if (c == '[' || c == '{' || c == '(')
                    brackets.Push(c);
                else if (c == ']' || c == '}' || c == ')')
                {
                    // Too many closing brackets, e.g. (123))
                    if (brackets.Count <= 0)
                        return false;

                    char open = brackets.Pop();

                    // Inconsistent brackets, e.g. (123]
                    if (c == '}' && open != '{' ||
                        c == ')' && open != '(' ||
                        c == ']' && open != '[')
                        return false;
                }
            }

            // Too many opening brackets, e.g. ((123) 
            if (brackets.Count > 0)
                return false;

            return true;
        }

        //24.02.21
        public static string boolToWord(bool word)
        {
            return word ? "Yes" : "No";
        }

        public static IEnumerable<T> UniqueInOrder<T>(IEnumerable<T> iterable)
        {
            var list = iterable.ToList();

            for (int i = 0; i < list.Count; i++)
            {
                if (i == list.Count - 1)
                    break;
                if (list[i].Equals(list[i + 1]))
                {
                    list.RemoveAt(i + 1);
                    i--;
                }
            }
            return list;
        }

        public static string OddOrEven(int[] array)
        {
            return array.Sum(x => x) % 2 == 0 ? "even" : "odd";
        }

        public static int Test(string numbers)
        {
            var array = numbers.Split();
            var list = new List<int>();
            var oddsList = new List<int>();
            var evensList = new List<int>();

            foreach (var item in array)
            {
                int number = Convert.ToInt32(item);
                list.Add(number);
                if (number % 2 == 0)
                    evensList.Add(number);
                else
                    oddsList.Add(number);
            }

            if (evensList.Count == 1)
                return list.FindIndex(x => x == evensList[0]) + 1;
            else
                return list.FindIndex(x => x == oddsList[0]) + 1;
        }

        //25.02.21
        public static string Switcheroo(string input)
        {
            return input.Replace("a", "d").Replace("b", "a").Replace("d", "b");
        }

        public static int[] MoveZeroes(int[] arr)
        {
            return arr.Where(x => x != 0).Concat(arr.Where(x => x == 0)).ToArray();
        }

        public static string CreatePhoneNumber(int[] numbers)
        {
            var str = String.Empty;
            foreach (var item in numbers)
                str += item.ToString();

            return $"({str[0..3]}) {str[3..6]}-{str[6..]}";
        }

        public static bool ValidParentheses(string input)
        {
            if (string.IsNullOrEmpty(input))
                return true;

            Stack<char> brackets = new Stack<char>();

            foreach (var c in input)
            {
                if (c == '(')
                    brackets.Push(c);
                else if (c == ')')
                {
                    // Too many closing brackets, e.g. (123))
                    if (brackets.Count <= 0)
                        return false;

                    char open = brackets.Pop();

                    // Inconsistent brackets, e.g. (123]
                    if (c == ')' && open != '(')
                        return false;
                }
            }

            // Too many opening brackets, e.g. ((123) 
            if (brackets.Count > 0)
                return false;

            return true;
        }

        public static int DescendingOrder(int num)
        {
            var stringNum = num.ToString();
            var list = stringNum.Select(x => Convert.ToInt32(x.ToString())).ToList();
            var reversedList = list.OrderByDescending(x => x);

            int result = 0;
            foreach (int entry in reversedList)
                result = 10 * result + entry;

            return result;
        }

        //26.02.21

        public static string MakeUpperCase(string str)
        {
            return str.ToUpper();
        }

        //01.03.21
        public static bool Hero(int bullets, int dragons)
        {
            return bullets / 2 >= dragons;
        }

        public static int[] MultiplyAll(int[] array, int number)
        {
            for (var i = 0; i < array.Length; i++)
                array[i] *= number;

            return array;
        }

        //Special Task 
        public static int TrailingZeros(int n)
        {
            var array = FactTree(n).ToString().ToCharArray().Reverse().ToArray();
            var zeroAmount = 0;
            foreach (var item in array)
            {
                if (item != '0')
                    break;

                zeroAmount++;
            }
            return zeroAmount;
        }

        static BigInteger FactTree(int n)
        {
            if (n < 0)
                return 0;
            if (n == 0)
                return 1;
            if (n == 1 || n == 2)
                return n;
            return ProdTree(2, n);
        }

        static BigInteger ProdTree(int l, int r)
        {
            if (l > r)
                return 1;
            if (l == r)
                return l;
            if (r - l == 1)
                return (BigInteger)l * r;
            int m = (l + r) / 2;
            return ProdTree(l, m) * ProdTree(m + 1, r);
        }

        //04.03.21
        public static int[] PartsSums(int[] ls)
        {
            var result = new int[ls.Length + 1];
            result[0] = ls.Sum();
            result[ls.Length] = 0;
            for (int i = 1; i < result.Length; i++)
            {
                result[i] = result[i - 1] - ls[i - 1];
            }
            return result;
        }

        public static string ExpandedForm(long num)
        {
            var result = String.Empty;
            var list = new List<string>();
            while (num != 0)
            {
                var digit = num % 10;
                list.Add(digit.ToString());
                num /= 10;
            }

            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] == "0")
                    continue;

                for (int j = 0; j < i; j++)
                    list[i] += "0";
            }

            var count = list.Count - 1;
            while (count >= 0)
            {
                if (list[count] == "0")
                {
                    count--;
                    continue;
                }

                result += $"{list[count]} + ";
                count--;
            }

            return result.Remove(result.Length - 3);
        }

        //10.03.21
        public static string IntToRoman(int n)
        {
            return
            new string('I', n)
                .Replace(new string('I', 1000), "M")
                .Replace(new string('I', 900), "CM")
                .Replace(new string('I', 500), "D")
                .Replace(new string('I', 400), "CD")
                .Replace(new string('I', 100), "C")
                .Replace(new string('I', 90), "XC")
                .Replace(new string('I', 50), "L")
                .Replace(new string('I', 40), "XL")
                .Replace(new string('I', 10), "X")
                .Replace(new string('I', 9), "IX")
                .Replace(new string('I', 5), "V")
                .Replace(new string('I', 4), "IV");
        }

        public static int[,] MultiplicationTable(int size)
        {
            var result = new int[size, size];

            for (var i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    result[i, j] = (i + 1) * (j + 1);
                }
            }
            return result;
        }

        //11.03.21
        public static string ToCamelCase(string str)
        {
            var result = String.Empty;
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i].Equals('_') || str[i].Equals('-'))
                {
                    result += str.Substring(i + 1, 1).ToUpper();
                    i++;
                    continue;
                }
                result += str.Substring(i, 1);
            }
            return result;
        }
    }
}
