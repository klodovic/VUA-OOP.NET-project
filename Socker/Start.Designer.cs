
namespace Socker
{
    partial class frmStart
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmStart));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbWomen = new System.Windows.Forms.RadioButton();
            this.rbMen = new System.Windows.Forms.RadioButton();
            this.btnNext = new System.Windows.Forms.Button();
            this.cbLang = new System.Windows.Forms.ComboBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbWomen);
            this.groupBox1.Controls.Add(this.rbMen);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
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
            // btnNext
            // 
            resources.ApplyResources(this.btnNext, "btnNext");
            this.btnNext.Name = "btnNext";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // cbLang
            // 
            resources.ApplyResources(this.cbLang, "cbLang");
            this.cbLang.FormattingEnabled = true;
            this.cbLang.Name = "cbLang";
            this.cbLang.SelectedIndexChanged += new System.EventHandler(this.cbLang_SelectedIndexChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Socker.ResourcesSocker.football_field;
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            // 
            // frmStart
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cbLang);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnNext);
            this.Name = "frmStart";
            this.Load += new System.EventHandler(this.frmStart_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbWomen;
        private System.Windows.Forms.RadioButton rbMen;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.ComboBox cbLang;
    }
}

