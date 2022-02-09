using DAL.APIConstants;
using DAL.CentralSavings;
using DAL.Data;
using DAL.Model;
using Socker.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Socker
{
    public partial class frmSettings : Form
    {
        public frmSettings()
        {
            InitializeComponent();
        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Dismiss editing?", "Confirm Exit", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dialog == DialogResult.OK)
            {
                this.Close();
            }

        }

        private void frmSettings_Load(object sender, EventArgs e)
        {
            AllSavings.SetCulture(AllSavings.settings.Language);
            PopulateComboBoxLang();
        }

        private void PopulateComboBoxLang()
        {
            Controls.Clear();
            InitializeComponent();
            cbLang.Items.Add(ApiConstants.HR);
            cbLang.Items.Add(ApiConstants.EN);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(ApiConstants.PREF_LANG))
                {
                    if (!File.Exists(ApiConstants.PREF_LANG)) return;
                    var favLang = cbLang.SelectedItem;
                    writer.WriteLine(favLang);
                }

                using (StreamWriter writer = new StreamWriter(ApiConstants.PREF_CUP))
                {
                    if (!File.Exists(ApiConstants.PREF_CUP)) return;
                    if (rbMen.Checked)
                    {
                        var favCup = ApiConstants.MEN;
                        writer.WriteLine(favCup);
                    }
                    if (rbWomen.Checked)
                    {
                        var favCup = ApiConstants.WOMEN;
                        writer.WriteLine(favCup);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message} {ex.StackTrace}");
            }

            if (cbLang.SelectedItem == null)
            {
                MessageBox.Show("Morate odabrati jezik...", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbLang.Focus();
            }
            else
            {
                MessageBox.Show("Uspješno ste spremili postavke...", "Information!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
        }
    }
}
