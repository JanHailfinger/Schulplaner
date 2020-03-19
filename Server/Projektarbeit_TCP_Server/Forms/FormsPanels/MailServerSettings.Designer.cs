namespace Projektarbeit_TCP_Server
{
    partial class MailServerSettings
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
            this.txt_email = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_domain = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_passwort = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_username = new System.Windows.Forms.TextBox();
            this.txt_port = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btn_openfileDialog = new System.Windows.Forms.Button();
            this.txt_dateipfad = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cb_htmldatei = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // txt_email
            // 
            this.txt_email.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.txt_email.Location = new System.Drawing.Point(27, 54);
            this.txt_email.Name = "txt_email";
            this.txt_email.Size = new System.Drawing.Size(493, 23);
            this.txt_email.TabIndex = 1;
            this.txt_email.Leave += new System.EventHandler(this.txt_email_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.label1.Location = new System.Drawing.Point(24, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(305, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "E-Mail Adresse der Ausgehenden Nachrichten :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.label3.Location = new System.Drawing.Point(388, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Port :";
            // 
            // txt_domain
            // 
            this.txt_domain.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.txt_domain.Location = new System.Drawing.Point(27, 59);
            this.txt_domain.Name = "txt_domain";
            this.txt_domain.Size = new System.Drawing.Size(345, 23);
            this.txt_domain.TabIndex = 3;
            this.txt_domain.Leave += new System.EventHandler(this.txt_domain_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.label4.Location = new System.Drawing.Point(281, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "Passwort :";
            // 
            // txt_passwort
            // 
            this.txt_passwort.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.txt_passwort.Location = new System.Drawing.Point(284, 58);
            this.txt_passwort.Name = "txt_passwort";
            this.txt_passwort.PasswordChar = '✹';
            this.txt_passwort.Size = new System.Drawing.Size(236, 23);
            this.txt_passwort.TabIndex = 5;
            this.txt_passwort.Leave += new System.EventHandler(this.txt_passwort_Leave);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.label5.Location = new System.Drawing.Point(24, 31);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 17);
            this.label5.TabIndex = 8;
            this.label5.Text = "Nutzername :";
            // 
            // txt_username
            // 
            this.txt_username.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.txt_username.Location = new System.Drawing.Point(27, 58);
            this.txt_username.Name = "txt_username";
            this.txt_username.Size = new System.Drawing.Size(236, 23);
            this.txt_username.TabIndex = 7;
            this.txt_username.Leave += new System.EventHandler(this.txt_username_Leave);
            // 
            // txt_port
            // 
            this.txt_port.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.txt_port.Location = new System.Drawing.Point(391, 59);
            this.txt_port.Name = "txt_port";
            this.txt_port.Size = new System.Drawing.Size(129, 23);
            this.txt_port.TabIndex = 9;
            this.txt_port.Leave += new System.EventHandler(this.txt_port_Leave);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.label7.Location = new System.Drawing.Point(24, 33);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 17);
            this.label7.TabIndex = 11;
            this.label7.Text = "Adresse :";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txt_domain);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txt_port);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.groupBox1.Location = new System.Drawing.Point(57, 165);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(550, 100);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "SMTP Server";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txt_username);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txt_passwort);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.groupBox2.Location = new System.Drawing.Point(57, 283);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(550, 100);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "SMTP Anmeldung";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txt_email);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.groupBox3.Location = new System.Drawing.Point(57, 48);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(550, 100);
            this.groupBox3.TabIndex = 14;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "E - Mail";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btn_openfileDialog);
            this.groupBox4.Controls.Add(this.txt_dateipfad);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.cb_htmldatei);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.groupBox4.Location = new System.Drawing.Point(57, 401);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(550, 100);
            this.groupBox4.TabIndex = 15;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "HTML Dateien";
            // 
            // btn_openfileDialog
            // 
            this.btn_openfileDialog.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_openfileDialog.FlatAppearance.BorderSize = 0;
            this.btn_openfileDialog.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_openfileDialog.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.btn_openfileDialog.Location = new System.Drawing.Point(498, 59);
            this.btn_openfileDialog.Name = "btn_openfileDialog";
            this.btn_openfileDialog.Size = new System.Drawing.Size(21, 21);
            this.btn_openfileDialog.TabIndex = 19;
            this.btn_openfileDialog.Text = "+";
            this.btn_openfileDialog.UseVisualStyleBackColor = false;
            this.btn_openfileDialog.Click += new System.EventHandler(this.btn_openfileDialog_Click);
            // 
            // txt_dateipfad
            // 
            this.txt_dateipfad.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.txt_dateipfad.Location = new System.Drawing.Point(239, 59);
            this.txt_dateipfad.Name = "txt_dateipfad";
            this.txt_dateipfad.ReadOnly = true;
            this.txt_dateipfad.Size = new System.Drawing.Size(253, 23);
            this.txt_dateipfad.TabIndex = 9;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.label8.Location = new System.Drawing.Point(236, 30);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(85, 17);
            this.label8.TabIndex = 18;
            this.label8.Text = "Datei Pfad :";
            // 
            // cb_htmldatei
            // 
            this.cb_htmldatei.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_htmldatei.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.cb_htmldatei.FormattingEnabled = true;
            this.cb_htmldatei.Location = new System.Drawing.Point(27, 57);
            this.cb_htmldatei.Name = "cb_htmldatei";
            this.cb_htmldatei.Size = new System.Drawing.Size(191, 25);
            this.cb_htmldatei.TabIndex = 17;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.label9.Location = new System.Drawing.Point(24, 30);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(67, 17);
            this.label9.TabIndex = 16;
            this.label9.Text = "Vorlage :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(24, 30);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(0, 15);
            this.label6.TabIndex = 15;
            // 
            // MailServerSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(202)))), ((int)(((byte)(87)))));
            this.ClientSize = new System.Drawing.Size(661, 558);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MailServerSettings";
            this.Text = "MailServerSettings";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox txt_email;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_domain;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_passwort;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_username;
        private System.Windows.Forms.TextBox txt_port;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox txt_dateipfad;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cb_htmldatei;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btn_openfileDialog;
    }
}