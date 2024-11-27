using System;
using System.Collections.Generic;

namespace TowerEscape
{
    class Game
    {
        private Player player;
        private Tower tower;
        private Cat companion;
        private bool hasKey = false;
        private bool metMysteriousFigure = false;
        private bool gainedMagicPower = false;
        private bool unlockedRooms = false;
        private int courage = 50;
        private bool visitedLibrary = false;
        private bool completedNote = false;

        public void Start()
        {
            Console.WriteLine("Welcome to 'Tower Unbroken'!");
            Console.Write("Enter your name, brave princess: ");
            string playerName = Console.ReadLine();
            player = new Player(playerName);
            tower = new Tower();
            DisplayIntro();
            MeetCat();
            ExploreRoom();
        }

        private void DisplayIntro()
        {
            Console.Clear();
            Console.WriteLine("\nBackground Story:");
            Console.WriteLine($"{player.Name} wakes up in a cold, stone cell in an ancient tower.");
            Console.WriteLine("Tired of waiting for a prince, she decides to take her fate into her own hands.");
            Console.WriteLine("The tower is filled with eerie whispers and dark creatures lurking in the shadows.\n");
        }

        private void MeetCat()
        {
            Console.Clear();
            Console.WriteLine("As you step out of the first room, you hear a faint meowing.");
            Console.WriteLine("A small black cat with emerald eyes emerges from the shadows.");
            Console.Write("What will you name your new companion? ");
            string catName = Console.ReadLine();
            companion = new Cat(catName);
            Console.WriteLine($"The cat, now named {companion.Name}, purrs happily and decides to follow you.\n");
            EnterLibrary();
        }

        private void EnterLibrary()
        {
            if (!visitedLibrary)
            {
                Console.Clear();
                Console.WriteLine("Following your companion, you find yourself in a mysterious library filled with ancient books and artifacts.");
                Console.WriteLine("In the middle of the room, a fairy with shimmering wings appears and speaks in a gentle voice.");
                Console.WriteLine("'Hello, brave princess. I am the Fairy of Riddles. Answer my three riddles correctly, and I shall grant you a magic power to aid you on your journey.'");



                RiddleFairy riddleFairy = new RiddleFairy();
                bool passedRiddles = riddleFairy.AskRiddle();

                if (passedRiddles)
                {
                    Console.WriteLine("\nYou feel a surge of magical energy as the fairy's gift takes hold.");
                    gainedMagicPower = true;
                    Console.WriteLine("\nAs you regain your senses, you realize you’re in a completely different room, shrouded in darkness.");
                    Console.WriteLine("From the shadows, a terrifying creature suddenly attacks!");
                    BeginSurpriseBattle();
                }
                visitedLibrary = true;
            }
        }

        private void BeginSurpriseBattle()
        {
            Enemy shadowEnemy = new Enemy("Shadow Fiend", 60, 15, false);
            FightMonster(shadowEnemy);
            EnterHiddenRoom();
        }

        private void AfterFirstBattle()
        {
            Console.WriteLine("After a hard-fought battle, you catch your breath and move on.");
            Console.WriteLine("Soon, you find yourself in a mysterious room surrounded by mirrors.");

            MirrorRoom mirrorRoom = new MirrorRoom();
            bool passedMirrorTest = mirrorRoom.TestWisdom();

            if (passedMirrorTest)
            {
                Console.WriteLine("\nYou feel a soft glow as the power to unlock hidden doors fills you.");
                Console.WriteLine("With renewed resolve, you continue your journey deeper into the tower.");
                unlockedRooms = true; // Grant the player the ability to unlock more rooms
            }
        }

        private void EnterHiddenRoom()
        {
            Console.Clear();
            Console.WriteLine("After a fierce battle, you stumble upon a hidden room you haven’t seen before.");
            Console.WriteLine("The door is slightly ajar, and as you enter, you notice a damaged note lying on a table.");



            DamagedNote damagedNote = new DamagedNote();
            bool completedDamagedNote = damagedNote.FillInTheNote();

            if (completedDamagedNote)
            {
                Console.WriteLine("\nCompleting the note fills you with determination and clarity for your journey ahead.");
                completedNote = true;
            }
        }

