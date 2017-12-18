namespace ZEBRA
{
    partial class CustomerSearch
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
            this.customerList = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.searchCusText = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cusSearchButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.customerList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // customerList
            // 
            this.customerList.BackgroundColor = System.Drawing.Color.LightYellow;
            this.customerList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.customerList.Location = new System.Drawing.Point(23, 171);
            this.customerList.Name = "customerList";
            this.customerList.RowTemplate.Height = 21;
            this.customerList.Size = new System.Drawing.Size(570, 181);
            this.customerList.TabIndex = 0;
            this.customerList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.customerList_CellContentClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS UI Gothic", 14F);
            this.label1.Location = new System.Drawing.Point(138, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "検索結果";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::ZEBRA.Properties.Resources.zebra;
            this.pictureBox1.Location = new System.Drawing.Point(12, 9);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(75, 68);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // searchCusText
            // 
            this.searchCusText.Location = new System.Drawing.Point(113, 128);
            this.searchCusText.Name = "searchCusText";
            this.searchCusText.Size = new System.Drawing.Size(149, 19);
            this.searchCusText.TabIndex = 38;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(54, 131);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 39;
            this.label2.Text = "顧客検索";
            // 
            // cusSearchButton
            // 
            this.cusSearchButton.Location = new System.Drawing.Point(268, 126);
            this.cusSearchButton.Name = "cusSearchButton";
            this.cusSearchButton.Size = new System.Drawing.Size(62, 23);
            this.cusSearchButton.TabIndex = 40;
            this.cusSearchButton.Text = "検索";
            this.cusSearchButton.UseVisualStyleBackColor = true;
            this.cusSearchButton.Click += new System.EventHandler(this.cusSearch_Click);
            // 
            // CustomerSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Ivory;
            this.ClientSize = new System.Drawing.Size(619, 379);
            this.Controls.Add(this.cusSearchButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.searchCusText);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.customerList);
            this.Name = "CustomerSearch";
            this.Text = "Customer_search";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.CustomerSearch_FormClosed);
            this.Load += new System.EventHandler(this.CustomerSearch_Load);
            ((System.ComponentModel.ISupportInitialize)(this.customerList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView customerList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox searchCusText;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button cusSearchButton;
    }
}