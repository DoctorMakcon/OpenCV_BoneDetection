namespace FirstTryInCV
{
    partial class Form1
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
            this.initialImage = new System.Windows.Forms.PictureBox();
            this.selectButton = new System.Windows.Forms.Button();
            this.filteredImage = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.initialImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.filteredImage)).BeginInit();
            this.SuspendLayout();
            // 
            // initialImage
            // 
            this.initialImage.Location = new System.Drawing.Point(12, 12);
            this.initialImage.Name = "initialImage";
            this.initialImage.Size = new System.Drawing.Size(650, 400);
            this.initialImage.TabIndex = 1;
            this.initialImage.TabStop = false;
            // 
            // selectButton
            // 
            this.selectButton.Location = new System.Drawing.Point(230, 432);
            this.selectButton.Name = "selectButton";
            this.selectButton.Size = new System.Drawing.Size(149, 32);
            this.selectButton.TabIndex = 2;
            this.selectButton.Text = "Select Image";
            this.selectButton.UseVisualStyleBackColor = true;
            this.selectButton.Click += new System.EventHandler(this.selectButton_Click);
            // 
            // filteredImage
            // 
            this.filteredImage.Location = new System.Drawing.Point(698, 12);
            this.filteredImage.Name = "filteredImage";
            this.filteredImage.Size = new System.Drawing.Size(650, 400);
            this.filteredImage.TabIndex = 3;
            this.filteredImage.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1009, 432);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(131, 32);
            this.button1.TabIndex = 4;
            this.button1.Text = "Proccess Image";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1362, 476);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.filteredImage);
            this.Controls.Add(this.selectButton);
            this.Controls.Add(this.initialImage);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.initialImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.filteredImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox initialImage;
        private System.Windows.Forms.Button selectButton;
        private System.Windows.Forms.PictureBox filteredImage;
        private System.Windows.Forms.Button button1;
    }
}

