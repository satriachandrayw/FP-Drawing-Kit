namespace SimpleDrawingKit
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
            this.lineButton = new System.Windows.Forms.Button();
            this.rectangButton = new System.Windows.Forms.Button();
            this.circleButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.refreshButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.redColorButton = new System.Windows.Forms.Button();
            this.orangeColorButton = new System.Windows.Forms.Button();
            this.yellowColorButton = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.lightblueColorButton = new System.Windows.Forms.Button();
            this.blueColorButton = new System.Windows.Forms.Button();
            this.greenColorButton = new System.Windows.Forms.Button();
            this.whiteColorButton = new System.Windows.Forms.Button();
            this.opacityTrackBar = new System.Windows.Forms.TrackBar();
            this.opacityText = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.opacityTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // lineButton
            // 
            this.lineButton.BackColor = System.Drawing.SystemColors.Control;
            this.lineButton.Location = new System.Drawing.Point(13, 15);
            this.lineButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lineButton.Name = "lineButton";
            this.lineButton.Size = new System.Drawing.Size(75, 23);
            this.lineButton.TabIndex = 0;
            this.lineButton.Text = "Line";
            this.lineButton.UseVisualStyleBackColor = false;
            this.lineButton.Click += new System.EventHandler(this.lineButton_Click);
            // 
            // rectangButton
            // 
            this.rectangButton.Location = new System.Drawing.Point(93, 15);
            this.rectangButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rectangButton.Name = "rectangButton";
            this.rectangButton.Size = new System.Drawing.Size(89, 23);
            this.rectangButton.TabIndex = 1;
            this.rectangButton.Text = "Rectangle";
            this.rectangButton.UseVisualStyleBackColor = true;
            this.rectangButton.Click += new System.EventHandler(this.rectangButton_Click);
            // 
            // circleButton
            // 
            this.circleButton.Location = new System.Drawing.Point(189, 15);
            this.circleButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.circleButton.Name = "circleButton";
            this.circleButton.Size = new System.Drawing.Size(75, 23);
            this.circleButton.TabIndex = 2;
            this.circleButton.Text = "Circle";
            this.circleButton.UseVisualStyleBackColor = true;
            this.circleButton.Click += new System.EventHandler(this.circleButton_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel1.Location = new System.Drawing.Point(13, 104);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(682, 363);
            this.panel1.TabIndex = 3;
            this.panel1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseClick_1);
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown_1);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove_1);
            this.panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseUp);
            // 
            // refreshButton
            // 
            this.refreshButton.Location = new System.Drawing.Point(593, 15);
            this.refreshButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(75, 23);
            this.refreshButton.TabIndex = 4;
            this.refreshButton.Text = "Refresh";
            this.refreshButton.UseVisualStyleBackColor = true;
            this.refreshButton.Click += new System.EventHandler(this.refreshButton_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(519, 15);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(67, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Select";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.selectButton_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(451, 15);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(60, 23);
            this.button2.TabIndex = 6;
            this.button2.Text = "Undo";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.undoButton_Click);
            // 
            // redColorButton
            // 
            this.redColorButton.BackColor = System.Drawing.Color.Red;
            this.redColorButton.Location = new System.Drawing.Point(279, 15);
            this.redColorButton.Name = "redColorButton";
            this.redColorButton.Size = new System.Drawing.Size(30, 30);
            this.redColorButton.TabIndex = 7;
            this.redColorButton.UseVisualStyleBackColor = false;
            this.redColorButton.Click += new System.EventHandler(this.rebColorButton_Click);
            // 
            // orangeColorButton
            // 
            this.orangeColorButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.orangeColorButton.Location = new System.Drawing.Point(315, 15);
            this.orangeColorButton.Name = "orangeColorButton";
            this.orangeColorButton.Size = new System.Drawing.Size(30, 30);
            this.orangeColorButton.TabIndex = 8;
            this.orangeColorButton.UseVisualStyleBackColor = false;
            this.orangeColorButton.Click += new System.EventHandler(this.orangeColorButton_Click);
            // 
            // yellowColorButton
            // 
            this.yellowColorButton.BackColor = System.Drawing.Color.Yellow;
            this.yellowColorButton.Location = new System.Drawing.Point(351, 15);
            this.yellowColorButton.Name = "yellowColorButton";
            this.yellowColorButton.Size = new System.Drawing.Size(30, 30);
            this.yellowColorButton.TabIndex = 9;
            this.yellowColorButton.UseVisualStyleBackColor = false;
            this.yellowColorButton.Click += new System.EventHandler(this.yellowColorButton_Click);
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.Black;
            this.button6.Location = new System.Drawing.Point(387, 15);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(30, 30);
            this.button6.TabIndex = 10;
            this.button6.UseVisualStyleBackColor = false;
            // 
            // lightblueColorButton
            // 
            this.lightblueColorButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.lightblueColorButton.Location = new System.Drawing.Point(279, 51);
            this.lightblueColorButton.Name = "lightblueColorButton";
            this.lightblueColorButton.Size = new System.Drawing.Size(30, 30);
            this.lightblueColorButton.TabIndex = 11;
            this.lightblueColorButton.UseVisualStyleBackColor = false;
            this.lightblueColorButton.Click += new System.EventHandler(this.lightblueColorButton_Click);
            // 
            // blueColorButton
            // 
            this.blueColorButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.blueColorButton.Location = new System.Drawing.Point(315, 51);
            this.blueColorButton.Name = "blueColorButton";
            this.blueColorButton.Size = new System.Drawing.Size(30, 30);
            this.blueColorButton.TabIndex = 12;
            this.blueColorButton.UseVisualStyleBackColor = false;
            this.blueColorButton.Click += new System.EventHandler(this.blueColorButton_Click);
            // 
            // greenColorButton
            // 
            this.greenColorButton.BackColor = System.Drawing.Color.Lime;
            this.greenColorButton.Location = new System.Drawing.Point(351, 51);
            this.greenColorButton.Name = "greenColorButton";
            this.greenColorButton.Size = new System.Drawing.Size(30, 30);
            this.greenColorButton.TabIndex = 13;
            this.greenColorButton.UseVisualStyleBackColor = false;
            this.greenColorButton.Click += new System.EventHandler(this.greenColorButton_Click);
            // 
            // whiteColorButton
            // 
            this.whiteColorButton.BackColor = System.Drawing.Color.White;
            this.whiteColorButton.Location = new System.Drawing.Point(387, 51);
            this.whiteColorButton.Name = "whiteColorButton";
            this.whiteColorButton.Size = new System.Drawing.Size(30, 30);
            this.whiteColorButton.TabIndex = 14;
            this.whiteColorButton.UseVisualStyleBackColor = false;
            this.whiteColorButton.Click += new System.EventHandler(this.whiteColorButton_Click);
            // 
            // opacityTrackBar
            // 
            this.opacityTrackBar.Location = new System.Drawing.Point(451, 45);
            this.opacityTrackBar.Maximum = 100;
            this.opacityTrackBar.Name = "opacityTrackBar";
            this.opacityTrackBar.Size = new System.Drawing.Size(140, 56);
            this.opacityTrackBar.TabIndex = 16;
            this.opacityTrackBar.Scroll += new System.EventHandler(this.opacityTrackBar_Scroll);
            // 
            // opacityText
            // 
            this.opacityText.AutoSize = true;
            this.opacityText.Location = new System.Drawing.Point(597, 51);
            this.opacityText.Name = "opacityText";
            this.opacityText.Size = new System.Drawing.Size(56, 17);
            this.opacityText.TabIndex = 17;
            this.opacityText.Text = "Opacity";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(13, 45);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(47, 42);
            this.button3.TabIndex = 18;
            this.button3.Text = "Set";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.setButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(713, 480);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.opacityText);
            this.Controls.Add(this.opacityTrackBar);
            this.Controls.Add(this.whiteColorButton);
            this.Controls.Add(this.greenColorButton);
            this.Controls.Add(this.blueColorButton);
            this.Controls.Add(this.lightblueColorButton);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.yellowColorButton);
            this.Controls.Add(this.orangeColorButton);
            this.Controls.Add(this.redColorButton);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.refreshButton);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.circleButton);
            this.Controls.Add(this.rectangButton);
            this.Controls.Add(this.lineButton);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "+";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.opacityTrackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button lineButton;
        private System.Windows.Forms.Button rectangButton;
        private System.Windows.Forms.Button circleButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button refreshButton;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button redColorButton;
        private System.Windows.Forms.Button orangeColorButton;
        private System.Windows.Forms.Button yellowColorButton;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button lightblueColorButton;
        private System.Windows.Forms.Button blueColorButton;
        private System.Windows.Forms.Button greenColorButton;
        private System.Windows.Forms.Button whiteColorButton;
        private System.Windows.Forms.TrackBar opacityTrackBar;
        private System.Windows.Forms.Label opacityText;
        private System.Windows.Forms.Button button3;
    }
}

