
namespace Socker.CustomControl
{
    partial class Visitors
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Visitors));
            this.lblVisitorsNum = new System.Windows.Forms.Label();
            this.lblVisitorsText = new System.Windows.Forms.Label();
            this.lblStadiumName = new System.Windows.Forms.Label();
            this.lbllHomeTeam = new System.Windows.Forms.Label();
            this.lblAwayTeam = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblVisitorsNum
            // 
            resources.ApplyResources(this.lblVisitorsNum, "lblVisitorsNum");
            this.lblVisitorsNum.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.lblVisitorsNum.Name = "lblVisitorsNum";
            // 
            // lblVisitorsText
            // 
            resources.ApplyResources(this.lblVisitorsText, "lblVisitorsText");
            this.lblVisitorsText.ForeColor = System.Drawing.SystemColors.GrayText;
            this.lblVisitorsText.Name = "lblVisitorsText";
            // 
            // lblStadiumName
            // 
            resources.ApplyResources(this.lblStadiumName, "lblStadiumName");
            this.lblStadiumName.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.lblStadiumName.Name = "lblStadiumName";
            // 
            // lbllHomeTeam
            // 
            resources.ApplyResources(this.lbllHomeTeam, "lbllHomeTeam");
            this.lbllHomeTeam.ForeColor = System.Drawing.Color.LimeGreen;
            this.lbllHomeTeam.Name = "lbllHomeTeam";
            // 
            // lblAwayTeam
            // 
            resources.ApplyResources(this.lblAwayTeam, "lblAwayTeam");
            this.lblAwayTeam.ForeColor = System.Drawing.Color.Gold;
            this.lblAwayTeam.Name = "lblAwayTeam";
            // 
            // pictureBox1
            // 
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            // 
            // Visitors
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lblAwayTeam);
            this.Controls.Add(this.lbllHomeTeam);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblVisitorsNum);
            this.Controls.Add(this.lblVisitorsText);
            this.Controls.Add(this.lblStadiumName);
            this.Name = "Visitors";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblVisitorsNum;
        private System.Windows.Forms.Label lblVisitorsText;
        private System.Windows.Forms.Label lblStadiumName;
        private System.Windows.Forms.Label lbllHomeTeam;
        private System.Windows.Forms.Label lblAwayTeam;
    }
}
