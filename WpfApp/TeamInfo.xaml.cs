using System.Windows;


namespace WpfApp
{
    /// <summary>
    /// Interaction logic for TeamInfo.xaml
    /// </summary>
    public partial class TeamInfo : Window
    {
        public TeamInfo()
        {
            InitializeComponent();
        }

        private void btnInfoTeam_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
