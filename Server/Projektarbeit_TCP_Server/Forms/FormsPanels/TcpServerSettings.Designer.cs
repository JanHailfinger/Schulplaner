namespace Projektarbeit_TCP_Server
{
    partial class TcpServerSettings
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
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.rd_aus = new System.Windows.Forms.RadioButton();
            this.rd_an = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_openfileDialog = new System.Windows.Forms.Button();
            this.txt_dateipfad = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txt_Port = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Controls.Add(this.textBox1);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.rd_aus);
            this.groupBox4.Controls.Add(this.rd_an);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Controls.Add(this.btn_openfileDialog);
            this.groupBox4.Controls.Add(this.txt_dateipfad);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Enabled = false;
            this.groupBox4.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.groupBox4.Location = new System.Drawing.Point(55, 235);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(550, 244);
            this.groupBox4.TabIndex = 19;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "SSL Verschlüsselung";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.label1.Location = new System.Drawing.Point(24, 168);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(153, 17);
            this.label1.TabIndex = 23;
            this.label1.Text = "SSL Zertifikat Passwort :";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.textBox1.Location = new System.Drawing.Point(27, 198);
            this.textBox1.Name = "textBox1";
            this.textBox1.PasswordChar = '✹';
            this.textBox1.Size = new System.Drawing.Size(493, 23);
            this.textBox1.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.label4.Location = new System.Drawing.Point(24, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(115, 17);
            this.label4.TabIndex = 12;
            this.label4.Text = "Verschlüsselung :";
            // 
            // rd_aus
            // 
            this.rd_aus.AutoSize = true;
            this.rd_aus.Checked = true;
            this.rd_aus.Location = new System.Drawing.Point(278, 60);
            this.rd_aus.Name = "rd_aus";
            this.rd_aus.Size = new System.Drawing.Size(48, 21);
            this.rd_aus.TabIndex = 22;
            this.rd_aus.TabStop = true;
            this.rd_aus.Text = "Aus";
            this.rd_aus.UseVisualStyleBackColor = true;
            // 
            // rd_an
            // 
            this.rd_an.AutoSize = true;
            this.rd_an.Location = new System.Drawing.Point(27, 60);
            this.rd_an.Name = "rd_an";
            this.rd_an.Size = new System.Drawing.Size(43, 21);
            this.rd_an.TabIndex = 21;
            this.rd_an.Text = "An";
            this.rd_an.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.label2.Location = new System.Drawing.Point(24, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 17);
            this.label2.TabIndex = 12;
            this.label2.Text = "SSL Zertifikat :";
            // 
            // btn_openfileDialog
            // 
            this.btn_openfileDialog.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_openfileDialog.FlatAppearance.BorderSize = 0;
            this.btn_openfileDialog.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_openfileDialog.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.btn_openfileDialog.Location = new System.Drawing.Point(499, 128);
            this.btn_openfileDialog.Name = "btn_openfileDialog";
            this.btn_openfileDialog.Size = new System.Drawing.Size(21, 21);
            this.btn_openfileDialog.TabIndex = 19;
            this.btn_openfileDialog.Text = "+";
            this.btn_openfileDialog.UseVisualStyleBackColor = false;
            // 
            // txt_dateipfad
            // 
            this.txt_dateipfad.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.txt_dateipfad.Location = new System.Drawing.Point(27, 128);
            this.txt_dateipfad.Name = "txt_dateipfad";
            this.txt_dateipfad.ReadOnly = true;
            this.txt_dateipfad.Size = new System.Drawing.Size(455, 23);
            this.txt_dateipfad.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(18, 30);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(0, 15);
            this.label6.TabIndex = 15;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txt_Port);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.groupBox2.Location = new System.Drawing.Point(55, 73);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(550, 100);
            this.groupBox2.TabIndex = 20;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "TCP Server";
            // 
            // txt_Port
            // 
            this.txt_Port.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.txt_Port.Location = new System.Drawing.Point(27, 58);
            this.txt_Port.Name = "txt_Port";
            this.txt_Port.Size = new System.Drawing.Size(493, 23);
            this.txt_Port.TabIndex = 7;
            this.txt_Port.Leave += new System.EventHandler(this.txt_Port_Leave);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.label5.Location = new System.Drawing.Point(24, 31);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(121, 17);
            this.label5.TabIndex = 8;
            this.label5.Text = "TCP Listener Port :";
            // 
            // TcpServerSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(202)))), ((int)(((byte)(87)))));
            this.ClientSize = new System.Drawing.Size(661, 558);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "TcpServerSettings";
            this.Text = "TcpServerSettings";
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btn_openfileDialog;
        private System.Windows.Forms.TextBox txt_dateipfad;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton rd_aus;
        private System.Windows.Forms.RadioButton rd_an;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txt_Port;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
    }
}