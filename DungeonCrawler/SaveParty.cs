using DungeonCrawler.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace DungeonCrawler
{
    static class SaveParty
    {
        private static readonly string filePath = @"C:\Users\h09825\source\repos\DungeonCrawler\party.json";
        public static void SaveToFile(ObservableCollection<Character> party) 
        {
            JsonSerializerSettings settings = new JsonSerializerSettings()
            {
                TypeNameHandling = TypeNameHandling.All
            };
            string savefile = JsonConvert.SerializeObject(party, settings);
            File.WriteAllText(filePath, savefile);
        }

        public static List<Character> LoadFromFile()
        {
            List<Character> list = new List<Character>();
            JsonSerializerSettings settings = new JsonSerializerSettings()
            {
                TypeNameHandling = TypeNameHandling.All
            };

            if (File.Exists(filePath))
            {
                string savefile = File.ReadAllText(filePath);
                if (!string.IsNullOrEmpty(savefile)) 
                {
                    list = JsonConvert.DeserializeObject<List<Character>>(savefile, settings);
                }
            }
            return list;
        }
    }
}
