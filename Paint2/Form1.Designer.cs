namespace Paint_sederhana
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
            this.line = new System.Windows.Forms.Button();
            this.rectang = new System.Windows.Forms.Button();
            this.circle = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.refresh = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // line
            // 
            this.line.Location = new System.Drawing.Point(13, 15);
            this.line.Name = "line";
            this.line.Size = new System.Drawing.Size(75, 23);
            this.line.TabIndex = 0;
            this.line.Text = "Line";
            this.line.UseVisualStyleBackColor = true;
            this.line.Click += new System.EventHandler(this.line_Click);
            // 
            // rectang
            // 
            this.rectang.Location = new System.Drawing.Point(94, 15);
            this.rectang.Name = "rectang";
            this.rectang.Size = new System.Drawing.Size(89, 23);
            this.rectang.TabIndex = 1;
            this.rectang.Text = "Rectangle";
            this.rectang.UseVisualStyleBackColor = true;
            this.rectang.Click += new System.EventHandler(this.rectang_Click);
            // 
            // circle
            // 
            this.circle.Location = new System.Drawing.Point(189, 15);
            this.circle.Name = "circle";
            this.circle.Size = new System.Drawing.Size(75, 23);
            this.circle.TabIndex = 2;
            this.circle.Text = "Circle";
            this.circle.UseVisualStyleBackColor = true;
            this.circle.Click += new System.EventHandler(this.circle_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel1.Location = new System.Drawing.Point(13, 44);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(673, 424);
            this.panel1.TabIndex = 3;
            this.panel1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseClick_1);
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown_1);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove_1);
            this.panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseUp);
            // 
            // refresh
            // 
            this.refresh.Location = new System.Drawing.Point(611, 15);
            this.refresh.Name = "refresh";
            this.refresh.Size = new System.Drawing.Size(75, 23);
            this.refresh.TabIndex = 4;
            this.refresh.Text = "Refresh";
            this.refresh.UseVisualStyleBackColor = true;
            this.refresh.Click += new System.EventHandler(this.refresh_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 480);
            this.Controls.Add(this.refresh);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.circle);
            this.Controls.Add(this.rectang);
            this.Controls.Add(this.line);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button line;
        private System.Windows.Forms.Button rectang;
        private System.Windows.Forms.Button circle;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button refresh;
    }
}

