using System.Collections.Generic;

namespace CodeSample.Core.Boggle
{
    public class BoggleDictionaryNode
    {
        public char Character;
        public bool isWord;
        public Dictionary<char, BoggleDictionaryNode> Leaves;

        public BoggleDictionaryNode(char character, bool isWord)
        {
            this.Character = character;
            this.isWord = isWord;
            this.Leaves = new Dictionary<char, BoggleDictionaryNode>();
        }
    }
}
