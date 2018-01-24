using CodeSample.Core.Boggle;
using CodeSample.Core.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace CodeSampleCoreUnitTests
{
    [TestClass]
    public class BoggleSolverTests
    {
        [TestMethod]
        public void TestBoggleSolverAgainstBungieKnownGood()
        {
            var dictionary = BoggleLibraryUtils.BuildDictionary(CodeSampleCoreUtils.ReturnWordList());
            
            char[][] board = new char[3][]
            {
               new char[]{'y', 'o', 'x' },
               new char[]{'r', 'b', 'a'},
               new char[]{'v', 'e', 'd' }
            };

            string[] bungieWords =
            {
               "bred",
               "yore",
               "byre",
               "abed",
               "oread",
               "bore",
               "orby",
               "robed",
               "broad",
               "byroad",
               "robe",
               "bored",
               "derby",
               "bade",
               "aero",
               "read",
               "orbed",
               "verb",
               "aery",
               "bead",
               "bread",
               "very",
               "road"
            };

            var foundWords = BoggleSolver.SolveBoggle(3, 3, board, 4, dictionary);

            foreach(string word in bungieWords)
            {
                Assert.IsTrue(foundWords.Contains(word), "We should have found, but didn't: " + word);
            }
        }
    }
}
