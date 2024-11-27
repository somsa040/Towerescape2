using System;

namespace TowerEscape
{
    class RiddleFairy
    {
        private int currentRiddleIndex;
        private string[] riddles;
        private string[][] options;
        private string[] correctAnswers;

        public RiddleFairy()
        {
            currentRiddleIndex = 0;
            riddles = new string[]
            {
                "I can travel the world without leaving my corner. What am I?",
                "I speak without a mouth and hear without ears. I have nobody, but I come alive with the wind. What am I?",
                "The more you take, the more you leave behind. What am I?"
            };

            options = new string[][]
            {
                new string[] { "A map", "A bird", "A coin" },
                new string[] { "A tree", "An echo", "A whisper" },
                new string[] { "Footsteps", "Shadows", "Memories" }
            };

            correctAnswers = new string[] { "A map", "An echo", "Footsteps" };
        }

        public bool AskRiddle()
        {
            while (currentRiddleIndex < riddles.Length)
            {
                Console.WriteLine($"\nRiddle {currentRiddleIndex + 1}: {riddles[currentRiddleIndex]}");
                Console.WriteLine("Options:");
                for (int i = 0; i < options[currentRiddleIndex].Length; i++)
                {
                    Console.WriteLine($"{i + 1}. {options[currentRiddleIndex][i]}");
                }

                Console.Write("Choose the correct option (1, 2, or 3): ");
                string playerChoice = Console.ReadLine();
                Console.Clear();

                if (int.TryParse(playerChoice, out int choice) && choice >= 1 && choice <= 3 &&
                    options[currentRiddleIndex][choice - 1] == correctAnswers[currentRiddleIndex])
                {
                    Console.WriteLine("Correct!");
                    currentRiddleIndex++;
                }
                else
                {
                    Console.WriteLine("Incorrect. The fairy waves her wand, and you forget the answers.");
                    Console.WriteLine("You must start the riddles from the beginning.\n");
                    currentRiddleIndex = 0;
                }
            }

            // Additional text lines after answering all riddles correctly
            Console.WriteLine("\nCongratulations, princess! You have answered correctly.");
            Console.WriteLine("I shall give you a powerful magic to fight the monsters that lurk in the shadows.");
            Console.WriteLine("As the fairy bestows her magic upon you, she suddenly disappears in a flash of light.");
            Console.WriteLine("The room begins to swirl, and you find yourself in a completely different, dark chamber...");
            Console.WriteLine("Suddenly, a shadow attacks from the darkness!");

            return true;
        }
    }
}
