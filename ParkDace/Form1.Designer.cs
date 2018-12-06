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
            this.components = new System.ComponentModel.Container();
            this.button_fetchSpots = new System.Windows.Forms.Button();
            this.button_stopFetching = new System.Windows.Forms.Button();
            this.richTextBoxSpotsDLL = new System.Windows.Forms.RichTextBox();
            this.buttonFetchBotSpots = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // button_fetchSpots
            // 
            this.button_fetchSpots.Location = new System.Drawing.Point(45, 288);
            this.button_fetchSpots.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button_fetchSpots.Name = "button_fetchSpots";
            this.button_fetchSpots.Size = new System.Drawing.Size(149, 19);
            this.button_fetchSpots.TabIndex = 1;
            this.button_fetchSpots.Text = "Fetch Spots DLL Park 1";
            this.button_fetchSpots.UseVisualStyleBackColor = true;
            this.button_fetchSpots.Click += new System.EventHandler(this.button_fetchSpots_Click);
            // 
            // button_stopFetching
            // 
            this.button_stopFetching.Location = new System.Drawing.Point(380, 288);
            this.button_stopFetching.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button_stopFetching.Name = "button_stopFetching";
            this.button_stopFetching.Size = new System.Drawing.Size(106, 19);
            this.button_stopFetching.TabIndex = 2;
            this.button_stopFetching.Text = "Stop fetching";
            this.button_stopFetching.UseVisualStyleBackColor = true;
            this.button_stopFetching.Click += new System.EventHandler(this.button_stopFetching_Click_1);
            // 
            // richTextBoxSpotsDLL
            // 
            this.richTextBoxSpotsDLL.Location = new System.Drawing.Point(45, 50);
            this.richTextBoxSpotsDLL.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.richTextBoxSpotsDLL.Name = "richTextBoxSpotsDLL";
            this.richTextBoxSpotsDLL.Size = new System.Drawing.Size(442, 154);
            this.richTextBoxSpotsDLL.TabIndex = 3;
            this.richTextBoxSpotsDLL.Text = "";
            this.richTextBoxSpotsDLL.TextChanged += new System.EventHandler(this.richTextBoxSpotsDLL_TextChanged);
            // 
            // buttonFetchBotSpots
            // 
            this.buttonFetchBotSpots.Location = new System.Drawing.Point(45, 313);
            this.buttonFetchBotSpots.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonFetchBotSpots.Name = "buttonFetchBotSpots";
            this.buttonFetchBotSpots.Size = new System.Drawing.Size(149, 19);
            this.buttonFetchBotSpots.TabIndex = 4;
            this.buttonFetchBotSpots.Text = "Fetch Spots Bot Park 2";
            this.buttonFetchBotSpots.UseVisualStyleBackColor = true;
            this.buttonFetchBotSpots.Click += new System.EventHandler(this.buttonFetchBotSpots_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 3000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.Controls.Add(this.buttonFetchBotSpots);
            this.Controls.Add(this.richTextBoxSpotsDLL);
            this.Controls.Add(this.button_stopFetching);
            this.Controls.Add(this.button_fetchSpots);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_fetchSpots;
        private System.Windows.Forms.Button button_stopFetching;
        private System.Windows.Forms.RichTextBox richTextBoxSpotsDLL;
        private System.Windows.Forms.Button buttonFetchBotSpots;
        private System.Windows.Forms.Timer timer1;
    }
}

