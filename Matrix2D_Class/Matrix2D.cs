using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix2D
{
    public class Matrix2D:IEquatable<Matrix2D>
    {
        public int[,] numbers = new int[2, 2];
        private static readonly Matrix2D id;

        public Matrix2D(int a, int b, int c, int d)
        {
            numbers[0, 0] = a;
            numbers[0, 1] = b;
            numbers[1, 0] = c;
            numbers[1, 1] = d;
        }

        public Matrix2D()
        {
            numbers[0, 0] = 1;
            numbers[0, 1] = 0;
            numbers[1, 0] = 0;
            numbers[1, 1] = 1;
        }

        public static Matrix2D Id
        {
            get
            {
                return new Matrix2D();
            }
        }

        public static Matrix2D Zero 
        {
            get
            {
                return new Matrix2D(0, 0, 0, 0);
            }
        }

        public override string ToString()
        {
            return $"[[{numbers[0, 0]}, {numbers[0, 1]}], [{numbers[1, 0]}, {numbers[1, 1]}]]";
        }

        public bool Equals(Matrix2D obj)
        {
            if (obj == null) return false;

            return this.numbers[0, 0] == obj.numbers[0, 0] &&
            this.numbers[0, 1] == obj.numbers[0, 1] &&
            this.numbers[1, 0] == obj.numbers[1, 0] &&
            this.numbers[1, 1] == obj.numbers[1, 1];
        }

        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != typeof(Matrix2D)) return false;
           
            return Equals((Matrix2D) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(numbers[0, 0], numbers[0, 1], numbers[1, 0], numbers[1, 1]);
        }

        public static bool operator == (Matrix2D left, Matrix2D right)
        {
            if (left is null) return right is null;

            return left.Equals(right);
        }

        public static bool operator != (Matrix2D left, Matrix2D right)
        {
            return !(left == right);
        }

        public static Matrix2D operator + (Matrix2D left, Matrix2D right)
        {
            Matrix2D result = new Matrix2D();
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    result.numbers[i, j] = left.numbers[i, j] + right.numbers[i, j];
                }
            }

            return result;
        }
        public static Matrix2D operator - (Matrix2D left, Matrix2D right)
        {
            Matrix2D result = new Matrix2D();
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    result.numbers[i, j] = left.numbers[i, j] - right.numbers[i, j];
                }
            }

            return result;
        }
        public static Matrix2D operator * (Matrix2D left, Matrix2D right)
        {
            Matrix2D result = new Matrix2D();
            result.numbers[0,0] = left.numbers[0,0] * right.numbers[0,0] + left.numbers[0,1] * right.numbers[1,0];
            result.numbers[0,1] = left.numbers[0,0] * right.numbers[0,1] + left.numbers[0,1] * right.numbers[1,1];
            result.numbers[1,0] = left.numbers[1,0] * right.numbers[0,0] + left.numbers[1,1] * right.numbers[1,0];
            result.numbers[1,1] = left.numbers[1,0] * right.numbers[0,1] + left.numbers[1,1] * right.numbers[1,1];

            return result;
        }
        public static Matrix2D operator *(int k, Matrix2D a)
        {
            Matrix2D result = new Matrix2D();
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    result.numbers[i, j] = k * a.numbers[i, j];
                }
            }

            return result;
        }
        public static Matrix2D operator *(Matrix2D a, int k)
        {
            Matrix2D result = new Matrix2D();
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    result.numbers[i, j] = a.numbers[i, j] * k;
                }
            }

            return result;
        }

        public static Matrix2D operator -(Matrix2D a)
        {
            return a * (-1);
        }

        public static Matrix2D Transpose(Matrix2D a)
        {
            return new Matrix2D(a.numbers[0, 0], a.numbers[1, 0], a.numbers[0, 1], a.numbers[1, 1]);
        }
        public static int Determinant(Matrix2D a)
        {
            return (a.numbers[0, 0] * a.numbers[1, 1]) - (a.numbers[1, 0] * a.numbers[0, 1]);
        }
        public int Det()
        {
            return (numbers[0, 0] * numbers[1, 1]) - (numbers[1, 0] * numbers[0, 1]);
        }
        
        public static explicit operator int[,](Matrix2D a)
        {
            int[,] result = new int[2, 2];
            result[0, 0] = a.numbers[0, 0];
            result[0, 1] = a.numbers[0, 1];
            result[1, 0] = a.numbers[1, 0];
            result[1, 1] = a.numbers[1, 1];

            return result;
        }

        public static Matrix2D Parse(string a)
        {
            if (a[0] != '[' || a[a.Length - 1] != ']') throw new FormatException("Invalid format");

            //a = a.Replace('[', ' ');
            //a = a.Replace(']', ' ');

            string[] values = a[2..^2].Split("], [");
            if (values.Length != 2)
            {
                values = a[2..^2].Split("],[");

                if (values.Length != 2)
                {
                    throw new FormatException("Invalid format");
                }
            }

            var row1 = values[0].Trim().Split(",");
            var row2 = values[1].Trim().Split(",");

            if (row1.Length != 2 || row2.Length != 2)
            {
                throw new FormatException("Invalid format");
            }

            Matrix2D result = new Matrix2D(
                int.Parse(row1[0]),
                int.Parse(row1[1]),
                int.Parse(row2[0]),
                int.Parse(row2[1])
                );

            return result;
        }
    }
}
