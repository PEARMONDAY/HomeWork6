using System;

namespace HomeWork6
{
    class Program
    {
        static void Main(string[] args)
        {
            double score = 0;
            double score1 = 0;
            int numberlevel = 0;
            double modify_answer = 0;
            int many_answer;
            bool check_input = false;
            while (check_input == false)
            {
                Difficulty level;
                level = (Difficulty)numberlevel;
                Console.WriteLine("Score = {0},Difficulty = {1}", score1, level);
                if (numberlevel == 0)
                {
                    numberlevel += 3;
                }
                else if (numberlevel == 1)
                {
                    numberlevel += 4;
                }
                else if (numberlevel == 2)
                {
                    numberlevel += 5;
                }
                Console.WriteLine("Pls Input. \n Number 0 Start \n Number1 = Setting \n Number2 = End");
                int number_setting = int.Parse(Console.ReadLine());
                if (number_setting == 0 || number_setting == 1 || number_setting == 2)
                {
                    if (number_setting == 0)
                    {
                        DateTimeOffset.Now.ToUniversalTime();
                        DateTime foo = DateTime.UtcNow;
                        long unixTime = ((DateTimeOffset)foo).ToUnixTimeSeconds();

                        Problem[] problem = GenerateRandomProblems(numberlevel);
                        foreach (Problem test in problem)
                        {
                            Console.WriteLine("Question :" + test.Message);
                            Console.Write("Ans =");
                                int Ans = int.Parse(Console.ReadLine());
                            if (Ans == test.Answer)
                            {
                                modify_answer++;
                            }
                            else
                            {
                                Console.WriteLine("incorrect");
                            }
                        }
                        many_answer = numberlevel;

                        if (numberlevel == 3)
                        {
                            numberlevel -= 3;
                        }
                        else if (numberlevel == 5)
                        {
                            numberlevel -= 4;
                        }
                        else if (numberlevel == 7)
                        {
                            numberlevel -= 5;
                        }

                        DateTime foo1 = DateTime.UtcNow;
                        long unixTime1 = ((DateTimeOffset)foo1).ToUnixTimeSeconds();

                        double Time;
                        Time = unixTime1 - unixTime;
                        Console.WriteLine("Time =" + Time);
                        Console.WriteLine("ans =" + modify_answer);
                        Console.WriteLine("numberlevel =" + numberlevel);

                        double score_1 = (modify_answer / many_answer)
                            , score_2 = (25 - Math.Pow(numberlevel, 2)) / (Math.Max(Time, 25 - Math.Pow(numberlevel, 2)))
                            , score_3 = Math.Pow(((2 * numberlevel) + 1), 2);

                        score = score_1 * score_2 * score_3;
                        score1 += score;
                        modify_answer = 0;
                    }
                    else if (number_setting == 1)
                    {
                        bool check_level = false;
                        while (check_level == false)
                        {
                            Console.WriteLine("Pls input level. \n Number 0 = Easy \n Number 1 = Normal \n Number 2 = Hard");
                            numberlevel = int.Parse(Console.ReadLine());
                            if (numberlevel != 0 && numberlevel != 1 && numberlevel != 2)
                            {
                                Console.WriteLine("Pls input level tryagin.\n" + numberlevel);
                            }
                            else
                                check_level = true;
                        }
                    }
                    else if (number_setting == 2)
                    {
                        check_input = true;
                    }
                }
                else
                    Console.WriteLine("Pls input 0-2. \n");
            }
        }
        enum Difficulty
        {
            Easy,
            Normal,
            Hard
        }
        struct Problem
        {
            public string Message;
            public int Answer;

            public Problem(string message, int answer)
            {
                Message = message;
                Answer = answer;
            }
        }
        static Problem[] GenerateRandomProblems(int numProblem)
        {
            Problem[] randomProblems = new Problem[numProblem];

            Random rnd = new Random();
            int x, y;
            for (int i = 0; i < numProblem; i++)
            {
                x = rnd.Next(50);
                y = rnd.Next(50);
                if (rnd.NextDouble() >= 0.5)
                {
                    randomProblems[i] = new Problem(String.Format("{0} + {1} = ?", x, y), x + y);
                }
                else
                    randomProblems[i] = new Problem(String.Format("{0} - {1} = ?", x, y), x - y);
            }

            return randomProblems;
        }
    }
}
