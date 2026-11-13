using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CrossDotProductAndAngleBetween { 

    public class VectorCalculator
    {
        

        public static void Main()
        {
            GetInput.GetInput input = new GetInput.GetInput();
            int whatDo = 0;
            Console.WriteLine("Please enter one of corresponding numbers:\n1: Cross Product\n2: Dot Product\n3: Angle Between\n4: Magnetude\n5: Projection");
            while (true)
            {
                try
                {

                    whatDo = int.Parse(Console.ReadLine());
                    if (whatDo > 5 || whatDo < 1)
                    {
                        Console.WriteLine("Please enter a number between 1 and 3");
                        continue;
                    }
                }
                catch
                {
                    Console.WriteLine("Kindly enter a number");
                    continue;
                }
                break;
            }
                     
            var vals = GetListInput(2, 2, 2, true);


            switch (whatDo)
            {
                case 1:
                    vals = GetListInput(3, 2, 3);
                    Console.WriteLine(vals.Item1[0] + ", " + vals.Item1[1] + ", " + vals.Item1[2] + "\n" + vals.Item2[0] + ", " + vals.Item2[1] + ", " + vals.Item2[2]);
                    CrossProduct(vals.Item1, vals.Item2);
                    break;

                case 2:
                    vals = GetListInput();
                    DotProduct(vals.Item1, vals.Item2);
                    break;
                case 3:
                    vals = GetListInput();
                    AngleBetween(vals.Item1, vals.Item2);
                    break;
                case 4:
                    vals = GetListInput(2, 1);
                    Magnetude(vals.Item1);
                    break;
                case 5:
                    vals = GetListInput(2);
                    Projection(vals.Item1, vals.Item2);
                    break;

            }
        }

public static (List<double>, List<double>) GetListInput(int minLen = 1, int numlists = 2, int maxLen = 10000000, bool init = false)

{
    
    string astring;
    string bstring;

    List<double> a = new List<double>();
    List<double> b = new List<double>();
    if (init)
    {
        return (a, b);
    }
    if (numlists == 2)
    {
        Console.WriteLine("Please enter your 2 vectors");
        while (true)
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("Please enter the values of your first vector, with each value seperated by a comma (\',\')");
                    astring = Console.ReadLine();

                    astring = astring.Replace(" ", "");


                    string[] aStringArray = new string[astring.Length];

                    aStringArray = astring.Split(",");
                    a.Clear();
                    for (int i = 0; i < aStringArray.Length; i++)
                    {
                        a.Add(double.Parse(aStringArray[i]));
                    }

                }
                catch
                {
                    Console.WriteLine("Kindly enter a number");
                    continue;
                }
                
                if (a.Count > maxLen)
                {
                    Console.WriteLine($"Kindly only enter {maxLen} values");
                    continue;
                }
                if (a.Count < minLen)
                {
                    Console.WriteLine($"Kindly enter at least {minLen} values");
                    continue;
                }
                break;
            }
            while (true)
            {
                try
                {
                    Console.WriteLine("Please enter the values of your second vector, with each value seperated by a comma (\',\')");
                    bstring = Console.ReadLine();

                    bstring = bstring.Replace(" ", "");


                    string[] bStringArray = new string[bstring.Length];

                    bStringArray = bstring.Split(",");
                    b.Clear();
                    for (int i = 0; i < bStringArray.Length; i++)
                    {
                        b.Add(double.Parse(bStringArray[i]));
                    }

                }
                catch
                {
                    Console.WriteLine("Kindly enter a number");
                    continue;
                }
                if (b.Count > maxLen)
                {
                    Console.WriteLine($"Kindly only enter {maxLen} values");
                    continue;
                }
                if (b.Count < minLen )
                {
                    Console.WriteLine($"Kindly enter at least {minLen} values");
                    continue;
                }
                break;
            }
            break;
        }
    } else if (numlists == 1)
    {
        Console.WriteLine("Please enter your vector");
        while (true)
        {
            try
            {
                Console.WriteLine("Please enter the values of your first vector, with each value seperated by a comma (\',\')");
                astring = Console.ReadLine();

                astring = astring.Replace(" ", "");


                string[] aStringArray = new string[astring.Length];

                aStringArray = astring.Split(",");
                for (int i = 0; i < aStringArray.Length; i++)
                {
                    a.Add(double.Parse(aStringArray[i]));
                }

            }
            catch
            {
                Console.WriteLine("Kindly enter a number");
                continue;
            }
            if (a.Count > maxLen)
            {
                Console.WriteLine("Kindly only enter " + maxLen + " values");
                continue;
            }
            if (a.Count < minLen)
            {
                Console.WriteLine("Kindly enter at least " + minLen + " values");
            }
            break;
        }
    }
   
    return (a, b);
}

public static double Magnetude(List<double> a)
{
    double curVal = 0;
    foreach (double x in a )
    {
        curVal += x * x;
    }
    double mag = Math.Sqrt(curVal);
    
    
    Console.WriteLine(mag);
    return mag;
    
}

public static double[] CrossProduct(List<double> a, List<double> b)
{
    double[] c = new double[3];
    c[0] = a[1] * b[2] - a[2] * b[1];
    c[1] = a[2] * b[0] - a[0] * b[2];
    c[2] = a[0] * b[1] - a[1] * b[0];



    Console.WriteLine($"The cross product between a and b is ({c[0]}, {c[1]}, {c[2]})");
            return c;
}

public static double DotProduct(List<double> a, List<double> b)
{
    double c = 0;
    double state = 0;
    for (int i = 0; i < a.Count; i++)
    {
        c += a[i] * b[i];
        state = a[i] * b[i];
        Console.WriteLine(state);
    }
        
    
    Console.WriteLine($"The dot product between a and b is {c}");
    return c;
}

        public static void AngleBetween(List<double> a, List<double> b)
{
    double ma;
    double mb;

    ma = Magnetude(a);
    

    mb = Magnetude(b);
    

    double theta = Math.Acos(DotProduct(a, b) / (ma * mb));
    theta = double.RadiansToDegrees(theta);
    Console.WriteLine($"The angle between a and b is {theta}");
}

public static List<double> Projection(List<double> a, List<double> b)
{
    double dot = DotProduct(a, b);
    double mag = Magnetude(b);

    double multer = dot / (mag * mag);
    List<double> prod = new List<double>();
    foreach (double x in b)
    {
        prod.Add(multer * x);
    }
    for (int i = 0; i < prod.Count; i++)
    {
        Console.WriteLine(prod[i]);
    }
            return prod;
}
}
}