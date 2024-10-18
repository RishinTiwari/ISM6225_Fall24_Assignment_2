using System;
using System.Collections.Generic;
// This program contains solutions to eight different problems, each implemented as a separate method.
namespace Assignment_2
{
    class Program
    {
        // The Main method serves as the entry point of the program, where each question's solution is executed and results are printed.
        static void Main(string[] args)
        {
            // Question 1: Find Missing Numbers in Array
            Console.WriteLine("Question 1:");
            // changed the inputs
            int[] nums1 = { 1 , 1 };
            IList<int> missingNumbers = FindMissingNumbers(nums1);
            Console.WriteLine(string.Join(",", missingNumbers));

            // Question 2: Sort Array by Parity
            Console.WriteLine("Question 2:");
            int[] nums2 = {0,1,2};
            int[] sortedArray = SortArrayByParity(nums2);
            Console.WriteLine(string.Join(",", sortedArray));

            // Question 3: Two Sum
            Console.WriteLine("Question 3:");
            // changed the input and target
            int[] nums3 = { 3,2,4 };
            int target = 6;
            int[] indices = TwoSum(nums3, target);
            Console.WriteLine(string.Join(",", indices));

            // Question 4: Find Maximum Product of Three Numbers
            Console.WriteLine("Question 4:");
            int[] nums4 = { 1, 2, 3};
            int maxProduct = MaximumProduct(nums4);
            Console.WriteLine(maxProduct);

            // Question 5: Decimal to Binary Conversion
            Console.WriteLine("Question 5:");
            // decimal value of 10 
            int decimalNumber = 10;
            string binary = DecimalToBinary(decimalNumber);
            Console.WriteLine(binary);

            // Question 6: Find Minimum in Rotated Sorted Array
            Console.WriteLine("Question 6:");
            int[] nums5 = { 4,5,6,7,0,1,2 };
            int minElement = FindMin(nums5);
            Console.WriteLine(minElement);

            // Question 7: Palindrome Number
            Console.WriteLine("Question 7:");
            int palindromeNumber = 10;
            bool isPalindrome = IsPalindrome(palindromeNumber);
            Console.WriteLine(isPalindrome);

            // Question 8: Fibonacci Number
            Console.WriteLine("Question 8:");
            int n = 3;
            int fibonacciNumber = Fibonacci(n);
            Console.WriteLine(fibonacciNumber);
        }

        // Question 1: Find Missing Numbers in Array
        // Using a HashSet to store numbers, then checking for missing numbers.
        public static IList<int> FindMissingNumbers(int[] nums)
        {
            try
            {
                HashSet<int> numbersSet = new HashSet<int>(nums);
                List<int> missingNumbers = new List<int>();

                for (int i = 1; i <= nums.Length; i++)
                {
                    if (!numbersSet.Contains(i))
                    {
                        missingNumbers.Add(i);
                    }
                }
                return missingNumbers;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return new List<int>();
            }
        }

        // Question 2: Sort Array by Parity
        // Two-pointer approach
        public static int[] SortArrayByParity(int[] nums)
        {
            try
            {
                int[] result = new int[nums.Length];
                int evenIndex = 0;
                int oddIndex = nums.Length - 1;

                foreach (int num in nums)
                {
                    if (num % 2 == 0)
                    {
                        result[evenIndex++] = num;
                    }
                    else
                    {
                        result[oddIndex--] = num;
                    }
                }
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return new int[0];
            }
        }

        // Question 3: Two Sum
        // A dictionary is used to store visited numbers
        public static int[] TwoSum(int[] nums, int target)
        {
            try
            {
                Dictionary<int, int> map = new Dictionary<int, int>();

                for (int i = 0; i < nums.Length; i++)
                {
                    int complement = target - nums[i];

                    if (map.ContainsKey(complement))
                    {
                        return new int[] { map[complement], i };
                    }
                    map[nums[i]] = i;
                }
                return new int[] { };
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return new int[0];
            }
        }

        // Question 4: Find Maximum Product of Three Numbers
        public static int MaximumProduct(int[] nums)
        {
            try
            {
                Array.Sort(nums);
                int n = nums.Length;

                // Compare product of largest three numbers with the product of the smallest two numbers (if negative) and the largest one
                return Math.Max(nums[n - 1] * nums[n - 2] * nums[n - 3], nums[0] * nums[1] * nums[n - 1]);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return 0;
            }
        }

        // Question 5: Decimal to Binary Conversion
        // divides the decimal number by 2 and collects the remainder to form the binary string.
        public static string DecimalToBinary(int decimalNumber)
        {
            try
            {
                if (decimalNumber == 0)
                    return "0";

                string binary = "";
                while (decimalNumber > 0)
                {
                    binary = (decimalNumber % 2) + binary;
                    decimalNumber /= 2;
                }
                return binary;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return "";
            }
        }

        // Question 6: Find Minimum in Rotated Sorted Array
        // A modified binary search is used to find the minimum in O(log n) time.
        public static int FindMin(int[] nums)
        {
            try
            {
                int left = 0, right = nums.Length - 1;

                while (left < right)
                {
                    int mid = left + (right - left) / 2;

                    if (nums[mid] > nums[right])
                    {
                        left = mid + 1;
                    }
                    else
                    {
                        right = mid;
                    }
                }
                return nums[left];
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return 0;
            }
        }

        // Question 7: Palindrome Number
        // The algorithm reverses the digits of the number and compares it with the original value.
        public static bool IsPalindrome(int x)
        {
            try
            {
                if (x < 0) return false;

                int original = x;
                int reversed = 0;

                while (x != 0)
                {
                    int pop = x % 10;
                    x /= 10;

                    if (reversed > int.MaxValue / 10 || (reversed == int.MaxValue / 10 && pop > 7)) return false;
                    reversed = reversed * 10 + pop;
                }

                return original == reversed;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return false;
            }
        }

        // Question 8: Fibonacci Number
        // The iterative approach is used to calculate the Fibonacci number in O(n) time.
        public static int Fibonacci(int n)
        {
            try
            {
                if (n == 0) return 0;
                if (n == 1) return 1;

                int a = 0, b = 1;

                for (int i = 2; i <= n; i++)
                {
                    int temp = a + b;
                    a = b;
                    b = temp;
                }
                return b;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return 0;
            }
        }
    }
}
