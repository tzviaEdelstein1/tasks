namespace MemoryGameWinform
{
    partial class Form4
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
            this.namePlayerLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.counterLabel = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.yourCounterLabel = new System.Windows.Forms.Label();
            this.partnerCounterLabel = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label_turn = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(554, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "current player name";
            // 
            // namePlayerLabel
            // 
            this.namePlayerLabel.AutoSize = true;
            this.namePlayerLabel.Location = new System.Drawing.Point(660, 9);
            this.namePlayerLabel.Name = "namePlayerLabel";
            this.namePlayerLabel.Size = new System.Drawing.Size(35, 13);
            this.namePlayerLabel.TabIndex = 1;
            this.namePlayerLabel.Text = "label2";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(319, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(137, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "current game matching sets";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(326, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Your counter:";
            // 
            // counterLabel
            // 
            this.counterLabel.AutoSize = true;
            this.counterLabel.Location = new System.Drawing.Point(322, 68);
            this.counterLabel.Name = "counterLabel";
            this.counterLabel.Size = new System.Drawing.Size(35, 13);
            this.counterLabel.TabIndex = 5;
            this.counterLabel.Text = "label4";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(359, 68);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "counter";
            // 
            // yourCounterLabel
            // 
            this.yourCounterLabel.AutoSize = true;
            this.yourCounterLabel.Location = new System.Drawing.Point(412, 36);
            this.yourCounterLabel.Name = "yourCounterLabel";
            this.yourCounterLabel.Size = new System.Drawing.Size(35, 13);
            this.yourCounterLabel.TabIndex = 7;
            this.yourCounterLabel.Text = "label4";
            // 
            // partnerCounterLabel
            // 
            this.partnerCounterLabel.AutoSize = true;
            this.partnerCounterLabel.Location = new System.Drawing.Point(417, 72);
            this.partnerCounterLabel.Name = "partnerCounterLabel";
            this.partnerCounterLabel.Size = new System.Drawing.Size(35, 13);
            this.partnerCounterLabel.TabIndex = 8;
            this.partnerCounterLabel.Text = "label6";
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(53, 100);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(681, 329);
            this.panel1.TabIndex = 9;
            // 
            // label_turn
            // 
            this.label_turn.AutoSize = true;
            this.label_turn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label_turn.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label_turn.Location = new System.Drawing.Point(82, 29);
            this.label_turn.Name = "label_turn";
            this.label_turn.Size = new System.Drawing.Size(51, 20);
            this.label_turn.TabIndex = 10;
            this.label_turn.Text = "label4";
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label_turn);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.partnerCounterLabel);
            this.Controls.Add(this.yourCounterLabel);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.counterLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.namePlayerLabel);
            this.Controls.Add(this.label1);
            this.Name = "Form4";
            this.Text = "Form4";
            this.Load += new System.EventHandler(this.Form4_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label namePlayerLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label counterLabel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label yourCounterLabel;
        private System.Windows.Forms.Label partnerCounterLabel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label_turn;
    }
}