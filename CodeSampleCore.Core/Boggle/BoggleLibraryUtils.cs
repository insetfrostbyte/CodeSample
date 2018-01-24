namespace CodeSample.Core.Boggle
{
    public static class BoggleLibraryUtils
    {
        /// <summary>
        /// Builds up the specified boggle dictionary from a list of words
        /// </summary>
        /// <param name="wordList">The source list of words</param>
        /// <returns>The boggleDictionary head node</returns>
        public static BoggleDictionaryNode BuildDictionary(string[] wordList)
        {
            var RootNode = new BoggleDictionaryNode('\0', false);

            for (int x = 0; x < wordList.Length; x++)
            {
                InsertWord(wordList[x], RootNode);
            }

            return RootNode;
        }

        /// <summary>
        /// Inserts a word into the boggle dictionary
        /// </summary>
        /// <param name="word">The word to place</param>
        /// <param name="root">The root node of the boggle dictionary</param>
        private static void InsertWord(string word, BoggleDictionaryNode root)
        {
            BoggleDictionaryNode current = root;
            foreach (char n in word.ToLower())
            {
                if (!current.Leaves.ContainsKey(n))
                {
                    current.Leaves.Add(n, new BoggleDictionaryNode(n, false));
                }
                current = current.Leaves[n];
            }
            current.isWord = true;
        }

        /// <summary>
        /// Determines if a word can be found in the boggle dictionary
        /// </summary>
        /// <param name="word">The Word to search for</param>
        /// <param name="root">The root node of the boggle dictionary</param>
        /// <returns>True if the word is in the dictionary, false otherwise</returns>
        public static bool ContainsWord(string word, BoggleDictionaryNode root)
        {
            BoggleDictionaryNode current = root;
            foreach (char n in word.ToLower())
            {
                if (!current.Leaves.ContainsKey(n))
                {
                    return false;
                }
                current = current.Leaves[n];
            }
            return current.isWord;
        }
    }
}