        private void ExploreRoom()
        {
            bool firstBattleCompleted = false;

            while (player.Health > 0 && !hasKey)
            {
                Console.Clear();
                Room currentRoom = tower.CurrentRoom;
                Console.WriteLine($"\nYou are in: {currentRoom.Description}");

                if (currentRoom.Enemy != null)
                {
                    if (!firstBattleCompleted && courage > 30)
                    {
                        FightMonster(currentRoom.Enemy);
                        firstBattleCompleted = true;

                        if (player.Health > 0)
                        {
                            AfterFirstBattle(); // Trigger Mirror Room event after the first battle
                        }

                        if (player.Health <= 0)
                        {
                            Console.WriteLine("You have been defeated. The game ends here.");
                            return;
                        }
                    }
                    else if (courage > 30)
                    {
                        FightMonster(currentRoom.Enemy);
                        if (player.Health <= 0)
                        {
                            Console.WriteLine("You have been defeated. The game ends here.");
                            return;
                        }
                    }
                    else
                    {
                        Console.WriteLine($"{companion.Name} senses danger. You feel too scared to face the enemy and move to another room.");
                        courage += 10;
                        tower.MoveToNextRoom();
                        continue;
                    }
                }

                TriggerRandomEvent();
                ShowRoomOptions(currentRoom);
            }

            EndGame();
        }

        private void TriggerRandomEvent()
        {
            Random rand = new Random();
            int eventChance = rand.Next(1, 6);
            Console.Clear();

            switch (eventChance)
            {
                case 1:
                    if (!metMysteriousFigure)
                    {
                        Console.WriteLine("\nA mysterious hooded figure appears, muttering a cryptic warning:");
                        Console.WriteLine("'Beware the shadows that guard the key. Trust not what you see.'");
                        Console.WriteLine("Before you can ask anything, he disappears.");
                        metMysteriousFigure = true;
                    }
                    break;
                case 2:
                    Console.WriteLine($"{companion.Name} senses something ahead. Following its lead, you find a hidden health potion.");
                    player.AddItemToInventory(new Item("Health Potion"));
                    break;
                case 3:
                    Console.WriteLine("You feel a sudden chill and find a dusty scroll with notes about an ancient ritual.");
                    Console.WriteLine("It hints at a powerful artifact deeper in the tower. Perhaps it can aid you.\n");
                    courage += 5;
                    break;
                case 4:
                    Console.WriteLine($"{companion.Name} alerts you just in time to dodge a trap—spikes shoot from the walls!");
                    player.TakeDamage(5);
                    Console.WriteLine("You take 5 damage but manage to escape the trap.\n");
                    break;
                case 5:
                    Console.WriteLine("\nYou find an old rusty sword on the ground. It's not much, but it might give you courage.");
                    player.AddItemToInventory(new Item("Rusty Sword"));
                    courage += 10;
                    break;
            }
        }

        private void ShowRoomOptions(Room room)
        {
            Console.WriteLine("\nWhat would you like to do?");
            Console.WriteLine("1. Search the room for items or clues.");
            Console.WriteLine("2. Move to the next room.");
            Console.WriteLine("3. Examine surroundings carefully.");

            if (player.Inventory.Exists(i => i.Name == "Torch"))
            {
                Console.WriteLine("4. Use torch to light up dark corners.");
            }

            Console.Write("Choose an option (1-4): ");
            string choice = Console.ReadLine();
            Console.Clear();

            switch (choice)
            {
                case "1":
                    Console.WriteLine("You take a moment to search around the room, carefully examining every corner and looking for anything useful.");
                    SearchRoom(room); // Conducts a search for items if available
                    break;

                case "2":
                    Console.WriteLine("You decide to leave this room behind and venture into the next one, hoping for a safer passage.");
                    tower.MoveToNextRoom(); // Moves player to the next room
                    break;

                case "3":
                    Console.WriteLine("You take a closer look at your surroundings, inspecting every detail with a watchful eye.");
                    InspectSurroundings(); // Allows the player to carefully examine the surroundings
                    break;

                case "4":
                    if (player.Inventory.Exists(i => i.Name == "Torch"))
                    {
                        Console.WriteLine("You pull out your torch and light it, illuminating the dark corners of the room to reveal any hidden secrets.");
                        UseTorch(); // Uses the torch to check for hidden items or clues
                    }
                    else
                    {
                        Console.WriteLine("You don't have a torch. Try something else.");
                    }
                    break;

                default:
                    Console.WriteLine("Invalid choice. Try again.");
                    break;
            }
        }

