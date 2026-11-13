using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetInput
{
    public class GetInput
    {
        public static string GetStringInput(string question)
        {
            Console.WriteLine(question);
            string userInput = Console.ReadLine();
            return userInput;
        }

        public static int GetIntInput(string question, string notNumberErr)
        {
            string stringInput = "";
            int intUserInput;
            while (true)
            {
                stringInput = GetStringInput(question);
                try
                {
                    intUserInput = int.Parse(stringInput);
                } catch
                {
                    Console.WriteLine(notNumberErr);
                    continue;
                }
                break;
            }
            return intUserInput;
        }

        public static double GetDoubleInput(string question, string notNumberErr)
        {
            string stringInput = "";
            double doubleInput;
            while (true)
            {
                stringInput = GetStringInput(question);
                try
                {
                    doubleInput = double.Parse(stringInput);
                } catch
                {
                    Console.WriteLine(notNumberErr);
                    continue;
                }
                break;
            }
            return doubleInput;
        }

        public static float GetFloatInput(string question, string notNumberErr)
        {
            string stringInput = "";
            float floatInput;
            while (true)
            {
                stringInput = GetStringInput(question);
                try
                {
                    floatInput = float.Parse(stringInput);
                } catch
                {
                    Console.WriteLine(notNumberErr);
                    continue;
                }
                break;
            }
            return floatInput;
        }

        public static bool GetBoolInput(string question, string yes, string no, string notBoolErr)
        {
            string stringInput = "";
            bool boolInput;
            while (true)
            {
                stringInput = GetStringInput(question);
                if (stringInput == yes)
                {
                    boolInput = true;
                } else if (stringInput == no)
                {
                    boolInput = false;
                } else
                {
                    Console.WriteLine(notBoolErr);
                    continue;
                }
                break;
            }
            return boolInput;
        }


    }
}
