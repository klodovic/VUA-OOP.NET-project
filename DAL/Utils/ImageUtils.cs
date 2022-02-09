using DAL.APIConstants;
using DAL.Model;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace DAL.Utils
{
    public static class ImageUtils
    {
        public static void GetSavedImageIfExsists(Player player)
        {
            List<string> savedPlayersImages = Directory.GetFiles(ApiConstants.PLAYERS_IMAGES).ToList();

            var playerName = player.Name.ToLower();

            foreach (var item in savedPlayersImages)
            {
                var playerNameFromImage = Path.GetFileNameWithoutExtension(item).ToLower();
                var imageExtension = item.Substring(item.LastIndexOf('.')).ToLower();

                if (playerName == playerNameFromImage)
                {
                    PictureBox pictureBox = new PictureBox();
                    pictureBox.ImageLocation = ApiConstants.PLAYERS_IMAGES + $@"\" + playerNameFromImage + imageExtension;
                    player.Image = ApiConstants.PLAYERS_IMAGES + $@"\" + playerNameFromImage + imageExtension;
                }
            }
        }
    }
}
