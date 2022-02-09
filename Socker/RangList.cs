using DAL.CentralSavings;
using DAL.Data;
using DAL.Model;
using Socker.Constants;
using Socker.CustomControl;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Windows.Forms;

namespace Socker
{
    public partial class RangList : Form
    {

        private const string goal = "goal";
        private const string yellowCard = "yellow-card";

        private List<TeamEvent> yellowCards = new List<TeamEvent>();
        private List<TeamEvent> goalEvents = new List<TeamEvent>();

        private Dictionary<Player, Player> goalRank = new Dictionary<Player, Player>();
        private Dictionary<Player, Player> yellowCardRank = new Dictionary<Player, Player>();

        public RangList()
        {
            InitializeComponent();
        }

        private void RangList_Load(object sender, EventArgs e)
        {
            AllSavings.SetCulture(AllSavings.settings.Language);
        }


        public RangList(object country, object fifaCode)
        {
            InitializeComponent();
            SelectedCountry = country;
            SelectedFifaCode = fifaCode;

            FillPanelWithPlayersGoals((string)fifaCode, (string)country);
        }
        public object SelectedCountry { get; }
        public object SelectedFifaCode { get; }



        private async void FillPanelWithPlayersGoals(string fifaCode, string country)
        {
            DataRetrieval dataRetrieval = new DataRetrieval();
            string link = Const.GetMatchesByGender() + fifaCode;
            List<SoccerMatch> soccerMatches = await dataRetrieval.GetStat(link);

            goalEvents = GetAllEvents(soccerMatches, country, goal);
            yellowCards = GetAllEvents(soccerMatches, country, yellowCard);

            CountGoalEvents(goalEvents, goalRank);
            CountYellowCardEvents(yellowCards, yellowCardRank);

            var sortedGoalsRank = goalRank.ToList();
            sortedGoalsRank.Sort((pair1, pair2) => pair1.Value.CompareTo(pair2.Value));
            var sortedYellowCardRank = yellowCardRank.ToList();
            sortedYellowCardRank.Sort((pair1, pair2) => pair1.Value.CompareToYellowCard(pair2.Value));
            soccerMatches.Sort();

            foreach (var item in sortedGoalsRank)
            {
                PlayerRangList playerRangList = new PlayerRangList(new Player
                {
                    Name = item.Key.Name,
                    Goals = item.Value.Goals
                });
                flpGoals.Controls.Add(playerRangList);
            }

            foreach (var item in sortedYellowCardRank)
            {
                PlayerRangList playerRangList = new PlayerRangList(new Player
                {
                    Name = item.Key.Name,
                    YellowCards = item.Value.YellowCards
                });
                flpYellowCards.Controls.Add(playerRangList);
            }

            foreach (var item in soccerMatches)
            {
                Visitors visitors = new Visitors(new SoccerMatch
                {

                    Venue = item.Venue,
                    HomeTeam = item.HomeTeam,
                    AwayTeam = item.AwayTeam,
                    Attendance = item.Attendance
                });
                flpVisitors.Controls.Add(visitors);
            }
        }

        //Zbroj žutih kartona
        private void CountYellowCardEvents(List<TeamEvent> yellowCards, Dictionary<Player, Player> yellowCardRank)
        {
            yellowCards.ToList().ForEach(tr =>
            {
                if (!yellowCardRank.ContainsKey(new Player { Name = tr.Player }))
                {
                    yellowCardRank.Add(new Player { Name = tr.Player }, new Player { YellowCards = tr.TypeOfEvent });
                }
            });

            yellowCardRank.ToList().ForEach(p =>
            {
                int yellowCardCount = yellowCards
                    .FindAll(g => g.Player.Equals(p.Key.Name))
                    .Count;

                p.Value.YellowCards = yellowCardCount.ToString();
            });
        }

        //Zbroj golova
        private void CountGoalEvents(List<TeamEvent> goalEvents, Dictionary<Player, Player> goalRank)
        {
            goalEvents.ToList().ForEach(tr =>
            {
                if (!goalRank.ContainsKey(new Player { Name = tr.Player }))
                {
                    goalRank.Add(new Player { Name = tr.Player }, new Player { Goals = tr.TypeOfEvent });
                }
            });

            goalRank.ToList().ForEach(p =>
            {
                int goalCount = goalEvents
                    .FindAll(g => g.Player.Equals(p.Key.Name))
                    .Count;

                p.Value.Goals = goalCount.ToString();
            });
        }

        //Dohvaćanje svih utakmica
        private List<TeamEvent> GetAllEvents(List<SoccerMatch> soccerMatches, string country, string eventType)
        {
            IEnumerable<TeamEvent> teamEvent = soccerMatches.SelectMany(match =>
            {
                if (match.HomeTeam.Country == country)
                {
                    return match.HomeTeamEvents.FindAll(m => m.TypeOfEvent.Equals(eventType));
                }
                if (match.AwayTeam.Country == country)
                {
                    return match.AwayTeamEvents.FindAll(m => m.TypeOfEvent.Equals(eventType));
                }
                return null;
            });
            return teamEvent.ToList();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            printPreviewDialog.ShowDialog();
        }

        private void printDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            var x = e.MarginBounds.Left;
            var y = e.MarginBounds.Top;
            var bmp = new Bitmap(this.Size.Width, this.Size.Height);



            this.DrawToBitmap(bmp, new Rectangle
            {
                X = 0,
                Y = 0,
                Width = this.Size.Width,
                Height = this.Size.Height
            });
            e.Graphics.DrawImage(bmp, x, y);

        }

        private void btnPrintSetup_Click(object sender, EventArgs e)
        {
            pageSetupDialog.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Exit window?", "Confirm Exit", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dialog == DialogResult.OK)
            {
                this.Close();
            }
        }
    }
}
