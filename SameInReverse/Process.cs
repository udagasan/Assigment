using System;
using System.Collections.Generic;
using System.Linq;

namespace SameInReverse
{
    public class Process
    {
        #region Properties
        public char[] ArrayList { get; set; }
        public char[] OriginalArray { get; set; }
        public List<Index> SameInReverseList { get; set; }
        #endregion

        #region Constructors
        public Process()
        {
            SameInReverseList = new List<Index>();
        }
        #endregion
        #region Methods
        public string GetSameReverseMessage(string source)
        {
            OriginalArray = source.ToCharArray();

            source = source.ToUpper();
            if (string.IsNullOrWhiteSpace(source))
            {
                throw new ArgumentNullException(nameof(source));
            }
            ArrayList = source.ToCharArray();


            Func(1);
            if (!SameInReverseList.Any())
            {
                return string.Empty;
            }
            var maxIndex = SameInReverseList?.OrderByDescending(x => x.CharCount)?.First();
            var resultMessage = string.Empty;
            for (int i = maxIndex.StartIndex; i <= maxIndex.FinishIndex; i++)
            {
                resultMessage += OriginalArray[i].ToString();
            }
            return resultMessage;
        }

        List<Index> Func(int index)
        {
            var index1 = index;
            var index2 = index;
            bool loop = false;
            do
            {
                index1 = index1 - 1;
                index2 = index2 + 1;
                if (index1 >= 0 &&
                    index2 < ArrayList.Length &&
                    ArrayList[index1] == ArrayList[index2])
                {
                    loop = true;
                    SameInReverseList.Add(new Index { StartIndex = index1, FinishIndex = index2, CharCount = index2 - index1 });
                }
                else
                {
                    loop = false;
                }
            } while (loop);

            if (index < ArrayList.Length)
            {
                return Func(++index);
            }
            return SameInReverseList;


            #endregion
        }
    }
    public sealed class Index
    {
        public int StartIndex { get; set; }
        public int FinishIndex { get; set; }
        public int CharCount { get; set; }
    }
}

