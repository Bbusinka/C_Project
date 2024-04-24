namespace SzkolaSport
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Bookman Old Style", 20F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(95, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(684, 40);
            this.label1.TabIndex = 0;
            this.label1.Text = "Witamy w Szkole Sportowej Hercules!";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.Window;
            this.button1.Font = new System.Drawing.Font("Bookman Old Style", 14F, System.Drawing.FontStyle.Bold);
            this.button1.Location = new System.Drawing.Point(102, 147);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(227, 63);
            this.button1.TabIndex = 1;
            this.button1.Text = "Student";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.Window;
            this.button2.Font = new System.Drawing.Font("Bookman Old Style", 14F, System.Drawing.FontStyle.Bold);
            this.button2.Location = new System.Drawing.Point(102, 247);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(227, 62);
            this.button2.TabIndex = 2;
            this.button2.Text = "Trener";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.SystemColors.Window;
            this.button3.Font = new System.Drawing.Font("Bookman Old Style", 14F, System.Drawing.FontStyle.Bold);
            this.button3.Location = new System.Drawing.Point(102, 347);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(227, 60);
            this.button3.TabIndex = 3;
            this.button3.Text = "Administrator";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::SzkolaSport.Properties.Resources._1;
            this.ClientSize = new System.Drawing.Size(893, 530);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hercules";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
    }
}

