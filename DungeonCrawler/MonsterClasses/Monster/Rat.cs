﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler.MonsterClasses.Monster
{
    public class Rat : BaseMonster
    {
        public Rat(string charactername, int str, int agi, int inte, int spi, int sta, int hp, int mp, int xp, int armor, int magicdefense, int level) 
            : base(charactername, str, agi, inte, spi, sta, hp, mp, xp, armor, magicdefense, level)
        {
        }
    }
}
