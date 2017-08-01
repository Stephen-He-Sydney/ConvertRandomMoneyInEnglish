using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deepend_Test.Business.Utility
{
    public static class DataFormatConverter
    {
        /// <summary>
        /// Convert any number into money in words
        /// </summary>
        /// <param name="moneyInput"></param>
        /// <returns></returns>
        public static string ConvertMoneyToEnglishWords(double moneyInput)
        {
            string input = moneyInput.ToString();

            string deciPlaces = "";

            if (input.Contains("."))
            {
                deciPlaces = input.Substring(input.IndexOf(".") + 1);

                // Remove digits after decimal point
                input = input.Remove(input.IndexOf("."));
            }
            //Get words without digits after decimal point
            string result = ConvertToWords(input).ToUpper();


            if (deciPlaces.Length > 0)
            {
                //Ensure only keep 2 digits after decimal point
                if (deciPlaces.Length > 2) deciPlaces = deciPlaces.Substring(0, 2);

                result += " DOLLARS AND " + ConvertToWords(deciPlaces).ToUpper() + " CENTS";
            }
            else result += " DOLLARS";

            return result;
        }

        private static string ConvertToWords(string input)
        {
            int i = 0;
            string words = string.Empty;

            while (input.Length > 0)
            {
                //Get 3 digits as unit
                string threeDigits = input.Length < 3 ? input : input.Substring(input.Length - 3);
               
                //Remove the current 3 digits from whole input
                input = input.Length < 3 ? "" : input.Remove(input.Length - 3);

                int numberOfUnit = int.Parse(threeDigits);

                // Convert 3 digit number into words.
                threeDigits = GetWord(numberOfUnit);

                //Add unit in words
                threeDigits += Units[i];

                words = threeDigits + words;

                // Convert next 3 digits
                i++;
            }
            return words;
        }

        private static string GetWord(int digits)
        {
            string word = string.Empty;

            if (digits > 99 && digits < 1000)
            {
                int i = digits / 100;
                word = word + Ones[i - 1] + " hundred ";
                
                // Get the rest of digits after 100
                digits = digits % 100;
            }

            if (digits > 19 && digits < 100)
            {
                int i = digits / 10;
                word = word + Tens[i - 1] + " ";
                
                // Get the rest of digits after 10
                digits = digits % 10;
            }

            if (digits > 0 && digits < 20)
            {
                word = word + Ones[digits - 1];
            }

            return word;
        }

        private static string[] Ones
        {
            get
            {
                return new string[]{
                    "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven",
                    "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "ninteen"
                    };
            }
        }
        private static string[] Tens
        {
            get
            {
                return new string[] { "ten", "twenty", "thirty", "fourty", "fift", "sixty", "seventy", "eighty", "ninty" };
            }
        }
        private static string[] Units
        {
            get
            {
                return new string[] { "", " thousand ", " million ", " billion " };
            }
        }
    }
}
