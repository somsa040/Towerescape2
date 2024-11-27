namespace TowerEscape

{

    class Room

    {

        public string Description { get; private set; }

        public Enemy Enemy { get; private set; }

        public Item Item { get; set; }



        public Room(string description, Enemy enemy, Item item)

        {

            Description = description;

            Enemy = enemy;

            Item = item;

        }

    }

}

