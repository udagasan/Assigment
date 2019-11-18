using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SameInReverse
{
    /// <summary>
    /// Process
    /// </summary>
    public class Process
    {
        #region Properties
        /// <summary>
        /// Gets or sets the array list.
        /// </summary>
        /// <value>
        /// The array list.
        /// </value>
        public char[] ArrayList { get; set; }
        /// <summary>
        /// Gets or sets the original array.
        /// </summary>
        /// <value>
        /// The original array.
        /// </value>
        public char[] OriginalArray { get; set; }
        /// <summary>
        /// Gets or sets the same in reverse list.
        /// </summary>
        /// <value>
        /// The same in reverse list.
        /// </value>
        public List<Index> SameInReverseList { get; set; }
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="Process"/> class.
        /// </summary>
        public Process()
        {
            SameInReverseList = new List<Index>();
        }
        #endregion
        #region Methods
        /// <summary>
        /// Gets the same reverse message.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">source</exception>
        public string GetSameInReverseTextInString(string source)
        {


            source = source.ToUpper();
            if (string.IsNullOrWhiteSpace(source))
            {
                throw new ArgumentNullException(nameof(source));
            }
            return GetResultMessage(source);
        }
        /// <summary>
        /// Gets the same reverse message from folder.
        /// </summary>
        /// <param name="sourcePath">The source path.</param>
        /// <returns></returns>
        public string GetSameInReverseTextInFile(string sourcePath)
        {

            var path = Path.GetFullPath(sourcePath);
            if (!File.Exists(path))
            {
                throw new FileNotFoundException(nameof(sourcePath));
            }
            if (!path.EndsWith(".sdx"))
            {
                throw new WrongFileFormatException(nameof(path));
            }
            var context = File.ReadAllText(path);

            return GetResultMessage(context);
        }

        string GetResultMessage(string context)
        {

            if (string.IsNullOrWhiteSpace(context))
            {
                throw new ArgumentNullException(nameof(context));
            }
            OriginalArray = context.ToCharArray();
            context = context.ToUpper();
            ArrayList = context.ToCharArray();


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
    /// <summary>
    /// Index
    /// </summary>
    public sealed class Index
    {
        /// <summary>
        /// Gets or sets the start index.
        /// </summary>
        /// <value>
        /// The start index.
        /// </value>
        public int StartIndex { get; set; }
        /// <summary>
        /// Gets or sets the index of the finish.
        /// </summary>
        /// <value>
        /// The index of the finish.
        /// </value>
        public int FinishIndex { get; set; }
        /// <summary>
        /// Gets or sets the character count.
        /// </summary>
        /// <value>
        /// The character count.
        /// </value>
        public int CharCount { get; set; }
    }
}

