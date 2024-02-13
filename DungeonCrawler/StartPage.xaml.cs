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
        //Håller den border vi har klickat på. Initialt null eftersom vi inte har klickat på något.
        private Border _border = null;

        //En lista över de savefiler som finns. Varje lista innehåller en lista över karaktärer. Därför blir det en lista i en lista.
        public ObservableCollection<ObservableCollection<Character>> characterList { get; set; }

        //Listan som håller den valda saven.
        public ObservableCollection<Character> chosenSave { get; set; }

        //Håller vårt Main Window så att vi har en koppling tillbaka
        private readonly MainWindow parentWindow;
        public StartPage(MainWindow w)
        {
            InitializeComponent();
            parentWindow = w;
            DataContext = this; //Datakontext säger var UI ska hämta sin data
            loadSavefiles();
        }

        private void loadSavefiles()
        {
            //Hämtar alla savefiler
            characterList = SaveParty.LoadFromFile(); 
        }

        private void newGameButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            //Callar en metod i MainWindow, som stänger ner vår Page, och öppnar CharacterCreation
            parentWindow.CharacterCreationPage();
        }

        private void loadGameButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            //Kollar om vi har valt en save och sedan callar en metod i MainWindow, som stänger ner vår Page
            if (_border != null) parentWindow.ClosePage(chosenSave);
            else MessageBox.Show("You need to select a save first.");
        }

        private void Border_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            //I object sender får man med det UI-element som man interagerat med.
            //För att man ska kunna tilldela det till ett typ av objekt måste man casta det, här genom sender as Border
            Border b = sender as Border;

            //Sparar ner datan från den Border vi har klickat på. UI hämtar data från chosenSave
            chosenSave = b.DataContext as ObservableCollection<Character>;
            
            //Innan man klickat försat gången på någon border är den null. Då behöver ingen färg ändras tillbaka.
            if (_border != null)
            {
                _border.BorderBrush = Brushes.Crimson;

            }
            //Sätter ny färg på den Border som klickats på.
            b.BorderBrush = Brushes.Blue;
            _border = b;
        }

        private void deleteSaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (chosenSave != null)
            {
                SaveParty.DeleteSaveFile(chosenSave[0].SaveID);
                characterList.Remove(chosenSave);
            }
            else MessageBox.Show("You need to select a save first");
        }
    }
}
