using System;



namespace TowerEscape

{

    class Enemy

    {

        public string Name { get; private set; }

        public int Health { get; private set; }

        public int Damage { get; private set; }

        public bool HasKey { get; private set; }

        public string BattleCry => "You shall not pass!";



        public Enemy(string name, int health, int damage, bool hasKey)

        {

            Name = name;

            Health = health;

            Damage = damage;

            HasKey = hasKey;

        }



        public int Attack()

        {

            return Damage + new Random().Next(1, 6);

        }



        public void TakeDamage(int damage)

        {

            Health -= damage;

            Console.WriteLine($"{Name} takes {damage} damage.");

        }

    }

}

