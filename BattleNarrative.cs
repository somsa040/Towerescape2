using System;

namespace TowerEscape
{
    class BattleNarrative
    {
        private Enemy enemy;

        public BattleNarrative(Enemy enemy)
        {
            this.enemy = enemy;
        }

        public void StartBattleDescription()
        {
            Console.WriteLine("\nAs you cautiously enter the dim room, shadows seem to twist and pulse along the walls.");
            Console.WriteLine("A low growl rumbles from the darkness, and suddenly, a figure begins to materialize.");
            Console.WriteLine($"The {enemy.Name} steps forward, its eyes gleaming with malice and its form shifting ominously.");
            Console.WriteLine("With a chilling snarl, it lunges toward you, ready for a fight!");
        }

        public void PlayerAttackDescription(int damage)
        {
            Console.WriteLine($"You gather your strength and release a surge of energy toward the {enemy.Name}, striking it for {damage} damage!");
            Console.WriteLine("The creature recoils, hissing in anger as it prepares to retaliate.");
        }

        public void EnemyAttackDescription(int enemyDamage)
        {
            Console.WriteLine($"{enemy.Name} lashes out, its claws swiping through the air.");
            Console.WriteLine($"The attack lands, dealing {enemyDamage} damage. You feel a wave of pain but manage to stay on your feet.");
        }

        public void CriticalHealthWarning(Player player)
        {
            if (player.Health < 20)
            {
                Console.WriteLine("\nYou're struggling to catch your breath. Blood trickles down your arm, and your vision blurs.");
                Console.WriteLine("This battle is nearing its end—you need to end it before it's too late!");
            }

            if (enemy.Health < 20)
            {
                Console.WriteLine($"\nThe {enemy.Name} staggers, its movements slowing. You sense that it's on the brink of defeat.");
                Console.WriteLine("Now's your chance to finish this fight once and for all!");
            }
        }

        public void EndBattleDescription()
        {
            Console.WriteLine($"\nWith one final strike, the {enemy.Name} collapses, dissolving into shadows.");
            Console.WriteLine("The room grows eerily silent as the last remnants of the creature fade away.");
            Console.WriteLine("Victory is yours, but you know the tower holds more challenges yet to come...");
        }
    }
}
