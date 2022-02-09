using DAL.Model;
using DAL.CentralSavings;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL.Utils;

namespace Socker.CustomControl
{
    public partial class PlayerRangList : UserControl
    {
        public PlayerRangList()
        {
            InitializeComponent();
        }

        public PlayerRangList(Player player)
        {
            InitializeComponent();
            lblPlayerName.Text = player.Name;

            if (AllSavings.settings.Gender == "men")
            {
                ImageUtils.GetSavedImageIfExsists(player);
                if (player.Image != null)
                {
                    Image playerSavedImage = Image.FromFile(player.Image);
                    pbPlayerPicture.Image = playerSavedImage;
                }
                else
                {
                    pbPlayerPicture.Image = ResourcesSocker.male_player;
                }
            }
            else
            {
                ImageUtils.GetSavedImageIfExsists(player);
                if (player.Image != null)
                {
                    Image playerSavedImage = Image.FromFile(player.Image);
                    pbPlayerPicture.Image = playerSavedImage;
                }
                else
                {
                    pbPlayerPicture.Image = ResourcesSocker.female_player;
                }
            }

            if (player.Goals != null)
            {
                if (AllSavings.settings.Language == "hr")
                {
                    lblEvent.Text = "Golovi";
                }
                else
                {
                    lblEvent.Text = "Goal";
                }
                lblEventNum.Text = player.Goals.ToString();
            }

            if (player.YellowCards != null)
            {
                if (AllSavings.settings.Language == "hr")
                {
                    lblEvent.Text = "Žuti kartoni";
                }
                else
                {
                    lblEvent.Text = "Yellow card";
                }
                lblEventNum.Text = player.YellowCards.ToString();
            }

        }
    }
}
