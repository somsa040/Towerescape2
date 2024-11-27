using System;



namespace TowerEscape

{

    class MirrorRoom

    {

        private int currentQuestionIndex;

        private string[] questions;

        private bool[] answers;



        public MirrorRoom()

        {

            currentQuestionIndex = 0;

            questions = new string[]

            {

                "The more knowledge a wise person has, the more they realize how much they don't know.",

                "True wisdom lies in knowing how to always follow others rather than choosing one's own path.",

                "Forgiving others can sometimes be a greater strength than seeking revenge."

            };



            answers = new bool[] { true, false, true };

        }



        public bool TestWisdom()

        {

            Console.Clear();

            Console.WriteLine("As you step into the next room, you find yourself surrounded by countless mirrors.");

            Console.WriteLine("Each mirror reflects a different version of yourself, some young, some old, each gaze questioning.");

            Console.WriteLine("\nA voice echoes softly from within the mirrors:");

            Console.WriteLine("\"Welcome, princess. I am here to test your wisdom.\"");

            Console.WriteLine("You must answer the following questions truthfully.\n");



            while (currentQuestionIndex < questions.Length)

            {

                Console.WriteLine($"Question {currentQuestionIndex + 1}: {questions[currentQuestionIndex]}");

                Console.Write("Answer (true/false): ");

                string playerAnswer = Console.ReadLine()?.Trim().ToLower();

                Console.Clear();



                bool isCorrect = playerAnswer == "true" ? true : playerAnswer == "false" ? false : false;



                if (isCorrect == answers[currentQuestionIndex])

                {

                    Console.WriteLine("Correct!");

                    currentQuestionIndex++;

                }

                else

                {

                    Console.WriteLine("Incorrect. You lose your memory and must start over from the beginning.");

                    currentQuestionIndex = 0;

                }

            }



            Console.WriteLine("\n\"Well done, princess! I can see your wisdom,\" the mirror voice echoes.");

            Console.WriteLine("As a reward, I shall grant you the power to open locked rooms. Now you may explore the tower more freely.");

            return true;

        }

    }

}

