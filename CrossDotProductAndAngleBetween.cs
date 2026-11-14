using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GetInput;


namespace CrossDotProductAndAngleBetween
{ 

    public class Master
    {
        public static void Main()
        {
            GetInput.GetInput input = new GetInput.GetInput();
            int whatDo = 0;
            Console.WriteLine("Please enter one of corresponding numbers:\n1: Cross Product\n2: Dot Product\n3: Angle Between\n4: Magnetude\n5: Projection\n6: Matrix Scaler Multiplication\n7: Matrix Addition\n8: Matrix Subtraction\n9: Transpose");
            while (true)
            {
                try
                {

                    whatDo = int.Parse(Console.ReadLine());
                    if (whatDo > 9 || whatDo < 1)
                    {
                        Console.WriteLine("Please enter a number between 1 and 9");
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

            var vectorVals = GetVectorInput(2, 2, 2, true);
            var matrixVals = GetMatrixInput(1, 1, 2, true);


            switch (whatDo)
            {
                case 1:
                    vectorVals = GetVectorInput(3, 2, 3);
                    Console.WriteLine(vectorVals.Item1[0] + ", " + vectorVals.Item1[1] + ", " + vectorVals.Item1[2] + "\n" + vectorVals.Item2[0] + ", " + vectorVals.Item2[1] + ", " + vectorVals.Item2[2]);
                    VectorCalculator.CrossProduct(vectorVals.Item1, vectorVals.Item2);
                    break;

                case 2:
                    vectorVals = GetVectorInput();
                    VectorCalculator.DotProduct(vectorVals.Item1, vectorVals.Item2);
                    break;
                case 3:
                    vectorVals = GetVectorInput();
                    VectorCalculator.AngleBetween(vectorVals.Item1, vectorVals.Item2);
                    break;
                case 4:
                    vectorVals = GetVectorInput(2, 1);
                    VectorCalculator.Magnetude(vectorVals.Item1);
                    break;
                case 5:
                    vectorVals = GetVectorInput(2);
                    VectorCalculator.Projection(vectorVals.Item1, vectorVals.Item2);
                    break;
                case 6:

                    matrixVals = GetMatrixInput(1, 1, 1);
                    MatrixCalculator.ScalerMult(matrixVals.Item1, GetInput.GetInput.GetDoubleInput("Please enter the number you wish to multiply by", "Please enter a number"));
                    break;
                case 7:
                    matrixVals = GetMatrixInput();
                    MatrixCalculator.Addition(matrixVals.Item1, matrixVals.Item2);
                    break;
                case 8:
                    matrixVals = GetMatrixInput();
                    MatrixCalculator.Subtraction(matrixVals.Item1, matrixVals.Item2);
                    break;
                case 9:
                    matrixVals = GetMatrixInput(1, 1, 1);
                    MatrixCalculator.Transpose(matrixVals.Item1);
                    break;
            }
        }

        public static (List<double>, List<double>) GetVectorInput(int minLen = 1, int numlists = 2, int maxLen = 10000000, bool init = false)

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
                        if (b.Count < minLen)
                        {
                            Console.WriteLine($"Kindly enter at least {minLen} values");
                            continue;
                        }
                        break;
                    }
                    break;
                }
            }
            else if (numlists == 1)
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

