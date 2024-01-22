using DungeonCrawler.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace DungeonCrawler
{
    /// <summary>
    /// Interaction logic for CharacterCreation.xaml
    /// </summary>
    public partial class CharacterCreation : Page
    {
        List<Character> characterList = new List<Character>();
        int unassignedPoints = 12;
        public CharacterCreation()
        {
            InitializeComponent();
            unassignedText.Text = $"Unassigned points: {unassignedPoints.ToString()}";
        }

        #region ChangeStats
        private void StrPlus_Click(object sender, RoutedEventArgs e)
        {
            int x;
            int.TryParse(StrValue.Text, out x);
            if (x < 20 && unassignedPoints > 0)
            {
                x++;
                StrValue.Text = x.ToString();
                unassignedPoints--;
                unassignedText.Text = $"Unassigned points: {unassignedPoints.ToString()}";
            }
        }

        private void StrMinus_Click(object sender, RoutedEventArgs e)
        {
            int x;
            int.TryParse(StrValue.Text, out x);
            if (x > 0)
            {
                x--;
                StrValue.Text = x.ToString();
                unassignedPoints++;
                unassignedText.Text = $"Unassigned points: {unassignedPoints.ToString()}";
            }
        }

        private void AgiPlus_Click(object sender, RoutedEventArgs e)
        {
            int x;
            int.TryParse(AgiValue.Text, out x);
            if (x < 20)
            {
                x++;
                AgiValue.Text = x.ToString();
                unassignedPoints--;
                unassignedText.Text = $"Unassigned points: {unassignedPoints.ToString()}";
            }
        }

        private void AgiMinus_Click(object sender, RoutedEventArgs e)
        {
            int x;
            int.TryParse(AgiValue.Text, out x);
            if (x > 0)
            {
                x--;
                AgiValue.Text = x.ToString();
                unassignedPoints++;
                unassignedText.Text = $"Unassigned points: {unassignedPoints.ToString()}";
            }
        }


        private void IntPlus_Click(object sender, RoutedEventArgs e)
        {
            int x;
            int.TryParse(IntValue.Text, out x);
            if (x < 20 && unassignedPoints > 0)
            {
                x++;
                IntValue.Text = x.ToString();
                unassignedPoints--;
                unassignedText.Text = $"Unassigned points: {unassignedPoints.ToString()}";
            }
        }

        private void IntMinus_Click(object sender, RoutedEventArgs e)
        {
            int x;
            int.TryParse(IntValue.Text, out x);
            if (x > 0)
            {
                x--;
                IntValue.Text = x.ToString();
                unassignedPoints++;
                unassignedText.Text = $"Unassigned points: {unassignedPoints.ToString()}";
            }
        }

        private void SpiPlus_Click(object sender, RoutedEventArgs e)
        {
            int x;
            int.TryParse(SpiValue.Text, out x);
            if (x < 20 && unassignedPoints > 0)
            {
                x++;
                SpiValue.Text = x.ToString();
                unassignedPoints--;
                unassignedText.Text = $"Unassigned points: {unassignedPoints.ToString()}";
            }
        }

        private void SpiMinus_Click(object sender, RoutedEventArgs e)
        {
            int x;
            int.TryParse(SpiValue.Text, out x);
            if (x > 0)
            {
                x--;
                SpiValue.Text = x.ToString();
                unassignedPoints++;
                unassignedText.Text = $"Unassigned points: {unassignedPoints.ToString()}";
            }
        }

        private void StaPlus_Click(object sender, RoutedEventArgs e)
        {
            int x;
            int.TryParse(StaValue.Text, out x);
            if (x < 20 && unassignedPoints > 0)
            {
                x++;
                StaValue.Text = x.ToString();
                unassignedPoints--;
                unassignedText.Text = $"Unassigned points: {unassignedPoints.ToString()}";
            }
        }

        private void StaMinus_Click(object sender, RoutedEventArgs e)
        {
            int x;
            int.TryParse(StaValue.Text, out x);
            if (x > 0)
            {
                x--;
                StaValue.Text = x.ToString();
                unassignedPoints++;
                unassignedText.Text = $"Unassigned points: {unassignedPoints.ToString()}";
            }
        }
        #endregion
        private void CreateChar_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(CharName.Text) && (CharName.Text.Length > 4 && CharName.Text.Length < 15))
            {
                if (characterList.Count < 4)
                {
                    if (RBPaladin.IsChecked == true)
                    {
                        int str, agi, inte, spi, sta;
                        int.TryParse(StrValue.Text, out str);
                        int.TryParse(AgiValue.Text, out agi);
                        int.TryParse(IntValue.Text, out inte);
                        int.TryParse(SpiValue.Text, out spi);
                        int.TryParse(StaValue.Text, out sta);
                        var p = new Paladin(str, agi, inte, spi, sta, CharName.Text);
                        characterList.Add(p);
                    }
                    else if (RBWarrior.IsChecked == true)
                    {
                        int str, agi, inte, spi, sta;
                        int.TryParse(StrValue.Text, out str);
                        int.TryParse(AgiValue.Text, out agi);
                        int.TryParse(IntValue.Text, out inte);
                        int.TryParse(SpiValue.Text, out spi);
                        int.TryParse(StaValue.Text, out sta);
                        var p = new Warrior(str, agi, inte, spi, sta, CharName.Text);

                    }
                    else if (RBRogue.IsChecked == true)
                    {
                        int str, agi, inte, spi, sta;
                        int.TryParse(StrValue.Text, out str);
                        int.TryParse(AgiValue.Text, out agi);
                        int.TryParse(IntValue.Text, out inte);
                        int.TryParse(SpiValue.Text, out spi);
                        int.TryParse(StaValue.Text, out sta);
                        var p = new Rogue(str, agi, inte, spi, sta, CharName.Text);
                        characterList.Add(p);
                    }
                    else if (RBRanger.IsChecked == true)
                    {
                        int str, agi, inte, spi, sta;
                        int.TryParse(StrValue.Text, out str);
                        int.TryParse(AgiValue.Text, out agi);
                        int.TryParse(IntValue.Text, out inte);
                        int.TryParse(SpiValue.Text, out spi);
                        int.TryParse(StaValue.Text, out sta);
                        var p = new Ranger(str, agi, inte, spi, sta, CharName.Text);
                        characterList.Add(p);
                    }
                    else if (RBMage.IsChecked == true)
                    {
                        int str, agi, inte, spi, sta;
                        int.TryParse(StrValue.Text, out str);
                        int.TryParse(AgiValue.Text, out agi);
                        int.TryParse(IntValue.Text, out inte);
                        int.TryParse(SpiValue.Text, out spi);
                        int.TryParse(StaValue.Text, out sta);
                        var p = new Mage(str, agi, inte, spi, sta, CharName.Text);
                        characterList.Add(p);
                    }
                    else if (RBPriest.IsChecked == true)
                    {
                        int str, agi, inte, spi, sta;
                        int.TryParse(StrValue.Text, out str);
                        int.TryParse(AgiValue.Text, out agi);
                        int.TryParse(IntValue.Text, out inte);
                        int.TryParse(SpiValue.Text, out spi);
                        int.TryParse(StaValue.Text, out sta);
                        var p = new Priest(str, agi, inte, spi, sta, CharName.Text);
                        characterList.Add(p);
                    }
                    saveFile();
                }
                else MessageBox.Show("You cannot add another character. Maximum party size is 4");
            }
            else if (string.IsNullOrEmpty(CharName.Text)) MessageBox.Show("You need to give the character a name");
            else MessageBox.Show("The character name must be between 5-14 characters long");
        }

        private void saveFile()
        {
            List<string> list = new List<string>();
            foreach(Character c in characterList)
            {
                string prop = "";
                if (c is Paladin)
                {
                    Paladin p = (Paladin)c;
                    prop = p.ClassName + "|";                   
                    prop += p.Strength.ToString() + "|";
                    prop += p.Agility.ToString() + "|";
                    prop += p.Intellect.ToString() + "|";
                    prop += p.Spirit.ToString() + "|";
                    prop += p.Stamina.ToString() + "|";
                    prop += p.characterName + "|";
                }
                else if (c is Warrior)
                {
                    Warrior p = (Warrior)c;
                    prop = p.ClassName + "|";
                    prop += p.Strength.ToString() + "|";
                    prop += p.Agility.ToString() + "|";
                    prop += p.Intellect.ToString() + "|";
                    prop += p.Spirit.ToString() + "|";
                    prop += p.Stamina.ToString() + "|";
                    prop += p.characterName + "|";
                }
                else if (c is Rogue)
                {
                    Rogue p = (Rogue)c;
                    prop = p.ClassName + "|";
                    prop += p.Strength.ToString() + "|";
                    prop += p.Agility.ToString() + "|";
                    prop += p.Intellect.ToString() + "|";
                    prop += p.Spirit.ToString() + "|";
                    prop += p.Stamina.ToString() + "|";
                    prop += p.characterName + "|";
                }
                else if (c is Ranger)
                {
                    Ranger p = (Ranger)c;
                    prop = p.ClassName + "|";
                    prop += p.Strength.ToString() + "|";
                    prop += p.Agility.ToString() + "|";
                    prop += p.Intellect.ToString() + "|";
                    prop += p.Spirit.ToString() + "|";
                    prop += p.Stamina.ToString() + "|";
                    prop += p.characterName + "|";
                }
                else if (c is Mage)
                {
                    Mage p = (Mage)c;
                    prop = p.ClassName + "|";
                    prop += p.Strength.ToString() + "|";
                    prop += p.Agility.ToString() + "|";
                    prop += p.Intellect.ToString() + "|";
                    prop += p.Spirit.ToString() + "|";
                    prop += p.Stamina.ToString() + "|";
                    prop += p.characterName + "|";
                }
                else if (c is Priest)
                {
                    Priest p = (Priest)c;
                    prop = p.ClassName + "|";
                    prop += p.Strength.ToString() + "|";
                    prop += p.Agility.ToString() + "|";
                    prop += p.Intellect.ToString() + "|";
                    prop += p.Spirit.ToString() + "|";
                    prop += p.Stamina.ToString() + "|";
                    prop += p.characterName + "|";
                }
                list.Add(prop);
            }
            File.WriteAllLines(@"C:\Bankapp\klasser.txt", list);
        }

        private void loadFile_Click(object sender, RoutedEventArgs e)
        {
            string[] list = File.ReadAllLines(@"C:\Bankapp\klasser.txt");
            List<string> prop = new List<string>();
            characterList.Clear();
            foreach (string s in list)
            {
                string x = "";
                foreach (char c in s)
                {
                    if (c != '|') x += c.ToString();
                    else
                    {
                        prop.Add(x.ToString());
                        x = "";
                    }
                }
                if (prop[0] == "Paladin")
                {
                    int str = int.Parse(prop[1]);
                    int agi = int.Parse(prop[2]);
                    int inte = int.Parse(prop[3]);
                    int spi = int.Parse(prop[4]);
                    int sta = int.Parse(prop[5]);
                    Paladin p = new Paladin(str, agi, inte, spi, sta, prop[6]);
                    characterList.Add(p);
                    partylist.Text += $"Name: {prop[6]} Class: {prop[0]} \n" +
                                      $"Str: {prop[1]} Agi: {prop[2]} Int: {prop[3]} Spi: {prop[4]} Sta: {prop[5]} \n";
                }
                else if (prop[0] == "Warrior") 
                {
                    int str = int.Parse(prop[1]);
                    int agi = int.Parse(prop[2]);
                    int inte = int.Parse(prop[3]);
                    int spi = int.Parse(prop[4]);
                    int sta = int.Parse(prop[5]);
                    Warrior p = new Warrior(str, agi, inte, spi, sta, prop[6]);
                    characterList.Add(p);
                    partylist.Text += $"Name: {prop[6]} Class: {prop[0]} \n" +
                           $"Str: {prop[1]} Agi: {prop[2]} Int: {prop[3]} Spi: {prop[4]} Sta: {prop[5]} \n";
                }
                else if (prop[0] == "Rogue")
                {
                    int str = int.Parse(prop[1]);
                    int agi = int.Parse(prop[2]);
                    int inte = int.Parse(prop[3]);
                    int spi = int.Parse(prop[4]);
                    int sta = int.Parse(prop[5]);
                    Rogue p = new Rogue(str, agi, inte, spi, sta, prop[6]);
                    characterList.Add(p);
                    partylist.Text += $"Name: {prop[6]} Class: {prop[0]} \n" +
                           $"Str: {prop[1]} Agi: {prop[2]} Int: {prop[3]} Spi: {prop[4]} Sta: {prop[5]} \n";
                }
                else if (prop[0] == "Ranger")
                {
                    int str = int.Parse(prop[1]);
                    int agi = int.Parse(prop[2]);
                    int inte = int.Parse(prop[3]);
                    int spi = int.Parse(prop[4]);
                    int sta = int.Parse(prop[5]);
                    Ranger p = new Ranger(str, agi, inte, spi, sta, prop[6]);
                    characterList.Add(p);
                    partylist.Text += $"Name: {prop[6]} Class: {prop[0]} \n" +
                           $"Str: {prop[1]} Agi: {prop[2]} Int: {prop[3]} Spi: {prop[4]} Sta: {prop[5]} \n";
                }
                else if (prop[0] == "Mage")
                {
                    int str = int.Parse(prop[1]);
                    int agi = int.Parse(prop[2]);
                    int inte = int.Parse(prop[3]);
                    int spi = int.Parse(prop[4]);
                    int sta = int.Parse(prop[5]);
                    Mage p = new Mage(str, agi, inte, spi, sta, prop[6]);
                    characterList.Add(p);
                    partylist.Text += $"Name: {prop[6]} Class: {prop[0]} \n" +
                           $"Str: {prop[1]} Agi: {prop[2]} Int: {prop[3]} Spi: {prop[4]} Sta: {prop[5]} \n";
                }
                else if (prop[0] == "Priest")
                {
                    int str = int.Parse(prop[1]);
                    int agi = int.Parse(prop[2]);
                    int inte = int.Parse(prop[3]);
                    int spi = int.Parse(prop[4]);
                    int sta = int.Parse(prop[5]);
                    Priest p = new Priest(str, agi, inte, spi, sta, prop[6]);
                    characterList.Add(p);
                    partylist.Text += $"Name: {prop[6]} Class: {prop[0]} \n" +
                           $"Str: {prop[1]} Agi: {prop[2]} Int: {prop[3]} Spi: {prop[4]} Sta: {prop[5]} \n";
                }
                prop.Clear();
            }
        }
    }
}
