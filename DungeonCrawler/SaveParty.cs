using DungeonCrawler.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.Windows.Documents;

namespace DungeonCrawler
{
    static class SaveParty
    {
        private static string folderName = @"..\..\..\Savefiles\";
        private static string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
        private static string folderPath = Path.GetFullPath(Path.Combine(currentDirectory + folderName));
        public static void SaveToFile(ObservableCollection<Character> party) 
        {
            int numberSaves = Directory.GetFiles(folderPath).Length;
            string filePath = folderPath + "Savefile" + (numberSaves + 1).ToString() + ".json";

            JsonSerializerSettings settings = new JsonSerializerSettings()
            {
                TypeNameHandling = TypeNameHandling.All
            };
            string savefile = JsonConvert.SerializeObject(party, settings);
            File.WriteAllText(filePath, savefile);
        }

        public static ObservableCollection<ObservableCollection<Character>> LoadFromFile()
        {
            ObservableCollection<ObservableCollection<Character>> list = new ObservableCollection<ObservableCollection<Character>>();

            if (Directory.Exists(folderPath))
            {
                JsonSerializerSettings settings = new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.All
                };
                foreach (string filePath in Directory.GetFiles(folderPath, "*.json"))
                {
                    string savefile = File.ReadAllText(filePath);
                    if (!string.IsNullOrEmpty(savefile))
                    {
                        ObservableCollection<Character> c = JsonConvert.DeserializeObject<ObservableCollection<Character>>(savefile, settings);
                        list.Add(c);

                    }
                }
            }
            return list;
        }
    }
}