        public static (double[,], double[,]) GetMatrixInput(int minCols = 1, int minRows = 1, int numArrs = 2, bool init = false)
        {

            if (init)
            {
                
                return (null, null);
            }

            int numCols;
            int numRows;
            int whatRow = 0;
            Console.WriteLine("Please enter the number of columns");
            while (true)
            {
                try
                {
                    numCols = int.Parse(Console.ReadLine());
                } catch
                {
                    Console.WriteLine("Please enter an Integer");
                    continue;
                }
                if (numCols < minCols)
                {
                    Console.WriteLine("Please enter an Integer greater than 0");
                    continue;
                }
                break;
            }

            Console.WriteLine("Please enter the number of rows");
            while (true)
            {
                try
                {
                    numRows = int.Parse(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Please enter an Integer");
                    continue;
                }
                if (numRows < minRows)
                {
                    Console.WriteLine("Please enter an Integer greater than 0");
                    continue;
                }
                break;
            }

            string input = "";
            double[,] matrix1 = new double[numRows, numCols];
            double[,] matrix2 = new double[numRows, numCols];

            if (numArrs == 2)
            {
                while (true)
                {
                    while (true)
                    {
                        try
                        {
                            Console.WriteLine("Enter the 1st row of your 1st matrix, with each number seperated by a comma");
                            input = Console.ReadLine();
                            input = input.Replace(" ", "");
                            string[] inputarray = new string[input.Length];

                            inputarray = input.Split(",");
                            if (inputarray.Length != numCols)
                            {
                                Console.WriteLine("Kindly enter exactly " + numCols + " numbers");
                                continue;
                            }
                            for (int i = 0; i < inputarray.Length; i++)
                            {
                                matrix1[0, i] = double.Parse(inputarray[i]);
                            }
                        }
                        catch
                        {
                            Console.WriteLine("Kindly enter numbers");
                            continue;
                        }
                        
                        break;
                    }
                    whatRow++;
                    while (whatRow < numRows)
                    {
                        while (true)
                        {
                            try
                            {
                                Console.WriteLine("Enter the next row of your 1st matrix, with each number seperated by a comma");
                                input = Console.ReadLine();
                                input = input.Replace(" ", "");
                                string[] inputarray = new string[input.Length];

                                inputarray = input.Split(",");
                                if (inputarray.Length != numCols)
                                {
                                    Console.WriteLine("Kindly enter exactly " + numCols + " numbers");
                                    continue;
                                }
                                for (int i = 0; i < inputarray.Length; i++)
                                {
                                    matrix1[whatRow, i] = double.Parse(inputarray[i]);
                                }
                            }
                            catch
                            {
                                Console.WriteLine("Kindly enter numbers");
                                continue;
                            }
                            break;
                        }
                        whatRow++;
                    }
                    whatRow = 0;
                    while (true)
                    {
                        try
                        {
                            Console.WriteLine("Enter the 1st row of your 2nd matrix, with each number seperated by a comma");
                            input = Console.ReadLine();
                            input = input.Replace(" ", "");
                            string[] inputarray = new string[input.Length];

                            inputarray = input.Split(",");
                            if (inputarray.Length != numCols)
                            {
                                Console.WriteLine("Kindly enter exactly " + numCols + " numbers");
                                continue;
                            }
                            for (int i = 0; i < inputarray.Length; i++)
                            {
                                matrix2[0, i] = double.Parse(inputarray[i]);
                            }
                        }
                        catch
                        {
                            Console.WriteLine("Kindly enter numbers");
                            continue;
                        }
                        break;
                    }
                    whatRow++;
                    while (whatRow < numRows)
                    {
                        while (true)
                        {
                            try
                            {
                                Console.WriteLine("Enter the next row of your 2nd matrix, with each number seperated by a comma");
                                input = Console.ReadLine();
                                input = input.Replace(" ", "");
                                string[] inputarray = new string[input.Length];

                                inputarray = input.Split(",");
                                if (inputarray.Length != numCols)
                                {
                                    Console.WriteLine("Kindly enter exactly " + numCols + " numbers");
                                    continue;
                                }
                                for (int i = 0; i < inputarray.Length; i++)
                                {
                                    matrix2[whatRow, i] = double.Parse(inputarray[i]);
                                }
                            }
                            catch
                            {
                                Console.WriteLine("Kindly enter numbers");
                                continue;
                            }
                            break;
                        }
                        whatRow++;
                    }
                    break;
                }
            }
            else if (numArrs == 1)
            {
                while (true)
                {
                    try
                    {
                        Console.WriteLine("Enter the 1st row of your matrix, with each number seperated by a comma");
                        input = Console.ReadLine();
                        input = input.Replace(" ", "");
                        string[] inputarray = new string[input.Length];

                        inputarray = input.Split(",");
                        if (inputarray.Length != numCols)
                        {
                            Console.WriteLine("Kindly enter exactly " + numCols + " numbers");
                            continue;
                        }
                        for (int i = 0; i < inputarray.Length; i++)
                        {
                            matrix1[0, i] = double.Parse(inputarray[i]);
                        }
                    }
                    catch
                    {
                        Console.WriteLine("Kindly enter numbers");
                        continue;
                    }
                    break;
                }
                whatRow++;
                while (whatRow < numRows)
                {
                    while (true)
                    {
                        try
                        {
                            Console.WriteLine("Enter the next row of your matrix, with each number seperated by a comma");
                            input = Console.ReadLine();
                            input = input.Replace(" ", "");
                            string[] inputarray = new string[input.Length];

                            inputarray = input.Split(",");
                            if (inputarray.Length != numCols)
                            {
                                Console.WriteLine("Kindly enter exactly " + numCols + " numbers");
                                continue;
                            }
                            for (int i = 0; i < inputarray.Length; i++)
                            {
                                matrix1[whatRow, i] = double.Parse(inputarray[i]);
                            }
                        }
                        catch
                        {
                            Console.WriteLine("Kindly enter numbers");
                            continue;
                        }
                        break;
                    }
                    whatRow++;
                }
            }
            
            return (matrix1, matrix2);
        }

        
        

    }

