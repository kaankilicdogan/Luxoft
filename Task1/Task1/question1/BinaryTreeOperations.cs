using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.question1
{
    /// <summary>
    /// Binary Tree Operation Class
    /// </summary>
    public static class BinaryTreeOperations
    {
        /// <summary>
        /// Compares two BTN objects and these objects are equal result will be true, otherwise result will be false.
        /// </summary>
        /// <param name="firstTree">First BTN object which will be compared with secondTree object.</param>
        /// <param name="secondTree">Second BTN object which will be compared with firstTree object.</param>
        /// <returns>Given two objects are same then result will be true, otherwise result will be false.</returns>
        public static bool Compare(BTN firstTree, BTN secondTree)
        {            
            if ((firstTree == null && secondTree != null) || (firstTree != null && secondTree == null))
            {
                return false;
            }

            if (firstTree != null && secondTree != null)
            {
                if (firstTree.val != secondTree.val || !Compare(firstTree.left, secondTree.left) || !Compare(firstTree.right, secondTree.right))
                {
                    return false;
                }
            }
            
            return true;
        }
    }
}
