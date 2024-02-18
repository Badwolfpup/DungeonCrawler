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

        #region private fields
        private int _Strength = 12;
        private int _Agility = 12;
        private int _Intellect = 12;
        private int _Spirit = 12;
        private int _Stamina = 12;
        private int _unassignedPoints = 12;
        #endregion

        #region public properties
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
        #endregion
        
        //Håller vårt Main Window så att vi har en koppling tillbaka
        private readonly MainWindow parentWindow;

        //Håller den border vi har klickat på. Initialt null eftersom vi inte har klickat på något.
        private Border? _border = null;
        public ICommand ChangeStats {  get; set; }

        //Håller värdet från den Radiobutton som vi klickar på. Eftersom Paladin är förvalt när programmet startar sätts det till initalt värde.
        private string _classIsChecked = "Paladin";

        //Håller ID-nyckeln för saven
        private string _saveID;

        //Implementering från INotifyPropertyChanged
        public event PropertyChangedEventHandler? PropertyChanged;

        public CharacterCreation(MainWindow w)
        {
            InitializeComponent();
            parentWindow = w;
            _saveID = GenerateSaveID();
            DataContext = this; //Datakontext säger var UI ska hämta sin data
            ChangeStats = new RelayCommand(IncrementOrDecrement); //Command 
            characterList = new ObservableCollection<Character>(); //Håller en lista över de skapade karaktärerna
        }

        protected virtual void OnPropertyChanged(string propertyName) //Metoden skickar en signal till UI att propertyt man skickar med (propertyname) har uppdateras
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private string GenerateSaveID() //Genererar ett unikt ID för varje save
        {
            string x = "";
            Random r = new Random();
            for (int i = 0; i < 10; i++)
            {
                x += r.Next(10).ToString();
            }
            return x;
        }

        private void IncrementOrDecrement(object parameter) //Ökar eller minskar valt property
        {
            //Kontrollerar att parameterna man har skickat med är en stringarray
            if (parameter is string[] param) 
            {
                //Namnet på den property man vill ändra. Anges i XAML.
                string stat = param[0];
                
                //Boolvärde, i stringformat, för om värdet ska ökas eller minskas. Anges i XAML. 
                bool IncOrDec = bool.Parse(param[1]);
                
                //Temporärt värde som håller värdet på propertyt man ändrar
                int tempstat;

                //Type kan vara vilken klass som helst. Används när man dynamiskt vill manipulera en klass. This i This.GetType() säger att det är klassen man befinner sig i.
                Type type = this.GetType();

                //PropertyInfo kan vara vilket property som helst. Användsa när man vill ändra eller läsa ett property utan att veta namnet på det.
                //Vi anger vilket property genom GetProperty("namnet på property som en string")
                PropertyInfo p = type.GetProperty(stat); 
                
                //Vi hämtar själv värdet på property med GetValue(). This säger att värdet finns i den klass vi befinner oss i. 
                //Vi behöver casta värdet med imlicit typecasting, (int), variabeltypen inom parantes före värdet vi castar från
                tempstat = (int)p.GetValue(this);

                //Kollar om det ska öka eller minska
                if (IncOrDec)
                {
                    //Villkor för när man kan öka värdet
                    if (tempstat < 20 && UnassignedPoints !=0)
                    {
                        tempstat++;
                        
                        //Sätter ett nytt värde på det property vi vill ändra på. This anger att property finns i samma klass som vi befinner oss i
                        //tempstat är det nya värdet. Null anger att property inte är en lista av något slag.
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



       
        private void CreateChar_Click(object sender, RoutedEventArgs e) //Skapar instanser av den typ av karaktär vi valt att lägga till i partyt.
        {
            //Kollar att TextBoxen inte är tom, d v s att karaktären har ett namn
            if (CharName.Text != "")
            {
                //Kollar att man inte överskrider mazximalt antal karaktärer i partyt.
                if(characterList.Count < 4) 
                {
                    //Type kan innehålla vilken klass som helst och används när man dynamiskt vill hantera klasser, d v s att man inte vet vilket klass i förväg
                    //GetType() är metoden som hämtar vilken typ av klass. Man skickar med genvägen till klassen som en string, inklusive mappar.
                    Type type = Type.GetType("DungeonCrawler.Classes." + _classIsChecked); //Vi hämtar namnet på klassen från Content i Radiobutton
                    
                    //Kontroll att den faktiskt klassen vi skapar ovan finns.
                    if (type != null)
                    {
                        //Skapar själva instansen av klassen med hjälp av Activator.CreateInstance.
                        //Vi skickar med type för att berätta vilken klass den ska skapa samt alla värden som klassens konstruktor kräver.
                        //Eftersom vi sparar klassen som dess Parent klass behöver typ type casta till Parent klassen (Character)
                        var p = (Character)Activator.CreateInstance(type, CharName.Text, 12, 12, 12, 12, 12, 100, 100, 0, 100, 100, _saveID);
                    
                        //Den skapade klassen läggs till i vår lista över Characters
                        characterList.Add(p);

                        //Återställer namn och stats
                        CharName.Text = "";
                        Strength = 12; Agility = 12; Intellect = 12; Spirit = 12; Stamina = 12; UnassignedPoints = 12;
                    }
                }
                else MessageBox.Show("You have reached the maximum number of characters. " +
                    "You need to delete a character from your party before adding new ones");
            }
            else MessageBox.Show("You need to give the character a name first");
  
        }



        private void deleteChar_Click(object sender, RoutedEventArgs e) //Raderar vald karaktär från listan
        {
            //Kollar att man faktiskt har klickat på en karaktär
            if (_border != null)
            {
                //Man hämtar vilken instans av Character genom .Datacontext. Character c är inte en kopia utan en pekare som pekar på instansen av klassen.
                Character c = _border.DataContext as Character;
                
                //Raderar klassen från listan
                characterList.Remove(c);
            }
            else MessageBox.Show("You need to select a character before you can delete it");
        }

        private void createParty_Click(object sender, RoutedEventArgs e)
        {
            //Kollar att man har fyllt partyt
            if (characterList.Count > 3)
            {
                //Skickar med listan till metoden SaveToFile, som är en statisk meetod i klassen SaveParty
                SaveParty.SaveToFile(characterList);
                
                //Callar en metod i MainWindow, som stänger ner vår Page
                parentWindow.ClosePage(characterList);
            }
            else MessageBox.Show("You need to add 4 characters to the party");
        }

 

        private void RadioButton_Checked(object sender, RoutedEventArgs e) //Ändrar stringvariablen som håller koll på vilken klass man vill lägga till i partyt
        {
            //I object sender får man med det UI-element som man interagerat med.
            //För att man ska kunna tilldela det till ett typ av objekt måste man casta det, här genom (RadioButton)sender
            RadioButton r = (RadioButton)sender;
            _classIsChecked = r.Content.ToString();
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e) //Ändrar färg på den border man klickar på samt sparar ner den så att man kan komma åt dess datacontext
        {
            //I object sender får man med det UI-element som man interagerat med.
            //För att man ska kunna tilldela det till ett typ av objekt måste man casta det, här genom sender as Border
            Border clickedBorder = sender as Border;
            
            //Innan man klickat försat gången på någon border är den null. Då behöver ingen färg ändras tillbaka.
            if (_border != null)
            {
                _border.BorderBrush = Brushes.Coral;
            }
            //Sätter ny färg på den Border som klickats på.
            clickedBorder.BorderBrush = Brushes.Blue;
             _border = clickedBorder;
        }
    }
}
