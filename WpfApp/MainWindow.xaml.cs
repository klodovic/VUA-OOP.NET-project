﻿using DAL.Data;
using DAL.CentralSavings;
using DAL.Model;
using Socker.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using DAL.APIConstants;
using System.IO;
using WpfApp.CustomControl;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const char DEL = 'X';
        private string _filePath = Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory);
        private string filePath = Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory);

        private List<SoccerMatch> soccerMatch = new List<SoccerMatch>();
        private List<Countries> countriesAll = new List<Countries>();
        private List<Countries> awayCountries = new List<Countries>();

        public MatchData matchData;

        string championShipFile;
        string favMenTeam;
        string favWomenTeam;
        string resolution;
        string favLang;
        Countries selectedHomeCountry;
        Countries selectedAwayCountry;
        private string homeCountry;

        public MainWindow()
        {
            SetCultureFromFile();
            InitializeComponent();
        }

        //Postavljanje jezika iz file-a
        private void SetCultureFromFile()
        {
            try
            {
                filePath = Directory.GetParent(filePath).FullName;
                filePath = Directory.GetParent(Directory.GetParent(filePath).FullName).FullName;

                favLang = filePath + ApiConstants.PREF_LANG_WPF;

                if (new FileInfo(favLang).Length != 0)
                {
                    var lines = File.ReadAllLines(favLang);
                    GetFavoriteLang(lines);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
            }
        }

        
        private void GetFavoriteLang(string[] lines)
        {
            foreach (var line in lines)
            {
                if (line == ApiConstants.HR)
                {
                    AllSavings.settings.Language = ApiConstants.HR;
                    AllSavings.SetCulture(ApiConstants.HR);
                }
                if (line == ApiConstants.EN)
                {
                    AllSavings.settings.Language = ApiConstants.EN;
                    AllSavings.SetCulture(ApiConstants.EN);
                }
            }
        }

        //Dohvaćam podatke o CUP i GENDER - popunjavam combobox sa timovima
        private async void Window_ContentRendered(object sender, EventArgs e)
        {
            _filePath = Directory.GetParent(_filePath).FullName;
            _filePath = Directory.GetParent(Directory.GetParent(_filePath).FullName).FullName;

            try
            {

                resolution = ApiConstants.PREF_RESOLUTION;
                championShipFile = _filePath + ApiConstants.PREF_CUP_WPF;
                favMenTeam = _filePath + ApiConstants.FAVTEAM_MEN_WPF;
                favWomenTeam = _filePath + ApiConstants.FAVTEAM_WOMEN_WPF;

                lblInfo.Content = "Dohvaćam podatke";

                if (new FileInfo(resolution).Length != 0)
                {
                    var lines = File.ReadAllLines(resolution);
                    GetResolutionFromFile(lines);
                    CenterWindowOnScreen();
                }

                if (new FileInfo(championShipFile).Length != 0)
                {
                    var lines = File.ReadAllLines(championShipFile);
                    string s = string.Join("", lines);

                    if (s == ApiConstants.MEN)
                    {
                        if (new FileInfo(favMenTeam).Length != 0)
                        {
                            AllSavings.settings.Gender = ApiConstants.MEN;
                            var linesMenTeam = File.ReadAllLines(favMenTeam);
                            await GetCountriesFromFile(Const.COUNTRYMEN);
                            GetFavoriteTeamFromFile(linesMenTeam);
                        }
                    }
                    else
                    {
                        if (new FileInfo(favWomenTeam).Length != 0)
                        {
                            AllSavings.settings.Gender = ApiConstants.WOMEN;
                            var linesWomenTeam = File.ReadAllLines(favWomenTeam);
                            await GetCountriesFromFile(Const.COUNTRYWOMEN);
                            GetFavoriteTeamFromFile(linesWomenTeam);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
            }
        }

        //Dohvat rezolucije
        private void GetResolutionFromFile(string[] lines)
        {
            foreach (var line in lines)
            {
                if (line == "Full-Screen")
                {
                    WindowState = WindowState.Maximized;
                }
                else
                {
                    string[] details = line.Split(DEL);
                    var x = int.Parse(details[0]);
                    var y = int.Parse(details[1]);

                    Application.Current.MainWindow.Width = x;
                    Application.Current.MainWindow.Height = y;
                }
            }
        }

        //Centriranje prozora u sredinu ekrana
        private void CenterWindowOnScreen()
        {
            double screenWidth = System.Windows.SystemParameters.PrimaryScreenWidth;
            double screenHeight = System.Windows.SystemParameters.PrimaryScreenHeight;
            double windowWidth = this.Width;
            double windowHeight = this.Height;
            this.Left = (screenWidth / 2) - (windowWidth / 2);
            this.Top = (screenHeight / 2) - (windowHeight / 2);
        }

        //Dohvat timova
        private async Task GetCountriesFromFile(string path)
        {
            try
            {
                DataRetrieval dataRetrieval = new DataRetrieval();
                countriesAll = await dataRetrieval.GetAllCountriesAsync(path);
                foreach (var item in countriesAll)
                {
                    cbHomeTeam.Items.Add(item);
                }
                lblInfo.Content = string.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
            }
        }

        //Dohvat omiljenog tima iz file-a 
        private void GetFavoriteTeamFromFile(string[] lines)
        {
            foreach (var line in lines)
            {
                string[] data = line.Split(' ');
                var countryHome = data[0];
                var fifa_code = data[1].Substring(1, data[1].Length - 2);
                GetDataPerMatch(fifa_code, countryHome);
            }
        }

        //Popunjavanje igračima omiljenog tima
        private async void GetDataPerMatch(string fifa_code, string country)
        {
            try
            {
                DataRetrieval dataRetrieval = new DataRetrieval();
                string link = Const.GetMatchesByGender() + fifa_code;
                soccerMatch = await dataRetrieval.GetStat(link);

                matchData = GetMatchData(soccerMatch, country);

                GetHomeTeam(matchData, country);
                homeCountry = country + $" (" + fifa_code + $")";
                cbAwayTeam.Items.Clear();

                GetOpponentTeams(matchData, country);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
            }
        }

        //Dohvat svih utakmica za odabrani tim
        private MatchData GetMatchData(List<SoccerMatch> soccerMatch, string country)
        {
            MatchData matchData = new MatchData
            {
                StartingEleven = soccerMatch[0].HomeTeamStatistics.StartingEleven.ToList(),
                MatchPlayed = new List<MatchPlayed>()
            };

            foreach (var item in soccerMatch)
            {
                var match = new MatchPlayed();

                if (item.HomeTeamCountry == country)
                {
                    match.HomeTeamCountry = item.HomeTeamCountry;
                    match.HomePlayers = GetEvents(item.HomeTeamStatistics.StartingEleven.ToList(), item.HomeTeamEvents);
                    match.HomesGoals = item.HomeTeam.Goals;
                }
                else
                {
                    match.AwayTeamCountry = item.HomeTeamCountry;
                    match.AwaysPlayers = GetEvents(item.HomeTeamStatistics.StartingEleven.ToList(), item.HomeTeamEvents);
                    match.AwaysGoals = item.HomeTeam.Goals;
                }

                if (item.AwayTeamCountry == country)
                {
                    match.HomeTeamCountry = item.AwayTeamCountry;
                    match.HomePlayers = GetEvents(item.AwayTeamStatistics.StartingEleven.ToList(), item.AwayTeamEvents);
                    match.HomesGoals = item.AwayTeam.Goals;
                }
                else
                {
                    match.AwayTeamCountry = item.AwayTeamCountry;
                    match.AwaysPlayers = GetEvents(item.AwayTeamStatistics.StartingEleven.ToList(), item.AwayTeamEvents);
                    match.AwaysGoals = item.AwayTeam.Goals;
                }
                matchData.MatchPlayed.Add(match);
            }

            return matchData;
        }

        //Dohvat evenata igrača (goal i yellow card)
        private List<Player> GetEvents(List<Player> playersList, List<TeamEvent> teamEvents)
        {
            List<Player> playersEvent = playersList;
            foreach (var item in teamEvents)
            {
                Player playerEvent = (from player in playersList
                                      where player.Name == item.Player
                                      select player).FirstOrDefault();

                foreach (var pl in playersList)
                {
                    if (pl.Name == item.Player)
                    {
                        if (item.TypeOfEvent == "yellow-card")
                        {
                            ++playerEvent.YellowCardsPerMatch;
                        }
                        if (item.TypeOfEvent == "goal-penalty")
                        {
                            ++playerEvent.GoalsPerMatch;
                        }
                        if (item.TypeOfEvent == "goal")
                        {
                            ++playerEvent.GoalsPerMatch;
                        }
                    }
                }
            }
            return playersEvent;
        }

        //Dohvat Home tima
        private void GetHomeTeam(MatchData matchData, string country)
        {
            foreach (var item in matchData.StartingEleven)
            {
                PlayerHolder playerHolder = new PlayerHolder(new Player
                {
                    Name = item.Name,
                    ShirtNumber = item.ShirtNumber,
                    Position = item.Position,
                    Image = item.Image,
                    Goals = item.GoalsPerMatch.ToString(),
                    YellowCards = item.YellowCardsPerMatch.ToString()
                });
                PopulateHomeTeamPlayers(item, playerHolder);
            }
        }

        //Dohvat oba tima 
        private void GetTeamsFromMatch(MatchData matchData, string country)
        {
            foreach (var item in matchData.MatchPlayed)
            {
                if (item.AwayTeamCountry == country)
                {
                    foreach (var p in item.AwaysPlayers)
                    {
                        PlayerHolder playerHolder = new PlayerHolder(new Player
                        {
                            Name = p.Name,
                            ShirtNumber = p.ShirtNumber,
                            Position = p.Position,
                            Image = p.Image,
                            Goals = p.GoalsPerMatch.ToString(),
                            YellowCards = p.YellowCardsPerMatch.ToString()
                        }); ;
                        PopulateAwayTeamPlayers(p, playerHolder);
                    }
                    foreach (var p in item.HomePlayers)
                    {
                        PlayerHolder playerHolder = new PlayerHolder(new Player
                        {
                            Name = p.Name,
                            ShirtNumber = p.ShirtNumber,
                            Position = p.Position,
                            Image = p.Image,
                            Goals = p.GoalsPerMatch.ToString(),
                            YellowCards = p.YellowCardsPerMatch.ToString()
                        });

                        PopulateHomeTeamPlayers(p, playerHolder);
                    }
                    lblHomeGoals.Content = item.HomesGoals.ToString();
                    lblAwayGoals.Content = item.AwaysGoals.ToString();
                }
            }
        }

        //Popunjavanje Home tima s igračima
        private void PopulateHomeTeamPlayers(Player item, PlayerHolder playerHolder)
        {
            if (item.Position.Equals("Goalie"))
            {
                Grid.SetColumn(playerHolder, 0);
                Grid.SetRow(playerHolder, 2);
                spGoalkeeperHome.Children.Add(playerHolder);
            }

            if (item.Position.Equals("Defender"))
            {
                Grid.SetColumn(playerHolder, 1);
                Grid.SetRow(playerHolder, 2);
                spDefenderHome.Children.Add(playerHolder);
            }

            if (item.Position.Equals("Midfield"))
            {
                Grid.SetColumn(playerHolder, 2);
                Grid.SetRow(playerHolder, 2);
                spMidfielderHome.Children.Add(playerHolder);
            }

            if (item.Position.Equals("Forward"))
            {
                Grid.SetColumn(playerHolder, 3);
                Grid.SetRow(playerHolder, 2);
                spForwardHome.Children.Add(playerHolder);
            }
        }

        //Popunjavanje Away tima s igračima
        private void PopulateAwayTeamPlayers(Player p, PlayerHolder playerHolder)
        {
            if (p.Position.Equals("Goalie"))
            {
                Grid.SetColumn(playerHolder, 7);
                Grid.SetRow(playerHolder, 2);
                spGoalkeeperGuests.Children.Add(playerHolder);
            }

            if (p.Position.Equals("Defender"))
            {
                Grid.SetColumn(playerHolder, 6);
                Grid.SetRow(playerHolder, 2);
                spDefenderGuests.Children.Add(playerHolder);
            }

            if (p.Position.Equals("Midfield"))
            {
                Grid.SetColumn(playerHolder, 5);
                Grid.SetRow(playerHolder, 2);
                spMidfielderGuests.Children.Add(playerHolder);
            }

            if (p.Position.Equals("Forward"))
            {
                Grid.SetColumn(playerHolder, 4);
                Grid.SetRow(playerHolder, 2);
                spForwardGuests.Children.Add(playerHolder);
            }
        }

        //Dohvat suparničkog tima
        private void GetOpponentTeams(MatchData matchData, string country)
        {
            awayCountries.Clear();
            foreach (var item in matchData.MatchPlayed)
            {
                if (item.HomeTeamCountry != country)
                {
                    awayCountries.Add(countriesAll.FirstOrDefault(countriesAll => countriesAll.Country == item.HomeTeamCountry));
                }
                if (item.AwayTeamCountry != country)
                {
                    awayCountries.Add(countriesAll.FirstOrDefault(countriesAll => countriesAll.Country == item.AwayTeamCountry));
                }
            }
            cbAwayTeam.Items.Clear();

            foreach (var item in awayCountries)
            {
                cbAwayTeam.Items.Add(item);
            }
        }

        //ComboBox Away tim
        private void cbAwayTeam_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedAwayCountry = cbAwayTeam.SelectedItem as Countries;
            selectedHomeCountry = cbHomeTeam.SelectedItem as Countries;
            ClearGuestPlayers();
            ClearHomePlayers();
            lblHomeGoals.Content = "0";
            lblAwayGoals.Content = "0";
            try
            {
                if (cbAwayTeam.SelectedItem != null)
                {
                    GetTeamsFromMatch(matchData, selectedAwayCountry.Country);
                    GetTeamsFromMatch(matchData, homeCountry);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
            }
        }

        //Uklanjanje gostujućih igrača
        private void ClearGuestPlayers()
        {
            spGoalkeeperGuests.Children.Clear();
            spDefenderGuests.Children.Clear();
            spMidfielderGuests.Children.Clear();
            spForwardGuests.Children.Clear();
        }

        //Uklanjanje igrača domaćina
        private void ClearHomePlayers()
        {
            spGoalkeeperHome.Children.Clear();
            spDefenderHome.Children.Clear();
            spMidfielderHome.Children.Clear();
            spForwardHome.Children.Clear();
        }

        //ComboBox Home tim
        private void cbHomeTeam_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedHomeCountry = cbHomeTeam.SelectedItem as Countries;
            try
            {
                if (cbHomeTeam.SelectedItem != null)
                {
                    ClearGuestPlayers();
                    ClearHomePlayers();
                    lblHomeGoals.Content = "0";
                    lblAwayGoals.Content = "0";

                    GetDataPerMatch(selectedHomeCountry.FifaCode, selectedHomeCountry.Country);
                    GetHomeTeam(matchData, selectedHomeCountry.Country);
                    cbAwayTeam.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
            }
        }

        //Info Home tim
        private void BtnInfoHomeTeam_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (cbHomeTeam.SelectedItem != null)
                {
                    selectedHomeCountry = cbHomeTeam.SelectedItem as Countries;
                    TeamInfo teamInfo = GetTeamStatistics(selectedHomeCountry.Country);
                    teamInfo.Show();
                }
                else
                {
                    MessageBox.Show("You have to choose a team...", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                    cbHomeTeam.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
            }
        }

        //Info Away tim
        private void btnInfoGuestsTeam_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (cbAwayTeam.SelectedItem != null)
                {
                    selectedAwayCountry = cbAwayTeam.SelectedItem as Countries;
                    TeamInfo teamInfo = GetTeamStatistics(selectedAwayCountry.Country);
                    teamInfo.Show();
                }
                else
                {
                    MessageBox.Show("You have to choose a team...", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                    cbAwayTeam.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
            }
        }

        //Popunjavanje Team Info prozora
        private TeamInfo GetTeamStatistics(string country)
        {
            TeamInfo teamInfo = new TeamInfo();
            foreach (var item in countriesAll)
            {
                if (item.Country == country)
                {
                    teamInfo.lblCountry.Content = item.Country;
                    teamInfo.lblWins.Content = item.Wins;
                    teamInfo.lblDraws.Content = item.Draws;
                    teamInfo.lblGamesPlayed.Content = item.GamesPlayed;
                    teamInfo.lblPoints.Content = item.Points;
                    teamInfo.lblGoalsFor.Content = item.GoalsFor;
                    teamInfo.lblGoalsAgainst.Content = item.GoalsAgainst;
                    teamInfo.lblGoalsDifferences.Content = item.GoalDifferential;
                }
            }
            return teamInfo;
        }

        //Settings
        private void btnSettings_Click(object sender, RoutedEventArgs e)
        {
            Settings settings = new Settings();
            settings.Show();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Do you want to exit?", "Confirm", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
            }
        }

    }
}
