using System;

using System.Collections.Generic;



namespace TowerEscape

{

    class Tower

    {

        private List<Room> rooms;

        public Room CurrentRoom { get; private set; }

        private int currentRoomIndex;



        public Tower()

        {

            rooms = new List<Room>

            {

                new Room("Dimly lit room with a broken window.", new Enemy("Shadow Beast", 50, 10, false), new Item("Torch")),

                new Room("Room with a dusty bookshelf.", null, new Item("Old Amulet")),

                new Room("Creepy chamber with eerie whispers.", new Enemy("Tower Ghost", 40, 8, true), null),

                new Room("A dark corridor with strange symbols on the walls.", null, new Item("Shield Amulet")),

                new Room("A hidden alcove, dusty but with faint traces of past visitors.", new Enemy("Shadow Wraith", 70, 12, false), new Item("Rusty Sword"))

            };

            currentRoomIndex = 0;

            CurrentRoom = rooms[currentRoomIndex];

        }



        public void MoveToNextRoom()

        {

            if (currentRoomIndex < rooms.Count - 1)

            {

                currentRoomIndex++;

                CurrentRoom = rooms[currentRoomIndex];

                Console.WriteLine("\nYou move to the next room...");

            }

            else

            {

                Console.WriteLine("\nThere are no more rooms ahead.");

            }

        }

    }

}



