using DAL.APIConstants;
using System;
using System.IO;
using System.Windows;


namespace WpfApp
{
    /// <summary>
    /// Interaction logic for Settings.xaml
    /// </summary>
    public partial class Settings : Window
    {
        string langFile;
        string championShipFile;
        private string _filePath = System.IO.Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory);
        public Settings()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            PopulateComboBoxLang();
            PopulateComboBoxContest();
            PopulateComboBoxResolution();
        }

        private void PopulateComboBoxResolution()
        {
            cbResolution.Items.Clear();
            InitializeComponent();
            cbResolution.Items.Add("1280X720");
            cbResolution.Items.Add("1440X900");
            cbResolution.Items.Add("1920X1080");
            cbResolution.Items.Add("Full-Screen");
        }

        private void PopulateComboBoxContest()
        {
            cbContest.Items.Clear();
            
            cbContest.Items.Add(ApiConstants.MEN);
            cbContest.Items.Add(ApiConstants.WOMEN);
        }

        private void PopulateComboBoxLang()
        {
            cbLang.Items.Clear();
            InitializeComponent();
            cbLang.Items.Add(ApiConstants.HR);
            cbLang.Items.Add(ApiConstants.EN);
        }


        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            _filePath = Directory.GetParent(_filePath).FullName;
            _filePath = Directory.GetParent(Directory.GetParent(_filePath).FullName).FullName;

            langFile = _filePath + ApiConstants.PREF_LANG_WPF;
            championShipFile = _filePath + ApiConstants.PREF_CUP_WPF;
            try
            {
                using (StreamWriter writer = new StreamWriter(langFile))
                {
                    if (!File.Exists(langFile)) return;
                    var favLang = cbLang.SelectedItem;
                    writer.WriteLine(favLang);
                }

                using (StreamWriter writer = new StreamWriter(championShipFile))
                {
                    if (!File.Exists(championShipFile)) return;
                    var favCup = cbContest.SelectedItem;
                        writer.WriteLine(favCup);
                }

                using (StreamWriter writer = new StreamWriter(ApiConstants.PREF_RESOLUTION))
                {
                    if (!File.Exists(ApiConstants.PREF_RESOLUTION)) return;
                    var favResolution = cbResolution.SelectedItem;
                        writer.WriteLine(favResolution);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message} {ex.StackTrace}");
            }

            if (cbLang.SelectedItem == null)
            {
                MessageBox.Show("Morate odabrati jezik...", "Warning!", MessageBoxButton.OK, MessageBoxImage.Warning);
                cbLang.Focus();
            }
            if (cbContest.SelectedItem == null)
            {
                MessageBox.Show("Morate odabrati prvenstvo...", "Warning!", MessageBoxButton.OK, MessageBoxImage.Warning);
                cbLang.Focus();
            }
            if (cbResolution.SelectedItem == null)
            {
                MessageBox.Show("Morate odabrati rezoluciju...", "Warning!", MessageBoxButton.OK, MessageBoxImage.Warning);
                cbLang.Focus();
            }
            else
            {
                MessageBox.Show("Uspješno ste spremili postavke...", "Information!", MessageBoxButton.OK, MessageBoxImage.Information);
                Close();
            }
        }

    }
}
