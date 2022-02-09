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
using Socker.Constants;
using Socker.Properties;
using System.IO;
using DAL.APIConstants;
using DAL.Utils;

namespace Socker.CustomControl
{
    public partial class PlayerHolder : UserControl
    {
        public bool SelectedPlayer { get; set; }

        public PlayerHolder()
        {
            InitializeComponent();
        }

        public PlayerHolder(Player player)
        {
            InitializeComponent();
            lblPlayerName.Text = player.Name;
            if (AllSavings.settings.Language == "hr")
            {
                lblYesNo.Text = player.Captain ? "Da" : "Ne";
            }
            else
            {
                lblYesNo.Text = player.Captain ? "Yes" : "No";
            }

            lblPlayerNumber.Text = player.ShirtNumber.ToString();
            lblPosition.Text = player.Position;


            //provjera postoji li spremljena slika igrača / u suprotnom se load-a slika iz resursa
            if (AllSavings.settings.Gender == "men")
            {
                ImageUtils.GetSavedImageIfExsists(player);
                if (player.Image != null)
                {
                    Image playerSavedImage = Image.FromFile(player.Image);
                    pbPlayerImage.Image = playerSavedImage;
                }
                else
                {
                    pbPlayerImage.Image = ResourcesSocker.male_player;
                }
            }
            else
            {
                ImageUtils.GetSavedImageIfExsists(player);
                if (player.Image != null)
                {
                    Image playerSavedImage = Image.FromFile(player.Image);
                    pbPlayerImage.Image = playerSavedImage;
                }
                else
                {
                    pbPlayerImage.Image = ResourcesSocker.female_player;
                }
            }
            pbStar.Image = player.FavouritePlayer ? ResourcesSocker.star : pbStar.Image = null;
        }

        private void btnChangePlayerImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = $"Odaberi format slike|*.jpg;*.jpeg;*.png|Sve|*.*";
            openFileDialog.ShowDialog();

            if (openFileDialog.FileName != null || openFileDialog.FileName != "")
            {
                ChangeAndSavePlayersImage(openFileDialog.FileName);
            }
            else
            {
                MessageBox.Show("Odabrani format nije podržan!!");
            }
        }

        private void ChangeAndSavePlayersImage(string fileName)
        {
            //var imageName = Path.GetFileNameWithoutExtension(fileName).ToLower();
            try
            {
                var imageName = lblPlayerName.Text.ToLower();
                var imageExtension = fileName.Substring(fileName.LastIndexOf('.')).ToLower();

                Image playerNewImage = Image.FromFile(fileName);

                pbPlayerImage.Image = playerNewImage;

                string settingNewImageName = ApiConstants.PLAYERS_IMAGES + $@"/" + $"{imageName}" + $"{imageExtension}";

                playerNewImage.Save(settingNewImageName, playerNewImage.RawFormat);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
            }
        }

        internal void UnselectPlayer()
        {
            BackColor = Color.White;
            SelectedPlayer = false;
        }

        internal void ShowStar()
        {
            pbStar.Image = ResourcesSocker.star;
        }

        internal void RemoveStar()
        {
            pbStar.Image = null;
        }

        internal string GetPlayer() => $"{lblPlayerName.Text}|{lblYesNo.Text}|{lblPlayerNumber.Text}|{lblPosition.Text}";


        //Selekcija kontrole - priprema za prebacivanje igrača u Panel Favorita
        private void PlayerHolder_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (BackColor == Color.White)
                {
                    BackColor = Color.Yellow;
                    SelectedPlayer = true;
                }
                else
                {
                    BackColor = Color.White;
                    SelectedPlayer = false;
                }
            }
            if (e.Button == MouseButtons.Left)
            {
                SelectedPlayer = true;
                BackColor = Color.Beige;
                PlayerHolder playerHolder = sender as PlayerHolder;
                playerHolder.DoDragDrop(this, DragDropEffects.Move);
            }
        }

    }
}
