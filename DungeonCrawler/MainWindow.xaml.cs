using DungeonCrawler.Classes;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.TextFormatting;

namespace DungeonCrawler
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        #region private Fields
        private Rooms.Room _currentRoom;
        private Character _clickedcharacter;

        private ObservableCollection<Character> _characterlist;

        #endregion

        #region Public properties
        public ObservableCollection<Rooms.Room> RoomsList { get; set; }
        public ObservableCollection<Character> CharacterList
        {
            get { return _characterlist; }
            set
            {
                if (_characterlist != value)
                {
                    _characterlist = value;
                    OnPropertyChanged(nameof(CharacterList));
                }
            }

        }

        public Rooms.Room CurrentRoom
        {
            get { return _currentRoom; }
            set
            {
                if (_currentRoom != value)
                {
                    _currentRoom = value;
                    OnPropertyChanged(nameof(CurrentRoom));
                }
            }
        }
        public Character ClickedCharacter
        {
            get { return _clickedcharacter; }
            set
            {
                if (_clickedcharacter != value)
                {
                    _clickedcharacter = value;
                    OnPropertyChanged(nameof(ClickedCharacter));
                }
            }
        }

        #endregion
        public MainWindow()
        {
            InitializeComponent();
            StartPagePage();
            DataContext = this;
            RoomsList = new ObservableCollection<Rooms.Room> { new Rooms.Room() };
            CurrentRoom = RoomsList.Last();
        }

        //Implementering från INotifyPropertyChanged
        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName) //Metoden skickar en signal till UI att propertyt man skickar med (propertyname) har uppdateras
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        private void StartPagePage() //Skapar en instans av StartPage och sätter content i MainWindow till StartPage
        {
            StartPage s = new StartPage(this);
            Content = s;
        }

        public void CharacterCreationPage() //Skapar en instans av CharacterCreation och sätter content i MainWindow till CharacterCreation
        {
            Content = null;
            CharacterCreation c = new CharacterCreation(this);
            Content = c;
        }

        public void ClosePage(ObservableCollection<Character> c) //Stänger den aktiva Page och laddar CharacterList med den skapade/laddade partyt
        {
            CharacterList = c;
            ClickedCharacter = CharacterList.First();
            Content = MainGrid;

        }

        private void Border_MouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e) //Sätter vilken 
        {
            //I object sender får man med det UI-element som man interagerat med.
            //För att man ska kunna tilldela det till ett typ av objekt måste man casta det, här genom sender as Border
            Border border = sender as Border;

            //Sparar ner datan från den Border vi har klickat på. UI hämtar data från ClickedCharacter
            ClickedCharacter = border.DataContext as Character;
        }

        private void Window_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Up)
            {
                RoomsList.Add(new Rooms.Room());
                CurrentRoom = RoomsList.Last();
            }
        }
    }
}
