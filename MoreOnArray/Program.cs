﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoreOnArray
{
   class Program
   {
      private static bool CheckPassed(int score)
      {
         if (score >= 60)
            return true;
         return false;
      }
      
      private static void Print(int value)
      {
         Console.Write($"{value} ");
      }

      static void Main(string[] args)
      {
         int[] scores = new int[] { 80, 74, 81, 90, 34 };

         foreach (int score in scores)
            Console.Write($"{score} ");

         Console.WriteLine();

         Array.Sort(scores);
         Array.ForEach<int>(scores, new Action<int>(Print));
         Console.WriteLine();

         Console.WriteLine($"Number of dimensions : {scores.Rank}");

         Console.WriteLine("Binary Search : 81 is at {0}", Array.BinarySearch<int>(scores, 81));
         Console.WriteLine("Linear Search : 90 is at {0}", Array.IndexOf(scores, 90));
         Console.WriteLine("Everone Passed? : {0}", Array.TrueForAll<int>(scores, CheckPassed));

         int index = Array.FindIndex<int>(scores, delegate (int score)
         {
            if (score < 60)
               return true;
            return false;
         });

         scores[index] = 61;
         Console.WriteLine("Everone Passed? : {0}", Array.TrueForAll<int>(scores, CheckPassed));
         Console.WriteLine($"Old length of scores : {scores.GetLength(0)}");
         Array.Resize<int>(ref scores,10);

         Array.ForEach<int>(scores, new Action<int>(Print));
         Console.WriteLine();

      }
   }
}
