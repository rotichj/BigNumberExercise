using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Exercise01.NumberService
{
    public class NumberDescriber
    {
        string numberInWords = string.Empty;
        public string Towards(BigInteger bigNumber)
        {
            //bool addNegative = false;  This thing wasnt a joke, I have never thought it as something worth trying , but finally I did int, COnverting nmbers to words

            //Int64 startingPoint = 1000000000000000;
            
            
            string word = string.Empty;

            if (bigNumber < 0)
            {
                word = " Negative";
                bigNumber = -1*bigNumber;
            }

            var groupLengthName = new[] { " hundred,", " thousand,", " million,", " billion,", " trillion,", " quandrillion,", " quintillion," };

            var numberGrouping = GroupedNumber(bigNumber.ToString());

            var groupLength = numberGrouping.Length;

            for (int i = numberGrouping.Length - 1; i >= 0; i--)
            {
                if (i != 0)
                {
                    if (numberGrouping[i].ToString() != "000")
                    {
                        var groupChars = numberGrouping[i].ToString().ToCharArray();

                        if (groupChars.Length == 3)
                        {
                            if (groupChars[2].ToString() != "0")
                            {
                                word = word + " " + LessThanHundredWording(groupChars[2].ToString()) + " hundred  and " + LessThanHundredWording(groupChars[1].ToString() + groupChars[0].ToString()) + groupLengthName[i];

                            }
                            else
                            {
                                word = word + " " + LessThanHundredWording(groupChars[1].ToString() + groupChars[0].ToString()) + groupLengthName[i];

                            }
                        }
                        if (groupChars.Length == 2)
                        {
                            word = word + " " + LessThanHundredWording(groupChars[1].ToString() + groupChars[0].ToString()) + groupLengthName[i];
                        }
                        if (groupChars.Length == 1 && groupChars[0].ToString() != "0")
                        {
                            word = word + " " + LessThanHundredWording(groupChars[0].ToString()) + groupLengthName[i];
                        }
                    }
                }
                else
                {

                    var groupChars = numberGrouping[i].ToString().ToCharArray();
                    if (groupChars.Length == 3)
                    {
                        if (groupChars[2].ToString() != "0")
                        {
                            word = word + " " + LessThanHundredWording(groupChars[2].ToString()) + " hundred and " + LessThanHundredWording(groupChars[1].ToString() + groupChars[0].ToString());
                        }
                        else
                        {
                            word = word + " " + LessThanHundredWording(groupChars[1].ToString() + groupChars[0].ToString());
                        }
                    }
                    if (groupChars.Length == 2)
                    {
                        word = word + " " + LessThanHundredWording(groupChars[1].ToString() + groupChars[0].ToString());
                    }
                    if (groupChars.Length == 1)
                    {
                        word = word + " " + LessThanHundredWording(groupChars[0].ToString());
                    }
                }

            }
            word= word.TrimStart(); // make it neat, just neat purposes
            word = char.ToUpper(word[0]) + word.Substring(1);
            return word;
               
        }


        string LessThanHundredWording(string numberIntString)
        {
            int number = int.Parse(numberIntString);
            string numInWords = string.Empty;
            
            var zeroToTwenty = new[] { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
            var zeroToTen = new[] { "zero", "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };

            if (number < 20)
                numInWords += zeroToTwenty[number];
            else
            {
                numInWords += zeroToTen[number / 10];
                if ((number % 10) > 0)
                    numInWords += "-" + zeroToTwenty[number % 10];
            }
            return numInWords;
        }




        public string[] GroupedNumber(string Number)
        {
            var charsInNumbers = Number.ToCharArray();

            List<string> groups = new List<string>();

            int breaker = 1;

            string tempString = string.Empty;
            for (int i = charsInNumbers.Length - 1; i > -1; i--)
            {

                if (breaker == 3)
                {
                    tempString += charsInNumbers[i];
                    groups.Add(tempString);
                    breaker = 1;
                    tempString = string.Empty;
                }
                else
                {
                    tempString += charsInNumbers[i];
                    breaker++;
                }
            }
            if(!string.IsNullOrEmpty(tempString))
            {
                groups.Add(tempString);
                tempString = "";
            }
            return groups.ToArray();
        }
        


        private string NumberGroup(Int64 number) // like million, thousand, billion,hundred
        {
            switch (number)
            {
                case 1000000000000000000:
                    return "Quintillion";
                case 100000000000000000:
                    return "Quadrillion";
                case 10000000000000000:
                    return "Quadrillion";
                case 1000000000000000:
                    return "Quadrillion";
                case 100000000000000:
                    return "trillion";
                case 10000000000000:
                    return "trillion";
                case 1000000000000:
                    return "trillion";
                case 100000000000:
                    return "billion";
                case 10000000000:
                    return "billion";
                case 1000000000:
                    return "billion";
                case 100000000:
                    return "million";
                case 10000000:
                    return "million";
                case 1000000:
                    return "million";
                case 100000:
                    return "thousand";
                case 10000:
                    return "thousand";
                case 1000:
                    return "thousand";
                case 100:
                    return "hundred";
                default:
                    return ""; // should not happen
            }
        }
    }
}
