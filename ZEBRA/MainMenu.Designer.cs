﻿namespace ZEBRA
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
            ((System.ComponentModel.ISupportInitialize)(this.list)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // newReportButton
            // 
            this.newReportButton.BackColor = System.Drawing.Color.DimGray;
            this.newReportButton.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.newReportButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.newReportButton.Location = new System.Drawing.Point(12, 86);
            this.newReportButton.Name = "newReportButton";
            this.newReportButton.Size = new System.Drawing.Size(75, 23);
            this.newReportButton.TabIndex = 0;
            this.newReportButton.Text = "新規作成";
            this.newReportButton.UseVisualStyleBackColor = false;
            this.newReportButton.Click += new System.EventHandler(this.newReportButton_Click);
            // 
            // searchWord
            // 
            this.searchWord.Location = new System.Drawing.Point(99, 197);
            this.searchWord.Name = "searchWord";
            this.searchWord.Size = new System.Drawing.Size(123, 19);
            this.searchWord.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(51, 197);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 18);
            this.label1.TabIndex = 2;
            this.label1.Text = "検索";
            // 
            // list
            // 
            this.list.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.list.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.list.Location = new System.Drawing.Point(99, 261);
            this.list.Name = "list";
            this.list.RowTemplate.Height = 21;
            this.list.Size = new System.Drawing.Size(494, 266);
            this.list.TabIndex = 3;
            this.list.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.list_CellContentClick);
            // 
            // admitLinkLabel
            // 
            this.admitLinkLabel.AutoSize = true;
            this.admitLinkLabel.LinkColor = System.Drawing.Color.Navy;
            this.admitLinkLabel.Location = new System.Drawing.Point(127, 138);
            this.admitLinkLabel.Name = "admitLinkLabel";
            this.admitLinkLabel.Size = new System.Drawing.Size(50, 12);
            this.admitLinkLabel.TabIndex = 4;
            this.admitLinkLabel.TabStop = true;
            this.admitLinkLabel.Text = "承認待ち";
            this.admitLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.admitLinkLabel_LinkClicked);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label2.Location = new System.Drawing.Point(42, 138);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 18);
            this.label2.TabIndex = 5;
            this.label2.Text = "お知らせ";
            // 
            // NGLinkLabel
            // 
            this.NGLinkLabel.AutoSize = true;
            this.NGLinkLabel.LinkColor = System.Drawing.Color.Navy;
            this.NGLinkLabel.Location = new System.Drawing.Point(127, 161);
            this.NGLinkLabel.Name = "NGLinkLabel";
            this.NGLinkLabel.Size = new System.Drawing.Size(45, 12);
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
            this.logoutButton.Location = new System.Drawing.Point(298, 12);
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
            this.label3.Font = new System.Drawing.Font("メイリオ", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label3.Location = new System.Drawing.Point(123, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(140, 36);
            this.label3.TabIndex = 13;
            this.label3.Text = "TOP MENU";
            // 
            // searchButton
            // 
            this.searchButton.BackColor = System.Drawing.Color.DimGray;
            this.searchButton.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.searchButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.searchButton.Location = new System.Drawing.Point(253, 192);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(75, 23);
            this.searchButton.TabIndex = 14;
            this.searchButton.Text = "検索";
            this.searchButton.UseVisualStyleBackColor = false;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Ivory;
            this.ClientSize = new System.Drawing.Size(665, 556);
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
    }
}

