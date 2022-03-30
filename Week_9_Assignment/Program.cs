//Sebastian Diaz
//Mar 30
//Description: you are to write a program that allows the user to enter the full name and path of a text file.
//Reads in that text file if it exists, and displays how many words are in the text file.

using System;
using System.Text.RegularExpressions;
using System.IO;

namespace Week_9_Assignment
{
    class Program
    {
        static void Main(string[] args)
        {
            //Ask the user for a filepath, then store it in the "filePath" variable
            Console.Write("Please enter a file path: ");
            string filePath = @"" + Console.ReadLine();

            var filePathChecker = new Regex(@"^[A-Z]:\\(\\*[A-Za-z0-9]+\s*)+\.txt");

            if (filePathChecker.IsMatch(filePath))
            {
                Console.WriteLine("File path is valid");
                try
                {
                    //Create a streamReader object with the variable "filePath"
                    StreamReader sr = new StreamReader(filePath);

                    Console.WriteLine("Opening the file...");

                    //Variables
                    int wordsCount = 0;
                    string line = "";
                    do
                    {
                        line = sr.ReadLine();
                        if (line != null)
                        {
                            string[] words = line.Split(' ', System.StringSplitOptions.RemoveEmptyEntries);
                            wordsCount += words.Length;
                            Console.WriteLine(line);
                        }

                    } while (line != null);

                    Console.WriteLine("There are " + wordsCount + " words in the file");
                }
                catch
                {
                    Console.WriteLine("Unfortunately, that file does not exist");
                }
            }
            else
            {
                Console.WriteLine("Not a valid file path!");
            }   
        }
    }
}
