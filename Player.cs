using System;

using System.Collections.Generic;



namespace TowerEscape

{

    class Player

    {

        public string Name { get; private set; }

        public int Health { get; private set; }

        private int magicDamage;

        private int healthPotions;

        public List<Item> Inventory { get; private set; }



        public Player(string name)

        {

            Name = name;

            Health = 100;

            magicDamage = 20;

            healthPotions = 2;

            Inventory = new List<Item>();

        }



        public int Attack()

        {

            return magicDamage + new Random().Next(1, 10);

        }



        public void Defend(int reducedDamage)

        {

            Health -= reducedDamage;

            Console.WriteLine($"{Name} reduces damage and takes only {reducedDamage} points.");

        }



        public void UseHealthPotion()

        {

            if (healthPotions > 0)

            {

                Health += 20;

                healthPotions--;

                Console.WriteLine("You use a health potion and recover 20 health.");

            }

            else

            {

                Console.WriteLine("You have no health potions left!");

            }

        }



        public void TakeDamage(int damage)

        {

            Health -= damage;

        }



        public void AddItemToInventory(Item item)

        {

            Inventory.Add(item);

            Console.WriteLine($"You added {item.Name} to your inventory.");

        }

    }

}

