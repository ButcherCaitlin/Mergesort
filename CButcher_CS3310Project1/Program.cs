using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CButcher_CS3310Project1
{
    class Program
    {
        public static int count;
        static void Main(string[] args)
        {
            var array = new List<int>();
            var rand = new Random();
            for(int i = 0; i < Math.Pow(2, 3); i++)
            {
                array.Add(rand.Next());
            }

            int n = array.Count;

            Console.WriteLine("The given array is: ");
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(array[i]);
            }
            
            mergeSort(array, 0, n - 1);

            Console.WriteLine("\nThe sorted array is: ");
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(array[i]);
            }
            
            Console.WriteLine("\nNumber of times the basic operation is done: {0}", count);
        }

        public static void Merge(List<int> array, int left, int middle, int right)
        {
           
            int firstNum = (middle - left + 1);
            int secondNum = (right - middle);

            // temporary arrays
            var tempLeft = new List<int>();
            var tempRight = new List<int>();

            // copy data to temporary arrays
            for (int i = 0; i < firstNum; i++)
            {
                tempLeft.Add(array[left + i]);
            }
            for(int j = 0; j < secondNum; j++)
            {
                tempRight.Add(array[middle + 1 + j]);
            }

            // merge the temporary arrays back
            int subI = 0; // index of first subarray
            int subJ = 0; // index of second subarray
            int k = left; // initial index of merged subarray

            while(subI < firstNum && subJ < secondNum)
            {
                count++;
                if (tempLeft[subI] <= tempRight[subJ])
                {
                    array[k] = tempLeft[subI];
                    subI++;
                }
                else
                {
                    array[k] = tempRight[subJ];
                    subJ++;
                }
                k++;
            }

            // copy any remaining elements of temporary arrays, if any
            while(subI < firstNum)
            {
                array[k] = tempLeft[subI];
                subI++;
                k++;
            }
            while(subJ < secondNum)
            {
                array[k] = tempRight[subJ];
                subJ++;
                k++;
            }
            
        }

        public static void mergeSort(List<int> array, int leftPos, int rightPos)
        {
            count++;
            if (leftPos < rightPos)
            {
                int middlePos = (leftPos + (rightPos - 1)) / 2;

                // sort first and second halves
                mergeSort(array, leftPos, middlePos);
                mergeSort(array, middlePos + 1, rightPos);
                Merge(array, leftPos, middlePos, rightPos);
            }
            
        }


    }
}
