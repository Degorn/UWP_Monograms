using System.Linq;

namespace MonogramsLib.Extensions
{
	public static class MatrixExtension
	{
		public static T[] GetColumn<T>(this T[,] matrix, int columnNumber)
		{
			return Enumerable.Range(0, matrix.GetHeight())
					.Select(y => matrix[y, columnNumber])
					.ToArray();
		}

		public static T[] GetRow<T>(this T[,] matrix, int rowNumber)
		{
			return Enumerable.Range(0, matrix.GetWidth())
					.Select(x => matrix[rowNumber, x])
					.ToArray();
		}

		public static T[][] GetColumns<T>(this T[,] matrix)
		{
			return Enumerable.Range(0, matrix.GetWidth())
					.Select(x => matrix.GetColumn(x))
					.ToArray();
		}

		public static T[][] GetRows<T>(this T[,] matrix)
		{
			return Enumerable.Range(0, matrix.GetHeight())
					.Select(x => matrix.GetRow(x))
					.ToArray();
		}

		public static int GetHeight<T>(this T[,] matrix)
		{
			return matrix.GetLength(0);
		}

		public static int GetWidth<T>(this T[,] matrix)
		{
			return matrix.GetLength(1);
		}

		public static T GetCell<T>(this T[,] matrix, int x, int y)
		{
			return matrix[y, x];
		}
	}
}