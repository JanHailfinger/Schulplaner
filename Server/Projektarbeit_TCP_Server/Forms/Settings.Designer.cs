namespace Projektarbeit_TCP_Server
{
    partial class Settings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Settings));
            this.panel = new System.Windows.Forms.Panel();
            this.btn_databasesettings = new System.Windows.Forms.Button();
            this.btn_mailserversettings = new System.Windows.Forms.Button();
            this.btn_tcpserversettings = new System.Windows.Forms.Button();
            this.btn_close = new System.Windows.Forms.Button();
            this.btn_save = new System.Windows.Forms.Button();
            this.copyright = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.box_tcpserver = new System.Windows.Forms.PictureBox();
            this.box_database = new System.Windows.Forms.PictureBox();
            this.box_mailserver = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.box_tcpserver)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.box_database)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.box_mailserver)).BeginInit();
            this.SuspendLayout();
            // 
            // panel
            // 
            this.panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(202)))), ((int)(((byte)(87)))));
            this.panel.Location = new System.Drawing.Point(262, 0);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(661, 558);
            this.panel.TabIndex = 0;
            // 
            // btn_databasesettings
            // 
            this.btn_databasesettings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(156)))), ((int)(((byte)(18)))));
            this.btn_databasesettings.FlatAppearance.BorderSize = 0;
            this.btn_databasesettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_databasesettings.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            this.btn_databasesettings.Image = global::Projektarbeit_TCP_Server.Properties.Resources.database1;
            this.btn_databasesettings.Location = new System.Drawing.Point(12, 324);
            this.btn_databasesettings.Name = "btn_databasesettings";
            this.btn_databasesettings.Size = new System.Drawing.Size(251, 50);
            this.btn_databasesettings.TabIndex = 2;
            this.btn_databasesettings.Text = "   Datenbank Einstellungen";
            this.btn_databasesettings.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_databasesettings.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_databasesettings.UseVisualStyleBackColor = false;
            this.btn_databasesettings.Click += new System.EventHandler(this.btn_databasesettings_Click);
            // 
            // btn_mailserversettings
            // 
            this.btn_mailserversettings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(156)))), ((int)(((byte)(18)))));
            this.btn_mailserversettings.FlatAppearance.BorderSize = 0;
            this.btn_mailserversettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_mailserversettings.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            this.btn_mailserversettings.Image = global::Projektarbeit_TCP_Server.Properties.Resources.email;
            this.btn_mailserversettings.Location = new System.Drawing.Point(12, 274);
            this.btn_mailserversettings.Name = "btn_mailserversettings";
            this.btn_mailserversettings.Size = new System.Drawing.Size(251, 50);
            this.btn_mailserversettings.TabIndex = 3;
            this.btn_mailserversettings.Text = "   Mail Server Einstellungen";
            this.btn_mailserversettings.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_mailserversettings.UseVisualStyleBackColor = false;
            this.btn_mailserversettings.Click += new System.EventHandler(this.btn_mailserversettings_Click);
            // 
            // btn_tcpserversettings
            // 
            this.btn_tcpserversettings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(156)))), ((int)(((byte)(18)))));
            this.btn_tcpserversettings.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btn_tcpserversettings.FlatAppearance.BorderSize = 0;
            this.btn_tcpserversettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_tcpserversettings.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_tcpserversettings.ForeColor = System.Drawing.Color.Black;
            this.btn_tcpserversettings.Image = global::Projektarbeit_TCP_Server.Properties.Resources.server;
            this.btn_tcpserversettings.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_tcpserversettings.Location = new System.Drawing.Point(12, 224);
            this.btn_tcpserversettings.Name = "btn_tcpserversettings";
            this.btn_tcpserversettings.Size = new System.Drawing.Size(251, 50);
            this.btn_tcpserversettings.TabIndex = 4;
            this.btn_tcpserversettings.Text = "   TCP Server Einstellungen";
            this.btn_tcpserversettings.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_tcpserversettings.UseVisualStyleBackColor = false;
            this.btn_tcpserversettings.Click += new System.EventHandler(this.btn_tcpserversettings_Click);
            // 
            // btn_close
            // 
            this.btn_close.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(156)))), ((int)(((byte)(18)))));
            this.btn_close.FlatAppearance.BorderSize = 0;
            this.btn_close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_close.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            this.btn_close.Image = global::Projektarbeit_TCP_Server.Properties.Resources.error;
            this.btn_close.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_close.Location = new System.Drawing.Point(12, 461);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(251, 50);
            this.btn_close.TabIndex = 5;
            this.btn_close.Text = "    Schließen";
            this.btn_close.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_close.UseVisualStyleBackColor = false;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // btn_save
            // 
            this.btn_save.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(156)))), ((int)(((byte)(18)))));
            this.btn_save.FlatAppearance.BorderSize = 0;
            this.btn_save.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_save.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            this.btn_save.Image = global::Projektarbeit_TCP_Server.Properties.Resources.save;
            this.btn_save.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_save.Location = new System.Drawing.Point(12, 411);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(251, 50);
            this.btn_save.TabIndex = 6;
            this.btn_save.Text = "    Speichern";
            this.btn_save.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_save.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_save.UseVisualStyleBackColor = false;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // copyright
            // 
            this.copyright.AutoSize = true;
            this.copyright.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            this.copyright.Location = new System.Drawing.Point(22, 520);
            this.copyright.Name = "copyright";
            this.copyright.Size = new System.Drawing.Size(223, 20);
            this.copyright.TabIndex = 8;
            this.copyright.Text = "©  Projektarbeit Jan Hailfinger";
            this.copyright.Click += new System.EventHandler(this.copyright_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Projektarbeit_TCP_Server.Properties.Resources.logo;
            this.pictureBox1.Location = new System.Drawing.Point(0, 1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(263, 189);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // box_tcpserver
            // 
            this.box_tcpserver.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(84)))), ((int)(((byte)(0)))));
            this.box_tcpserver.Location = new System.Drawing.Point(0, 224);
            this.box_tcpserver.Name = "box_tcpserver";
            this.box_tcpserver.Size = new System.Drawing.Size(10, 50);
            this.box_tcpserver.TabIndex = 9;
            this.box_tcpserver.TabStop = false;
            // 
            // box_database
            // 
            this.box_database.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(84)))), ((int)(((byte)(0)))));
            this.box_database.Location = new System.Drawing.Point(0, 324);
            this.box_database.Name = "box_database";
            this.box_database.Size = new System.Drawing.Size(10, 50);
            this.box_database.TabIndex = 10;
            this.box_database.TabStop = false;
            // 
            // box_mailserver
            // 
            this.box_mailserver.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(84)))), ((int)(((byte)(0)))));
            this.box_mailserver.Location = new System.Drawing.Point(0, 274);
            this.box_mailserver.Name = "box_mailserver";
            this.box_mailserver.Size = new System.Drawing.Size(10, 50);
            this.box_mailserver.TabIndex = 11;
            this.box_mailserver.TabStop = false;
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(156)))), ((int)(((byte)(18)))));
            this.ClientSize = new System.Drawing.Size(919, 556);
            this.Controls.Add(this.box_mailserver);
            this.Controls.Add(this.box_database);
            this.Controls.Add(this.box_tcpserver);
            this.Controls.Add(this.copyright);
            this.Controls.Add(this.btn_close);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.btn_tcpserversettings);
            this.Controls.Add(this.btn_mailserversettings);
            this.Controls.Add(this.btn_databasesettings);
            this.Controls.Add(this.panel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Settings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Projektarbeit Server Einstellungen";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.box_tcpserver)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.box_database)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.box_mailserver)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.Button btn_databasesettings;
        private System.Windows.Forms.Button btn_mailserversettings;
        private System.Windows.Forms.Button btn_tcpserversettings;
        private System.Windows.Forms.Button btn_close;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label copyright;
        private System.Windows.Forms.PictureBox box_tcpserver;
        private System.Windows.Forms.PictureBox box_database;
        private System.Windows.Forms.PictureBox box_mailserver;
    }
}