using DAL.APIConstants;
using DAL.CentralSavings;
using DAL.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace WpfApp.CustomControl
{
    /// <summary>
    /// Interaction logic for PlayerHolder.xaml
    /// </summary>
    public partial class PlayerHolder : UserControl
    {
        private Player player;
        public PlayerHolder(Player player)
        {
            InitializeComponent();
            this.player = player;
            lblPlayerName.Content = player.Name;
            lblShirtNumber.Content = player.ShirtNumber.ToString();
            imgPlayer.Source = GetImageIfExistsWPF(player);

        }

        private ImageSource GetImageIfExistsWPF(Player player)
        {
            var playerName = player.Name.ToLower();
            string workingDirectory = Environment.CurrentDirectory;
            string pictureDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName + ApiConstants.PLAYERS_IMAGES_WPF;
            List<string> savedPlayersImages = Directory.GetFiles(pictureDirectory).ToList();

            if (AllSavings.settings.Gender == ApiConstants.WOMEN)
            {
                imgPlayer.Source = new BitmapImage(new Uri(ApiConstants.DEFAULT_WOMEN_IMAGE, UriKind.Relative));
            }

            foreach (var item in savedPlayersImages)
            {
                string playerNameFromImage = item.Substring(item.LastIndexOf(@"\")).Replace(@"\", "");
                string[] playerNameData = playerNameFromImage.Split('.');

                if (playerName == playerNameData[0].ToLower())
                {
                    imgPlayer.Source = new BitmapImage(new Uri(item, UriKind.Absolute));
                    break;
                }
            }
           return imgPlayer.Source;
        }

        private void UserControl_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            PlayerInfo playerInfo = new PlayerInfo(player);
            playerInfo.Show();
        }

    }
}