    public class MatrixCalculator
    {
        public static double[,] ScalerMult(double[,] matrix, double multiplier)
        {
            for (int i = 0; i < matrix.GetLength(0);i++)
            {
                for (int j = 0; j < matrix.GetLength(1);j++)
                {
                    matrix[i, j] = matrix[i, j] * multiplier;
                }
            }
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j] + ",");
                }
                Console.WriteLine();
            }

            return matrix;
        }

        public static double[,] Addition(double[,] matrix1, double[,] matrix2)
        {
            double[,] result = new double[matrix1.GetLength(0), matrix1.GetLength(1)];
            for (int i = 0; i < matrix1.GetLength(0); i++)
            {
                for (int j = 0; j < matrix1.GetLength(1); j++)
                {
                    result[i, j] = matrix1[i, j] + matrix2[i, j];
                }
            }

            for (int i = 0; i < result.GetLength(0); i++)
            {
                for (int j = 0; j < result.GetLength(1); j++)
                {
                    Console.Write(result[i, j] + ",");
                }
                Console.WriteLine();
            }
            return result;
        }

        public static double[,] Subtraction(double[,] matrix1, double[,] matrix2)
        {
            double[,] result = new double[matrix1.GetLength(0), matrix1.GetLength(1)];
            for (int i = 0; i < matrix1.GetLength(0); i++)
            {
                for (int j = 0; j < matrix1.GetLength(1); j++)
                {
                    result[i, j] = matrix1[i, j] - matrix2[i, j];
                }
            }
            for (int i = 0; i < result.GetLength(0); i++)
            {
                for (int j = 0; j < result.GetLength(1); j++)
                {
                    Console.Write(result[i, j] + ",");
                }
                Console.WriteLine();
            }
            return result;
        }

        public static double[,] Transpose(double[,] matrix)
        {
            double[,] result = new double[matrix.GetLength(1), matrix.GetLength(0)];
            List<double> temp = new List<double>();

            int tempPos = 0;
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                for (int j = 0; j < matrix.GetLength(0); j++)
                {
                    temp.Add(matrix[j, i]);
                }
            }

            for (int i = 0; i < result.GetLength(0); i++)
            {
                for (int j = 0;j < result.GetLength(1); j++)
                {
                    result[i, j] = temp[tempPos];
                    tempPos++;
                }
            }

            for (int i = 0; i < result.GetLength(0); i++)
            {
                for (int j = 0; j < result.GetLength(1); j++)
                {
                    Console.Write(result[i, j] + ",");
                }
                Console.WriteLine();
            }
            return result;
        }
    }



    public class VectorCalculator
    {
        

        

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