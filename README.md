# QuChallenge
# WordFinder

This program uses a given matrix and wordstream to find words in the matrix. The words can be found horizontally, vertically, and diagonally.

## Usage

1. First, the matrix and wordstream are read into a list of strings.
2. Then, a new `WordFinder` instance is created with the matrix as a parameter.
3. The words in the matrix are found with the `Find()` method, which takes the wordstream as a parameter.
4. The results are printed to the console.

## Methods

- `InsertWordHorizontalRandom()`
- `InsertWordVerticalRandom()`
- `InsertWordDiagonalRandom()`

These methods are used to insert words into the matrix. Each method takes the matrix and a word as parameters. A random row and column for the starting position of the word are selected, and the word is inserted into the matrix.

- `Find()`

This method takes the wordstream as a parameter and finds the words in the matrix. The results are returned as an `IEnumerable` of strings.

- `FindVertically()`
- `FindHorizontally()`
- `FindDiagonally()`

These methods find the words in the matrix vertically, horizontally, and diagonally, respectively. Each method takes a word as a parameter and returns an `IEnumerable` of strings with the results.
