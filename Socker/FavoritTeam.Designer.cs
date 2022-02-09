
namespace Socker
{
    partial class FavoritTeam
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FavoritTeam));
            this.cbCountry = new System.Windows.Forms.ComboBox();
            this.flpAllTeamPlayers = new System.Windows.Forms.FlowLayoutPanel();
            this.flpFavoritePlayers = new System.Windows.Forms.FlowLayoutPanel();
            this.btnReturnToAllPlayers = new System.Windows.Forms.Button();
            this.lblInfo = new System.Windows.Forms.Label();
            this.btnAddToFavoritePlayers = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnRangList = new System.Windows.Forms.Button();
            this.btnSettings = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // cbCountry
            // 
            resources.ApplyResources(this.cbCountry, "cbCountry");
            this.cbCountry.FormattingEnabled = true;
            this.cbCountry.Name = "cbCountry";
            this.cbCountry.SelectedIndexChanged += new System.EventHandler(this.cbCountry_SelectedIndexChanged);
            // 
            // flpAllTeamPlayers
            // 
            resources.ApplyResources(this.flpAllTeamPlayers, "flpAllTeamPlayers");
            this.flpAllTeamPlayers.AllowDrop = true;
            this.flpAllTeamPlayers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.flpAllTeamPlayers.Name = "flpAllTeamPlayers";
            this.flpAllTeamPlayers.DragDrop += new System.Windows.Forms.DragEventHandler(this.flpAllTeamPlayers_DragDrop);
            this.flpAllTeamPlayers.DragOver += new System.Windows.Forms.DragEventHandler(this.flpAllTeamPlayers_DragOver);
            // 
            // flpFavoritePlayers
            // 
            resources.ApplyResources(this.flpFavoritePlayers, "flpFavoritePlayers");
            this.flpFavoritePlayers.AllowDrop = true;
            this.flpFavoritePlayers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.flpFavoritePlayers.Name = "flpFavoritePlayers";
            this.flpFavoritePlayers.DragDrop += new System.Windows.Forms.DragEventHandler(this.flpFavoritePlayers_DragDrop);
            this.flpFavoritePlayers.DragOver += new System.Windows.Forms.DragEventHandler(this.flpFavoritePlayers_DragOver);
            // 
            // btnReturnToAllPlayers
            // 
            resources.ApplyResources(this.btnReturnToAllPlayers, "btnReturnToAllPlayers");
            this.btnReturnToAllPlayers.Name = "btnReturnToAllPlayers";
            this.btnReturnToAllPlayers.UseVisualStyleBackColor = true;
            this.btnReturnToAllPlayers.Click += new System.EventHandler(this.btnReturnToAllPlayers_Click);
            // 
            // lblInfo
            // 
            resources.ApplyResources(this.lblInfo, "lblInfo");
            this.lblInfo.Name = "lblInfo";
            // 
            // btnAddToFavoritePlayers
            // 
            resources.ApplyResources(this.btnAddToFavoritePlayers, "btnAddToFavoritePlayers");
            this.btnAddToFavoritePlayers.Name = "btnAddToFavoritePlayers";
            this.btnAddToFavoritePlayers.UseVisualStyleBackColor = true;
            this.btnAddToFavoritePlayers.Click += new System.EventHandler(this.btnAddToFavoritePlayers_Click);
            // 
            // btnSave
            // 
            resources.ApplyResources(this.btnSave, "btnSave");
            this.btnSave.Name = "btnSave";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnRangList
            // 
            resources.ApplyResources(this.btnRangList, "btnRangList");
            this.btnRangList.Name = "btnRangList";
            this.btnRangList.UseVisualStyleBackColor = true;
            this.btnRangList.Click += new System.EventHandler(this.btnRangList_Click);
            // 
            // btnSettings
            // 
            resources.ApplyResources(this.btnSettings, "btnSettings");
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.UseVisualStyleBackColor = true;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // btnClose
            // 
            resources.ApplyResources(this.btnClose, "btnClose");
            this.btnClose.Name = "btnClose";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // pictureBox1
            // 
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.Image = global::Socker.ResourcesSocker.fav;
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            // 
            // FavoritTeam
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSettings);
            this.Controls.Add(this.btnRangList);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnAddToFavoritePlayers);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.btnReturnToAllPlayers);
            this.Controls.Add(this.flpFavoritePlayers);
            this.Controls.Add(this.flpAllTeamPlayers);
            this.Controls.Add(this.cbCountry);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Name = "FavoritTeam";
            this.Load += new System.EventHandler(this.FavoritTeam_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox cbCountry;
        private System.Windows.Forms.FlowLayoutPanel flpAllTeamPlayers;
        private System.Windows.Forms.FlowLayoutPanel flpFavoritePlayers;
        private System.Windows.Forms.Button btnReturnToAllPlayers;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.Button btnAddToFavoritePlayers;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnRangList;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.Button btnClose;
    }
}