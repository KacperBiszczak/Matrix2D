namespace Matrix2D
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var matrix1 = new Matrix2D(1, 2, 3, 4);
            var matrix2 = new Matrix2D(2, 0, 1, 2);

            Console.WriteLine($"Matrix1: {matrix1}");
            Console.WriteLine($"Matrix2: {matrix2}");
            Console.WriteLine($"Matrix1 + Matrix2: {matrix1 + matrix2}");
            Console.WriteLine($"Matrix1 - Matrix2: {matrix1 - matrix2}");
            Console.WriteLine($"Matrix1 * Matrix2: {matrix1 * matrix2}");
            Console.WriteLine($"2 * Matrix1: {2 * matrix1}");
            Console.WriteLine($"Matrix1 * 2: {matrix1 * 2}");
            Console.WriteLine($"Determinant of Matrix1: {matrix1.Det()}");
            Console.WriteLine($"Transpose of Matrix1: {Matrix2D.Transpose(matrix1)}");

            try
            {
                var matrix3 = Matrix2D.Parse("[[2, 1] [3, 2]]");
                Console.WriteLine($"Parsed Matrix: {matrix3}");
            }
            catch (FormatException e)
            {
                Console.WriteLine($"Error parsing matrix: {e.Message}");
            }
        }
    }
}
