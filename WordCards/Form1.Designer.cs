namespace WordCards
{
    partial class frmWordCards
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.palMain = new System.Windows.Forms.Panel();
            this.lstWordList = new System.Windows.Forms.ListBox();
            this.txtHelp = new System.Windows.Forms.Label();
            this.txtExplain = new System.Windows.Forms.Label();
            this.txtPhonogram = new System.Windows.Forms.Label();
            this.txtWord = new System.Windows.Forms.Label();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.btnAutoPlay = new System.Windows.Forms.Button();
            this.sssWord = new System.Windows.Forms.StatusStrip();
            this.tsslMessage = new System.Windows.Forms.ToolStripStatusLabel();
            this.timPlayer = new System.Windows.Forms.Timer(this.components);
            this.palMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.sssWord.SuspendLayout();
            this.SuspendLayout();
            // 
            // palMain
            // 
            this.palMain.BackColor = System.Drawing.Color.NavajoWhite;
            this.palMain.Controls.Add(this.lstWordList);
            this.palMain.Controls.Add(this.txtHelp);
            this.palMain.Controls.Add(this.txtExplain);
            this.palMain.Controls.Add(this.txtPhonogram);
            this.palMain.Controls.Add(this.txtWord);
            this.palMain.Controls.Add(this.picLogo);
            this.palMain.Controls.Add(this.btnAutoPlay);
            this.palMain.Dock = System.Windows.Forms.DockStyle.Top;
            this.palMain.Location = new System.Drawing.Point(0, 0);
            this.palMain.Name = "palMain";
            this.palMain.Size = new System.Drawing.Size(595, 247);
            this.palMain.TabIndex = 0;
            this.palMain.Paint += new System.Windows.Forms.PaintEventHandler(this.palMain_Paint);
            // 
            // lstWordList
            // 
            this.lstWordList.Dock = System.Windows.Forms.DockStyle.Left;
            this.lstWordList.FormattingEnabled = true;
            this.lstWordList.ItemHeight = 12;
            this.lstWordList.Location = new System.Drawing.Point(0, 0);
            this.lstWordList.Name = "lstWordList";
            this.lstWordList.Size = new System.Drawing.Size(120, 247);
            this.lstWordList.TabIndex = 10;
            this.lstWordList.Click += new System.EventHandler(this.lstWordList_Click);
            // 
            // txtHelp
            // 
            this.txtHelp.ForeColor = System.Drawing.Color.Red;
            this.txtHelp.Location = new System.Drawing.Point(461, 187);
            this.txtHelp.Name = "txtHelp";
            this.txtHelp.Size = new System.Drawing.Size(109, 34);
            this.txtHelp.TabIndex = 9;
            this.txtHelp.Text = " Enter 下一個單字\n Space重複";
            this.txtHelp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtExplain
            // 
            this.txtExplain.AutoSize = true;
            this.txtExplain.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtExplain.ForeColor = System.Drawing.Color.DimGray;
            this.txtExplain.Location = new System.Drawing.Point(145, 87);
            this.txtExplain.Name = "txtExplain";
            this.txtExplain.Size = new System.Drawing.Size(44, 17);
            this.txtExplain.TabIndex = 8;
            this.txtExplain.Text = "label3";
            // 
            // txtPhonogram
            // 
            this.txtPhonogram.AutoSize = true;
            this.txtPhonogram.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtPhonogram.ForeColor = System.Drawing.Color.Green;
            this.txtPhonogram.Location = new System.Drawing.Point(143, 55);
            this.txtPhonogram.Name = "txtPhonogram";
            this.txtPhonogram.Size = new System.Drawing.Size(56, 21);
            this.txtPhonogram.TabIndex = 7;
            this.txtPhonogram.Text = "label2";
            // 
            // txtWord
            // 
            this.txtWord.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtWord.AutoSize = true;
            this.txtWord.Font = new System.Drawing.Font("微軟正黑體", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtWord.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.txtWord.Location = new System.Drawing.Point(141, 9);
            this.txtWord.Name = "txtWord";
            this.txtWord.Size = new System.Drawing.Size(92, 35);
            this.txtWord.TabIndex = 6;
            this.txtWord.Text = "label1";
            // 
            // picLogo
            // 
            this.picLogo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picLogo.Image = global::WordCards.Properties.Resources.WordCards_Logo;
            this.picLogo.Location = new System.Drawing.Point(474, 9);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(86, 104);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picLogo.TabIndex = 4;
            this.picLogo.TabStop = false;
            this.picLogo.Click += new System.EventHandler(this.picLogo_Click);
            // 
            // btnAutoPlay
            // 
            this.btnAutoPlay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAutoPlay.Location = new System.Drawing.Point(474, 119);
            this.btnAutoPlay.Name = "btnAutoPlay";
            this.btnAutoPlay.Size = new System.Drawing.Size(86, 23);
            this.btnAutoPlay.TabIndex = 3;
            this.btnAutoPlay.Text = "Play";
            this.btnAutoPlay.UseVisualStyleBackColor = true;
            this.btnAutoPlay.Click += new System.EventHandler(this.btnAutoPlay_Click);
            // 
            // sssWord
            // 
            this.sssWord.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslMessage});
            this.sssWord.Location = new System.Drawing.Point(0, 250);
            this.sssWord.Name = "sssWord";
            this.sssWord.Size = new System.Drawing.Size(595, 22);
            this.sssWord.TabIndex = 6;
            this.sssWord.Text = "statusStrip1";
            // 
            // tsslMessage
            // 
            this.tsslMessage.Name = "tsslMessage";
            this.tsslMessage.Size = new System.Drawing.Size(58, 17);
            this.tsslMessage.Text = "Message";
            // 
            // timPlayer
            // 
            this.timPlayer.Interval = 200;
            this.timPlayer.Tick += new System.EventHandler(this.timPlayer_Tick);
            // 
            // frmWordCards
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(595, 272);
            this.Controls.Add(this.sssWord);
            this.Controls.Add(this.palMain);
            this.KeyPreview = true;
            this.Name = "frmWordCards";
            this.Text = "單字卡";
            this.Load += new System.EventHandler(this.frmWordCards_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frmWordCards_KeyPress);
            this.palMain.ResumeLayout(false);
            this.palMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.sssWord.ResumeLayout(false);
            this.sssWord.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel palMain;
        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.Button btnAutoPlay;
        private System.Windows.Forms.StatusStrip sssWord;
        private System.Windows.Forms.ToolStripStatusLabel tsslMessage;
        private System.Windows.Forms.Timer timPlayer;
        private System.Windows.Forms.Label txtHelp;
        private System.Windows.Forms.Label txtExplain;
        private System.Windows.Forms.Label txtPhonogram;
        private System.Windows.Forms.Label txtWord;
        private System.Windows.Forms.ListBox lstWordList;
    }
}

