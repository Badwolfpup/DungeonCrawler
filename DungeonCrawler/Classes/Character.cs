using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler.Classes
{
    abstract class Character
    {
        public string characterName { get; set; }
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
