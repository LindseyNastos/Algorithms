using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LogFlipping
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var logs = new int[] { 11, 3, 10, 2, 4, 7, 12, 1, 6 };

            var flip = new Flip();
            flip.LogSort(logs);

        }


    }
    public class Flip
    {
        private int Counter = 0;

        public int[] LogFlip(int[] numArray) {
            var largestNum = 0;
            var leftToSort = numArray.Length - Counter;

            //find largest num
            for (var i = 0; i < leftToSort; i++)
            {
                if (numArray[i] > largestNum) {
                    largestNum = numArray[i];
                }
            }

            //send highest num to top
            for (var i = 0; i < leftToSort; i++){
                if (numArray[i] == largestNum)
                {
                    var top = numArray.Take(i + 1);
                    var swap = top.Reverse().ToArray();
                    numArray = swap.Union(numArray).ToArray();
                    var x = numArray.Take(leftToSort);
                    var y = x.Reverse().ToArray();
                    numArray = y.Union(numArray).ToArray();
                }
            }

            
            return numArray;
        }



        public void LogSort(int[] numList)
        {
            var sorted = new int[numList.Length];
            for (var n = 0; n < numList.Length; n++ ) {
                sorted[n] = numList[n];
            }
            Array.Sort(sorted);

            if (!sorted.SequenceEqual(numList))
            {
                Console.WriteLine("no match");
                numList = LogFlip(numList);
                Counter++;
                LogSort(numList);
            }
            else {
                Console.WriteLine("they match");
            }


            foreach (var n in numList)
            {
                Console.WriteLine(n);
            }
            Console.ReadLine();
        }

    }
}
