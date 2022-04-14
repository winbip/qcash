namespace QCash
{
    partial class frmSplash
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
            this.pbProductLogo = new System.Windows.Forms.PictureBox();
            this.MyProgressBar = new Framework.Controls.XpProgressBar();
            this.bgwPrimaryDataLoader = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.pbProductLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // pbProductLogo
            // 
            this.pbProductLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pbProductLogo.Location = new System.Drawing.Point(0, 0);
            this.pbProductLogo.Name = "pbProductLogo";
            this.pbProductLogo.Size = new System.Drawing.Size(435, 242);
            this.pbProductLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbProductLogo.TabIndex = 0;
            this.pbProductLogo.TabStop = false;
            // 
            // MyProgressBar
            // 
            this.MyProgressBar.ColorBackGround = System.Drawing.Color.White;
            this.MyProgressBar.ColorBarBorder = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(240)))), ((int)(((byte)(170)))));
            this.MyProgressBar.ColorBarCenter = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(150)))), ((int)(((byte)(10)))));
            this.MyProgressBar.ColorText = System.Drawing.Color.Black;
            this.MyProgressBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MyProgressBar.Location = new System.Drawing.Point(0, 242);
            this.MyProgressBar.Name = "MyProgressBar";
            this.MyProgressBar.Position = 50;
            this.MyProgressBar.PositionMax = 100;
            this.MyProgressBar.PositionMin = 0;
            this.MyProgressBar.Size = new System.Drawing.Size(435, 18);
            this.MyProgressBar.TabIndex = 1;
            this.MyProgressBar.Text = "xpProgressBar1";
            // 
            // bgwPrimaryDataLoader
            // 
            this.bgwPrimaryDataLoader.WorkerReportsProgress = true;
            this.bgwPrimaryDataLoader.WorkerSupportsCancellation = true;
            this.bgwPrimaryDataLoader.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwPrimaryDataLoader_DoWork);
            this.bgwPrimaryDataLoader.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwPrimaryDataLoader_RunWorkerCompleted);
            this.bgwPrimaryDataLoader.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgwPrimaryDataLoader_ProgressChanged);
            // 
            // frmSplash
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(435, 260);
            this.Controls.Add(this.MyProgressBar);
            this.Controls.Add(this.pbProductLogo);
            this.Name = "frmSplash";
            this.Text = "frmSplash";
            this.Load += new System.EventHandler(this.frmSplash_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbProductLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbProductLogo;
        private Framework.Controls.XpProgressBar MyProgressBar;
        private System.ComponentModel.BackgroundWorker bgwPrimaryDataLoader;
    }
}