        private void InspectSurroundings()
        {
            Console.WriteLine("\nYou take a careful look around the room.");
            Console.WriteLine($"{companion.Name} sniffs the air, sensing something hidden.");

            if (new Random().Next(0, 2) == 1)
            {
                Console.WriteLine("You discover a hidden compartment with a Shield Amulet that boosts your defense!");
                player.AddItemToInventory(new Item("Shield Amulet"));
            }
            else
            {
                Console.WriteLine("Nothing unusual catches your attention.");
            }
        }

        private void UseTorch()
        {
            Console.WriteLine("\nThe torch illuminates the dark corners of the room, revealing a hidden symbol on the wall.");
            Console.WriteLine("The symbol seems to hint at a hidden passage later in the tower.\n");
        }

        private void SearchRoom(Room room)
        {
            Console.Clear();

            if (room.Item != null)
            {
                Console.WriteLine($"You found a {room.Item.Name}!");
                player.AddItemToInventory(room.Item);
                room.Item = null;
            }
            else
            {
                Console.WriteLine("There is nothing useful here.");
            }
        }

        private void FightMonster(Enemy enemy)
        {
            Console.Clear();
            Console.WriteLine("As the princess steps cautiously into the next room, an eerie silence fills the air.");
            Console.WriteLine("The flickering torches cast long, ominous shadows on the walls, making every corner seem alive with dark energy.");
            Console.WriteLine("\nWith each step forward, the room grows darker, as if the light itself is being swallowed by an unseen force.");
            Console.WriteLine("A chilling wind brushes past, carrying with it whispers of past souls trapped in the tower’s depths.");
            Console.WriteLine("\nSuddenly, a deep growl resonates from the shadows, and a figure begins to emerge from the darkness.");
            Console.WriteLine("The shadows coalesce, taking form as a towering creature with gleaming red eyes—a shadow monster, waiting to attack.");
            Console.WriteLine("The princess steadies herself, realizing that this is a fight she cannot avoid.\n");
            Console.WriteLine("Press any key to face the enemy...");
            Console.ReadKey();

            BattleNarrative battleNarrative = new BattleNarrative(enemy);
            battleNarrative.StartBattleDescription();

            while (player.Health > 0 && enemy.Health > 0)
            {
                Console.Clear();
                Console.WriteLine($"\n{player.Name}'s Health: {player.Health}");
                Console.WriteLine($"{enemy.Name}'s Health: {enemy.Health}");

                Console.WriteLine("\nChoose your action:");
                Console.WriteLine("1. Attack with magic.");
                Console.WriteLine("2. Defend.");
                Console.WriteLine("3. Use a health potion.");

                string action = Console.ReadLine();
                Console.Clear();

                switch (action)
                {
                    case "1":
                        int damage = player.Attack();
                        if (gainedMagicPower)
                        {
                            damage += 10;
                            Console.WriteLine("Your magic power surges, increasing your attack!");
                        }
                        enemy.TakeDamage(damage);
                        battleNarrative.PlayerAttackDescription(damage);
                        break;

                    case "2":
                        Console.WriteLine("You brace yourself, reducing incoming damage.");
                        player.Defend(enemy.Attack() / 2);
                        break;

                    case "3":
                        player.UseHealthPotion();
                        break;

                    default:
                        Console.WriteLine("Invalid choice, you lose your turn!");
                        break;
                }

                if (enemy.Health > 0)
                {
                    int enemyDamage = (int)(enemy.Attack() * 0.55);
                    battleNarrative.EnemyAttackDescription(enemyDamage);
                    player.TakeDamage(enemyDamage);
                }

                // Show critical health warnings if either is near defeat
                battleNarrative.CriticalHealthWarning(player);
            }

            if (player.Health > 0)
            {
                battleNarrative.EndBattleDescription();
                if (enemy.HasKey)
                {
                    Console.WriteLine("You find a key on its body.");
                    hasKey = true;
                }
            }
        }

        private void EndGame()
        {
            Console.Clear();
            if (hasKey)
            {
                Console.WriteLine("\nWith the key in hand, you unlock the heavy iron door at the tower's entrance.");
                Console.WriteLine($"{player.Name} steps out into the morning light, with {companion.Name} at her side.");
                Console.WriteLine("The cursed tower crumbles behind her, leaving only ruins and a new horizon ahead.");
                Console.WriteLine("\nCongratulations! You have escaped the tower and started a new adventure.");
            }
        }
    }
}
