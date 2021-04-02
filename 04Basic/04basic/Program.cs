using System;
using System.Text.RegularExpressions;
namespace _04basic
{
    class Program
    {
        static void Main(string[] args)
        {
            string palindrome = "Was it a car or a cat I saw?";
            string sentence = "Hello my name is Goran Turundjov and im 27 years old";
            ReverseString(palindrome);
            Console.WriteLine("````````````````````````````````");
            totalNumberOfVowels(palindrome);
            Console.WriteLine("````````````````````````````````");
            isItAPalindrome(palindrome);
            Console.WriteLine("````````````````````````````````");
            LargestWordInString(sentence);
            Console.WriteLine("````````````````````````````````");
            ShortestWord(sentence);
            Console.WriteLine("````````````````````````````````");
            wordCountSentence(sentence);
            Console.WriteLine("````````````````````````````````");
            Console.WriteLine("````````````````````````````````");
            printMostUsedChar(sentence);
           
        }
        //print the reverse string
        static void ReverseString(string str)
        {
            char[] theString = str.ToCharArray();
            Array.Reverse(theString);
            string reversed = new string(theString);
            Console.WriteLine(reversed);
        }
        // print total vowels in string
        static void totalNumberOfVowels(string str)
        {
            char[] theString = str.ToLower().ToCharArray();
          ;
            int counter = 0;
            foreach(char letter in theString)
            {
                if(letter == 'a' || letter == 'e' || letter == 'i' || letter == 'o' || letter == 'u')
                {
                    counter++;
                }
                
            }
            Console.WriteLine($"In the String {str} there are {counter} vowels");
        }
        // check if a string is a palindrome
        static void isItAPalindrome(string str)
        {
            Regex rgx = new Regex("[^a-zA-Z0-9]");
            string cleared = rgx.Replace(str, "").ToLower();
            char[] madeArray = cleared.ToCharArray();
            Array.Reverse(madeArray);
            string reversed = new string(madeArray);
            Console.WriteLine("");
            if(cleared == reversed)
            {
                Console.WriteLine($"{str} is a palindrome ");
            }

            
        }

        // print the largest word
        static void LargestWordInString(string str)
        {
            Regex rgx = new Regex("[^a-zA-Z0-9]");
            string largestWord = "";
            int largestCount = 0;
            string[] splited = str.Split(" ");
           foreach(string word in splited)
            {
              string theWord = rgx.Replace(word, "");
              if(largestCount < theWord.Length && theWord != "")
                {
                    largestWord = theWord;
                    largestCount = theWord.Length;
                }
            }
            Console.WriteLine($"Longest word in {str} is: \n  \"{largestWord}\" and is {largestCount} characters long");
        }
        static void ShortestWord(string str)
        {
            Regex rgx = new Regex("[^a-zA-Z0-9]");
            string lowestWord = "";
            int lowestCount = int.MaxValue;
            string[] splited = str.Split(" ");
            foreach (string word in splited)
            {
                string theWord = rgx.Replace(word, "");
                if (lowestCount > theWord.Length && theWord != "")
                {
                    lowestWord = theWord;
                    lowestCount = theWord.Length;
                }
            }
            Console.WriteLine($"Shortest word in {str} is: \n  \"{lowestWord}\" and is {lowestCount} characters long");

        }
        static void wordCountSentence(string str)
        {
            string[] array = str.Split(" ");
            foreach (string word in array)
            {
                Console.WriteLine($"The Word \"{word}\" is {word.Length} characters long");
            }
        }
        static void printMostUsedChar(string str)
        {
            while (str.Length > 0)
            {
                Console.Write(str[0] + " = ");
                int cal = 0;
                for (int i = 0; i < str.Length; i++)
                {
                    if (str[0] == str[i])
                    {
                        cal++;
                    }
                }
                Console.WriteLine(cal);
                str = str.Replace(str[0].ToString(), string.Empty);
            }
        }
       
        
    }
}
