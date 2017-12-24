using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task1.question2;

namespace UnitTest
{
    /// <summary>
    /// This test class contains CollectionOperations class's unit tests.
    /// </summary>
    [TestClass]
    public class CollectionTest
    {
        /// <summary>
        /// This test method created for testing GetUniqueNumberAndOlderThanTwentyFive method.
        /// </summary>
        [TestMethod]
        public void GetUniqueNumberAndOlderThanTwentyFiveMethodTest()
        {
            ICollection<Element> inputCollection = null;
            ICollection<Element> result = CollectionOperations.GetUniqueNumberAndOlderThanTwentyFive(inputCollection);
            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Count);
        }

        /// <summary>
        /// This test method created for testing GetUniqueNumberAndOlderThanTwentyFive method.
        /// </summary>
        [TestMethod]
        public void GetUniqueNumberAndOlderThanTwentyFiveMethodTestCaseTwo()
        {
            ICollection<Element> inputCollection = new List<Element>();
            this.CreateList(inputCollection);
            ICollection<Element> result = CollectionOperations.GetUniqueNumberAndOlderThanTwentyFive(inputCollection);
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count);
        }

        /// <summary>
        /// This test method created for testing GetUniqueNumberAndOlderThanTwentyFive method.
        /// </summary>
        [TestMethod]
        public void GetUniqueNumberAndOlderThanTwentyFiveMethodTestCaseThree()
        {
            ICollection<Element> inputCollection = new List<Element>();
            this.CreateListWithTwoElement(inputCollection);
            ICollection<Element> result = CollectionOperations.GetUniqueNumberAndOlderThanTwentyFive(inputCollection);
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count);
            var enumerator = result.GetEnumerator();
            enumerator.MoveNext();
            Assert.AreEqual(1, enumerator.Current.num);
            Assert.AreEqual(30, enumerator.Current.age);
            Assert.AreEqual("Jhon", enumerator.Current.name);
        }

        /// <summary>
        /// This test method created for testing GetUniqueNumberAndOlderThanTwentyFive method.
        /// </summary>
        [TestMethod]
        public void GetUniqueNumberAndOlderThanTwentyFiveMethodTestCaseFour()
        {
            ICollection<Element> inputCollection = new List<Element>();
            this.CreateListWithThreeElement(inputCollection);
            ICollection<Element> result = CollectionOperations.GetUniqueNumberAndOlderThanTwentyFive(inputCollection);
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count);
            var enumerator = result.GetEnumerator();
            enumerator.MoveNext();
            Assert.AreEqual(1, enumerator.Current.num);
            Assert.AreEqual(30, enumerator.Current.age);
            Assert.AreEqual("Jhon", enumerator.Current.name);
        }

        /// <summary>
        /// Creates one list element age > 20.
        /// </summary>
        /// <param name="elementList">List will be popuşated with data.</param>
        private void CreateList(ICollection<Element> elementList)
        {
            elementList.Add(new Element { num = 1, age = 30, name = "Jhon" });
        }

        /// <summary>
        /// Creates two objects. one list element age > 20. the other is not.
        /// </summary>
        /// <param name="elementList">List will be popuşated with data.</param>
        private void CreateListWithTwoElement(ICollection<Element> elementList)
        {
            elementList.Add(new Element { num = 1, age = 30, name = "Jhon" });
            elementList.Add(new Element { num = 2, age = 10, name = "Jack" });
        }

        /// <summary>
        /// Creates two objects. one list element age > 20. the other is not. one is same num with first element.
        /// </summary>
        /// <param name="elementList">List will be popuşated with data.</param>
        private void CreateListWithThreeElement(ICollection<Element> elementList)
        {
            elementList.Add(new Element { num = 1, age = 30, name = "Jhon" });
            elementList.Add(new Element { num = 2, age = 10, name = "Jack" });
            elementList.Add(new Element { num = 1, age = 28, name = "Jammy" });
        }
    }
}
