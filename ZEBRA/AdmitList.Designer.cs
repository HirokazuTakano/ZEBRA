namespace ZEBRA
{
    partial class AdmitList
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
            this.admitViewList = new System.Windows.Forms.DataGridView();
            this.topPageButton = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.admitViewList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // admitViewList
            // 
            this.admitViewList.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.admitViewList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.admitViewList.Location = new System.Drawing.Point(39, 128);
            this.admitViewList.Name = "admitViewList";
            this.admitViewList.RowTemplate.Height = 21;
            this.admitViewList.Size = new System.Drawing.Size(847, 224);
            this.admitViewList.TabIndex = 0;
            this.admitViewList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.admitViewList_CellContentClick);
            // 
            // topPageButton
            // 
            this.topPageButton.BackColor = System.Drawing.Color.DimGray;
            this.topPageButton.ForeColor = System.Drawing.Color.White;
            this.topPageButton.Location = new System.Drawing.Point(12, 86);
            this.topPageButton.Name = "topPageButton";
            this.topPageButton.Size = new System.Drawing.Size(79, 25);
            this.topPageButton.TabIndex = 31;
            this.topPageButton.Text = "トップページ";
            this.topPageButton.UseVisualStyleBackColor = false;
            this.topPageButton.Click += new System.EventHandler(this.topPageButton_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::ZEBRA.Properties.Resources.zebra;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(75, 68);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 32;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(391, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 19);
            this.label1.TabIndex = 33;
            this.label1.Text = "承認待ち";
            // 
            // AdmitList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Ivory;
            this.ClientSize = new System.Drawing.Size(898, 364);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.topPageButton);
            this.Controls.Add(this.admitViewList);
            this.Name = "AdmitList";
            this.Text = "AdmitWait";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AdmitList_FormClosed);
            this.Load += new System.EventHandler(this.AdmitList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.admitViewList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView admitViewList;
        private System.Windows.Forms.Button topPageButton;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
    }
}