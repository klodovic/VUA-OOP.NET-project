using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL.APIConstants;
using DAL.CentralSavings;

namespace Socker
{
    public partial class frmStart : Form
    {
        public frmStart()
        {
            InitializeComponent();
        }

        private void frmStart_Load(object sender, EventArgs e)
        {
            PopulateComboBoxLang();
            try
            {
                if (new FileInfo(ApiConstants.PREF_LANG).Length != 0)
                {
                    var lines = File.ReadAllLines(ApiConstants.PREF_LANG);

                    foreach (var item in lines)
                    {
                        if (item.Equals(ApiConstants.EN))
                        {
                            AllSavings.SetCulture(ApiConstants.EN);
                            AllSavings.settings.Language = ApiConstants.EN;
                            ComboBoxLang();
                            cbLang.SelectedItem = ApiConstants.EN;
                        }
                        if (item.Equals(ApiConstants.HR))
                        {
                            AllSavings.SetCulture(ApiConstants.HR);
                            AllSavings.settings.Language = ApiConstants.HR;
                            ComboBoxLang();
                            cbLang.SelectedItem = ApiConstants.HR;
                        }
                    }
                }

                if (new FileInfo(ApiConstants.PREF_CUP).Length != 0)
                {
                    var lines = File.ReadAllLines(ApiConstants.PREF_CUP);

                    foreach (var item in lines)
                    {
                        if (item.Equals(ApiConstants.MEN))
                        {
                            rbMen.Checked = true;
                            AllSavings.settings.Gender = ApiConstants.MEN;
                        }
                        if (item.Equals(ApiConstants.WOMEN))
                        {
                            rbWomen.Checked = true;
                            AllSavings.settings.Gender = ApiConstants.WOMEN;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
            }
        }




        private void cbLang_SelectedIndexChanged(object sender, EventArgs e)
        {
            int lastIndex = cbLang.SelectedIndex;
            if (lastIndex == 1)
            {
                AllSavings.SetCulture(ApiConstants.EN);
                AllSavings.settings.Language = ApiConstants.EN;
                ComboBoxLang();
                cbLang.SelectedItem = ApiConstants.EN;
            }
            if (lastIndex == 0)
            {
                AllSavings.SetCulture(ApiConstants.HR);
                AllSavings.settings.Language = ApiConstants.HR;
                ComboBoxLang();
                cbLang.SelectedItem = ApiConstants.HR;
            }
        }

        private void ComboBoxLang()
        {
            if (!cbLang.Items.Contains(ApiConstants.HR))
            {
                cbLang.Items.Add(ApiConstants.HR);
            }
            if (!cbLang.Items.Contains(ApiConstants.EN))
            {
                cbLang.Items.Add(ApiConstants.EN);
            }
        }

        private void PopulateComboBoxLang()
        {
            Controls.Clear();
            InitializeComponent();
            cbLang.Items.Add(ApiConstants.HR);
            cbLang.Items.Add(ApiConstants.EN);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (rbMen.Checked)
            {
                AllSavings.settings.Gender = ApiConstants.MEN;
            }
            if (rbWomen.Checked)
            {
                AllSavings.settings.Gender = ApiConstants.WOMEN;
            }

            FavoritTeam favoritTeam = new FavoritTeam();
            favoritTeam.Show();
        }
    }
}
