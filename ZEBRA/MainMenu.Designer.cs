namespace ZEBRA
{
    partial class MainMenu
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.newReportButton = new System.Windows.Forms.Button();
            this.searchWord = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.list = new System.Windows.Forms.DataGridView();
            this.admitLinkLabel = new System.Windows.Forms.LinkLabel();
            this.label2 = new System.Windows.Forms.Label();
            this.NGLinkLabel = new System.Windows.Forms.LinkLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.logoutButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.searchButton = new System.Windows.Forms.Button();
            this.userName = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.list)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // newReportButton
            // 
            this.newReportButton.BackColor = System.Drawing.Color.LightGray;
            this.newReportButton.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.newReportButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.newReportButton.Location = new System.Drawing.Point(100, 12);
            this.newReportButton.Name = "newReportButton";
            this.newReportButton.Size = new System.Drawing.Size(105, 36);
            this.newReportButton.TabIndex = 0;
            this.newReportButton.Text = "新規作成";
            this.newReportButton.UseVisualStyleBackColor = false;
            this.newReportButton.Click += new System.EventHandler(this.newReportButton_Click);
            // 
            // searchWord
            // 
            this.searchWord.Location = new System.Drawing.Point(207, 221);
            this.searchWord.Name = "searchWord";
            this.searchWord.Size = new System.Drawing.Size(170, 19);
            this.searchWord.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(107, 222);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "作成者検索";
            // 
            // list
            // 
            this.list.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.list.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.list.Location = new System.Drawing.Point(54, 261);
            this.list.Name = "list";
            this.list.RowTemplate.Height = 21;
            this.list.Size = new System.Drawing.Size(648, 266);
            this.list.TabIndex = 3;
            this.list.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.list_CellContentClick);
            // 
            // admitLinkLabel
            // 
            this.admitLinkLabel.AutoSize = true;
            this.admitLinkLabel.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.admitLinkLabel.LinkColor = System.Drawing.Color.Navy;
            this.admitLinkLabel.Location = new System.Drawing.Point(205, 164);
            this.admitLinkLabel.Name = "admitLinkLabel";
            this.admitLinkLabel.Size = new System.Drawing.Size(56, 13);
            this.admitLinkLabel.TabIndex = 4;
            this.admitLinkLabel.TabStop = true;
            this.admitLinkLabel.Text = "承認待ち";
            this.admitLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.admitLinkLabel_LinkClicked);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label2.Location = new System.Drawing.Point(120, 164);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "お知らせ";
            // 
            // NGLinkLabel
            // 
            this.NGLinkLabel.AutoSize = true;
            this.NGLinkLabel.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.NGLinkLabel.LinkColor = System.Drawing.Color.Navy;
            this.NGLinkLabel.Location = new System.Drawing.Point(205, 189);
            this.NGLinkLabel.Name = "NGLinkLabel";
            this.NGLinkLabel.Size = new System.Drawing.Size(50, 13);
            this.NGLinkLabel.TabIndex = 7;
            this.NGLinkLabel.TabStop = true;
            this.NGLinkLabel.Text = "承認NG";
            this.NGLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.NGLinkLabel_LinkClicked);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::ZEBRA.Properties.Resources.zebra;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(75, 68);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // logoutButton
            // 
            this.logoutButton.BackColor = System.Drawing.Color.DimGray;
            this.logoutButton.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.logoutButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.logoutButton.Location = new System.Drawing.Point(643, 8);
            this.logoutButton.Name = "logoutButton";
            this.logoutButton.Size = new System.Drawing.Size(75, 23);
            this.logoutButton.TabIndex = 11;
            this.logoutButton.Text = "ログアウト";
            this.logoutButton.UseVisualStyleBackColor = false;
            this.logoutButton.Click += new System.EventHandler(this.logoutButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("HG創英角ｺﾞｼｯｸUB", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label3.Location = new System.Drawing.Point(292, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(132, 27);
            this.label3.TabIndex = 13;
            this.label3.Text = "TOP MENU";
            // 
            // searchButton
            // 
            this.searchButton.BackColor = System.Drawing.Color.DimGray;
            this.searchButton.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.searchButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.searchButton.Location = new System.Drawing.Point(403, 219);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(75, 23);
            this.searchButton.TabIndex = 14;
            this.searchButton.Text = "検索";
            this.searchButton.UseVisualStyleBackColor = false;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // userName
            // 
            this.userName.AutoSize = true;
            this.userName.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.userName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.userName.Location = new System.Drawing.Point(459, 12);
            this.userName.Name = "userName";
            this.userName.Size = new System.Drawing.Size(45, 13);
            this.userName.TabIndex = 16;
            this.userName.Text = "label5";
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Ivory;
            this.ClientSize = new System.Drawing.Size(730, 556);
            this.Controls.Add(this.userName);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.logoutButton);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.NGLinkLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.admitLinkLabel);
            this.Controls.Add(this.list);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.searchWord);
            this.Controls.Add(this.newReportButton);
            this.Name = "MainMenu";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainMenu_FormClosed);
            this.Load += new System.EventHandler(this.MainMenu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.list)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button newReportButton;
        private System.Windows.Forms.TextBox searchWord;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView list;
        private System.Windows.Forms.LinkLabel admitLinkLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.LinkLabel NGLinkLabel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button logoutButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.Label userName;
    }
}

