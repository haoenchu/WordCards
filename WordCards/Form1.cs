using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;
using System.Collections.ObjectModel;
using System.IO;



namespace WordCards
{
   

    public partial class frmWordCards : Form
    {
        public class WordItem
        {
            public string Word { get; set; }
            public string Phonogram { get; set; }
            public string SoundPath { get; set; }
            public string Explain { get; set; }
            /// <summary>
            /// 建構子
            /// </summary>
            /// <param name=“str”>單行的單字資料</param>
            public WordItem(string str)
            { // 用Tab分隔字串
                string[] strLists = str.Split('\t');
                if (strLists.Length >= 3)
                {
                    Word = strLists[0];
                    Phonogram = strLists[1];
                    SoundPath = strLists[2];
                    Explain = string.Join(Environment.NewLine, strLists.Skip(3));
                }
            }
            /// <summary>
            /// 覆寫 ToString() 可將物件自動轉換為字串
            /// </summary>
            /// <returns></returns>
            public override string ToString()
            {
                return Word;
            }
        }
        public class WordCollection : Collection<WordItem>
        {
            /// <summary>
            /// 從字串陣列載入資料
            /// </summary>
            /// <param name="lines">輸入的單字字串陣列</param>
            public void LoadFromStringArray(string[] lines)
            {
                this.Clear(); // 清空現有的資料

                // 將字串陣列的資料載入到 WordCollection 物件中
                foreach (string line in lines)
                {
                    // 產生 WordItem 物件
                    WordItem item = new WordItem(line);
                    this.Add(item);
                }
            }
        }

        /// <summary>
        /// 單字清單
        /// </summary>
        WordCollection _WordList = new WordCollection();
        /// <summary>
        /// Windows Media Player 播放器
        /// </summary>
        WindowsMediaPlayer wmp = new WindowsMediaPlayer();
        string strWordFile = "WordCards.txt"; // 單字檔名
        /// <summary>
        /// 是否自動播放
        /// </summary>
        bool isPlay = false;

        /// <summary>
        /// 顯示單字
        /// </summary>
        /// <param name="word">單字物件</param>
        private void ShowWord(WordItem word)
        {
            txtWord.Text = word.Word;
            txtPhonogram.Text = word.Phonogram;
            txtExplain.Text = word.Explain;

            // 換字後重新蓋上遮罩
            UpdateCovers();
        }

        /// <summary>
        /// 將單字加入到播放清單
        /// </summary>
        private void UpdateWordList()
        {
            lstWordList.BeginUpdate(); // 開始更新
            lstWordList.Items.Clear();
            foreach (WordItem item in this._WordList)
            {
                lstWordList.Items.Add(item);
            }
            lstWordList.EndUpdate(); // 結束更新
        }

        public frmWordCards()
        {
            InitializeComponent();
            InitCovers();

        }


        // 在現有欄位下方加入
        bool isMemoryMode = false;      // 是否背單字模式
        bool isHideChinese = false;     // 是否隱藏中文模式
        bool isHideEnglish = false;     // 是否隱藏英文模式


        private void InitCovers()
        {
            picCoverChinese.Cursor = Cursors.Hand;
            picCoverChinese.SendToBack();   // ← 取代 Visible = false

            picCoverEnglish.Cursor = Cursors.Hand;
            picCoverEnglish.SendToBack();   // ← 取代 Visible = false
        }

        private void UpdateCovers()
        {
            if (!isMemoryMode)
            {
                picCoverChinese.SendToBack(); 
                picCoverEnglish.SendToBack(); 
                hide_list.Visible = false;
                return;
            }

            if (isHideChinese)
            {
                picCoverChinese.Bounds = txtExplain.Bounds;
                picCoverChinese.BringToFront();  // 蓋住中文
                picCoverEnglish.SendToBack();
                hide_list.Visible = false;
            }
            else if (isHideEnglish)
            {
                Rectangle r1 = txtWord.Bounds;
                Rectangle r2 = txtPhonogram.Bounds;
                picCoverEnglish.Bounds = Rectangle.Union(r1, r2);
                picCoverEnglish.BringToFront();  // 蓋住英文
                picCoverChinese.SendToBack();

                hide_list.Visible = true;
                hide_list.BringToFront();
            }
        }

        private void picCoverChinese_Click(object sender, EventArgs e)
        {
            picCoverChinese.SendToBack();  // 沉底，露出中文
        }

        private void picCoverEnglish_Click(object sender, EventArgs e)
        {
            picCoverEnglish.SendToBack();  // 沉底，露出英文
            
        }

        // txtExplain (中文) 被點到 → 重新蓋上
        private void txtExplain_Click(object sender, EventArgs e)
        {
            if (isMemoryMode && isHideChinese)
                picCoverChinese.BringToFront();
        }

        // txtWord 被點到 → 重新蓋上
        private void txtWord_Click(object sender, EventArgs e)
        {
            if (isMemoryMode && isHideEnglish)
                picCoverEnglish.BringToFront();
        }

        // txtPhonogram 被點到 → 重新蓋上
        private void txtPhonogram_Click(object sender, EventArgs e)
        {
            if (isMemoryMode && isHideEnglish)
                picCoverEnglish.BringToFront();
        }


        private void btnHideChinese_Click(object sender, EventArgs e)
        {

            isHideChinese = true;
            isHideEnglish = false;
            btnHideChinese.BackColor = Color.LightCoral;   // 標記啟用
            btnHideEnglish.BackColor = SystemColors.Control;
            UpdateCovers();
        }

        private void btnHideEnglish_Click(object sender, EventArgs e)
        {
            isHideEnglish = true;
            isHideChinese = false;
            btnHideEnglish.BackColor = Color.LightCoral;
            btnHideChinese.BackColor = SystemColors.Control;
            UpdateCovers();
        }



        

