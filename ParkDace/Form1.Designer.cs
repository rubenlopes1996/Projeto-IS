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
            this.timerBot = new System.Windows.Forms.Timer(this.components);
            this.btnStartDataAcquisition = new System.Windows.Forms.Button();
            this.timerDLL = new System.Windows.Forms.Timer(this.components);
            this.richTextBoxSpotsDLL = new System.Windows.Forms.RichTextBox();
            this.richTextBoxSpotsBot = new System.Windows.Forms.RichTextBox();
            this.BOT = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // timerBot
            // 
            this.timerBot.Interval = 3000;
            this.timerBot.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // btnStartDataAcquisition
            // 
            this.btnStartDataAcquisition.Location = new System.Drawing.Point(276, 331);
            this.btnStartDataAcquisition.Name = "btnStartDataAcquisition";
            this.btnStartDataAcquisition.Size = new System.Drawing.Size(219, 81);
            this.btnStartDataAcquisition.TabIndex = 0;
            this.btnStartDataAcquisition.Text = "Start data acquisition";
            this.btnStartDataAcquisition.UseVisualStyleBackColor = true;
            this.btnStartDataAcquisition.Click += new System.EventHandler(this.btnStartDataAcquisition_Click);
            // 
            // timerDLL
            // 
            this.timerDLL.Interval = 3000;
            this.timerDLL.Tick += new System.EventHandler(this.timerDLL_Tick);
            // 
            // richTextBoxSpotsDLL
            // 
            this.richTextBoxSpotsDLL.Location = new System.Drawing.Point(12, 40);
            this.richTextBoxSpotsDLL.Name = "richTextBoxSpotsDLL";
            this.richTextBoxSpotsDLL.Size = new System.Drawing.Size(381, 251);
            this.richTextBoxSpotsDLL.TabIndex = 1;
            this.richTextBoxSpotsDLL.Text = "";
            // 
            // richTextBoxSpotsBot
            // 
            this.richTextBoxSpotsBot.Location = new System.Drawing.Point(399, 40);
            this.richTextBoxSpotsBot.Name = "richTextBoxSpotsBot";
            this.richTextBoxSpotsBot.Size = new System.Drawing.Size(389, 251);
            this.richTextBoxSpotsBot.TabIndex = 2;
            this.richTextBoxSpotsBot.Tag = "";
            this.richTextBoxSpotsBot.Text = "";
            // 
            // BOT
            // 
            this.BOT.AutoSize = true;
            this.BOT.Location = new System.Drawing.Point(407, 20);
            this.BOT.Name = "BOT";
            this.BOT.Size = new System.Drawing.Size(37, 17);
            this.BOT.TabIndex = 3;
            this.BOT.Text = "BOT";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "DLL";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.BOT);
            this.Controls.Add(this.richTextBoxSpotsBot);
            this.Controls.Add(this.richTextBoxSpotsDLL);
            this.Controls.Add(this.btnStartDataAcquisition);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer timerBot;
        private System.Windows.Forms.Button btnStartDataAcquisition;
        private System.Windows.Forms.Timer timerDLL;
        private System.Windows.Forms.RichTextBox richTextBoxSpotsDLL;
        private System.Windows.Forms.RichTextBox richTextBoxSpotsBot;
        private System.Windows.Forms.Label BOT;
        private System.Windows.Forms.Label label2;
    }
}

