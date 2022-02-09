using DAL.APIConstants;
using DAL.CentralSavings;
using DAL.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for PlayerInfo.xaml
    /// </summary>
    public partial class PlayerInfo : Window
    {
        public PlayerInfo(Player player)
        {
            InitializeComponent();
            lblPlayerName.Content = player.Name;
            lblShirtName.Content = player.ShirtNumber;
            lblCaptain.Content = player.Captain ? "Yes" : "No";
            lblGoals.Content = player.Goals;
            lblYellowCard.Content = player.YellowCards;
            playerImage.Source = GetImageIfExistsWPF(player);
        }

        private ImageSource GetImageIfExistsWPF(Player player)
        {
            var playerName = player.Name.ToLower();
            string workingDirectory = Environment.CurrentDirectory;
            string pictureDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName + ApiConstants.PLAYERS_IMAGES_WPF;
            List<string> savedPlayersImages = Directory.GetFiles(pictureDirectory).ToList();

            if (AllSavings.settings.Gender == ApiConstants.WOMEN)
            {
                playerImage.Source = new BitmapImage(new Uri(ApiConstants.DEFAULT_WOMEN_IMAGE, UriKind.Relative));
            }

            foreach (var item in savedPlayersImages)
            {
                string playerNameFromImage = item.Substring(item.LastIndexOf(@"\")).Replace(@"\", "");
                string[] playerNameData = playerNameFromImage.Split('.');

                if (playerName == playerNameData[0].ToLower())
                {
                    playerImage.Source = new BitmapImage(new Uri(item, UriKind.Absolute));
                    break;
                }
            }
            return playerImage.Source;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}
