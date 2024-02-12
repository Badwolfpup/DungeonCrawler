﻿namespace DungeonCrawler.Classes
{
    public class Character
    {
        public string CharacterName { get; set; }
        public int Strength { get; set; }
        public int Agility { get; set; }
        public int Intellect { get; set; }
        public int Spirit { get; set; }
        public int Stamina { get; set; }

        public int MaxHP { get; set; }

        public int CurrentHP { get; set; }
        public int MaxMP { get; set; }

        public int CurrentMP { get; set; }
        public int XP { get; set; }

        public int Armor { get; set; }
        public int MagicDefense { get; set; }

        public Character(string charactername, int str, int agi, int inte, int spi, int sta, int hp, int mp, int xp, int armor, int magicdefense)
        {
            CharacterName = charactername;
            Strength = str;
            Agility = agi;
            Intellect = inte;
            Spirit = spi;
            Stamina = sta;
            MaxHP = hp;
            CurrentHP = hp;

            MaxMP = mp;
            CurrentMP = mp;
            XP = xp;
            Armor = armor;
            MagicDefense = magicdefense;
        }
    }
}
