using System;
using System.Collections.Generic;
using System.Threading;

namespace MemoryGame
{
    class Program
    {
        static void Main(string[] args)
        {
            int level = 1;
            while (true)
            {
                int[] values = GenerateValues(level);
                int[] answers = GetAnswers(level);

                bool levelSuccess = Compare(level, values, answers);

                if (levelSuccess)
                {
                    Console.WriteLine("Great Work!");
                    Thread.Sleep(1000);
                    Console.Clear();
                    level++;
                }
                else
                {
                    Console.WriteLine("Wrong answer, try again!");
                    Console.WriteLine("Values: " + string.Join(", ", values));
                    Console.WriteLine("Answers: " + string.Join(", ", answers));
                    break;
                }
            }
        }

        private static bool Compare(int level, int[] values, int[] answers)
        {
            bool levelSuccess = true;
            for (int i = 0; i < level; i++)
            {
                if (values[i] != answers[i])
                {
                    levelSuccess = false;
                }
            }

            return levelSuccess;
        }

        private static int[] GetAnswers(int level)
        {
            int[] answers = new int[level];
            for (int i = 0; i < level; i++)
            {
                string entry = Console.ReadLine();
                bool validEntry = int.TryParse(entry, out int value);

                if (validEntry)
                {
                    answers[i] = value;
                }
                else
                {
                    Console.WriteLine("Invalid Entry!");
                    i--;
                }
            }

            return answers;
        }

        private static int[] GenerateValues(int level)
        {
            int[] values = new int[level];
            for (int i = 0; i < level; i++)
            {
                int value = new Random().Next(9);
                values[i] = value;
                Console.WriteLine(value);
            }

            Thread.Sleep(500 * level);
            Console.Clear();

            return values;
        }
    }
}
