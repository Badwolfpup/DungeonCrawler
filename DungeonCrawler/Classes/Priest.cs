namespace DungeonCrawler.Classes
{
    class Priest : Character
    {
        public string ClassName { get; set; }


        public Priest(string charactername, int strength, int agility, int intellect, int spirit, int stamina, int hp, int mp, int xp, int armor, int magicdefense)
           : base(charactername, strength, agility, intellect, spirit, stamina, hp, mp, xp, armor, magicdefense)
        {
            ClassName = "Priest";
        }
    }
}
