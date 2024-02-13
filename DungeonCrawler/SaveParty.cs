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
        //Namn på den folder man hittar filerna i. ..\..\..\ säger hur många mappar bakåt man ska gå
        private static string folderName = @"..\..\..\Savefiles\";

        //Genväg till den folder som exe.filen är i. Default är bin\Debug\net7.0-windows från projektmappen
        private static string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
        
        //Ger den korrekt genvägen till foldern där filerna finns. 
        private static string folderPath = Path.GetFullPath(Path.Combine(currentDirectory + folderName));
        
        public static void SaveToFile(ObservableCollection<Character> party) //Sparar ner klasserna i en json-fil. Saknar logik för att hantera när man raderat filer
        {
            //Kolla hur många filer som finns i foldern
            int numberSaves = Directory.GetFiles(folderPath).Length;

            //Skapar en full filgenväg, inklusive filnamn och filändelse
            string filePath = folderPath + "Savefile" + (numberSaves + 1).ToString() + ".json";

            JsonSerializerSettings settings = new JsonSerializerSettings() 
            {
                TypeNameHandling = TypeNameHandling.All //TypeNameHandling.All gör att Child-klassen hanteras i json-filen
            };

            //Sparar ner klassen i en string enligt det format som json sparas i
            string savefile = JsonConvert.SerializeObject(party, settings);
            
            //Skapar json-filen
            File.WriteAllText(filePath, savefile);
        }

        public static ObservableCollection<ObservableCollection<Character>> LoadFromFile() //Laddar i alla savefiler i en lista
        {
            //Eftersom varje savefil innehåller en lista av karaktärer behöver i en lista i en lista
            ObservableCollection<ObservableCollection<Character>> list = new ObservableCollection<ObservableCollection<Character>>();

            //Kollar att foldern existerar
            if (Directory.Exists(folderPath))
            {
                JsonSerializerSettings settings = new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.All //TypeNameHandling.All gör att Child-klassen hanteras i json-filen
                };

                //Läser in filgenvägen en fil i taget
                foreach (string filePath in Directory.GetFiles(folderPath, "*.json"))
                {
                    //Läser in savefilen i en string
                    string savefile = File.ReadAllText(filePath);

                    //Kollar att savefilen inte är tom
                    if (!string.IsNullOrEmpty(savefile))
                    {
                        //Laddar in savefilen i en lista. JsonConvert.DeserializeObject sköter konverteringen av text till instanser av klasser
                        ObservableCollection<Character> c = JsonConvert.DeserializeObject<ObservableCollection<Character>>(savefile, settings);
                        list.Add(c);
                    }
                }
            }
            return list;
        }

        public static void DeleteSaveFile(string saveid) //Identisk med LoadFile ovan förutom en sak
        {
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
                        if (c[0].SaveID == saveid) //Kollar att saveID på den valda saven stämmer överrens med den i json-filen
                        {
                            File.Delete(filePath); //Deletar filer
                            return; //Avbryter metoden
                        }

                    }

                }
            }
        }
    }
}
