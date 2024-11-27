using System;



namespace TowerEscape

{

    class DamagedNote

    {

        private int currentQuestionIndex;

        private string[] notes;

        private string[][] choices;

        private string[] correctAnswers;



        public DamagedNote()

        {

            currentQuestionIndex = 0;

            notes = new string[]

            {

                "The princess looked into the ___ and saw her future.",

                "To escape the tower, one must be as ___ as a fox.",

                "Only the ___ will find the way through the darkness."

            };



            choices = new string[][]

            {

                new string[] { "Mirror", "River", "Book", "Fire" },

                new string[] { "Wise", "Swift", "Quiet", "Brave" },

                new string[] { "Strong", "Fearless", "Determined", "Clever" }

            };



            correctAnswers = new string[] { "Mirror", "Wise", "Clever" };

        }



        public bool FillInTheNote()

        {

            Console.WriteLine("\nYou find a note on the table, but it seems to be damaged.");

            Console.WriteLine("Your task is to complete the missing words to reveal its message.\n");



            while (currentQuestionIndex < notes.Length)

            {

                Console.WriteLine($"Note: {notes[currentQuestionIndex]}");

                Console.WriteLine("Choices:");

                for (int i = 0; i < choices[currentQuestionIndex].Length; i++)

                {

                    Console.WriteLine($"{i + 1}. {choices[currentQuestionIndex][i]}");

                }



                Console.Write("Choose the correct answer (1, 2, 3, or 4): ");

                string playerChoice = Console.ReadLine();

                Console.Clear();



                if (int.TryParse(playerChoice, out int choice) && choice >= 1 && choice <= 4 &&

                    choices[currentQuestionIndex][choice - 1] == correctAnswers[currentQuestionIndex])

                {

                    Console.WriteLine("Correct!");

                    currentQuestionIndex++;

                }

                else

                {

                    Console.WriteLine("Incorrect. You lose your memory of the note and must start from the beginning.\n");

                    currentQuestionIndex = 0;

                }

            }



            Console.WriteLine("\nYou have successfully completed the note. It reveals valuable insight for your journey.");

            return true;

        }

    }

}

