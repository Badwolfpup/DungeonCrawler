﻿namespace DungeonCrawler.Classes
{
    class Mage : Character
    {
        public string ClassName { get; set; }
        public string IconPath { get; set; }

        public Mage(string charactername, int strength, int agility, int intellect, int spirit, int stamina, int hp, int mp, int xp, int armor, int magicdefense, string saveid)
            : base(charactername, strength, agility, intellect, spirit, stamina, hp, mp, xp, armor, magicdefense, saveid)
        {
            ClassName = "Mage";
            IconPath = "pack://application:,,,/DungeonCrawler;component/Image/Icon/mage%20ikon.jpg";
        }
    }
}
