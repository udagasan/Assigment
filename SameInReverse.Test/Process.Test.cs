using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SameInReverse.Test
{
    [TestClass]
    public class SameReverseUnitTest
    {
        [TestMethod]
        public void When_String_Contains_ReverseString_Process_Shoul_Found()
        {
            //Given
            var testString = "abckelekdef";

            //When
            var result = new SameInReverse.Process().GetSameReverseMessage(testString);

            //Then
            Assert.AreEqual(result, "kelek");
        }

        [TestMethod]
        public void Where_Suorce_Has_Capitall_Result_Dont_Change()
        {
            //Given
            var testString = "DevilNecerEveNLIVED";

            //When
            var result = new SameInReverse.Process().GetSameReverseMessage(testString);

            //Then
            Assert.AreEqual(result, "devilneverevenlived");
        }
        [TestMethod]
        public void When_String_DoesNot_Contains_Any_Reverse_It_Should_Return_EmptyString()
        {
            //Given
            var testString = "abcthydef";

            //When
            var result = new SameInReverse.Process().GetSameReverseMessage(testString);

            //Then
            Assert.AreEqual(result, string.Empty);
        }
        [TestMethod]
        public void When_Source_Include_More_Then_One_Reverse_String_It_Must_Return_Max()
        {
            //Given 
            var testString = "ababckelekdefcthyasdasddevilneverevenlivedasdasdasdasasddef";

            //When
            var result = new SameInReverse.Process().GetSameReverseMessage(testString);

            //Then
            Assert.AreEqual(result, "devilneverevenlived");
        }
    }
}
