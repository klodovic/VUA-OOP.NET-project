
namespace Socker
{
    partial class frmSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSettings));
            this.rbWomen = new System.Windows.Forms.RadioButton();
            this.rbMen = new System.Windows.Forms.RadioButton();
            this.cbLang = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnCancle = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // rbWomen
            // 
            resources.ApplyResources(this.rbWomen, "rbWomen");
            this.rbWomen.Name = "rbWomen";
            this.rbWomen.UseVisualStyleBackColor = true;
            // 
            // rbMen
            // 
            resources.ApplyResources(this.rbMen, "rbMen");
            this.rbMen.Checked = true;
            this.rbMen.Name = "rbMen";
            this.rbMen.TabStop = true;
            this.rbMen.UseVisualStyleBackColor = true;
            // 
            // cbLang
            // 
            resources.ApplyResources(this.cbLang, "cbLang");
            this.cbLang.FormattingEnabled = true;
            this.cbLang.Name = "cbLang";
            // 
            // groupBox1
            // 
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Controls.Add(this.rbWomen);
            this.groupBox1.Controls.Add(this.rbMen);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // btnCancle
            // 
            resources.ApplyResources(this.btnCancle, "btnCancle");
            this.btnCancle.Name = "btnCancle";
            this.btnCancle.UseVisualStyleBackColor = true;
            this.btnCancle.Click += new System.EventHandler(this.btnCancle_Click);
            // 
            // pictureBox1
            // 
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.Image = global::Socker.ResourcesSocker.Edit;
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            // 
            // btnSave
            // 
            resources.ApplyResources(this.btnSave, "btnSave");
            this.btnSave.Name = "btnSave";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // frmSettings
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnCancle);
            this.Controls.Add(this.cbLang);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmSettings";
            this.Load += new System.EventHandler(this.frmSettings_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.RadioButton rbWomen;
        private System.Windows.Forms.RadioButton rbMen;
        private System.Windows.Forms.ComboBox cbLang;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnCancle;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnSave;
    }
}