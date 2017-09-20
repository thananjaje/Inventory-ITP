namespace EwingInventory
{
    partial class Homepage
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
            this.btn_users = new System.Windows.Forms.Button();
            this.btn_logOff = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button_manufact = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_users
            // 
            this.btn_users.BackgroundImage = global::EwingInventory.Properties.Resources.icon_user;
            this.btn_users.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_users.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_users.Location = new System.Drawing.Point(8, 15);
            this.btn_users.Name = "btn_users";
            this.btn_users.Size = new System.Drawing.Size(60, 60);
            this.btn_users.TabIndex = 1;
            this.btn_users.UseVisualStyleBackColor = true;
            this.btn_users.Click += new System.EventHandler(this.btn_users_Click);
            // 
            // btn_logOff
            // 
            this.btn_logOff.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.btn_logOff.BackgroundImage = global::EwingInventory.Properties.Resources.icon_Logoff1;
            this.btn_logOff.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_logOff.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_logOff.ForeColor = System.Drawing.SystemColors.InfoText;
            this.btn_logOff.Location = new System.Drawing.Point(1032, 15);
            this.btn_logOff.Name = "btn_logOff";
            this.btn_logOff.Size = new System.Drawing.Size(60, 60);
            this.btn_logOff.TabIndex = 0;
            this.btn_logOff.UseVisualStyleBackColor = false;
            this.btn_logOff.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox1.BackColor = System.Drawing.Color.RoyalBlue;
            this.groupBox1.Controls.Add(this.button_manufact);
            this.groupBox1.Controls.Add(this.btn_users);
            this.groupBox1.Controls.Add(this.btn_logOff);
            this.groupBox1.Location = new System.Drawing.Point(-3, -12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1290, 80);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // button_manufact
            // 
            this.button_manufact.BackgroundImage = global::EwingInventory.Properties.Resources.icon_manufact;
            this.button_manufact.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_manufact.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_manufact.Location = new System.Drawing.Point(326, 15);
            this.button_manufact.Name = "button_manufact";
            this.button_manufact.Size = new System.Drawing.Size(60, 60);
            this.button_manufact.TabIndex = 3;
            this.button_manufact.UseVisualStyleBackColor = true;
            this.button_manufact.Click += new System.EventHandler(this.button2_Click);
            // 
            // Homepage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(1264, 750);
            this.Controls.Add(this.groupBox1);
            this.Name = "Homepage";
            this.Text = "Homepage";
            this.Load += new System.EventHandler(this.Homepage_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_logOff;
        public System.Windows.Forms.Button btn_users;
        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.Button button_manufact;
    }
}