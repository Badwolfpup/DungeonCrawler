namespace DungeonCrawler.Monster
{
    abstract class Monster
    {
        public abstract int Strength { get; set; }
        public abstract int Agility { get; set; }
        public abstract int Intellect { get; set; }
        public abstract int Spirit { get; set; }
        public abstract int Stamina { get; set; }
        public abstract int HP { get; set; }
        public abstract int MP { get; set; }
        public abstract int XP { get; set; }
        public abstract int Armor { get; set; }
        public abstract int MagicDefense { get; set; }
    }
}
