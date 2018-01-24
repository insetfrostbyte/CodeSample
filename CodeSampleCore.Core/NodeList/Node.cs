using System;
using System.Collections.Generic;

namespace CodeSample.Core.NodeList
{
    public class Node
    {
        Node Next;
        string Tag;
        Node Reference;

        /// <summary>
        /// Default constructor for node object
        /// </summary>
        public Node() : this(string.Empty) { }

        public Node(string Tag)
        {
            this.Tag = string.Copy(Tag); //Explicit copy to prevent any under the cover shenanigans that would keep these pointed
        }

        /// <summary>
        /// Compares two nodes to each other. This checks that the TAGS are of equal value
        /// and that the references to other tags point to the same place
        /// </summary>
        /// <param name="compare">The node to compare the node with</param>
        /// <returns>True if they are equal, false if not</returns>
        public bool IsEquals(Node compare)
        {
            if (compare == null)
            {
                return false;
            }

            bool referencesEqual = (this.Reference == null) ? compare.Reference == null : compare.Reference != null && this.Reference.Tag == compare.Reference.Tag;
            return this.Tag == compare.Tag && referencesEqual;
        }

        /// <summary>
        /// Returns the next node in the series
        /// </summary>
        /// <returns>The node following the current one, or NULL if at at the last node</returns>
        public Node GetNext()
        {
            return this.Next;
        }

        /// <summary>
        /// Duplicates the list starting at the provided node. 
        /// </summary>
        /// <param name="list">The node to begin the copy from</param>
        /// <returns>The head of the copied node list</returns>
        public static Node DuplicateList(Node list)
        {
            Node current = list;
            Node previous = null;

            var nodeReference = new Dictionary<string, Node>();

            while (current != null)
            {
                // If we've already created a node when building a reference, we just need to bring it back to place it
                // Otherwise create a new node
                // NOTE: We are assuming that each tag is unique. If duplicate tags are allowed, we would need to append
                // a random salt value on the end of each tag to try to attempt to create uniqueness.
                var temp =  nodeReference.ContainsKey(current.Tag) ? nodeReference[current.Tag] : new Node(current.Tag);

                // if the current node is supposed to have a reference, we need to add it
                if (current.Reference != null)
                {             
                    // If we have already created the referenced node lets link to it
                    if(nodeReference.ContainsKey(current.Reference.Tag))
                    {
                        temp.Reference = nodeReference[current.Reference.Tag];
                    }
                    // If haven't created the node yet, we need to create it and put it in the reference dictionay
                    else
                    {
                        temp.Reference = new Node(current.Reference.Tag);
                        nodeReference.Add(current.Reference.Tag, temp.Reference);
                    }
                }

                if (previous == null)
                {
                    list = temp;
                }
                else
                {
                    previous.Next = temp;
                }

                previous = temp;
                current = current.Next;
            }

            return list;
        }

        /// <summary>
        /// Creates a list of a specified length with random words as Tags
        /// </summary>
        /// <param name="listSize">The size of the desired list</param>
        /// <returns>The head pointer of the list</returns>
        public static Node CreateList(int listSize, Random rand = null, bool allowSelfLinks = true)
        {
            var wordList = Utilities.CodeSampleCoreUtils.ReturnWordList();
            var referenceList = new List<Node>();

            if (rand == null)
            {
                rand = new Random(DateTime.UtcNow.Millisecond);
            }

            Node head = null;

            // First we need to create the whole list of words, then we can go and link back on referenced items
            for (int x = 0; x < listSize; x++)
            {
                var temp = new Node(wordList[rand.Next(wordList.Length)]);
                referenceList.Add(temp); //This lets us quickly reference items to relink them

                temp.Next = head;
                head = temp;
            }

            var current = head;
            while(current != null)
            {
                if(rand.Next(0,100) % 2 == 0)
                {
                    var refNode = referenceList[rand.Next(0, listSize)];
                    if(refNode.Tag != current.Tag || allowSelfLinks)
                    {
                        current.Reference = refNode;
                    }
                }
                current = current.Next;
            }
            return head;
        }

        /// <summary>
        /// Creates a string representing the list
        /// </summary>
        /// <param name="list">The head of the list that that is deired to be represented</param>
        /// <returns>The string representative of the list</returns>
        public static string CreateListString(Node list, bool printSubleaves = true)
        {
            string temp = string.Empty;
            Node current = list;

            while (current != null)
            {
                temp += current.Tag;

                //Print the subleaves
                temp += string.Format("({0}) ", current.Reference == null ? "NULL" : current.Reference.Tag);

                temp += "->";
                current = current.Next;
            }
            temp += "NULL";

            return temp;
        }
    }
}
