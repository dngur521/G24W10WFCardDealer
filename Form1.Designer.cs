namespace G24W10WFCardDealer
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Card1 = new PictureBox();
            CardDealButton = new Button();
            Card2 = new PictureBox();
            Card3 = new PictureBox();
            Card4 = new PictureBox();
            Card5 = new PictureBox();
            label1 = new Label();
            label3 = new Label();
            label4 = new Label();
            ((System.ComponentModel.ISupportInitialize)Card1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Card2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Card3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Card4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Card5).BeginInit();
            SuspendLayout();
            // 
            // Card1
            // 
            Card1.Image = Properties.Resources.black_joker;
            Card1.Location = new Point(12, 12);
            Card1.Name = "Card1";
            Card1.Size = new Size(227, 326);
            Card1.SizeMode = PictureBoxSizeMode.Zoom;
            Card1.TabIndex = 0;
            Card1.TabStop = false;
            // 
            // CardDealButton
            // 
            CardDealButton.Location = new Point(12, 344);
            CardDealButton.Name = "CardDealButton";
            CardDealButton.Size = new Size(1159, 49);
            CardDealButton.TabIndex = 1;
            CardDealButton.Text = "카드 분배";
            CardDealButton.UseVisualStyleBackColor = true;
            CardDealButton.Click += OnDeal;
            // 
            // Card2
            // 
            Card2.Image = Properties.Resources.black_joker;
            Card2.Location = new Point(245, 12);
            Card2.Name = "Card2";
            Card2.Size = new Size(227, 326);
            Card2.SizeMode = PictureBoxSizeMode.Zoom;
            Card2.TabIndex = 0;
            Card2.TabStop = false;
            // 
            // Card3
            // 
            Card3.Image = Properties.Resources.black_joker;
            Card3.Location = new Point(478, 12);
            Card3.Name = "Card3";
            Card3.Size = new Size(227, 326);
            Card3.SizeMode = PictureBoxSizeMode.Zoom;
            Card3.TabIndex = 0;
            Card3.TabStop = false;
            // 
            // Card4
            // 
            Card4.Image = Properties.Resources.black_joker;
            Card4.Location = new Point(711, 12);
            Card4.Name = "Card4";
            Card4.Size = new Size(227, 326);
            Card4.SizeMode = PictureBoxSizeMode.Zoom;
            Card4.TabIndex = 0;
            Card4.TabStop = false;
            // 
            // Card5
            // 
            Card5.Image = Properties.Resources.black_joker;
            Card5.Location = new Point(944, 12);
            Card5.Name = "Card5";
            Card5.Size = new Size(227, 326);
            Card5.SizeMode = PictureBoxSizeMode.Zoom;
            Card5.TabIndex = 0;
            Card5.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("맑은 고딕", 20F);
            label1.Location = new Point(12, 428);
            label1.Name = "label1";
            label1.Size = new Size(121, 62);
            label1.TabIndex = 2;
            label1.Text = "종류";
            label1.TextAlign = ContentAlignment.TopRight;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("맑은 고딕", 10F);
            label3.Location = new Point(12, 396);
            label3.Name = "label3";
            label3.Size = new Size(71, 32);
            label3.TabIndex = 2;
            label3.Text = "value";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("맑은 고딕", 10F);
            label4.Location = new Point(12, 489);
            label4.Name = "label4";
            label4.Size = new Size(52, 32);
            label4.TabIndex = 2;
            label4.Text = "suit";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1180, 534);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label1);
            Controls.Add(CardDealButton);
            Controls.Add(Card5);
            Controls.Add(Card4);
            Controls.Add(Card3);
            Controls.Add(Card2);
            Controls.Add(Card1);
            Name = "Form1";
            Text = "카드 딜러";
            ((System.ComponentModel.ISupportInitialize)Card1).EndInit();
            ((System.ComponentModel.ISupportInitialize)Card2).EndInit();
            ((System.ComponentModel.ISupportInitialize)Card3).EndInit();
            ((System.ComponentModel.ISupportInitialize)Card4).EndInit();
            ((System.ComponentModel.ISupportInitialize)Card5).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox Card1;
        private Button CardDealButton;
        private PictureBox Card2;
        private PictureBox Card3;
        private PictureBox Card4;
        private PictureBox Card5;
        private Label label1;
        private Label label3;
        private Label label4;
    }
}
