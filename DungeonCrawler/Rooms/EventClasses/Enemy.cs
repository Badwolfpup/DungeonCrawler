using DungeonCrawler.MonsterClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler.Rooms.EventClasses
{
    public class Enemy : BaseEvent, INotifyPropertyChanged
    {
        #region Private Fields
        private string _EventText;

        #endregion

        #region Public properties
        public string EventText
        {
            get { return _EventText; }
            set
            {
                if (_EventText != value)
                {
                    _EventText = value;
                    OnPropertyChanged(nameof(EventText));
                }
            }
        }

        #endregion
        public BaseMonster selectedMonster { get; set; } //Det monster som slumpats fram

        //Implementering från INotifyPropertyChanged
        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName) //Metoden skickar en signal till UI att propertyt man skickar med (propertyname) har uppdateras
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public Enemy()
        {
            SelectMonster();
        }

        public void SelectMonster()
        {
            string[]? classFiles; //Håller genvägen till alla klasser som finns i foldern
            string folderName = @"..\..\..\MonsterClasses\Monster\"; //Namn på den folder man hittar filerna i. ..\..\..\ säger hur många mappar bakåt man ska gå
            string currentDirectory = AppDomain.CurrentDomain.BaseDirectory; //Genväg till den folder som exe.filen är i. Default är bin\Debug\net7.0-windows från projektmappen
            string folderPath = Path.GetFullPath(Path.Combine(currentDirectory + folderName)); //Ger den korrekt genvägen till foldern där filerna finns. 
            if (Directory.Exists(folderPath)) //Kollar att foldern existerar
            {
                //Laddar ner genvägen till alla klasser i foldern
                classFiles = Directory.GetFiles(folderPath, "*.cs"); 

                //Kollar att det finns minst en klass i foldern
                if (classFiles.Length > 0) 
                {
                    Random r = new Random();

                    //Slumpar fram en av genvägarna till klasserna
                    string randommizedClass = classFiles[r.Next(classFiles.Length)];

                    //Hämtar klassens namn, utan filändelser
                    string className = Path.GetFileNameWithoutExtension(randommizedClass);

                    //Type kan vara vilken klass som helst. Används när man dynamiskt vill manipulera en klass. Man skickar med klassens namn, inlkusive mappgenväg, som en string
                    Type type = Type.GetType("DungeonCrawler.MonsterClasses.Monster." + className);

                    //Kollar att det gick att skapa en klass av typen man skickade med
                    if (type != null)
                    {
                        //Skapar själva instansen av klassen med hjälp av Activator.CreateInstance.
                        //Vi skickar med type för att berätta vilken klass den ska skapa samt alla värden som klassens konstruktor kräver.
                        //Eftersom vi sparar klassen som dess Parent klass behöver typ type casta till Parent klassen (BaseMonster)
                        selectedMonster = (BaseMonster)Activator.CreateInstance(type, className, 12, 12, 12, 12, 12, 100, 100, 0, 100, 100, 1);

                        //Den text som visas i UI
                        EventText = $"You are attacked by a {className}!";
                    }
                }
            }
        }
    }
}
