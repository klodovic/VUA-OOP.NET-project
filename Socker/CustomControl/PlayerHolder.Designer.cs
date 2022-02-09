namespace Socker.CustomControl
{
    partial class PlayerHolder
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlayerHolder));
            this.btnChangePlayerImage = new System.Windows.Forms.Button();
            this.lblPlayerNumber = new System.Windows.Forms.Label();
            this.lblPlayerName = new System.Windows.Forms.Label();
            this.lblPosition = new System.Windows.Forms.Label();
            this.lblCaptain = new System.Windows.Forms.Label();
            this.lblYesNo = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.pbStar = new System.Windows.Forms.PictureBox();
            this.pbPlayerImage = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbStar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPlayerImage)).BeginInit();
            this.SuspendLayout();
            // 
            // btnChangePlayerImage
            // 
            resources.ApplyResources(this.btnChangePlayerImage, "btnChangePlayerImage");
            this.btnChangePlayerImage.Name = "btnChangePlayerImage";
            this.btnChangePlayerImage.UseVisualStyleBackColor = true;
            this.btnChangePlayerImage.Click += new System.EventHandler(this.btnChangePlayerImage_Click);
            // 
            // lblPlayerNumber
            // 
            resources.ApplyResources(this.lblPlayerNumber, "lblPlayerNumber");
            this.lblPlayerNumber.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.lblPlayerNumber.Name = "lblPlayerNumber";
            // 
            // lblPlayerName
            // 
            resources.ApplyResources(this.lblPlayerName, "lblPlayerName");
            this.lblPlayerName.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.lblPlayerName.Name = "lblPlayerName";
            // 
            // lblPosition
            // 
            resources.ApplyResources(this.lblPosition, "lblPosition");
            this.lblPosition.ForeColor = System.Drawing.SystemColors.GrayText;
            this.lblPosition.Name = "lblPosition";
            // 
            // lblCaptain
            // 
            resources.ApplyResources(this.lblCaptain, "lblCaptain");
            this.lblCaptain.ForeColor = System.Drawing.SystemColors.GrayText;
            this.lblCaptain.Name = "lblCaptain";
            // 
            // lblYesNo
            // 
            resources.ApplyResources(this.lblYesNo, "lblYesNo");
            this.lblYesNo.ForeColor = System.Drawing.SystemColors.GrayText;
            this.lblYesNo.Name = "lblYesNo";
            // 
            // pbStar
            // 
            resources.ApplyResources(this.pbStar, "pbStar");
            this.pbStar.Name = "pbStar";
            this.pbStar.TabStop = false;
            // 
            // pbPlayerImage
            // 
            resources.ApplyResources(this.pbPlayerImage, "pbPlayerImage");
            this.pbPlayerImage.Name = "pbPlayerImage";
            this.pbPlayerImage.TabStop = false;
            // 
            // PlayerHolder
            // 
            resources.ApplyResources(this, "$this");
            this.AllowDrop = true;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lblYesNo);
            this.Controls.Add(this.lblCaptain);
            this.Controls.Add(this.lblPosition);
            this.Controls.Add(this.lblPlayerName);
            this.Controls.Add(this.lblPlayerNumber);
            this.Controls.Add(this.btnChangePlayerImage);
            this.Controls.Add(this.pbStar);
            this.Controls.Add(this.pbPlayerImage);
            this.Name = "PlayerHolder";
            //this.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.PlayerHolder_MouseDoubleClick);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PlayerHolder_MouseDown);
            ((System.ComponentModel.ISupportInitialize)(this.pbStar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPlayerImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbPlayerImage;
        private System.Windows.Forms.PictureBox pbStar;
        private System.Windows.Forms.Button btnChangePlayerImage;
        private System.Windows.Forms.Label lblPlayerNumber;
        private System.Windows.Forms.Label lblPlayerName;
        private System.Windows.Forms.Label lblPosition;
        private System.Windows.Forms.Label lblCaptain;
        private System.Windows.Forms.Label lblYesNo;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}
