using System;

namespace TowerEscape

{

    class Item

    {

        public string Name { get; private set; }

        public string Type { get; private set; } // e.g., "weapon", "potion", "artifact"

        public int EffectValue { get; private set; } // e.g., healing amount or courage boost

        public bool IsConsumable { get; private set; }



        public Item(string name, string type = "misc", int effectValue = 0, bool isConsumable = false)

        {

            Name = name;

            Type = type;

            EffectValue = effectValue;

            IsConsumable = isConsumable;

        }



        public void Use(Player player)

        {

            if (Type == "potion" && IsConsumable)

            {

                Console.WriteLine($"You use the {Name}, recovering {EffectValue} health.");

                player.TakeDamage(-EffectValue); // Negative effect heals

            }

            else if (Type == "weapon")

            {

                Console.WriteLine($"You equip the {Name}, boosting your attack power by {EffectValue}.");

                // Modify player’s attack power here

            }

            else

            {

                Console.WriteLine("This item doesn't seem to have a direct effect.");

            }

        }

    }

}

