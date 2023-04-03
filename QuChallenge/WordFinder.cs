using System;
using System.Collections.Generic;
using System.Linq;

namespace QuChallenge
{

	public class WordFinder
	{
		private readonly IEnumerable<string> matrix;

		public WordFinder(IEnumerable<string> matrix)
		{
			this.matrix = matrix;
		}

		public IEnumerable<string> Find(IEnumerable<string> wordstream)
		{
			if (matrix == null || !matrix.Any() || matrix.Count() > 64)
				throw new ArgumentException("The length or size of the input strings is incorrect");

			var results = new List<string>();
			foreach (var word in wordstream)
			{
				results.AddRange(FindVertically(word));
				results.AddRange(FindHorizontally(word));
				results.AddRange(FindDiagonally(word));
			}
			return results.Distinct().Take(10);
		}

		private IEnumerable<string> FindVertically(string word)
		{
			for (int col = 0; col < matrix.First().Length; col++)
			{
				var colString = new string(matrix.Select(row => row[col]).ToArray());
				if (colString.Contains(word))
				{
					yield return $"{word}: Vertical(Column:{col})";
				}
			}
		}

		private IEnumerable<string> FindHorizontally(string word)
		{
			foreach (var row in matrix)
			{
				int index = -1;
				while ((index = row.IndexOf(word, index + 1, StringComparison.OrdinalIgnoreCase)) != -1)
				{
					yield return $"{word}: Horizontal(Row:{index}, {matrix.ToList().IndexOf(row)})";
				}
			}
		}

		private IEnumerable<string> FindDiagonally(string word)
		{
			for (int i = 0; i < matrix.Count(); i++)
			{
				for (int j = 0; j < matrix.First().Length; j++)
				{
					if (IsWordDiagonal(word, i, j))
					{
						yield return $"{word}: Diagonal({i}, {j})";
					}
				}
			}
		}

		private bool IsWordDiagonal(string word, int rowIndex, int colIndex)
		{
			int wordIndex = 0;
			while (wordIndex < word.Length)
			{
				if (IsWordCharAtPosition(word[wordIndex], rowIndex, colIndex))
				{
					wordIndex++;
					rowIndex++;
					colIndex++;
				}
				else
				{
					return false;
				}
				if (wordIndex == word.Length)
				{
					return true;
				}
			}
			return false;
		}
		private bool IsWordCharAtPosition(char wordChar, int rowIndex, int colIndex)
		{
			// Check if the given row and column indices are within the bounds of the matrix
			if (rowIndex < 0 || rowIndex >= matrix.Count() || colIndex < 0 || colIndex >= matrix.First().Length)
			{
				return false;
			}

			// Check if the character at the given position in the matrix matches the current character of the word being searched for
			return matrix.ElementAt(rowIndex)[colIndex] == wordChar;
		}
	}
}
