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
        private string _EventText;

        public BaseMonster selectedMonster { get; set; }
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

        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public Enemy()
        {
            SelectMonster();
        }

        public void SelectMonster()
        {
            string[]? classFiles;
            string folderName = @"..\..\..\MonsterClasses\Monster\";
            string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string folderPath = Path.GetFullPath(Path.Combine(currentDirectory + folderName));
            if (Directory.Exists(folderPath))
            {
                classFiles = Directory.GetFiles(folderPath, "*.cs");

                if (classFiles.Length > 0) 
                {
                    Random r = new Random();
                    string randommizedClass = classFiles[r.Next(classFiles.Length)];
                    string className = Path.GetFileNameWithoutExtension(randommizedClass);
                    Type type = Type.GetType("DungeonCrawler.MonsterClasses.Monster." + className);
                    if (type != null)
                    {
                        selectedMonster = (BaseMonster)Activator.CreateInstance(type, className, 12, 12, 12, 12, 12, 100, 100, 0, 100, 100, 1);
                        EventText = $"You are attacked by a {className}!";
                    }
                }
            }
        }
    }
}
