using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WCF
{
    public static class Convertor
    {
        const string dollars = " dollars";
        const string cents = " cents";
        const string and = " and ";

        public static string Convert(string value)
        {
            string words;
            string temp;

             // analiza i pobranie liczb calkowitych i dziesietnych
            var parsed = Parse(value);

            
            if (parsed != null)
            {
                words = NumberToWords(parsed[0]);

                // warunek - jesli zawiera one nie dopisuj "S"                                                                 
                if (words == "one")
                    words += dollars.Replace("s", "");
                else
                    words += dollars;
            }
            else             //zły format
                return null;

                                                                                          
            if (parsed.Count > 1)
            {
                temp = NumberToWords(parsed[1]);

                // warunek ten sam co powyzej tylko ze dla centow                                                       
                if (temp == "one")
                    words += and + temp + cents.Replace("s", "");
                else
                    words += and + temp + cents;
            }

             // usuwanei podwojnej spacji
            words = words.Replace("  ", " ");
            return words;
        }


        private static List<int> Parse(string value)
        {
            value = value.Replace(" ", "");
            var split = value.Split(',');

            var numbers = new List<int>();
            int number;
            bool valid;

             // analiza części calkowitej
            valid = int.TryParse(split[0], out number);
            if (valid)
                numbers.Add(number);
            else
                return null;

            // analiza części dziesiętnej
            valid = false;
            string decPart = "";

            if (split.Length > 1)
            {
                decPart = split[1];
                if (decPart.Length == 1) decPart += "0";

                valid = int.TryParse(decPart, out number);
                if (valid)
                    numbers.Add(number);
            }

            return numbers;
        }

        // glowna metoda
        public static string NumberToWords(int number)
        {
            if (number == 0)
                return "zero";

            if (number < 0)
                return "minus " + NumberToWords(Math.Abs(number));

            string words = "";

            if ((number / 1000000) > 0)
            {
                words += NumberToWords(number / 1000000) + " million ";
                number %= 1000000;
            }

            if ((number / 1000) > 0)
            {
                words += NumberToWords(number / 1000) + " thousand ";
                number %= 1000;
            }

            if ((number / 100) > 0)
            {
                words += NumberToWords(number / 100) + " hundred ";
                number %= 100;
            }

            if (number > 0)
            {
                                                                                                                                                                                                                                               

                var unitsMap = new[] { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
                var tensMap = new[] { "zero", "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };

                if (number < 20)
                    words += unitsMap[number];
                else
                {
                    words += tensMap[number / 10];
                    if ((number % 10) > 0)
                        words += "-" + unitsMap[number % 10];
                }
            }

            return words;
        }



    }
}