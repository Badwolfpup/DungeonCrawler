using System.Collections.ObjectModel;
using System.ComponentModel;

namespace DungeonCrawler.Classes
{
    public class Character
    {
        #region private properties
        private string _charactername;
        private int _strength;
        private int _agility;
        private int _intellect;
        private int _spirit;
        private int _stamina;
        private int _maxhp;
        private int _currenthp;
        private int _maxmp;
        private int _currentmp;
        private int _xp;
        private int _level;
        private int _armor;
        private int _magicdefense;
        #endregion

        #region public properties
        public string CharacterName
        {
            get { return _charactername; }
            set
            {
                if (_charactername != value)
                {
                    _charactername = value;
                    OnPropertyChanged(nameof(CharacterName));
                }
            }
        }
        public int Strength
        {
            get { return _strength; }
            set
            {
                if (_strength != value)
                {
                    _strength = value;
                    OnPropertyChanged(nameof(Strength));
                }
            }
        }
        public int Agility
        {
            get { return _agility; }
            set
            {
                if (_agility != value)
                {
                    _agility = value;
                    OnPropertyChanged(nameof(Agility));
                }
            }
        }
        public int Intellect
        {
            get { return _intellect; }
            set
            {
                if (_intellect != value)
                {
                    _intellect = value;
                    OnPropertyChanged(nameof(Intellect));
                }
            }
        }
        public int Spirit
        {
            get { return _spirit; }
            set
            {
                if (_spirit != value)
                {
                    _spirit = value;
                    OnPropertyChanged(nameof(Spirit));
                }
            }
        }
        public int Stamina
        {
            get { return _stamina; }
            set
            {
                if (_stamina != value)
                {
                    _stamina = value;
                    OnPropertyChanged(nameof(Stamina));
                }
            }
        }
        public int MaxHP
        {
            get { return _maxhp; }
            set
            {
                if (_maxhp != value)
                {
                    _maxhp = value;
                    OnPropertyChanged(nameof(MaxHP));
                }
            }
        }

        public int CurrentHP
        {
            get { return _currenthp; }
            set
            {
                if (_currenthp != value)
                {
                    _currenthp = value;
                    OnPropertyChanged(nameof(_currenthp));
                }
            }
        }
        public int MaxMP
        {
            get { return _maxmp; }
            set
            {
                if (_maxmp != value)
                {
                    _maxmp = value;
                    OnPropertyChanged(nameof(MaxMP));
                }
            }
        }

        public int CurrentMP
        {
            get { return _currentmp; }
            set
            {
                if (_currentmp != value)
                {
                    _currentmp = value;
                    OnPropertyChanged(nameof(CurrentMP));
                }
            }
        }
        public int XP
        {
            get { return _xp; }
            set
            {
                if (_xp != value)
                {
                    _xp = value;
                    OnPropertyChanged(nameof(XP));
                }
            }
        }

        public int Level
        {
            get { return _level; }
            set
            {
                if (_level != value)
                {
                    _level = value;
                    OnPropertyChanged(nameof(Level));
                }
            }
        }

        public int Armor
        {
            get { return _armor; }
            set
            {
                if (_armor != value)
                {
                    _armor = value;
                    OnPropertyChanged(nameof(Armor));
                }
            }
        }
        public int MagicDefense
        {
            get { return _magicdefense; }
            set
            {
                if (_magicdefense != value)
                {
                    _magicdefense = value;
                    OnPropertyChanged(nameof(MagicDefense));
                }
            }
        }

        #endregion

        public string SaveID { get; set; }


        public Character(string charactername, int str, int agi, int inte, int spi, int sta, int hp, int mp, int xp, int armor, int magicdefense, string saveID)
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
            Level = 1;
            SaveID = saveID;
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
