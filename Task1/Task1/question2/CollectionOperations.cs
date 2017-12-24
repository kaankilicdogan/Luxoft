using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.question2
{
    /// <summary>
    /// Collection Operations class.
    /// </summary>
    public static class CollectionOperations
    {
        /// <summary>
        /// This Method filter object by age > 25 and num property is unique.
        /// </summary>
        /// <param name="givenCollection">Element object collection.</param>
        /// <returns>Filtered Element object List.</returns>
        public static ICollection<Element> GetUniqueNumberAndOlderThanTwentyFive(ICollection<Element> givenCollection)
        {
            if (givenCollection != null)
            {
                return givenCollection.Where(x => x.age > 20).GroupBy(x => x.num).Select(x => x.First()).ToList();
            }
            else
            {
                return new List<Element>();
            }
        }
    }
}
