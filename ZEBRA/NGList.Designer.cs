namespace ZEBRA
{
    partial class NGList
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
            this.NGViewList = new System.Windows.Forms.DataGridView();
            this.topPageButton = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.NGViewList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // NGViewList
            // 
            this.NGViewList.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.NGViewList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.NGViewList.Location = new System.Drawing.Point(43, 129);
            this.NGViewList.Name = "NGViewList";
            this.NGViewList.RowTemplate.Height = 21;
            this.NGViewList.Size = new System.Drawing.Size(652, 209);
            this.NGViewList.TabIndex = 0;
            this.NGViewList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.NGViewList_CellContentClick);
            // 
            // topPageButton
            // 
            this.topPageButton.BackColor = System.Drawing.Color.DimGray;
            this.topPageButton.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.topPageButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.topPageButton.Location = new System.Drawing.Point(22, 86);
            this.topPageButton.Name = "topPageButton";
            this.topPageButton.Size = new System.Drawing.Size(75, 23);
            this.topPageButton.TabIndex = 38;
            this.topPageButton.Text = "トップページ";
            this.topPageButton.UseVisualStyleBackColor = false;
            this.topPageButton.Click += new System.EventHandler(this.topPageButton_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::ZEBRA.Properties.Resources.zebra;
            this.pictureBox1.Location = new System.Drawing.Point(22, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(75, 68);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 39;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(317, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 19);
            this.label1.TabIndex = 40;
            this.label1.Text = "NG一覧";
            // 
            // NGList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Ivory;
            this.ClientSize = new System.Drawing.Size(728, 361);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.topPageButton);
            this.Controls.Add(this.NGViewList);
            this.Name = "NGList";
            this.Text = "NG_List";
            this.Load += new System.EventHandler(this.NGList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.NGViewList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView NGViewList;
        private System.Windows.Forms.Button topPageButton;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
    }
}