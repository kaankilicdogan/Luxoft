using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task1.question1;

namespace UnitTest
{
    /// <summary>
    /// This test class contains BinaryTreeOperations class's unit tests.
    /// </summary>
    [TestClass]
    public class BinaryTreeTest
    {
        /// <summary>
        /// This test method created for testing Compare method.
        /// </summary>
        [TestMethod]
        public void CompareMethodTest()
        {
            BTN first = new BTN();
            BTN second = new BTN();
            this.createFirstCaseObjects(first, second);
            bool result = BinaryTreeOperations.Compare(first, second);
            Assert.IsFalse(result);
        }

        /// <summary>
        /// This test method created for testing Compare method.
        /// </summary>
        [TestMethod]
        public void CompareMethodTestSecondCase()
        {
            BTN first = new BTN();
            BTN second = new BTN();
            this.createSecondCaseObjects(first, second);
            bool result = BinaryTreeOperations.Compare(first, second);
            Assert.IsTrue(result);
        }

        /// <summary>
        /// This test method created for testing Compare method.
        /// </summary>
        [TestMethod]
        public void CompareMethodTestThirdCase()
        {
            BTN first = new BTN();
            BTN second = new BTN();
            this.createThirdCaseObjects(first, second);
            bool result = BinaryTreeOperations.Compare(first, second);
            Assert.IsFalse(result);
        }

        /// <summary>
        /// This test method created for testing Compare method.
        /// </summary>
        [TestMethod]
        public void CompareMethodTestLastCase()
        {
            BTN second = new BTN();
            bool result = BinaryTreeOperations.Compare(null, second);
            Assert.IsFalse(result);
        }

        /// <summary>
        /// Creates two objects. one of them will be null, other will be correct instance.
        /// </summary>
        /// <param name="first">BTN object which will be populate.</param>
        /// <param name="second">BTN object which will be populate.</param>
        private void createFirstCaseObjects(BTN first, BTN second)
        {
            first = null;
            second.val = 1;
            second.left = new BTN { val = 2, left = null, right = null };
            second.right = new BTN { val = 3, left = null, right = null };
        }

        /// <summary>
        /// Creates two objects. Both objects have same values.
        /// </summary>
        /// <param name="first">BTN object which will be populate.</param>
        /// <param name="second">BTN object which will be populate.</param>
        private void createSecondCaseObjects(BTN first, BTN second)
        {
            first.val = 1;
            first.left = new BTN { val = 2, left = new BTN { val = 3, left = null, right = null }, right = new BTN { val = 4, left = null, right = null } };
            first.right = new BTN { val = 5, left = new BTN { val = 6, left = null, right = null }, right = new BTN { val = 7, left = null, right = null } };
            second.val = 1;
            second.left = new BTN { val = 2, left = new BTN { val = 3, left = null, right = null }, right = new BTN { val = 4, left = null, right = null } };
            second.right = new BTN { val = 5, left = new BTN { val = 6, left = null, right = null }, right = new BTN { val = 7, left = null, right = null } };
        }

        /// <summary>
        /// Creates two objects. one of them will be different instance, other will be correct instance.
        /// </summary>
        /// <param name="first">BTN object which will be populate.</param>
        /// <param name="second">BTN object which will be populate.</param>
        private void createThirdCaseObjects(BTN first, BTN second)
        {
            first.val = 1;
            first.left = new BTN { val = 2, left = new BTN { val = 3, left = null, right = null }, right = new BTN { val = 4, left = null, right = null } };
            first.right = new BTN { val = 5, left = new BTN { val = 6, left = null, right = null }, right = new BTN { val = 8, left = null, right = null } };
            second.val = 1;
            second.left = new BTN { val = 2, left = new BTN { val = 3, left = null, right = null }, right = new BTN { val = 4, left = null, right = null } };
            second.right = new BTN { val = 5, left = new BTN { val = 6, left = null, right = null }, right = new BTN { val = 7, left = null, right = null } };
        }
    }
}
