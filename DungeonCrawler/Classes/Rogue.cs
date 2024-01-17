using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler.Classes
{
    class Rogue : Character
    {
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
    }
}
