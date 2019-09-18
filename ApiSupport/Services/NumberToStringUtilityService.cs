using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TAM.LogisticSystem.Services
{
    public class NumberToStringUtilityService
    {
        public string ResultString { get; set; }

        public NumberToStringUtilityService(string number)
        {
            ResultString = NumberToStringGenerator(number);
        }

        /// <summary>
        /// Number to string method
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        private string NumberToStringGenerator(string number)
        {
            var numberString = "";
            var flagThreeSeparator = false;
            if (number.Length > 1)
            {
                for (var index = 0; index < number.Length; index++)
                {
                    var tempNum = int.Parse(number.Substring(index, 1));

                    // Check if number one or not ( i.e se-### )
                    if (IsNumberOneAboveTen(tempNum, index, number.Length))
                    {
                        // last 2 digit ( i.e 10 (sepuluh) up to 19 (sembilan belas) )
                        if (index == number.Length - 2)
                        {
                            tempNum = int.Parse(number.Substring(index, 2));
                            numberString += GetNumberBelasString(tempNum);
                            break;
                        }
                        // last 2 digit ( i.e 10 (sepuluh) up to 19 (sembilan belas) ) after thousand
                        if ((number.Length - (index + 1)) % 3 == 1)
                        {
                            tempNum = int.Parse(number.Substring(index, 2));
                            index++;
                            numberString += $"{GetNumberBelasString(tempNum)} { GetNumberSeparatorStringV2(index, number.Length)}";

                        }
                        // thousand separator with one as the beginning ( i.e seratus and seribu)
                        else
                        {
                            numberString += $"SE{GetNumberSeparatorStringV2(index, number.Length)}";
                        }
                        flagThreeSeparator = false;
                    }
                    // Skip zero
                    else if (tempNum != 0)
                    {
                        numberString += $"{GetNumberString(tempNum)} {GetNumberSeparatorStringV2(index, number.Length)}";
                        flagThreeSeparator = false;

                    }
                    // thousand separator
                    else if ((number.Length - (index)) % 3 == 1 && index != number.Length - 2 && flagThreeSeparator == false && !string.IsNullOrEmpty(numberString))
                    {
                        numberString += $"{GetNumberSeparatorStringV2(index, number.Length)} ";
                        flagThreeSeparator = true;
                    }

                    // ADD ON
                    // Put Space between words
                    if (index + 1 < number.Length && tempNum != 0)
                    {
                        numberString += " ";
                    }
                    // Set flag thousand separator after first appearance
                    if ((number.Length - (index)) % 3 == 1)
                    {
                        flagThreeSeparator = true;
                    }
                }
            }
            else if (number.Length == 1)
            {
                var tempNumb = int.Parse(number.Substring(0, 1));

                numberString += GetNumberString(tempNumb);
            }
            return numberString.TrimEnd();
        }

        /// <summary>
        /// Check number one position
        /// </summary>
        /// <param name="number"></param>
        /// <param name="index"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        private bool IsNumberOneAboveTen(int number, int index, int length)
        {

            var numb = length - (index + 1);
            if (number == 1)
            {
                if (numb % 3 == 1 || numb % 3 == 2)
                {
                    return true;
                }
                else if (numb == 3 && length == 4)
                {
                    //thousand
                    return true;
                }
                else if (numb == 3 && length > 4)
                {
                    //thousand
                    return false;
                }
                else if (numb == 6)
                {
                    //million
                    return false;
                }
                else if (numb == 9)
                {
                    //billion
                    return false;
                }
                else if (numb == 12)
                {
                    //trillion
                    return false;
                }
            }

            return false;
        }

        /// <summary>
        /// Get string of normal number
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        private string GetNumberString(int number)
        {
            switch (number)
            {
                case 0:
                    return "NOL";
                case 1:
                    return "SATU";
                case 2:
                    return "DUA";
                case 3:
                    return "TIGA";
                case 4:
                    return "EMPAT";
                case 5:
                    return "LIMA";
                case 6:
                    return "ENAM";
                case 7:
                    return "TUJUH";
                case 8:
                    return "DELAPAN";
                case 9:
                    return "SEMBILAN";
                default: return "";
            }
        }

        /// <summary>
        /// Get string of number for last 2 digit starting with 10-19
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        private string GetNumberBelasString(int number)
        {
            switch (number)
            {
                case 10:
                    return "SEPULUH";
                case 11:
                    return "SEBELAS";
                case 12:
                    return "DUA BELAS";
                case 13:
                    return "TIGA BELAS";
                case 14:
                    return "EMPAT BELAS";
                case 15:
                    return "LIMA BELAS";
                case 16:
                    return "ENAM BELAS";
                case 17:
                    return "TUJUH BELAS";
                case 18:
                    return "DELAPAN BELAS";
                case 19:
                    return "SEMBILAN BELAS";
                default: return "";
            }
        }

        /// <summary>
        /// Get number separator up to trillion
        /// </summary>
        /// <param name="index"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        private string GetNumberSeparatorStringV2(int index, int length)
        {
            var numberOfZero = length - (index + 1);

            if (numberOfZero % 3 == 2)
            {
                return "RATUS";
            }
            else if (numberOfZero % 3 == 1)
            {
                return "PULUH";
            }
            else
            {
                switch (numberOfZero)
                {
                    case 3: return "RIBU";
                    case 6: return "JUTA";
                    case 9: return "MILIAR";
                    case 12: return "TRILIUN";
                        //case 15: return "KUADRILIUN";
                        //case 18: return "KUANTILIUN";
                        //case 21: return "SEKSTILIUN";
                        //case 24: return "SEPTILIUN";
                        //case 27: return "OKTILIUN";
                        //case 30: return "NONILIUN";
                        //case 33: return "DESLIUN";
                }
            }
            return "";
        }
    }
}
