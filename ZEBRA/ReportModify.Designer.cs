namespace ZEBRA
{
    partial class ReportModify
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
            this.label1 = new System.Windows.Forms.Label();
            this.topPageButton = new System.Windows.Forms.Button();
            this.registButton = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.toMinute = new System.Windows.Forms.ComboBox();
            this.toHour = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.fromMinute = new System.Windows.Forms.ComboBox();
            this.fromHour = new System.Windows.Forms.ComboBox();
            this.toDate = new System.Windows.Forms.DateTimePicker();
            this.fromDate = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.another = new System.Windows.Forms.RadioButton();
            this.their = new System.Windows.Forms.RadioButton();
            this.opponentHouse = new System.Windows.Forms.RadioButton();
            this.bossName = new System.Windows.Forms.Label();
            this.customer_search = new System.Windows.Forms.Button();
            this.customer = new System.Windows.Forms.TextBox();
            this.reportText = new System.Windows.Forms.TextBox();
            this.createDate = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.mail = new System.Windows.Forms.RadioButton();
            this.tell = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(224, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 19);
            this.label1.TabIndex = 14;
            this.label1.Text = "日報修正";
            // 
            // topPageButton
            // 
            this.topPageButton.BackColor = System.Drawing.Color.DimGray;
            this.topPageButton.ForeColor = System.Drawing.Color.White;
            this.topPageButton.Location = new System.Drawing.Point(10, 81);
            this.topPageButton.Name = "topPageButton";
            this.topPageButton.Size = new System.Drawing.Size(75, 23);
            this.topPageButton.TabIndex = 30;
            this.topPageButton.Text = "トップページ";
            this.topPageButton.UseVisualStyleBackColor = false;
            // 
            // registButton
            // 
            this.registButton.BackColor = System.Drawing.Color.DimGray;
            this.registButton.ForeColor = System.Drawing.Color.White;
            this.registButton.Location = new System.Drawing.Point(24, 506);
            this.registButton.Name = "registButton";
            this.registButton.Size = new System.Drawing.Size(75, 23);
            this.registButton.TabIndex = 29;
            this.registButton.Text = "修正";
            this.registButton.UseVisualStyleBackColor = false;
            this.registButton.Click += new System.EventHandler(this.registButton_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(155, 225);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(18, 12);
            this.label15.TabIndex = 62;
            this.label15.Text = "To";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(155, 168);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(31, 12);
            this.label14.TabIndex = 61;
            this.label14.Text = "From";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.label13.Location = new System.Drawing.Point(275, 196);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(0, 20);
            this.label13.TabIndex = 60;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(508, 225);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(17, 12);
            this.label10.TabIndex = 59;
            this.label10.Text = "分";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(425, 225);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(17, 12);
            this.label11.TabIndex = 58;
            this.label11.Text = "時";
            // 
            // toMinute
            // 
            this.toMinute.FormattingEnabled = true;
            this.toMinute.Items.AddRange(new object[] {
            "0",
            "10",
            "20",
            "30",
            "40",
            "50"});
            this.toMinute.Location = new System.Drawing.Point(448, 219);
            this.toMinute.Name = "toMinute";
            this.toMinute.Size = new System.Drawing.Size(44, 20);
            this.toMinute.TabIndex = 57;
            // 
            // toHour
            // 
            this.toHour.FormattingEnabled = true;
            this.toHour.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23"});
            this.toHour.Location = new System.Drawing.Point(371, 219);
            this.toHour.Name = "toHour";
            this.toHour.Size = new System.Drawing.Size(48, 20);
            this.toHour.TabIndex = 56;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(508, 168);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(17, 12);
            this.label9.TabIndex = 55;
            this.label9.Text = "分";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(425, 168);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(17, 12);
            this.label8.TabIndex = 54;
            this.label8.Text = "時";
            // 
            // fromMinute
            // 
            this.fromMinute.FormattingEnabled = true;
            this.fromMinute.Items.AddRange(new object[] {
            "0",
            "10",
            "20",
            "30",
            "40",
            "50"});
            this.fromMinute.Location = new System.Drawing.Point(448, 163);
            this.fromMinute.Name = "fromMinute";
            this.fromMinute.Size = new System.Drawing.Size(44, 20);
            this.fromMinute.TabIndex = 53;
            // 
            // fromHour
            // 
            this.fromHour.FormattingEnabled = true;
            this.fromHour.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23"});
            this.fromHour.Location = new System.Drawing.Point(371, 162);
            this.fromHour.Name = "fromHour";
            this.fromHour.Size = new System.Drawing.Size(48, 20);
            this.fromHour.TabIndex = 52;
            // 
            // toDate
            // 
            this.toDate.Location = new System.Drawing.Point(229, 220);
            this.toDate.Name = "toDate";
            this.toDate.Size = new System.Drawing.Size(121, 19);
            this.toDate.TabIndex = 51;
            // 
            // fromDate
            // 
            this.fromDate.Location = new System.Drawing.Point(229, 163);
            this.fromDate.Name = "fromDate";
            this.fromDate.Size = new System.Drawing.Size(121, 19);
            this.fromDate.TabIndex = 50;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(46, 317);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 49;
            this.label7.Text = "訪問種別";
            // 
            // another
            // 
            this.another.AutoSize = true;
            this.another.Location = new System.Drawing.Point(269, 335);
            this.another.Name = "another";
            this.another.Size = new System.Drawing.Size(54, 16);
            this.another.TabIndex = 48;
            this.another.TabStop = true;
            this.another.Text = "その他";
            this.another.UseVisualStyleBackColor = true;
            // 
            // their
            // 
            this.their.AutoSize = true;
            this.their.Location = new System.Drawing.Point(157, 335);
            this.their.Name = "their";
            this.their.Size = new System.Drawing.Size(47, 16);
            this.their.TabIndex = 47;
            this.their.TabStop = true;
            this.their.Text = "自社";
            this.their.UseVisualStyleBackColor = true;
            // 
            // opponentHouse
            // 
            this.opponentHouse.AutoSize = true;
            this.opponentHouse.Location = new System.Drawing.Point(367, 313);
            this.opponentHouse.Name = "opponentHouse";
            this.opponentHouse.Size = new System.Drawing.Size(59, 16);
            this.opponentHouse.TabIndex = 46;
            this.opponentHouse.TabStop = true;
            this.opponentHouse.Text = "相手宅";
            this.opponentHouse.UseVisualStyleBackColor = true;
            // 
            // bossName
            // 
            this.bossName.AutoSize = true;
            this.bossName.Location = new System.Drawing.Point(155, 474);
            this.bossName.Name = "bossName";
            this.bossName.Size = new System.Drawing.Size(61, 12);
            this.bossName.TabIndex = 45;
            this.bossName.Text = "高野　浩一";
            // 
            // customer_search
            // 
            this.customer_search.BackColor = System.Drawing.Color.DimGray;
            this.customer_search.ForeColor = System.Drawing.Color.White;
            this.customer_search.Location = new System.Drawing.Point(333, 277);
            this.customer_search.Name = "customer_search";
            this.customer_search.Size = new System.Drawing.Size(57, 23);
            this.customer_search.TabIndex = 44;
            this.customer_search.Text = "検索";
            this.customer_search.UseVisualStyleBackColor = false;
            // 
            // customer
            // 
            this.customer.Location = new System.Drawing.Point(157, 279);
            this.customer.Name = "customer";
            this.customer.Size = new System.Drawing.Size(155, 19);
            this.customer.TabIndex = 43;
            // 
            // reportText
            // 
            this.reportText.Location = new System.Drawing.Point(157, 362);
            this.reportText.Multiline = true;
            this.reportText.Name = "reportText";
            this.reportText.Size = new System.Drawing.Size(368, 100);
            this.reportText.TabIndex = 42;
            // 
            // createDate
            // 
            this.createDate.Location = new System.Drawing.Point(152, 133);
            this.createDate.Name = "createDate";
            this.createDate.Size = new System.Drawing.Size(198, 19);
            this.createDate.TabIndex = 41;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(56, 474);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 40;
            this.label5.Text = "上司";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(56, 362);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 39;
            this.label4.Text = "内容";
            // 
            // mail
            // 
            this.mail.AutoSize = true;
            this.mail.Location = new System.Drawing.Point(269, 313);
            this.mail.Name = "mail";
            this.mail.Size = new System.Drawing.Size(51, 16);
            this.mail.TabIndex = 38;
            this.mail.TabStop = true;
            this.mail.Text = "メール";
            this.mail.UseVisualStyleBackColor = true;
            // 
            // tell
            // 
            this.tell.AutoSize = true;
            this.tell.Location = new System.Drawing.Point(157, 313);
            this.tell.Name = "tell";
            this.tell.Size = new System.Drawing.Size(47, 16);
            this.tell.TabIndex = 37;
            this.tell.TabStop = true;
            this.tell.Text = "電話";
            this.tell.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(44, 286);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 12);
            this.label3.TabIndex = 36;
            this.label3.Text = "訪問先の顧客";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(51, 168);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 35;
            this.label2.Text = "日時";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(51, 138);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(41, 12);
            this.label12.TabIndex = 34;
            this.label12.Text = "記入日";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::ZEBRA.Properties.Resources.zebra;
            this.pictureBox1.Location = new System.Drawing.Point(10, 7);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(75, 68);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 63;
            this.pictureBox1.TabStop = false;
            // 
            // ReportModify
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Ivory;
            this.ClientSize = new System.Drawing.Size(570, 554);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.toMinute);
            this.Controls.Add(this.toHour);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.fromMinute);
            this.Controls.Add(this.fromHour);
            this.Controls.Add(this.toDate);
            this.Controls.Add(this.fromDate);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.another);
            this.Controls.Add(this.their);
            this.Controls.Add(this.opponentHouse);
            this.Controls.Add(this.bossName);
            this.Controls.Add(this.customer_search);
            this.Controls.Add(this.customer);
            this.Controls.Add(this.reportText);
            this.Controls.Add(this.createDate);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.mail);
            this.Controls.Add(this.tell);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.topPageButton);
            this.Controls.Add(this.registButton);
            this.Controls.Add(this.label1);
            this.Name = "ReportModify";
            this.Text = "ChangeDetail";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button topPageButton;
        private System.Windows.Forms.Button registButton;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox toMinute;
        private System.Windows.Forms.ComboBox toHour;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox fromMinute;
        private System.Windows.Forms.ComboBox fromHour;
        private System.Windows.Forms.DateTimePicker toDate;
        private System.Windows.Forms.DateTimePicker fromDate;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RadioButton another;
        private System.Windows.Forms.RadioButton their;
        private System.Windows.Forms.RadioButton opponentHouse;
        private System.Windows.Forms.Label bossName;
        private System.Windows.Forms.Button customer_search;
        private System.Windows.Forms.TextBox customer;
        private System.Windows.Forms.TextBox reportText;
        private System.Windows.Forms.DateTimePicker createDate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton mail;
        private System.Windows.Forms.RadioButton tell;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}