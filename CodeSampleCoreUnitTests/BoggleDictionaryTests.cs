using CodeSample.Core.Boggle;
using CodeSample.Core.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodeSampleCoreUnitTests
{
    [TestClass]
    public class BoggleDictionaryTests
    {
        [TestMethod]
        public void TestFullLoadOfWords()
        {
            string[] lines = CodeSampleCoreUtils.ReturnWordList();

            var dictionary = BoggleLibraryUtils.BuildDictionary(lines);

            foreach(string word in lines)
            {
                var containsWord = BoggleLibraryUtils.ContainsWord(word, dictionary);
                Assert.IsTrue(containsWord, "We expect to find this word: " + word);
            }
        }

        [TestMethod]
        public void TestNonWordsAreExcluded()
        {
            var dictionary = BoggleLibraryUtils.BuildDictionary(CodeSampleCoreUtils.ReturnWordList());

            var containsWord = BoggleLibraryUtils.ContainsWord("woeiruwoeiruwoeiur", dictionary);
            Assert.IsFalse(containsWord, "What we typed in is not a word");
        }
    }
}
