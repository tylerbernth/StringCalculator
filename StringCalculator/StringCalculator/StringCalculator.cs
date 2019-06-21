using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace StringCalculator
{

    public class StringCalculator
    {
        private String numbers;
        private String delimiter;

        public StringCalculator()
        {
            this.delimiter = "";
            this.numbers = "";
        }

        public StringCalculator(String nums, String delim)
        {
            this.delimiter = delim;
            this.numbers = nums;
        }

        public int Add(String numbers)
        {

            //Base case, empty string
            if (numbers.Equals(""))
            {
                return 0;
            }

            List<string> delimiters = new List<string>();
            string[] delimitersArray = new string[] { };
            List<int> negativeNumbers = new List<int>();

            //Check to see if the user passed in a different delimiter
            Regex rx = new Regex("//(.*)\n");

            MatchCollection matches = rx.Matches(numbers);

            string matchString = "";

            //Check to see if any matches were found
            foreach (Match m in matches)
            {
                matchString = m.ToString();
                matchString = matchString.Replace("\n", "");
                matchString = matchString.Replace("/", "");
                delimiters.Add(matchString);
            }

            if (!matchString.Equals(""))
            {

                Regex rx2 = new Regex(@"\[(.*?)\]");
                matches = rx2.Matches(matchString);

                //Just a single character was added (no '[')
                if (matches.Count == 0)
                {
                    delimiters.Add(matchString);
                }
                else
                {
                    //Looking to see if multiple character delimiters were passed in
                    foreach (Match m in matches)
                    {
                        matchString = m.ToString();
                        matchString = matchString.Replace("[", "");
                        matchString = matchString.Replace("]", "");

                        delimiters.Add(matchString);
                    }
                }
            }

            delimiters.Add(",");
            delimiters.Add("\n");
            delimitersArray = delimiters.ToArray();

            //Split the input based on the default delimeters, as well as new ones passed in
            string[] values = numbers.Split(delimitersArray, StringSplitOptions.None);

            int total = 0;
            int currentNumber = 0;

            foreach (String number in values)
            {
                currentNumber = 0;
                int.TryParse(number, out currentNumber);

                if (currentNumber < 0)
                {
                    negativeNumbers.Add(currentNumber);
                }
                else if (currentNumber <= 1000)
                {
                    total += currentNumber;
                }
            }

            if (negativeNumbers.Count > 0)
            {
                throw new ArgumentException("negatives not allowed: " + negativeNumbers.ToString());
            }

            return total;
        }
    }
}