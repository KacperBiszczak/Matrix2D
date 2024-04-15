namespace Matrix2D;

[TestClass]
public class Matrix2DTests
{
    [TestMethod]
    public void TestMatrixToString()
    {
        var matrix = new Matrix2D(1, 2, 3, 4);
        Assert.AreEqual("[[1, 2], [3, 4]]", matrix.ToString());
    }

    [TestMethod]
    public void TestMatrixEquality()
    {
        var matrix1 = new Matrix2D(1, 2, 3, 4);
        var matrix2 = new Matrix2D(1, 2, 3, 4);
        Assert.AreEqual(matrix1, matrix2);
    }

    [TestMethod]
    public void TestMatrixAddition()
    {
        var matrix1 = new Matrix2D(1, 2, 3, 4);
        var matrix2 = new Matrix2D(2, 3, 4, 5);
        var result = matrix1 + matrix2;
        Assert.AreEqual(new Matrix2D(3, 5, 7, 9), result);
    }

    [TestMethod]
    public void TestMatrixSubtraction()
    {
        var matrix1 = new Matrix2D(1, 2, 3, 4);
        var matrix2 = new Matrix2D(2, 3, 4, 5);
        var result = matrix1 - matrix2;
        Assert.AreEqual(new Matrix2D(-1, -1, -1, -1), result);
    }

    [TestMethod]
    public void TestMatrixMultiplication()
    {
        var matrix1 = new Matrix2D(1, 2, 3, 4);
        var matrix2 = new Matrix2D(2, 0, 1, 2);
        var result = matrix1 * matrix2;
        Assert.AreEqual(new Matrix2D(4, 4, 10, 8), result);
    }

    [TestMethod]
    public void TestScalarMultiplication()
    {
        var matrix = new Matrix2D(1, 2, 3, 4);
        var result1 = 2 * matrix;
        var result2 = matrix * 2;
        Assert.AreEqual(new Matrix2D(2, 4, 6, 8), result1);
        Assert.AreEqual(result1, result2);
    }

    [TestMethod]
    public void TestMatrixNegation()
    {
        var matrix = new Matrix2D(1, 2, 3, 4);
        var result = -matrix;
        Assert.AreEqual(new Matrix2D(-1, -2, -3, -4), result);
    }

    [TestMethod]
    public void TestMatrixTranspose()
    {
        var matrix = new Matrix2D(1, 2, 3, 4);
        var result = Matrix2D.Transpose(matrix);
        Assert.AreEqual(new Matrix2D(1, 3, 2, 4), result);
    }

    [TestMethod]
    public void TestMatrixDeterminant()
    {
        var matrix = new Matrix2D(1, 2, 3, 4);
        var det = matrix.Det();
        Assert.AreEqual(-2, det);
    }

    [TestMethod]
    public void TestMatrixParse()
    {
        var matrix = Matrix2D.Parse("[[2, 1], [3, 2]]");
        Assert.AreEqual(new Matrix2D(2, 1, 3, 2), matrix);
    }

    [TestMethod]
    public void TestMatrixParseInvalidFormat()
    {
        Assert.ThrowsException<FormatException>(() => Matrix2D.Parse("[[2, 1] [3, 2]]"));
    }
}
