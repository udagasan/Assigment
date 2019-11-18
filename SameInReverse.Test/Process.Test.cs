using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SameInReverse.Test
{
    /// <summary>
    /// SameReverseUnitTest
    /// </summary>
    [TestClass]
    public class SameReverseUnitTest
    {
        /// <summary>
        /// Whens the string contains reverse string process shoul found.
        /// </summary>
        [TestMethod]
        public void When_String_Contains_ReverseString_Process_Shoul_Found()
        {
            //Given
            var testString = "abckelekdef";

            //When
            var result = new SameInReverse.Process().GetSameInReverseTextInString(testString);

            //Then
            Assert.AreEqual(result, "kelek");
        }

        /// <summary>
        /// Wheres the suorce has capitall result dont change.
        /// </summary>
        [TestMethod]
        public void Where_Suorce_Has_Capitall_Result_Dont_Change()
        {
            //Given
            var testString = "DevilNecerEveNLIVED";

            //When
            var result = new SameInReverse.Process().GetSameInReverseTextInString(testString);

            //Then
            Assert.AreEqual(result, "devilneverevenlived");
        }
        /// <summary>
        /// Whens the string does not contains any reverse it should return empty string.
        /// </summary>
        [TestMethod]
        public void When_String_DoesNot_Contains_Any_Reverse_It_Should_Return_EmptyString()
        {
            //Given
            var testString = "abcthydef";

            //When
            var result = new SameInReverse.Process().GetSameInReverseTextInString(testString);

            //Then
            Assert.AreEqual(result, string.Empty);
        }
        /// <summary>
        /// Whens the source include more then one reverse string it must return maximum.
        /// </summary>
        [TestMethod]
        public void When_Source_Include_More_Then_One_Reverse_String_It_Must_Return_Max()
        {
            //Given 
            var testString = "ababckelekdefcthyasdasddevilneverevenlivedasdasdasdasasddef";

            //When
            var result = new SameInReverse.Process().GetSameInReverseTextInString(testString);

            //Then
            Assert.AreEqual(result, "devilneverevenlived");
        }
    }
}
