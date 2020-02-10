using System;
using System.Linq;
using System.Collections.Generic;

namespace question_4
{
    class Program
    {
        public static void Main(String[] args)
        {
            string[] palin = new string[5] { "abcd", "dcba", "lls", "s", "sssll" };
             
            Console.WriteLine("\nQuestion 1:");   PrintPattern(5);
            Console.WriteLine("\nQuestion 2:");   PrintSeries(6);
            Console.WriteLine("\nQuestion 3:\n" + UsfTime("9:15:35 PM"));
            Console.WriteLine("\nQuestion 4:");   UsfNumbers(110, 11);
            Console.WriteLine("\nQuestion 5:");   PalindromePairs(palin);
            Console.WriteLine("\nQuestion 6:");   Stones(101);
        }

        // Question 1
        /*n – number of lines for the pattern, integer (int)
         * summary   : This method prints number pattern of integers using recursion
         * For example n = 5 will display the output as: 
         * 54321
         * 4321
         * 321
         * 21
         * 1
         * returns      : N/A
         * return type  : void
         */

        private static void PrintPattern(int n)
        {
            try
            {
                while (n > 0)
                {
                    int m = n;

                    while (m > 0)
                    {
                        Console.Write(m);
                        m = m - 1;
                    }
                    Console.WriteLine();
                    n = n - 1;
                }
            }
            catch
            {

            }
        }

        // Question 2

        /*n2 – number of terms of the series, integer (int)
         * This method prints the following series till n terms: 1, 3, 6, 10, 15, 21……
         * For example, if n2 = 6, output will be
         * 1,3,6,10,15,21
         * Returns : N/A
         * Return type: void
         * Hint: Series is 1,1+2=3,1+2+3=6,1+2+3+4=10,1+2+3+4+5=15, 1+2+3+4+5+6=21……
         */
        public static void PrintSeries(int n)
        {
            try {
                if (n <= 0) {
                    Console.WriteLine("Invalid input. Abort!");
                }
                else
                {
                    int sum = 0;
                    // let's start with the looping
                    for (int series = 1; series < n + 1; series++)
                    {
                        sum = series + sum;
                        Console.Write(sum + " ");
                    }
                }

            } catch
            {
                Console.WriteLine("Invalid input. Abort!");
            }

        }

        // Question 3

        /* On planet “USF” which is similar to that of Earth follows different clock
         * where instead of hours they have U , instead of minutes they have S , instead
         * of seconds they have F. Similar to earth where each day has 24 hours, each hour
         * has 60 minutes and each minute has 60 seconds , USF planet’s day has 36 U , each
         * U has 60 S and each S has 45 F. 
         * Your task is to write a method usfTime which takes 12HR  format and return string 
         * representing input time in USF time format.
         * Input format: A string s with time in 12 hour clock format (i.e. hh:mm:ssAM or
          * hh:mm:ssPM) where 01<= hh<=12, 00<=mm,ss,<=60
         * Output format: a string with converted time in USF clock format (i.e. UU:SS:FF ) 
         * where 01<= UU<=36, 00<=SS<=59,00<=FF<=45
         * 
         * Sample Input : 09:15:35PM
         * Sample Output: 28:20:35 
         * 
         * returns      : String
         * return type  : string
         * 
         * Hint: One way of doing this is by calculating total number of seconds in Input time
         * and dividing those seconds according to USF time.
         */

        public static string UsfTime(string t) {
            DateTime time = Convert.ToDateTime(t);
            string rtn;
            float u;
            float s;
            float f;
            float sec;

            try {
                sec = time.Hour   * 3600
                    + time.Minute * 60
                    + time.Second;

                f = (sec % 45) / 45;
                s = (((sec / 45) - f) % 60) / 60;
                u = (((sec / 45) - f) / 60) - s;

                f *= 45;
                s *= 60;

                rtn = u + ":" + s + ":" + f;
            } catch {
                rtn = "Invalid input. Abort!";
            }
            return rtn;
        }

        // Question 4

