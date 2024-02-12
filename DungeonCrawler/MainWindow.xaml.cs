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
        Frame frame;
        private Rooms.Room _currentRoom;
        private Character _clickedcharacter;

        private ObservableCollection<Character> _characterlist;

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
        public MainWindow()
        {
            InitializeComponent();
            StartPagePage();
            DataContext = this;
            RoomsList = new ObservableCollection<Rooms.Room> { new Rooms.Room() };
            CurrentRoom = RoomsList.Last();
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void closeCharCreatePage()
        {
            Content = null;
        }

        private void StartPagePage()
        {
            StartPage s = new StartPage(this);
            Content = s;
        }

        public void CharacterCreationPage()
        {
            Content = null;
            CharacterCreation c = new CharacterCreation(this);
            Content = c;
        }

        public void ClosePage(ObservableCollection<Character> c)
        {
            CharacterList = c;
            ClickedCharacter = CharacterList.First();
            Content = MainGrid;

        }

        private void Border_MouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Border border = sender as Border;
            ClickedCharacter = border.DataContext as Character;
        }
    }
}
