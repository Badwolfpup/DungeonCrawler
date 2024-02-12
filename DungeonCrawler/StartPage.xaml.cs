using DungeonCrawler.Classes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DungeonCrawler
{
    /// <summary>
    /// Interaction logic for StartPage.xaml
    /// </summary>
    /// 
    

    public partial class StartPage : Page
    {

        private Border _border = null;
        public ObservableCollection<ObservableCollection<Character>> characterList { get; set; }

        public ObservableCollection<Character> chosenSave { get; set; }

        private readonly MainWindow parentWindow;
        public StartPage(MainWindow w)
        {
            InitializeComponent();
            parentWindow = w;
            DataContext = this;
            loadSavefiles();
        }

        private void loadSavefiles()
        {
            characterList = SaveParty.LoadFromFile();
        }

        private void newGameButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            parentWindow.CharacterCreationPage();
        }

        private void loadGameButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (_border != null) parentWindow.ClosePage(chosenSave);
            else MessageBox.Show("You need to select a save first.");
        }

        private void Border_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Border b = sender as Border;

            chosenSave = b.DataContext as ObservableCollection<Character>;

            if (_border != null)
            {
                _border.BorderBrush = Brushes.Crimson;

            }
            b.BorderBrush = Brushes.Blue;
            _border = b;
        }
    }
}
