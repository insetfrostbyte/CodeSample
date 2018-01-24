using System.Collections.Generic;

namespace CodeSample.Core.Boggle
{
    public static class BoggleSolver
    {
        /// <summary>
        /// Finds words within a boggle board of a specified length
        /// </summary>
        /// <param name="height">The height of the boggle board</param>
        /// <param name="width">The width of the boggle board</param>
        /// <param name="board">the representation of the boggle board as a two dimensional char array</param>
        /// <param name="minWordSize">The smallest size of a word that is desired to be returned</param>
        /// <param name="dictionary">THe boggle dictionary object to check against</param>
        /// <returns>List of all of the words found</returns>
        public static List<string> SolveBoggle(int height, int width, char[][] board, int minWordSize, BoggleDictionaryNode dictionary)
        {
            if(dictionary == null)
            {
                throw new System.ArgumentNullException(nameof(dictionary));
            }

            var visitedBoard = new bool[height][];

            for(int x = 0; x < height; x++)
            {
                visitedBoard[x] = new bool[width];
            }

            var foundWordList = new List<string>();            

            for(int y = 0; y < height; y++)
            {
                for(int x = 0; x < width; x++)
                {
                    SearchBoggleBoard(x, y, board, visitedBoard, dictionary.Leaves[char.ToLower(board[y][x])], foundWordList, string.Empty , minWordSize);
                }
            }

            return foundWordList;
        }

        /// <summary>
        /// Recursively goes through a boggle board looking for words. 
        /// </summary>
        /// <param name="currentX">The current x position on the boggle board</param>
        /// <param name="currentY">The current y position on the boggle board</param>
        /// <param name="boggleBoard">The current boggle board</param>
        /// <param name="visitedBoard">The array of bools representing the state of what has been searched</param>
        /// <param name="currentNode">The current node in the dictionary</param>
        /// <param name="wordList">The list of words that have been found so far</param>
        /// <param name="currentWord">the current "word". May not be a valid word at any given time</param>
        /// <param name="minWordSize">The minimmum length a word should be before adding it to the list</param>
        private static void SearchBoggleBoard(int currentX, int currentY, char[][] boggleBoard, bool[][] visitedBoard, BoggleDictionaryNode currentNode, List<string> wordList, string currentWord, int minWordSize)
        {
            // We add the current letter to our current "word"
            // we also need to mark the current board as having been visited
            currentWord += boggleBoard[currentY][currentX];
            visitedBoard[currentY][currentX] = true;

            if (currentNode.isWord && currentWord.Length >= minWordSize && !wordList.Contains(currentWord))
            {
                wordList.Add(currentWord);
            }

            for(int lookX = -1; lookX < 2; lookX++)
            {
                for(int lookY = -1; lookY <2; lookY++)
                {
                    int nextX = currentX + lookX;
                    int nextY = currentY + lookY;

                    /// We recursively look at other places but we have to make sure
                    /// we only check for places that we haven't been, that are on the board
                    /// and that continue a chain in our dictionary
                    if(nextX >= 0 &&
                       nextY >= 0 &&
                       nextY < boggleBoard.Length &&
                       nextX < boggleBoard[nextY].Length &&
                       !visitedBoard[nextY][nextX] &&
                       currentNode.Leaves.ContainsKey(boggleBoard[nextY][nextX]))
                    {
                        SearchBoggleBoard(nextX, nextY, boggleBoard, visitedBoard, currentNode.Leaves[boggleBoard[nextY][nextX]], wordList, currentWord, minWordSize);
                    }
                }
            }

            visitedBoard[currentY][currentX] = false;
        }
    }
}
