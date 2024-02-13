using DungeonCrawler.Rooms.EventClasses;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler.Rooms
{
    public class Room : INotifyPropertyChanged
    {
        //Implementering från INotifyPropertyChanged
        public event PropertyChangedEventHandler? PropertyChanged;

        #region Private Fields
        private ObservableCollection<BaseEvent> _eventList;

        private string _description;
        #endregion

        #region Public properties
        public ObservableCollection<BaseEvent> EventList //Lista över events i ett room
        {
            get { return _eventList; }
            set
            {
                if (_eventList != value)
                {
                    _eventList = value;
                    OnPropertyChanged(nameof(EventList));
                }
            }
        } 
        public string Description //Beskrivning av room
        {
            get { return _description; }
            set
            {
                _description = value;
                OnPropertyChanged(nameof(Description));
            }
        }
        #endregion
        public Room()
        {
            Description = RoomDescription();
            EventList = new ObservableCollection<BaseEvent>();
            AddEvent();
        }
        protected virtual void OnPropertyChanged(string propertyName) //Metoden skickar en signal till UI att propertyt man skickar med (propertyname) har uppdateras
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private string RoomDescription() //Genererar slumpmässig bskrivning av ett Room
        {
            string[] environment = { "The walls are lined with moss", "On the floor you see a skeleton of an unfortunate adventurer", "In the center of the room there is a puddle of an unknown substance" };

            string[] feeling = { "The hair of your neck stand up", "Chills run down your spine", "At any moment you expect something to attack you" };

            Random r = new Random();
            return $"{environment[r.Next(environment.Length)]} \n{feeling[r.Next(feeling.Length)]}";
        }

        private void AddEvent() //Lägger till event till ett Room
        {
            Random r = new Random();
            int x = r.Next(10);
            if (x < 10)
            {
                EventList.Add(new Enemy());
            }
        }
    }
}
