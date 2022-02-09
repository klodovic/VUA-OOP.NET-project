using DAL.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Socker.CustomControl
{
    public partial class Visitors : UserControl
    {
        //char[] charsToTrim = { ' ', '(', ')' };
        public Visitors()
        {
            InitializeComponent();
        }

        public Visitors(SoccerMatch soccerMatch)
        {
            InitializeComponent();
            lblStadiumName.Text = soccerMatch.Venue;
            lbllHomeTeam.Text = soccerMatch.HomeTeam.Country;
            lblAwayTeam.Text = soccerMatch.AwayTeam.Country;
            lblVisitorsNum.Text = soccerMatch.Attendance;
        }



    }
}
