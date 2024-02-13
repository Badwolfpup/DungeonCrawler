namespace DungeonCrawler.Classes
{
    class Ranger : Character
    {
        public string ClassName { get; set; }
        public string IconPath { get; set; }


        public Ranger(string charactername, int strength, int agility, int intellect, int spirit, int stamina, int hp, int mp, int xp, int armor, int magicdefense, string saveid)
            : base(charactername, strength, agility, intellect, spirit, stamina, hp, mp, xp, armor, magicdefense, saveid)
        {
            ClassName = "Ranger";
            IconPath = "pack://application:,,,/DungeonCrawler;component/Image/Icon/ranger%20ikon.jpg";

        }
    }
}
