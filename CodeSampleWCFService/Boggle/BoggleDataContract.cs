using System.Runtime.Serialization;

namespace CodeSampleWCFService.BoggleSvc
{
    [DataContract]
    public class BoggleDataContract
    {
        char[][] board;
        int height;
        int width;
        int minWordSize;

        [DataMember]
        public char[][] Board
        {
            get { return board; }
            set { board = value; }
        }

        [DataMember]
        public int Height
        {
            get { return height; }
            set { height = value; }
        }

        [DataMember]
        public int Width
        {
            get { return width; }
            set { width = value; }
        }

        [DataMember]
        public int MinWordSize
        {
            get { return minWordSize; }
            set { minWordSize = value; }
        }
    }
}