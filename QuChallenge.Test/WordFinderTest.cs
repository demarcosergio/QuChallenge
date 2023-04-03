using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace QuChallenge.Test
{
	public class WordFinderTest
	{
		private static List<string> _matrix = new List<string>();
		[SetUp]
		public void Setup()
		{
			_matrix = new List<string>()
			{
				"aaaabbbb",
				"ccccdddd",
				"eeeeffff"
			};
		}

		[Test]
		public void FindHorizontally_FindsWordInMatrix_ReturnsCorrectResult()
		{
			// Arrange
			WordFinder finder = new WordFinder(_matrix);
			List<string> word = new List<string> { "cccc" };

			// Act
			IEnumerable<string> wordsFound = finder.Find(word);

			// Assert
			Assert.AreEqual("cccc: Horizontal(Row:0, 1)", wordsFound.First());
		}
		[Test]
		public void FindVertically_FindsWordInMatrix_ReturnsCorrectResult()
		{
			// Arrange
			WordFinder finder = new WordFinder(_matrix);
			List<string> word = new List<string> { "ace" };

			// Act
			IEnumerable<string> wordsFound = finder.Find(word);

			// Assert
			Assert.AreEqual("ace: Vertical(Column:0)", wordsFound.First());
		}
		[Test]
		public void FindDiagonally_FindsWordInMatrix_ReturnsCorrectResult()
		{
			// Arrange
			WordFinder finder = new WordFinder(_matrix);
			List<string> word = new List<string> { "adf" };

			// Act
			IEnumerable<string> wordsFound = finder.Find(word);

			// Assert
			Assert.AreEqual("adf: Diagonal(0, 3)", wordsFound.First());
		}
		[Test]
		public void FindAllPositions_FindsWordInMatrix_ReturnsEmptyResult()
		{
			// Arrange
			WordFinder finder = new WordFinder(_matrix);
			List<string> word = new List<string> { "agggd" };

			// Act
			IEnumerable<string> wordsFound = finder.Find(word);

			// Assert
			Assert.AreEqual(false, (wordsFound.Any()));
		}
	}
}