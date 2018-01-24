using CodeSample.Core.NodeList;
using CodeSample.Core.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CodeSampleCoreUnitTests
{
    [TestClass]
    public class NodeListTests
    {
        private static string[] wordList;

        private static Random rand = new Random();

        [ClassInitialize]
        public static void InitializeClass(TestContext context)
        {
            wordList = CodeSampleCoreUtils.ReturnWordList();
        }

        [TestMethod]
        public void TestDuplicateListGoldenPath5()
        {
            var initialList = Node.CreateList(5);
            var copy = Node.DuplicateList(initialList);

            CompareLists(initialList, copy);            
        }

        [TestMethod]
        public void TestDuplicateListGoldenPath1()
        {
            var initialList = Node.CreateList(1);
            var copy = Node.DuplicateList(initialList);

            CompareLists(initialList, copy);
        }

        [TestMethod]
        public void TestDuplicateListGoldenPath100()
        {
            var initialList = Node.CreateList(100);
            var copy = Node.DuplicateList(initialList);

            CompareLists(initialList, copy);
        }

        [TestMethod]
        public void TestDuplicateListGoldenPath100NoSelfLinks()
        {
            var initialList = Node.CreateList(100, allowSelfLinks:false);
            var copy = Node.DuplicateList(initialList);

            CompareLists(initialList, copy);
        }

        [TestMethod]
        public void TestDuplicateIfPassedNull()
        {
            var copy = Node.DuplicateList(null);
            Assert.IsNull(copy, "Copying null should return null");
        }
        
        private static void CompareLists(Node original, Node copy)
        {
            Node originalCurrent = original;
            Node copyCurrent = copy;

            while (originalCurrent != null)
            {
                Assert.IsTrue(originalCurrent.IsEquals(copyCurrent) , "Nodes should be equal");

                originalCurrent = originalCurrent.GetNext();
                copyCurrent = copyCurrent.GetNext();
            }

            Assert.IsNull(copyCurrent, "we should be null at the end");
        }
    }
}
