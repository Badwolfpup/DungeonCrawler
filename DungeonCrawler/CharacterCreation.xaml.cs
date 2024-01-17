using DungeonCrawler.Classes;
using System;
using System.Collections.Generic;
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

namespace DungeonCrawler
{
    /// <summary>
    /// Interaction logic for CharacterCreation.xaml
    /// </summary>
    public partial class CharacterCreation : Page
    {
        List<Character> characterList = new List<Character>();
        public CharacterCreation()
        {
            InitializeComponent();
        }

        private void StrPlus_Click(object sender, RoutedEventArgs e)
        {
            int x;
            int.TryParse(StrValue.Text, out x);
            if (x < 20)
            {
                x++;
                StrValue.Text = x.ToString();
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
            }
        }

        private void CreateChar_Click(object sender, RoutedEventArgs e)
        {
            if (RBPaladin.IsChecked == true)
            {
                if (characterList.Count < 4)
                {
                    int str, agi, inte, spi, sta;
                    int.TryParse(StrValue.Text, out str);
                    int.TryParse(AgiValue.Text, out agi);
                    Paladin p = new Paladin(str, agi, 12, 12, 12);
                    characterList.Add(p);
                }
            } else if (RBWarrior.IsChecked == true)
            {

            } else if (RBRogue.IsChecked == true)
            {

            } else if (RBRanger.IsChecked == true)
            {

            } else if (RBMage.IsChecked == true)
            {

            } else if (RBPriest.IsChecked == true)
            {

            }
        }
    }
}
