
using System;
using System.Drawing; // Add this using directive for the Color class
using System.Windows.Forms;

namespace framework.View.Forms
{
    partial class LoginBase<IAuth>
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private TableLayoutPanel tableLayoutPanel;
        private Label labelUsername;
        private TextBox textBoxUsername;
        private Label labelPassword;
        private TextBox textBoxPassword;
        private Button buttonLogin;
        private LinkLabel linkLabelRegister;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.labelUsername = new System.Windows.Forms.Label();
            this.textBoxUsername = new System.Windows.Forms.TextBox();
            this.labelPassword = new System.Windows.Forms.Label();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.buttonLogin = new System.Windows.Forms.Button();
            this.linkLabelRegister = new System.Windows.Forms.LinkLabel();
            this.tableLayoutPanel.SuspendLayout();
            this.SuspendLayout();

            // tableLayoutPanel
            this.tableLayoutPanel.ColumnCount = 2;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel.Controls.Add(this.labelUsername, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.textBoxUsername, 1, 0);
            this.tableLayoutPanel.Controls.Add(this.labelPassword, 0, 1);
            this.tableLayoutPanel.Controls.Add(this.textBoxPassword, 1, 1);
            this.tableLayoutPanel.Controls.Add(this.buttonLogin, 1, 3);
            this.tableLayoutPanel.Controls.Add(this.linkLabelRegister, 1, 2);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            //this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel.Name = "tablelayout_login";
            this.tableLayoutPanel.RowCount = 4; // Increase the row count to accommodate the Register link
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));

            this.tableLayoutPanel.Size = new System.Drawing.Size(300, 100); // Increase the size to accommodate the Register link
            this.tableLayoutPanel.TabIndex = 0;
            this.tableLayoutPanel.BackColor = SystemColors.Control; // Set the background color to the default

            // labelUsername
            this.labelUsername.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelUsername.AutoSize = true;
            this.labelUsername.Text = "Username:";

            // textBoxUsername
            this.textBoxUsername.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxUsername.Name = "Username_login";

            // labelPassword
            this.labelPassword.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelPassword.AutoSize = true;
            this.labelPassword.Text = "Password:";

            // textBoxPassword
            this.textBoxPassword.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxPassword.Name = "Password_login";
            this.textBoxPassword.PasswordChar = '*';

            // buttonLogin
            this.buttonLogin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonLogin.Text = "Login";
            this.buttonLogin.Click += new System.EventHandler(this.OnButtonClick);

            this.linkLabelRegister.Dock = System.Windows.Forms.DockStyle.Fill;
            this.linkLabelRegister.AutoSize = true;
            this.linkLabelRegister.Text = "Register";
            this.linkLabelRegister.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelRegister_LinkClicked);
            // Center the tableLayoutPanel within the form
            this.tableLayoutPanel.Anchor = AnchorStyles.None;

            // Form1
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.tableLayoutPanel.Location = new System.Drawing.Point((this.ClientSize.Width - this.tableLayoutPanel.Width) / 2,
                                                             (this.ClientSize.Height - this.tableLayoutPanel.Height) / 2);

            this.Controls.Add(this.tableLayoutPanel);
            this.Name = "Login";
            this.Text = "Login";
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
            this.ResumeLayout(false);
        }
        
        
        #endregion
    }
}