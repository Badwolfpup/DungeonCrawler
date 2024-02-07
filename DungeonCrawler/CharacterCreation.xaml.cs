using DungeonCrawler.Classes;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using System.Reflection;
using System.ComponentModel;

namespace DungeonCrawler

{
    public partial class CharacterCreation : Page, INotifyPropertyChanged
    {
        public ObservableCollection<Character> characterList { get; set; }

        private int _Strength = 12;
        private int _Agility = 12;
        private int _Intellect = 12;
        private int _Spirit = 12;
        private int _Stamina = 12;
        private int _unassignedPoints = 12;

        int unassignedPoints;

        public int Strength
        {
            get { return _Strength; }
            set
            {
                if (_Strength != value)
                {
                    _Strength = value;
                    OnPropertyChanged(nameof(Strength));
                }
            }
        }
        public int Agility
        {
            get { return _Agility; }
            set
            {
                if (_Agility != value)
                {
                    _Agility = value;
                    OnPropertyChanged(nameof(Agility));
                }
            }
        }
        public int Intellect
        {
            get { return _Intellect; }
            set
            {
                if (_Intellect != value)
                {
                    _Intellect = value;
                    OnPropertyChanged(nameof(Intellect));
                }
            }
        }
        public int Spirit
        {
            get { return _Spirit; }
            set
            {
                if (_Spirit != value)
                {
                    _Spirit = value;
                    OnPropertyChanged(nameof(Spirit));
                }
            }
        }
        public int Stamina
        {
            get { return _Stamina; }
            set
            {
                if (_Stamina != value)
                {
                    _Stamina = value;
                    OnPropertyChanged(nameof(Stamina));
                }
            }
        }
        public int UnassignedPoints
        {
            get { return _unassignedPoints; }
            set
            {
                if (_unassignedPoints != value)
                {
                    _unassignedPoints = value;
                    OnPropertyChanged(nameof(UnassignedPoints));
                }
            }
        }

        int selectedChar;
        private readonly MainWindow parentWindow;

        private Border? _border = null;
        public ICommand ChangeStats {  get; set; }

        private string _classIsChecked = "Paladin";

        public event PropertyChangedEventHandler? PropertyChanged;

        public CharacterCreation(MainWindow w)
        {
            InitializeComponent();
            parentWindow = w;
            DataContext = this;
            ChangeStats = new RelayCommand(IncrementOrDecrement);
            characterList = new ObservableCollection<Character>();
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void IncrementOrDecrement(object parameter)
        {
            if (parameter is string[] param)
            {
                string stat = param[0];
                bool IncOrDec = bool.Parse(param[1]);
                int tempstat;

                Type type = this.GetType();
                PropertyInfo p = type.GetProperty(stat);
                tempstat = (int)p.GetValue(this);

                if (IncOrDec)
                {
                    if (tempstat < 20 && UnassignedPoints !=0)
                    {
                        tempstat++;
                        p.SetValue(this, tempstat, null);
                        UnassignedPoints--;
                    }
                } else
                {
                    tempstat--;
                    p.SetValue(this, tempstat, null);
                    UnassignedPoints++;
                }
            }
        }



       
        private void CreateChar_Click(object sender, RoutedEventArgs e)
        {
            if (CharName.Text != "")
            {
                if(characterList.Count < 4) 
                {
                    Type type = Type.GetType("DungeonCrawler.Classes." + _classIsChecked);
                    if (type != null)
                    {
                        var p = (Character)Activator.CreateInstance(type, CharName.Text, 12, 12, 12, 12, 12, 100, 100, 0, 100, 100);
                        characterList.Add(p);
                        
                    }
                }
                else MessageBox.Show("You have reached the maximum number of characters. " +
                    "You need to delete a character from your party before adding new ones");
            }
            else MessageBox.Show("You need to give the character a name first");
  
        }



        private void deleteChar_Click(object sender, RoutedEventArgs e)
        {
            if (_border != null)
            {
                Character c = _border.DataContext as Character;
                characterList.Remove(c);
            }
        }

        private void createParty_Click(object sender, RoutedEventArgs e)
        {
            if (characterList.Count > 3)
            {
                SaveParty.SaveToFile(characterList);
                parentWindow.closeCharCreatePage();
                //characterList.Clear();
                //characterList = SaveParty.LoadFromFile();
                //addCharToPartyGrid();
            }
            else MessageBox.Show("You need to add 4 characters to the party");
        }

 

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton r = (RadioButton)sender;
            _classIsChecked = r.Content.ToString();
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Border clickedBorder = sender as Border;
            if (_border != null)
            {
                _border.BorderBrush = Brushes.Coral;
            }
            clickedBorder.BorderBrush = Brushes.Blue;
            _border = clickedBorder;
        }
    }
}