        /*n- total number of integers( 110 )
        * k-number of numbers per line ( 11)
        * USF Numbers : This method prints the numbers 1 to 110, 11 numbers per line.
        * The method shall print 'U' in place of numbers which are multiple of 3,"S" for 
        * multiples of 5,"F" for multiples of 7, 'US' in place of numbers which are multiple 
        * of 3 and 5,'SF' in place of numbers which are multiple of 5 and 7 and so on. 
        * The output shall look like 
        * 1 2 U 4 S U F 8 U S 11 
        * U 13 F US 16 17 U 19 S UF 22
        * 23 U S 26 U F 29 US 31 32 U....
        * 
        * returns      : N/A
        * return type  : void
        */
        public static void UsfNumbers(int n3, int k)
        {
            String tab = "\t";
            String nln = "\n";

            for (int i = 1; i <= n3; i++)
            {
                String val = "";

                if (i % 105 == 0)
                {
                    val = "USF";
                }
                else
                if (i % 35 == 0)
                {
                    val = "SF";
                }
                else
                if (i % 21 == 0)
                {
                    val = "UF";
                }
                else
                if (i % 15 == 0)
                {
                    val = "US";
                }
                else
                if (i % 7 == 0)
                {
                    val = "F";
                }
                else
                if (i % 5 == 0)
                {
                    val = "S";
                }
                else
                if (i % 3 == 0)
                {
                    val = "U";
                }
                else
                {
                    val = i.ToString();
                }

                if (i % k == 0)
                {
                    Console.Write(val + nln);
                }
                else
                {
                    Console.Write(val + tab);
                }
            } 
        }

        // Question 5

        /* You are given a list of unique words, the task is to find all the pairs of 
         * distinct indices (i,j) in the given list such that, the concatenation of two
         * words i.e. words[i]+words[j] is a palindrome.
         * Example:
         * Input: ["abcd","dcba","lls","s","sssll"]
         * Output: [[0,1],[1,0],[3,2],[2,4]] 
         * Explanation: The palindromes are ["dcbaabcd","abcddcba","slls","llssssll"]
         * Example:
         * Input: ["bat","tab","cat"]
         * Output: [[0,1],[1,0]] 
         * Explanation: The palindromes are ["battab","tabbat"]
         * 
         * returns      : N/A
         * return type  : void
         */

        public static void PalindromePairs(string[] words)
        {
            string rtn = "";

            for (int i = 0; i < words.Length; i++)
            {
                for (int j = 0; j < words.Length; j++)
                {
                    if (i != j)
                    {
                        if (PalindromeCheck(words[i], words[j]))
                        {
                            if (rtn != "") { rtn = rtn + ","; }
                            rtn = rtn + "[" + i + "," + j + "]";
                        }
                    }
                }
            }
            Console.WriteLine(rtn);
        }
        public static bool PalindromeCheck(string x, string y)
        {
            string z = x + y;

            for (int i = 0; i < z.Length; i++)
            {
                if (z[i] != z[z.Length - i - 1])
                {
                    return false;
                }
            }

            return true;
        }

        /*
        * You are playing a stone game with one of your friends. There are N number of 
        * The player who takes out the last stone will be the winner. In this case you
        * stones in a bag, each time one of you take turns to take out 1 to 3 stones. 
        * will be the first player to remove the stone(s)(Player 1).
        * 
        * Write a method to determine whether you can win the game given the number of 
        * stones in the bag. Print false if you cannot win the game, otherwise print any
        * one set of moves where you are winning the game. Array should contain moves by
        * both the players.
        * Input: 4
        * Output: false
        * Explanation: As there are 4 stones in the bag, you will never win the game. 
        * No matter 1,2 or 3 stones you take out, the last stone will always be removed by
        * your friend.
        * Input: 5
        * Output: [1,1,3]   or [1,2,2] or [1,3,1]
        * Player 1 picks up 1 stone then player 2 picks up 1 or 2 or 3 stones and the  
        * remaining stones are picked up by player 1.
        * Explanation: As there are 5 stones in the bag, you take out one stone.
        * As there are 4 stones in the bag and it’s your friend’s turn. He will never win 
        * the game because no matter 1,2 or 3 stones he takes out, you will the one to take 
        * out the last stone.
        * 
        * returns      : N/A
        * return type  : void
        */

        public static void Stones(int n)
        {
            string rtn;
            int win = 0;

            List<int> list = new List<int>();

            if (n < 4) {
                Console.WriteLine("Invalid input. Abort!");
            }
            else
            {
                if (n % 4 == 0)
                {
                    Console.WriteLine("false");
                }
                else
                {
                    win = n % 4;

                    list.Add(win);

                    while (list.AsQueryable().Sum() != n)
                    {
                        if (list.AsQueryable().Sum() + 3 <= n) { list.Add(3); }
                        else
                        if (list.AsQueryable().Sum() + 2 <= n) { list.Add(2); }
                        else
                        if (list.AsQueryable().Sum() + 1 <= n) { list.Add(1); }
                    }
                }
                rtn = String.Join(",", list);
                Console.WriteLine(rtn);
            }
        }
    }
}