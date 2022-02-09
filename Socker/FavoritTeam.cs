using DAL.APIConstants;
using DAL.CentralSavings;
using DAL.Data;
using DAL.Model;
using Socker.Constants;
using Socker.CustomControl;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Socker
{
    public partial class FavoritTeam : Form
    {
        private Countries selectedCountry;
        private IList<Player> allTeamsPlayers = new List<Player>();
        private List<Countries> c = new List<Countries>();
        string championShipFile;
        string favoritePlayersFile;
        public FavoritTeam()
        {
            InitializeComponent();
        }

        //dohvat svih zamalja
        private async void FavoritTeam_Load(object sender, EventArgs e)
        {

            AllSavings.SetCulture(AllSavings.settings.Language);

            btnRangList.Enabled = false;
            btnSave.Enabled = false;

            if (AllSavings.settings.Language == "en")
            {
                lblInfo.Text = "I'm retrieving data on national teams...";
            }
            else
            {
                lblInfo.Text = "Dohvaćam podatke o reprezentacijama...";
            }

            if (AllSavings.settings.Gender == "men")
            {
                championShipFile = ApiConstants.FAVTEAM_MEN;
                favoritePlayersFile = ApiConstants.FAVPLAYERS_MEN;
            }
            else
            {
                championShipFile = ApiConstants.FAVTEAM_WOMEN;
                favoritePlayersFile = ApiConstants.FAVPLAYERS_WOMEN;
            }


            //dohvat svih država (reprezentacija)
            try
            {
                DataRetrieval dataRetrieval = new DataRetrieval();
                c = await dataRetrieval.GetAllCountriesAsync(Const.GetCountriesByGender());
                foreach (var item in c)
                {
                    cbCountry.Items.Add(item);
                }
                lblInfo.Text = string.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
            }

            //Provjera text file - a ako postoji zapis o omiljenom timu i omiljeni igračima
            try
            {
                if (new FileInfo(championShipFile).Length != 0)
                {
                    var lines = File.ReadAllLines(championShipFile);
                    GetFavoriteTeamFromFile(lines);

                    if (new FileInfo(favoritePlayersFile).Length != 0)
                    {
                        var linesPlayers = File.ReadAllLines(favoritePlayersFile);

                        GetFavoritePlayersFromFile(linesPlayers);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
            }
        }

        private void GetFavoritePlayersFromFile(string[] linesPlayers)
        {
            foreach (var player in linesPlayers)
            {
                string[] details = player.Split(ApiConstants.DEL);

                PlayerHolder playerHolder = new PlayerHolder(new Player
                {
                    Name = details[0],
                    Captain = details[1].Equals("NE") ? true : false,
                    ShirtNumber = int.Parse(details[2]),
                    Position = details[3],
                    FavouritePlayer = true
                });
                flpFavoritePlayers.Controls.Add(playerHolder);
            }
        }

        private void GetFavoriteTeamFromFile(string[] lines)
        {
            foreach (var line in lines)
            {
                string[] data = line.Split(' ');
                var country = data[0];
                var fifa_code = data[1].Substring(1, data[1].Length - 2);
                foreach (var item in c)
                {
                    if (item.Country.Equals(country))
                        cbCountry.SelectedItem = item;
                }
                FillPanelWithPlayers(fifa_code, country);
            }
        }

        //event na promjenu zemlje
        private void cbCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                selectedCountry = cbCountry.SelectedItem as Countries;
                string fifa_code = selectedCountry.FifaCode;
                string country = selectedCountry.Country;
                flpAllTeamPlayers.Controls.Clear();
                FillPanelWithPlayers(fifa_code, country);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
            }
        }

        //Popunjavanje FlowLayOutPanela sa user kontrolom (igračima)
        private async void FillPanelWithPlayers(string fifa_code, string country)
        {
            try
            {
                DataRetrieval dataRetrieval = new DataRetrieval();
                string link = Const.GetMatchesByGender() + fifa_code;
                List<SoccerMatch> soccerMatches = await dataRetrieval.GetAllTeamPlayersAsync(link);

                allTeamsPlayers = GetAllTeamsPlayers(soccerMatches, country);

                foreach (var item in allTeamsPlayers)
                {
                    PlayerHolder playerHolder = new PlayerHolder(new Player
                    {
                        Name = item.Name,
                        Captain = item.Captain,
                        ShirtNumber = item.ShirtNumber,
                        Position = item.Position
                    });
                    flpAllTeamPlayers.Controls.Add(playerHolder);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
            }

            btnRangList.Enabled = true;
            btnSave.Enabled = true;
        }

        //dohvat starting eleven i substitutes igrača
        private List<Player> GetAllTeamsPlayers(List<SoccerMatch> soccerMatches, string country)
        {
            try
            {
                SoccerMatch soccerGame = soccerMatches.FirstOrDefault();
                if (soccerGame.HomeTeam.Country == country)
                {
                    return new List<Player>(soccerGame.HomeTeamStatistics.StartingEleven.Union(soccerGame.HomeTeamStatistics.Substitutes));
                }
                if (soccerGame.AwayTeam.Country == country)
                {
                    return new List<Player>(soccerGame.AwayTeamStatistics.StartingEleven.Union(soccerGame.AwayTeamStatistics.Substitutes));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
            }

            return new List<Player>();
        }

        //BUTTON EVENTS
        //Click event za dodavanje igrača u favorite
        private void btnAddToFavoritePlayers_Click(object sender, EventArgs e)
        {
            try
            {
                List<PlayerHolder> favoritPlayers = GetSelectedPlayersToFavorit(flpAllTeamPlayers);
                if (!CountOfMaximumFavoritPlayers(favoritPlayers))
                {
                    MessageBox.Show("Dozvoljeno je dodati samo 3 omiljena igrača!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    if (flpFavoritePlayers.Controls.Count < 3)
                    {
                        MovingSelectedPlayersToFavoritPanel(favoritPlayers, flpAllTeamPlayers, flpFavoritePlayers);
                    }
                    else
                    {
                        MessageBox.Show("Dodali ste već 3 omiljena igrača!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        foreach (PlayerHolder item in favoritPlayers)
                        {
                            item.UnselectPlayer();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
            }

            btnSave.Enabled = true;
        }

        private bool CountOfMaximumFavoritPlayers(List<PlayerHolder> favoritPlayers)
        {
            if (favoritPlayers.Count > 3)
            {
                foreach (PlayerHolder item in favoritPlayers)
                {
                    item.UnselectPlayer();
                }
                return false;
            }
            return true;
        }

        //Click event za vraćanje igrača u listu svih igrača
        private void btnReturnToAllPlayers_Click(object sender, EventArgs e)
        {
            List<PlayerHolder> favoritPlayers = GetSelectedPlayersToFavorit(flpFavoritePlayers);
            MovingSelectedPlayersFromFavoritPanel(favoritPlayers, flpFavoritePlayers, flpAllTeamPlayers);
        }



        //METODE EVENATA
        //Dodavanje igrača u listu igrača Favorita
        private List<PlayerHolder> GetSelectedPlayersToFavorit(FlowLayoutPanel flpAllTeamPlayers)
        {
            List<PlayerHolder> favoritPlayersToList = new List<PlayerHolder>();

            foreach (PlayerHolder player in flpAllTeamPlayers.Controls)
            {
                if (player.SelectedPlayer)
                {
                    favoritPlayersToList.Add(player);
                }
            }
            return favoritPlayersToList;
        }

        //Uklanjanje igrača iz Panela Favorita
        private void MovingSelectedPlayersFromFavoritPanel(List<PlayerHolder> favoritPlayers, FlowLayoutPanel flpFavoritePlayers, FlowLayoutPanel flpAllTeamPlayers)
        {
            foreach (PlayerHolder item in favoritPlayers)
            {
                if (item.SelectedPlayer)
                {
                    item.UnselectPlayer();
                }
                flpAllTeamPlayers.Controls.Add(item);
                flpFavoritePlayers.Controls.Remove(item);
                item.RemoveStar();
            }
        }

        //Prebacivanje selektiranih igrača u Panel Favorita
        private void MovingSelectedPlayersToFavoritPanel(List<PlayerHolder> favoritPlayers, FlowLayoutPanel flpAllTeamPlayers, FlowLayoutPanel flpFavoritePlayers)
        {
            foreach (PlayerHolder item in favoritPlayers)
            {
                if (item.SelectedPlayer)
                {
                    item.UnselectPlayer();
                }
                flpAllTeamPlayers.Controls.Remove(item);
                flpFavoritePlayers.Controls.Add(item);
                item.ShowStar();
            }
        }

        //DRAG N DROP EVENTS


        private void flpFavoritePlayers_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                List<PlayerHolder> favoritPlayers = GetSelectedPlayersToFavorit(flpAllTeamPlayers);
                if (!CountOfMaximumFavoritPlayers(favoritPlayers))
                {
                    MessageBox.Show("Dozvoljeno je dodati samo 3 omiljena igrača!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    if (flpFavoritePlayers.Controls.Count < 3)
                    {
                        MovingSelectedPlayersToFavoritPanel(favoritPlayers, flpAllTeamPlayers, flpFavoritePlayers);
                    }
                    else
                    {
                        MessageBox.Show("Dodali ste već 3 omiljena igrača!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        foreach (PlayerHolder item in favoritPlayers)
                        {
                            item.UnselectPlayer();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
            }

            btnSave.Enabled = true;
        }

        private void flpFavoritePlayers_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }


        private void flpAllTeamPlayers_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void flpAllTeamPlayers_DragDrop(object sender, DragEventArgs e)
        {
            List<PlayerHolder> favoritPlayers = GetSelectedPlayersToFavorit(flpFavoritePlayers);
            MovingSelectedPlayersFromFavoritPanel(favoritPlayers, flpFavoritePlayers, flpAllTeamPlayers);
        }


        //Spremanje omiljenog tima i igrača u TxtFile
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(championShipFile))
                {
                    if (!File.Exists(championShipFile)) return;
                    var favTeam = cbCountry.SelectedItem as Countries;
                    writer.WriteLine(favTeam);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message} {ex.StackTrace}");
            }

            try
            {
                using (StreamWriter writer = new StreamWriter(favoritePlayersFile))
                {
                    if (!File.Exists(favoritePlayersFile)) return;

                    foreach (PlayerHolder item in flpFavoritePlayers.Controls)
                    {
                        writer.WriteLine(item.GetPlayer());
                    }

                    MessageBox.Show("Uspješno ste spremili postavke...", "Information!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
            }
        }


        public void btnRangList_Click(object sender, EventArgs e)
        {
            selectedCountry = cbCountry.SelectedItem as Countries;
            string fifaCode = selectedCountry.FifaCode;
            string country = selectedCountry.Country;
            RangList rangList = new RangList(country, fifaCode);
            rangList.Show();
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            frmSettings settings = new frmSettings();
            settings.Show();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Exit program?", "Confirm Exit", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dialog == DialogResult.OK)
            {
                Application.Exit();
            }
        }

    }
}
