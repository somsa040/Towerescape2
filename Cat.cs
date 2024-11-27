using System;



namespace TowerEscape

{

    class Cat

    {

        public string Name { get; private set; }



        public Cat(string name)

        {

            Name = name;

        }



        public void Interact()

        {

            Console.WriteLine($"{Name} rubs against your leg and purrs, giving you a sense of comfort.");

        }



        public void AlertPlayer()

        {

            Console.WriteLine($"{Name} hisses, alerting you to potential danger!");

        }

    }

}

