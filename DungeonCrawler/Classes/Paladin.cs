namespace DungeonCrawler.Classes
{
    class Paladin : Character
    {
        public string ClassName { get; set; }
        public string IconPath { get; set; }


        public Paladin(string charactername, int strength, int agility, int intellect, int spirit, int stamina, int hp, int mp, int xp, int armor, int magicdefense)
            : base(charactername, strength, agility, intellect, spirit, stamina, hp, mp, xp, armor, magicdefense)
        {
            ClassName = "Paladin";
            IconPath = "pack://application:,,,/DungeonCrawler;component/Image/Icon/paladin%20ikon.jpg";
        }
    }
}