        private void frmWordCards_Load(object sender, EventArgs e)
        {
            string[] lines;
            // 若單字檔存在
            if (File.Exists(strWordFile))
            {
                lines = File.ReadAllLines(strWordFile, Encoding.UTF8);
            }
            else
            {
                MessageBox.Show($"找不到單字檔\n{strWordFile}", "錯誤", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                Application.Exit();
                return;
            }
            // 載入單字檔
            this._WordList.LoadFromStringArray(lines);
            if (this._WordList.Count > 0)
            {
                // 更新單字清單
                UpdateWordList();
                // 顯示第一個單字
                this.ShowWord(_WordList[0]);
                tsslMessage.Text = $"單字數量：{_WordList.Count}";
            }
        }


        /// <summary>
        /// 播放單字音檔
        /// </summary>
        /// <param name="word">單字物件</param>
        public void PlayWord(WordItem word)
        {
            // 判斷音效檔是否存在
            if (File.Exists(word.SoundPath))
            {
                // 播放單字音檔
                wmp.URL = word.SoundPath;
                wmp.settings.autoStart = false;
                wmp.settings.mute = false;
                wmp.controls.play();
            }
            else
                tsslMessage.Text = $"找無 {word.SoundPath} 音效檔";
        }

        /// <summary>
        /// 播放目前選取的單字
        /// </summary>
        private void PlaySelectedWord()
        {
            // 判斷目前選的項目是否為空
            if (lstWordList.SelectedItem != null)
            {
                // 取得目前選取的單字索引
                int idx = lstWordList.SelectedIndex;
                // 顯示單字
                ShowWord(_WordList[idx]);
                // 播放單字的發音
                PlayWord(_WordList[idx]);
            }
        }

        private void lstWordList_Click(object sender, EventArgs e)
        {
            // 判斷是否自動播放
            if (isPlay == true)
                btnAutoPlay.PerformClick(); // 點擊自動播放按鈕
                                            // 判斷是否有選取項目
            if (lstWordList.SelectedItem != null)
                // 判斷是否有選取項目
                if (lstWordList.SelectedItem.ToString().Length != 0)
                {
                    // 顯示並播放目前選取的單字
                    PlaySelectedWord();
                }
        }

        /// <summary>
        /// 將單字清單的選項移到下一個
        /// </summary>
        private void NextWordList()
        {
            // 將焦點移到單字清單
            lstWordList.Focus();
            // 判斷目前選的下一項是否超過清單的項目數
            if (lstWordList.SelectedIndex + 1 >= lstWordList.Items.Count)
                lstWordList.SelectedIndex = 0; // 如果超過就回到第一項
            else
                lstWordList.SelectedIndex++; // 如果沒有就選擇下一項
                                             // 計算目前 lstWordList 顯示的行數
            int lstRows = lstWordList.Height / lstWordList.GetItemHeight(0);
            // 如果目前選的項目大於 lstRows / 2
            if (lstWordList.SelectedIndex >= lstRows / 2)
                // 將 lstWordList 的 選項保持在中間
                lstWordList.TopIndex = lstWordList.SelectedIndex - lstRows / 2;
        }


        private void palMain_Paint(object sender, PaintEventArgs e)
        {

        }

        private async void timPlayer_Tick(object sender, EventArgs e)
        {
            // 移到下一個單字
            NextWordList();
            // 顯示並播放目前選取的單字
            PlaySelectedWord();
            await Task.Delay(3000);
        }

        private void btnAutoPlay_Click(object sender, EventArgs e)
        {
            // 將焦點移到單字清單
            lstWordList.Focus();
            // 若目前不是自動播放
            if (isPlay == false)
            {
                btnAutoPlay.Text = "Stop";
                isPlay = true;
                // 顯示並播放目前選取的單字
                PlaySelectedWord();
                timPlayer.Start();
            }
            else
            {
                btnAutoPlay.Text = "Play";
                isPlay = false;
                timPlayer.Stop();
            }

        }

        private void frmWordCards_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (isPlay == true)
                return;
            switch (e.KeyChar)
            {
                case (char)Keys.Return:
                    // 當按下 Enter 時，播放下一個單字
                    NextWordList();
                    // 顯示並播放目前選取的單字
                    PlaySelectedWord();
                    e.Handled = true;
                    break;
                case (char)Keys.Space:
                    // 當按下 Space 時，重複播放目前單字
                    if (lstWordList.SelectedIndex >= 0)
                    {
                        // 顯示並播放目前選取的單字
                        PlaySelectedWord();
                    }
                    e.Handled = true;
                    break;
                case (char)Keys.F1:
                    PlaySelectedWord();
                    break;
            }
        }



        private void btnMemoryMode_Click(object sender, EventArgs e)
        {
            
            isMemoryMode = !isMemoryMode;

            if (isMemoryMode)
            {
                if (!isHideChinese && !isHideEnglish) {
                    MessageBox.Show("請先選擇隱藏中文或英文", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    isMemoryMode = false;
                    return;
                }
                    


                btnMemoryMode.Text = "結束背單字";
                btnMemoryMode.BackColor = Color.LightGreen;
                UpdateCovers();
            }
            else
            {
                btnMemoryMode.Text = "背單字模式";
                btnMemoryMode.BackColor = SystemColors.Control;
                UpdateCovers();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            // 播放目前顯示的單字（不移動到下一個）
            if (lstWordList.SelectedIndex >= 0)
            {
                PlayWord(_WordList[lstWordList.SelectedIndex]);
            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void lstWordList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void picLogo_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e) {
            PlaySelectedWord();
        }

        private void hide_list_Click(object sender, EventArgs e) {

        }
    }
}
