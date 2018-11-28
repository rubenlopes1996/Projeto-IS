namespace ParkDace
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
            this.button_fetchSpots = new System.Windows.Forms.Button();
            this.button_stopFetching = new System.Windows.Forms.Button();
            this.richTextBoxSpotsDLL = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // button_fetchSpots
            // 
            this.button_fetchSpots.Location = new System.Drawing.Point(60, 355);
            this.button_fetchSpots.Name = "button_fetchSpots";
            this.button_fetchSpots.Size = new System.Drawing.Size(102, 23);
            this.button_fetchSpots.TabIndex = 1;
            this.button_fetchSpots.Text = "Fetch Spots";
            this.button_fetchSpots.UseVisualStyleBackColor = true;
            this.button_fetchSpots.Click += new System.EventHandler(this.button_fetchSpots_Click);
            // 
            // button_stopFetching
            // 
            this.button_stopFetching.Location = new System.Drawing.Point(507, 355);
            this.button_stopFetching.Name = "button_stopFetching";
            this.button_stopFetching.Size = new System.Drawing.Size(141, 23);
            this.button_stopFetching.TabIndex = 2;
            this.button_stopFetching.Text = "Stop fetching";
            this.button_stopFetching.UseVisualStyleBackColor = true;
            this.button_stopFetching.Click += new System.EventHandler(this.button_stopFetching_Click_1);
            // 
            // richTextBoxSpotsDLL
            // 
            this.richTextBoxSpotsDLL.Location = new System.Drawing.Point(60, 62);
            this.richTextBoxSpotsDLL.Name = "richTextBoxSpotsDLL";
            this.richTextBoxSpotsDLL.Size = new System.Drawing.Size(588, 189);
            this.richTextBoxSpotsDLL.TabIndex = 3;
            this.richTextBoxSpotsDLL.Text = "";
            this.richTextBoxSpotsDLL.TextChanged += new System.EventHandler(this.richTextBoxSpotsDLL_TextChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.richTextBoxSpotsDLL);
            this.Controls.Add(this.button_stopFetching);
            this.Controls.Add(this.button_fetchSpots);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_fetchSpots;
        private System.Windows.Forms.Button button_stopFetching;
        private System.Windows.Forms.RichTextBox richTextBoxSpotsDLL;
    }
}

