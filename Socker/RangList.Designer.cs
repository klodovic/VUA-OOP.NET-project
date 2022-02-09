
namespace Socker
{
    partial class RangList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RangList));
            this.flpGoals = new System.Windows.Forms.FlowLayoutPanel();
            this.lblGoalsText = new System.Windows.Forms.Label();
            this.lblYellovCardText = new System.Windows.Forms.Label();
            this.flpYellowCards = new System.Windows.Forms.FlowLayoutPanel();
            this.lblVisitorsText = new System.Windows.Forms.Label();
            this.flpVisitors = new System.Windows.Forms.FlowLayoutPanel();
            this.btnPrint = new System.Windows.Forms.Button();
            this.printDocument = new System.Drawing.Printing.PrintDocument();
            this.printPreviewDialog = new System.Windows.Forms.PrintPreviewDialog();
            this.pageSetupDialog = new System.Windows.Forms.PageSetupDialog();
            this.btnPrintSetup = new System.Windows.Forms.Button();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // flpGoals
            // 
            resources.ApplyResources(this.flpGoals, "flpGoals");
            this.flpGoals.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.flpGoals.Name = "flpGoals";
            // 
            // lblGoalsText
            // 
            resources.ApplyResources(this.lblGoalsText, "lblGoalsText");
            this.lblGoalsText.Name = "lblGoalsText";
            // 
            // lblYellovCardText
            // 
            resources.ApplyResources(this.lblYellovCardText, "lblYellovCardText");
            this.lblYellovCardText.Name = "lblYellovCardText";
            // 
            // flpYellowCards
            // 
            resources.ApplyResources(this.flpYellowCards, "flpYellowCards");
            this.flpYellowCards.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.flpYellowCards.Name = "flpYellowCards";
            // 
            // lblVisitorsText
            // 
            resources.ApplyResources(this.lblVisitorsText, "lblVisitorsText");
            this.lblVisitorsText.Name = "lblVisitorsText";
            // 
            // flpVisitors
            // 
            resources.ApplyResources(this.flpVisitors, "flpVisitors");
            this.flpVisitors.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.flpVisitors.Name = "flpVisitors";
            // 
            // btnPrint
            // 
            resources.ApplyResources(this.btnPrint, "btnPrint");
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // printDocument
            // 
            this.printDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument_PrintPage);
            // 
            // printPreviewDialog
            // 
            resources.ApplyResources(this.printPreviewDialog, "printPreviewDialog");
            this.printPreviewDialog.Document = this.printDocument;
            this.printPreviewDialog.Name = "printPreviewDialog1";
            // 
            // pageSetupDialog
            // 
            this.pageSetupDialog.Document = this.printDocument;
            // 
            // btnPrintSetup
            // 
            resources.ApplyResources(this.btnPrintSetup, "btnPrintSetup");
            this.btnPrintSetup.Name = "btnPrintSetup";
            this.btnPrintSetup.UseVisualStyleBackColor = true;
            this.btnPrintSetup.Click += new System.EventHandler(this.btnPrintSetup_Click);
            // 
            // pictureBox3
            // 
            resources.ApplyResources(this.pictureBox3, "pictureBox3");
            this.pictureBox3.Image = global::Socker.ResourcesSocker.Supporters;
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            resources.ApplyResources(this.pictureBox2, "pictureBox2");
            this.pictureBox2.Image = global::Socker.ResourcesSocker.YellowCard;
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.Image = global::Socker.ResourcesSocker.Goal;
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            // 
            // btnClose
            // 
            resources.ApplyResources(this.btnClose, "btnClose");
            this.btnClose.Name = "btnClose";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // RangList
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnPrintSetup);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.flpVisitors);
            this.Controls.Add(this.lblVisitorsText);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblYellovCardText);
            this.Controls.Add(this.lblGoalsText);
            this.Controls.Add(this.flpYellowCards);
            this.Controls.Add(this.flpGoals);
            this.Name = "RangList";
            this.Load += new System.EventHandler(this.RangList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flpGoals;
        private System.Windows.Forms.Label lblGoalsText;
        private System.Windows.Forms.Label lblYellovCardText;
        private System.Windows.Forms.FlowLayoutPanel flpYellowCards;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label lblVisitorsText;
        private System.Windows.Forms.FlowLayoutPanel flpVisitors;
        private System.Windows.Forms.Button btnPrint;
        private System.Drawing.Printing.PrintDocument printDocument;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog;
        private System.Windows.Forms.PageSetupDialog pageSetupDialog;
        private System.Windows.Forms.Button btnPrintSetup;
        private System.Windows.Forms.Button btnClose;
    }
}