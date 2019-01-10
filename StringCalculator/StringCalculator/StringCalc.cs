using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculator
{
    public class StringCalc
    {
        private readonly List<string> delimiters = new List<string> { ",", "\n" };
        private const string customDelimiter = "//";
        private const int StartIndexOfNumbersWithCustomDelimiter = 3;
        private const int StartIndexOfNumbersWithCustomDelimiterWithBracket = 5;
        private const int StartIndexOfCustomDelimiter = 2;

        public int Add(string numbers)
        {
            if (String.IsNullOrWhiteSpace(numbers)) return 0;

            if (numbers.StartsWith(customDelimiter))
            {
                numbers = GetNumbersExcludingCustomDelimiter(numbers);
            }

            numbers = ReplaceBackslashN(numbers);

            return GetSumOfNumbers(numbers);
        }

        private int GetSumOfNumbers(string numbers)
        {
            if (numbers.IndexOf("\n") == 0)
            {
                numbers = numbers.Substring(1);
            }

            var lstNumbers = numbers.Split(delimiters.ToArray(), StringSplitOptions.None).Select(int.Parse).ToList();

            ValidateNumbersArePositive(lstNumbers);

            return lstNumbers.Sum();
        }

        private static void ValidateNumbersArePositive(IReadOnlyCollection<int> lstNumbers)
        {
            if (!lstNumbers.Any(x => x < 0)) return;

            var negativeNumbers = string.Join(",", lstNumbers.Where(x => x < 0).Select(x => x.ToString()).ToArray());
            throw new FormatException("negatives(" + negativeNumbers + ") not allowed ");
        }

        private string GetNumbersExcludingCustomDelimiter(string numbers)
        {
            var startIndexOfString = AssignCustomDelimiterAndReturnStartIndexOfNumbers(numbers);

            return numbers.Substring(startIndexOfString);
        }

        private int AssignCustomDelimiterAndReturnStartIndexOfNumbers(string numbers)
        {
            var customDelimiters = GetCustomDelimiter(numbers);
            delimiters.AddRange(customDelimiters);

            if (numbers.IndexOf("[") == 2)
            {
                return StartIndexOfNumbersWithCustomDelimiterWithBracket;
            }
            else
            {
                return StartIndexOfNumbersWithCustomDelimiter;
            }
        }

        private static IList<string> GetCustomDelimiter(string numbers)
        {
            numbers = ReplaceBackslashN(numbers);

            var allDelimiters = numbers.Substring(StartIndexOfCustomDelimiter, numbers.IndexOf("\n") - StartIndexOfCustomDelimiter);

            var splitDelimiters = allDelimiters.Split('[').Select(x => x.TrimEnd(']')).ToList();

            if (splitDelimiters.Contains(string.Empty))
            {
                splitDelimiters.Remove(string.Empty);
            }

            return splitDelimiters;
        }




        private static string ReplaceBackslashN(string numbers)
        {
            if (numbers.Contains("\\n"))
            {
                numbers = numbers.Replace("\\n", "\n");
            }

            return numbers;
        }
    }
}

