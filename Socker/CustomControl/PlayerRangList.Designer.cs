
namespace Socker.CustomControl
{
    partial class PlayerRangList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlayerRangList));
            this.lblPlayerName = new System.Windows.Forms.Label();
            this.lblEvent = new System.Windows.Forms.Label();
            this.lblEventNum = new System.Windows.Forms.Label();
            this.pbPlayerPicture = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbPlayerPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // lblPlayerName
            // 
            resources.ApplyResources(this.lblPlayerName, "lblPlayerName");
            this.lblPlayerName.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.lblPlayerName.Name = "lblPlayerName";
            // 
            // lblEvent
            // 
            resources.ApplyResources(this.lblEvent, "lblEvent");
            this.lblEvent.ForeColor = System.Drawing.SystemColors.GrayText;
            this.lblEvent.Name = "lblEvent";
            // 
            // lblEventNum
            // 
            resources.ApplyResources(this.lblEventNum, "lblEventNum");
            this.lblEventNum.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.lblEventNum.Name = "lblEventNum";
            // 
            // pbPlayerPicture
            // 
            resources.ApplyResources(this.pbPlayerPicture, "pbPlayerPicture");
            this.pbPlayerPicture.Image = global::Socker.ResourcesSocker.male_player;
            this.pbPlayerPicture.Name = "pbPlayerPicture";
            this.pbPlayerPicture.TabStop = false;
            // 
            // PlayerRangList
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.pbPlayerPicture);
            this.Controls.Add(this.lblEventNum);
            this.Controls.Add(this.lblEvent);
            this.Controls.Add(this.lblPlayerName);
            this.Name = "PlayerRangList";
            ((System.ComponentModel.ISupportInitialize)(this.pbPlayerPicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblPlayerName;
        private System.Windows.Forms.Label lblEvent;
        private System.Windows.Forms.Label lblEventNum;
        private System.Windows.Forms.PictureBox pbPlayerPicture;
    }
}
