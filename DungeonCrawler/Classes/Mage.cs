namespace DungeonCrawler.Classes
{
    class Mage : Character
    {
        public string ClassName { get; set; }
        public override int Strength { get; set; }
        public override int Agility { get; set; }
        public override int Intellect { get; set; }
        public override int Spirit { get; set; }
        public override int Stamina { get; set; }
        public override int HP { get; set; }
        public override int MP { get; set; }
        public override int XP { get; set; }
        public override int Armor { get; set; }
        public override int MagicDefense { get; set; }

        public Mage(int strength, int agility, int intellect, int spirit, int stamina, string name)
        {
            ClassName = "Mage";
            Strength = strength;
            Agility = agility;
            Intellect = intellect;
            Spirit = spirit;
            Stamina = stamina;
            characterName = name;
        }
    }
}
