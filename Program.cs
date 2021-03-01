using System;
using System.Collections.Generic;
using System.Linq;

namespace Assignment2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Question1:
            Console.WriteLine("Question 1");
            int[] ar1 = { 1,2,3,4,4,3,2,1 };
            int n1 = 3;
            ShuffleArray(ar1, n1);
            Console.WriteLine("");

            //Question 2 
            Console.WriteLine("Question 2");
            int[] ar2 = { 0, 1, 0, 3, 12 };
            MoveZeroes(ar2);
            Console.WriteLine("");

            //Question3
            Console.WriteLine("Question 3");
            int[] ar3 = { 1, 2, 3 };
            CoolPairs(ar3);
            Console.WriteLine();

            //Question 4
            Console.WriteLine("Question 4");
            int[] ar4 = { 3, 3 };
            int target = 6;
            TwoSum(ar4, target);
            Console.WriteLine();

            //Question 5
            Console.WriteLine("Question 5");
            string s5 = "korfsucy";
            int[] indices = { 6, 4, 3, 2, 1, 0, 5, 7 };
            RestoreString(s5, indices);
            Console.WriteLine();

            //Question 6
            Console.WriteLine("Question 6");
            string s61 = "bulls";
            string s62 = "sunny";
            if (Isomorphic(s61, s62))
            {
                Console.WriteLine("Yes the two strings are Isomorphic");
            }
            else
            {
                Console.WriteLine("No, the given strings are not Isomorphic");
            }
            Console.WriteLine();

            //Question 7
            Console.WriteLine("Question 7");
            int[,] scores = { { 1, 91 }, { 1, 92 }, { 2, 93 }, { 2, 97 }, { 1, 60 }, { 2, 77 }, { 1, 65 }, { 1, 87 }, { 1, 100 }, { 2, 100 }, { 2, 76 } };
            HighFive(scores);
            Console.WriteLine();

            //Question 8
            Console.WriteLine("Question 8");
            int n8 = 19;
            if (HappyNumber(n8))
            {
                Console.WriteLine("{0} is a happy number", n8);
            }
            else
            {
                Console.WriteLine("{0} is not a happy number", n8);
            }

            Console.WriteLine();

            //Question 9
            Console.WriteLine("Question 9");
            int[] ar9 = { 7, 1, 5, 3, 6, 4 };
            int profit = Stocks(ar9);
            if (profit == 0)
            {
                Console.WriteLine("No Profit is possible");
            }
            else
            {
                Console.WriteLine("Profit is {0}", profit);
            }
            Console.WriteLine();

            //Question 10
            Console.WriteLine("Question 10");
            int n10 = 3;
            Stairs(n10);
            Console.WriteLine();
        }

        //Question 1
        /// <summary>
        /// Shuffle the input array nums consisting of 2n elements in the form [x1,x2,...,xn,y1,y2,...,yn].
        /// Print the array in the form[x1, y1, x2, y2, ..., xn, yn].
        ///Example 1:
        ///Input: nums = [2,5,1,3,4,7], n = 3
        ///Output: [2,3,5,4,1,7]
        ///  Explanation: Since x1 = 2, x2 = 5, x3 = 1, y1 = 3, y2 = 4, y3 = 7 then the answer is [2,3,5,4,1,7].
        ///Example 2:
        ///Input: nums = [1,2,3,4,4,3,2,1], n = 4
        ///Output: [1,4,2,3,3,2,4,1]
        ///Example 3:
        ///Input: nums = [1,1,2,2], n = 2
        ///Output: [1,2,1,2]
        /// </summary>

        
        //Self reflection: This problem was quite easy once i figured out that I can use an external index for my output array
        private static void ShuffleArray(int[] nums, int n)
        {
            
            try
            {
                int[] op = new int[nums.Length];
                if (nums.Length == 2*n){
                    //using an index to keep track of our output array which will be shuffled as required
                    int index = 0;
                    for (int i = 0; i < n; i++)
                    {

                        op[index] = nums[i];
                        op[index + 1] = nums[i + 3];
                        index += 2;

                    }
                    //ouputting the output array
                    for (int i = 0; i < op.Length; i++)
                    {
                        Console.Write(op[i] + " ");
                    }
                }
                else
                {
                    Console.WriteLine("Please enter " +2*n+ " elements in the array ");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        //Question 2:
        /// <summary>
        /// Write a method to move all 0's to the end of the given array. You should maintain the relative order of the non-zero elements. 
        /// You must do this in-place without making a copy of the array.
        /// Example:
        ///Input: [0,1,0,3,12]
        /// Output: [1,3,12,0,0]
        /// </summary>
        
        //self reflection: This was an interesting problem as we cannot use another array. There was no time constraint, so I was able to solve this with O(n*n)
        private static void MoveZeroes(int[] ar2)
        {
            try
            {
                if (ar2.Length > 1)
                {
                    //looping through the array, by swapping if the next element found is a 0. Did not use third variabel for swapping because the element to be swapped will always be a 0
                    for (int i = 0; i < ar2.Length; i++)
                    {
                        for (int j = i + 1; j < ar2.Length; j++)
                        {
                            if (ar2[i] == 0 && ar2[j] != 0)
                            {
                                ar2[i] = ar2[j];
                                ar2[j] = 0;
                                break;
                            }
                        }
                    }

                    //priting the array
                    for (int i = 0; i < ar2.Length; i++)
                    {
                        Console.Write(ar2[i] + " ");
                    }
                }
                else
                {
                    Console.Write("please enter 2 or more numbers");
                }
               
              

            }


            
            catch (Exception)
            {

                throw;
            }
        }


        //Question 3
        /// <summary>
        /// For an array of integers - nums
        ///A pair(i, j) is called cool if nums[i] == nums[j] and i<j
        ///Print the number of cool pairs
        ///Example 1
        ///Input: nums = [1,2,3,1,1,3]
        ///Output: 4
        ///Explanation: There are 4 cool pairs (0,3), (0,4), (3,4), (2,5) 
        ///Example 3:
        ///Input: nums = [1, 2, 3]
        ///Output: 0
        ///Constraints: time complexity should be O(n).
        /// </summary>

        //Self reflection: It was cleatr that I had to use a dictionary to get the count of elements in the array. It took a while to figure our the formula for calculating the total cool pairs
        private static void CoolPairs(int[] nums)
        {
            try
            {
                if (nums.Length > 1)
                {
                    Dictionary<int, int> map = new Dictionary<int, int>();

                    // using a dictionary to the store the count of each element
                    for (int i = 0; i < nums.Length; i++)
                    {
                        if (map.ContainsKey(nums[i]))
                        {
                            map[nums[i]] = map[nums[i]] + 1;
                        }
                        else
                            map.Add(nums[i], 1);
                    }
                    int ans = 0;

                    //calculating the cool pairs
                    foreach (KeyValuePair<int, int> pair in map)
                    {
                        int count = pair.Value;
                        ans += (count * (count - 1)) / 2;
                    }
                    Console.WriteLine(ans);
                }
                else
                {
                    Console.Write("please enter 2 or more numbers");
                }
                
            }
            catch (Exception)
            {

                throw;
            }
        }

        //Question 4:
        /// <summary>
        /// Given integer target and an array of integers, print indices of the two numbers such that they add up to the target.
        ///You may assume that each input would have exactly one solution, and you may not use the same element twice.
        /// You can print the answer in any order
        ///Example 1:
        ///Input: nums = [2,7,11,15], target = 9
        /// Output: [0,1]
        ///Output: Because nums[0] + nums[1] == 9, we print [0, 1].
        ///Example 2:
        ///Input: nums = [3,2,4], target = 6
        ///Output: [1,2]
        ///Example 3:
        ///Input: nums = [3,3], target = 6
        ///Output: [0,1]
        ///Constraints: Time complexity should be O(n)
        /// </summary>
        
        //self reflection: It took time to figure that I can use the difference of target and array element. From then it as easy.
        private static void TwoSum(int[] nums, int target)
        {
            try
            {
                if(nums.Length > 1)
                {
                    Dictionary<int, int> map = new Dictionary<int, int>();

                    int diff = 0;
                    for (int i = 0; i < nums.Length; i++)
                    {
                        diff = target - nums[i];

                        //if the dictionary contains our key ie  our difference then output its value
                        if (diff > 0 && map.TryGetValue(diff, out int index))
                        {
                            Console.WriteLine("[" + index + "," + i + "]");
                        }

                        //storing the element in dictionary if it is no present already
                        if (!map.ContainsKey(nums[i]))
                        {
                            map.Add(nums[i], i);
                        }
                    }
                }
                else
                {
                    Console.Write("please enter 2 or more numbers");
                }


            }
            catch (Exception)
            {

                throw;
            }

        }

        //Question 5:
        /// <summary>
        /// Given a string s and an integer array indices of the same length.
        ///The string s will be shuffled such that the character at the ith position moves to indices[i] in the shuffled string.
        ///Print the shuffled string.
        ///Example 1
        ///Input: s = "korfsucy", indices = [6,4,3,2,1,0,5,7]
        ///Output: "usfrocky"
        ///Explanation: As shown in the assignment document, “K” should be at index 6, “O” should be at index 4 and so on. “korfsucy” becomes “usfrocky”
        ///Example 2:
        ///Input: s = "USF", indices = [0,1,2]
        ///Output: "USF"
        ///Explanation: After shuffling, each character remains in its position.
        ///Example 3:
        ///Input: s = "ockry", indices = [1, 2, 3, 0, 4]
        ///Output: "rocky"
        /// </summary>
        

        //Self reflection: This one was quite easy compared to the other problems. 
        private static void RestoreString(string s, int[] indices)
        {
            try
            {
                if(s.Length == indices.Length)
                {
                    char[] a = new char[s.Length];
                    //using the indice value as the output values indice and assigning it with strings indices 
                    for (int i = 0; i < indices.Length; i++)
                    {
                        a[indices[i]] = s[i];
                    }

                    foreach (char c in a)
                    {
                        Console.Write(c);
                    }
                }
                else
                {
                    Console.Write("the number of indices should be same as string length");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Question 6
        /// <summary>
        /// Determine whether two give strings s1 and s2, are isomorphic.
        ///Two strings are isomorphic if the characters in s1 can be replaced to get s2.
        ///All occurrences of a character must be replaced with another character while preserving the order of characters.
        ///No two characters may map to the same character but a character may map to itself.
        ///Example 1:
        ///Input:s1 = “bulls” s2 = “sunny” 
        ///Output : True
        ///Explanation: ‘b’ can be replaced with ‘s’ and similarly ‘u’ with ‘u’, ‘l’ with ‘n’ and ‘s’ with ‘y’.
        ///Example 2:
        ///Input: s1 = “usf” s2 = “add”
        ///Output : False
        ///Explanation: ‘u’ can be replaced with ‘a’, but ‘s’ and ‘f’ should be replaced with ‘d’ to produce s2, which is not possible. So False.
        ///Example 3:
        ///Input : s1 = “ab” s2 = “aa”
        ///Output: False
        /// </summary>
        /// 

        ///Self refection: this problem was a little hard. It took a while for me to figure out how I can check if a dictionary has a value, it later turned out ot be simple.
        private static bool Isomorphic(string s1, string s2)
        {
 
            try
            {
                //if they are  not of equal lengths then its bvious that are not isomorphic
                if (s1.Length != s2.Length)
                {
                    return false;
                }
                s1 = s1.ToLower();
                s2 = s2.ToLower();
                Dictionary<char,char> dict = new Dictionary<char, char>();
                for(int i = 0; i < s1.Length; i++)
                {
                    //checking if the dicionary already the contains the value. If the value is already present, loop until you find that value and checkif the key of value is same as s2's current value
                    if (dict.ContainsValue(s2[i]))
                    {
                        foreach (KeyValuePair<char, char> pair in dict)
                        {
                            if (pair.Value == s2[i] && pair.Key != s1[i])
                            {
                                return false;
                            }
                        }
                    }
                    else
                    //enters if the dicionary does not have the value, it should also satisfy that the current key in loop is not already there
                    {
                        if (!dict.ContainsKey(s1[i]))
                        {
                            dict.Add(s1[i], s2[i]);
                        }
                        
                    }
                }
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Question 7
        /// <summary>
        /// Given a list of the scores of different students, items, where items[i] = [IDi, scorei] represents one score from a student with IDi, calculate each student's top five average.
        /// Print the answer as an array of pairs result, where result[j] = [IDj, topFiveAveragej] represents the student with IDj and their top five average.Sort result by IDj in increasing order.
        /// A student's top five average is calculated by taking the sum of their top five scores and dividing it by 5 using integer division.
        /// Example 1:
        /// Input: items = [[1, 91], [1,92], [2,93], [2,97], [1,60], [2,77], [1,65], [1,87], [1,100], [2,100], [2,76]]
        /// Output: [[1,87],[2,88]]
        /// Explanation: 
        /// The student with ID = 1 got scores 91, 92, 60, 65, 87, and 100. Their top five average is (100 + 92 + 91 + 87 + 65) / 5 = 87.
        /// The student with ID = 2 got scores 93, 97, 77, 100, and 76. Their top five average is (100 + 97 + 93 + 77 + 76) / 5 = 88.6, but with integer division their average converts to 88.
        /// Example 2:
        /// Input: items = [[1,100],[7,100],[1,100],[7,100],[1,100],[7,100],[1,100],[7,100],[1,100],[7,100]]
        /// Output: [[1,100],[7,100]]
        /// Constraints:
        /// 1 <= items.length <= 1000
        /// items[i].length == 2
        /// 1 <= IDi <= 1000
        /// 0 <= scorei <= 100
        /// For each IDi, there will be at least five scores.
        /// </summary>
        /// 

        //self reflection: This was by far the toughest problem of the lot. Took time to figure out how I can store the marks as a array value in the dictionary. Used lists instead of an array.
        private static void HighFive(int[,] items)
        {
            try
            {
                if(items.Length >=1 && items.Length <= 1000)
                {
                    int[,] ans = new int[2, 2];
                    int temp = 0;
                   
                    //keeping student ID as key and marks as list. Adding marks to the list, as we need the 2D array.
                    Dictionary<int, List<int>> map = new Dictionary<int, List<int>>();
                    for (int i = 0; i < items.Length/2; i++)
                    {
                        if (map.ContainsKey(items[i, 0]))
                        {
                            map[items[i, 0]].Add(items[i, 1]);
                        }
                        else
                        {
                            map.Add(items[i, 0], new List<int> { items[i, 1] });
                        }
                    }

                    //sorting and reversing our list of marks. taking the top 5 values using linq, summing it up and taking the average
                    foreach (KeyValuePair<int, List<int>> pair in map)
                    {
                        pair.Value.Sort();
                        pair.Value.Reverse();
                        ans[temp, 0] = pair.Key;
                        ans[temp, 1] = (pair.Value.Take(5).Sum() / 5);
                        temp = temp + 1;
                    }

                    Console.WriteLine("[" + ans[0, 0] + "," + ans[0, 1] + "]");
                    Console.WriteLine("[" + ans[1, 0] + "," + ans[1, 1] + "]");
                }
              

            }
            catch (Exception)
            {

                throw;
            }
        }

        //Question 8
        /// <summary>
        /// Write an algorithm to determine if a number n is happy.
        ///A happy number is a number defined by the following process:
        ///•	Starting with any positive integer, replace the number by the sum of the squares of its digits.
        ///•	Repeat the process until the number equals 1 (where it will stay), or it loops endlessly in a cycle which does not include 1.
        ///•	Those numbers for which this process ends in 1 are happy.
        ///Return true if n is a happy number, and false if not.
        ///Example 1:
        ///Input: n = 19
        ///Output: true
        ///Explanation:
        ///12 + 92 = 82
        ///82 + 22 = 68
        ///62 + 82 = 100
        ///12 + 02 + 02 = 1
        ///Example 2:
        ///Input: n = 2
        ///Output: false
        ///Constraints:
        ///1 <= n <= 231 - 1
        /// </summary>
        /// 

        //self reflection: This was hard to solve, borrowed a few ideas from the internet to solve this one. 
        public static int sumDigitSquare(int n)
        {
            int sum = 0;
            try
            {

                while (n != 0)
                {
                    int temp = (n % 10);
                    sum += temp * temp;
                    n = n / 10;
                }
                return sum;
            }
            catch (Exception)
            {

                throw;
            }
        }
        private static bool HappyNumber(int n)
        {
            if(n >= 1 && n <= 231 - 1)
            {
                //storing the numbers in list as find sum of squares
                List<int> s = new List<int>();
                s.Add(n);

                try
                {
                    while (true)
                    {
                        if (n == 1)
                        {
                            return true;
                        }
                        n = sumDigitSquare(n);
                        if (s.Contains(n))
                        {
                            return false;
                        }
                        s.Add(n);
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
            else
            {
                return false;
            }
         
        }


        //Question 9
        /// <summary>
        /// Professor Manish is planning to invest in stocks. He has the data of the price of a stock for the next n days.  
        /// Tell him the maximum profit he can earn from the given stock prices.Choose a single day to buy a stock and choose another day in the future to sell the stock for a profit
        /// If you cannot achieve any profit return 0.
        /// Example 1:
        /// Input: prices = [7,1,5,3,6,4]
        /// Output: 5
        /// Explanation: Buy on day 2 (price = 1) and sell on day 5 (price = 6), profit = 6-1 = 5.
        /// Note that buying on day 2 and selling on day 1 is not allowed because you must buy before you sell.
        /// Example 2:
        /// Input: prices = [7,6,4,3,1]
        /// Output: 0
        ///Explanation: In this case, no transactions are done and the max profit = 0.
        ///Try to solve it in O(n) time complexity.
        /// </summary>
    
        //self reflection: This was an interesting problem, as we had to do everythin in one pass.
        private static int Stocks(int[] prices)
        {
            if(prices.Length > 1)
            {
                int highest = 0;
                int bd = prices[0];
                try
                {   //updating the highest value as we pas through the string. We aso update the buying day if it is bigger than the current value in the array.
                    for (int i = 1; i < prices.Length; i++)
                    {
                        if (prices[i] - bd > highest)
                        {
                            highest = prices[i] - bd;
                        }
                        if (prices[i] < bd)
                        {
                            bd = prices[i];
                        }
                    }
                    return highest;
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return 0;
          
        }

        //Question 10
        /// <summary>
        /// Professor Clinton is climbing the stairs in the Muma College of Business. He generally takes one or two steps at a time.
        /// One day he came across an idea and wanted to find the total number of unique ways that he can climb the stairs. Help Professor Clinton.
        /// Print the number of unique ways. 
        /// Example 1:
        ///Input: n = 2
        ///Output: 2
        ///Explanation: There are two ways to climb to the top.
        ///1. 1 step + 1 step
        ///2. 2 steps
        ///Example 2:
        ///Input: n = 3
        ///Output: 3
        ///Explanation: There are three ways to climb to the top.
        ///1. 1 step + 1 step + 1 step
        ///2. 1 step + 2 steps
        ///3. 2 steps + 1 step
        ///Hint : Use the concept of Fibonacci series.
        /// </summary>
        /// 
        
        //self reflection: learnt to use th recrusive approach for using fibonacci
        static int fib(int n)
        {
            if (n <= 1)
            {
                return n;
            }
            //Using the recrusive approach to find the fibnocci series
            return fib(n - 1) + fib(n - 2);
        }

        //Calling our fibonacci function 
        private static void Stairs(int steps)
        {
            try
            {
                Console.WriteLine(fib(steps + 1));

            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}

//Recommendations: There was a lot I learnt through this assignment. I was able to find the right data structure for the problem.
//It would be nice, if there is a way to formulate questions where we have to pick the right data structure to solve the problem. It would nice to learn, as data scientists I think we need to learn that.
//It would also be good if we could see the best time complexity and space compleixiy for the problems. SO we can see where we stand with our solutions.