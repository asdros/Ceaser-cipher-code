using System;
using System.Collections.Generic;

namespace Caesar_cipher
{
    public class Core
    {
        List<string> BeforeConversion = new List<string>();
        List<string> AfterConversion = new List<string>();

        public void Reader(string RowToConversion)
        {
            BeforeConversion.Add(RowToConversion);
        }
        public void MainConverter(sbyte shift = 13) //-128 to 129
        {

            foreach (string element in BeforeConversion)
            {
                char[] TempWord = new char[element.Length];
                for (int j = 0; j < element.Length; j++)
                {
                    char ASCIICodeOfChar = element[j];
                    //if ((int)ASCIICodeOfChar == 32 || ) //char of space
                    //    TempWord[j] = (char)32;
                    //else
                    //    TempWord[j] = (char)((int)(ASCIICodeOfChar + shift - 65) % 26 + 97);
                    //// Console.WriteLine((int)ASCIICodeOfChar);
                    ///
                    if ((int)ASCIICodeOfChar < 65 || (int)ASCIICodeOfChar > 122) //ascii code is smaller than 'A' code and bigger than 'z' code
                        TempWord[j] = ASCIICodeOfChar;
                    else
                        TempWord[j] = (char)((int)(ASCIICodeOfChar + shift - 65) % 26 + 97);
                }
                string temp = new string(TempWord);

                Saver(temp);
            }
        }
        public void Saver(string ConvertedWord)
        {
            AfterConversion.Add(ConvertedWord);
        }
        public void PrintResults()
        {
            for (int i = 0; i < AfterConversion.Count; i++)
            {
                Console.WriteLine($"{BeforeConversion[i]}\t{AfterConversion[i]}");
            }
        }

        public static void Main()
        {
            Core core = new Core();
            bool status = false;    //menu in loop
            string temp;

            Console.WriteLine("\t\t\tCaesar cipher\n");
            while (status == false)
            {

                Console.WriteLine("Input words to encoding.\nPlease write '0' if you want to finish entering words.");
                temp = Console.ReadLine();
                if (temp == "0")
                {
                    status = true;
                    core.MainConverter();
                }
                else
                {
                    core.Reader(temp.ToUpper());
                }
                Console.Clear();
            }
            Console.ReadKey();
        }
    }
}