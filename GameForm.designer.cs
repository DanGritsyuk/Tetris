namespace Tetris
{
    partial class GameForm
    {

        private System.ComponentModel.IContainer components = null;


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
            this.TickTimer = new System.Windows.Forms.Timer(this.components);
            this.btnStart = new System.Windows.Forms.Button();
            this.btnPause = new System.Windows.Forms.Button();
            this.lblLevelText = new System.Windows.Forms.Label();
            this.lblScoreText = new System.Windows.Forms.Label();
            this.lblLevelValue = new System.Windows.Forms.Label();
            this.lblScoreValue = new System.Windows.Forms.Label();
            this.ptbNextShape = new System.Windows.Forms.PictureBox();
            this.ptbField = new System.Windows.Forms.PictureBox();
            this.GamepudPanel = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblBtrType = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ptbNextShape)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbField)).BeginInit();
            this.GamepudPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // TickTimer
            // 
            this.TickTimer.Interval = 2500;
            this.TickTimer.Tick += new System.EventHandler(this.TickTimer_Tick);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(23, 558);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(114, 23);
            this.btnStart.TabIndex = 2;
            this.btnStart.Text = "Старт";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnPause
            // 
            this.btnPause.Enabled = false;
            this.btnPause.Location = new System.Drawing.Point(153, 558);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(113, 23);
            this.btnPause.TabIndex = 3;
            this.btnPause.Text = "Пауза";
            this.btnPause.UseVisualStyleBackColor = true;
            this.btnPause.Click += new System.EventHandler(this.btnPause_Click);
            // 
            // lblLevelText
            // 
            this.lblLevelText.AutoSize = true;
            this.lblLevelText.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblLevelText.Location = new System.Drawing.Point(24, 68);
            this.lblLevelText.MaximumSize = new System.Drawing.Size(151, 113);
            this.lblLevelText.Name = "lblLevelText";
            this.lblLevelText.Size = new System.Drawing.Size(70, 17);
            this.lblLevelText.TabIndex = 4;
            this.lblLevelText.Text = "Уровень";
            // 
            // lblScoreText
            // 
            this.lblScoreText.AutoSize = true;
            this.lblScoreText.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblScoreText.Location = new System.Drawing.Point(24, 91);
            this.lblScoreText.Name = "lblScoreText";
            this.lblScoreText.Size = new System.Drawing.Size(44, 17);
            this.lblScoreText.TabIndex = 4;
            this.lblScoreText.Text = "Счет";
            // 
            // lblLevelValue
            // 
            this.lblLevelValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblLevelValue.Location = new System.Drawing.Point(100, 64);
            this.lblLevelValue.Name = "lblLevelValue";
            this.lblLevelValue.Size = new System.Drawing.Size(57, 21);
            this.lblLevelValue.TabIndex = 5;
            this.lblLevelValue.Text = "0";
            this.lblLevelValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblScoreValue
            // 
            this.lblScoreValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblScoreValue.Location = new System.Drawing.Point(74, 85);
            this.lblScoreValue.Name = "lblScoreValue";
            this.lblScoreValue.Size = new System.Drawing.Size(83, 25);
            this.lblScoreValue.TabIndex = 6;
            this.lblScoreValue.Text = "0";
            this.lblScoreValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ptbNextShape
            // 
            this.ptbNextShape.BackColor = System.Drawing.Color.Navy;
            this.ptbNextShape.Location = new System.Drawing.Point(175, 15);
            this.ptbNextShape.Name = "ptbNextShape";
            this.ptbNextShape.Size = new System.Drawing.Size(91, 106);
            this.ptbNextShape.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.ptbNextShape.TabIndex = 1;
            this.ptbNextShape.TabStop = false;
            this.ptbNextShape.Visible = false;
            // 
            // ptbField
            // 
            this.ptbField.Location = new System.Drawing.Point(24, 126);
            this.ptbField.Margin = new System.Windows.Forms.Padding(2);
            this.ptbField.Name = "ptbField";
            this.ptbField.Size = new System.Drawing.Size(242, 427);
            this.ptbField.TabIndex = 0;
            this.ptbField.TabStop = false;
            // 
            // GamepudPanel
            // 
            this.GamepudPanel.Controls.Add(this.pictureBox1);
            this.GamepudPanel.Controls.Add(this.lblBtrType);
            this.GamepudPanel.Location = new System.Drawing.Point(12, 12);
            this.GamepudPanel.Name = "GamepudPanel";
            this.GamepudPanel.Size = new System.Drawing.Size(93, 31);
            this.GamepudPanel.TabIndex = 10;
            this.GamepudPanel.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(39, 20);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            // 
            // lblBtrType
            // 
            this.lblBtrType.Font = new System.Drawing.Font("HoloLens MDL2 Assets", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblBtrType.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblBtrType.Location = new System.Drawing.Point(48, 3);
            this.lblBtrType.Name = "lblBtrType";
            this.lblBtrType.Size = new System.Drawing.Size(34, 20);
            this.lblBtrType.TabIndex = 11;
            this.lblBtrType.Text = "";
            this.lblBtrType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblBtrType.UseCompatibleTextRendering = true;
            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(293, 600);
            this.Controls.Add(this.GamepudPanel);
            this.Controls.Add(this.lblScoreValue);
            this.Controls.Add(this.lblLevelValue);
            this.Controls.Add(this.lblScoreText);
            this.Controls.Add(this.lblLevelText);
            this.Controls.Add(this.btnPause);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.ptbNextShape);
            this.Controls.Add(this.ptbField);
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "GameForm";
            this.Text = "Tetris";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.ptbNextShape)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbField)).EndInit();
            this.GamepudPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox ptbField;
        private System.Windows.Forms.Timer TickTimer;
        private System.Windows.Forms.PictureBox ptbNextShape;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnPause;
        private System.Windows.Forms.Label lblLevelText;
        private System.Windows.Forms.Label lblScoreText;
        private System.Windows.Forms.Label lblLevelValue;
        private System.Windows.Forms.Label lblScoreValue;
        public System.Windows.Forms.Panel GamepudPanel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblBtrType;
    }
}