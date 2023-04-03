using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json.Serialization;
using System.Xml.Linq;

namespace QuChallenge
{
	class Program
	{
		static void Main(string[] args)
		{
			// Read the matrix file into a list of strings
			List<string> matrix = File.ReadAllLines("Assets/matrix.txt").ToList();
			InsertWordHorizontalRandom(matrix, "chill");
			InsertWordVerticalRandom(matrix, "cold");
			InsertWordDiagonalRandom(matrix, "wind");

			// Create a new WordFinder instance
			WordFinder finder = new WordFinder(matrix);

			Console.WriteLine("Matrix:");
			foreach (var line in matrix)
			{
				Console.WriteLine(line);
			}
			Console.WriteLine("\n");


			// Read the wordstream file into a list of strings
			List<string> wordstream = File.ReadAllLines("Assets/wordstream.txt").ToList();

			// Find the words in the matrix and print the results
			IEnumerable<string> wordsFound = finder.Find(wordstream);
			Console.WriteLine("Words found:");
			foreach (string word in wordsFound)
			{
				Console.WriteLine(word);
			}

			Console.ReadKey();

		}
		private static void InsertWordHorizontalRandom(List<string> matrix, string word)
		{
			// Select a random row and column for the starting position of the word
			Random rnd = new Random();
			int row = rnd.Next(0, matrix.Count);
			int col = rnd.Next(0, matrix[row].Length - word.Length + 1);

			// Insert the word into the matrix
			for (int i = 0; i < word.Length; i++)
			{
				matrix[row] = matrix[row].Substring(0, col + i) + word[i] + matrix[row].Substring(col + i + 1);
			}
		}
		private static void InsertWordVerticalRandom(List<string> matrix, string word)
		{
			// Select a random row and column for the starting position of the word
			Random rnd = new Random();
			int row = rnd.Next(0, matrix.Count - word.Length + 1);
			int col = rnd.Next(0, matrix[row].Length);

			// Insert the word into the matrix
			for (int i = 0; i < word.Length; i++)
			{
				matrix[row + i] = matrix[row + i].Substring(0, col) + word[i] + matrix[row + i].Substring(col + 1);
			}
		}
		private static void InsertWordDiagonalRandom(List<string> matrix, string word)
		{
			// Select a random row and column for the starting position of the word
			Random rnd = new Random();
			int row = rnd.Next(0, matrix.Count - word.Length + 1);
			int col = rnd.Next(0, matrix[row].Length - word.Length + 1);

			// Insert the word into the matrix
			for (int i = 0; i < word.Length; i++)
			{
				matrix[row + i] = matrix[row + i].Substring(0, col + i) + word[i] + matrix[row + i].Substring(col + i + 1);
			}
		}

	}
}