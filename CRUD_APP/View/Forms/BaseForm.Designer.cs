using System;
using System.Windows.Forms;
namespace framework.View.Forms
{
    public partial class BaseForm<T>
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dataGridView;

        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button refreshButton;



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
            this.dataGridView = new System.Windows.Forms.DataGridView();

            this.addButton = new System.Windows.Forms.Button();
            this.refreshButton = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(12, 12);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(800, 550);
            this.dataGridView.TabIndex = 0;
            this.dataGridView.ReadOnly=true;
            this.dataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView_CellDoubleClick);

            this.addButton.Name = "AddButton";
            this.addButton.Size = new System.Drawing.Size(40, 25);

            this.addButton.Text = "Add";
            this.addButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addButton.FlatAppearance.BorderColor = System.Drawing.Color.Blue; // Replace with your desired color
            this.addButton.Click += new System.EventHandler(this.AddButton_Click);
            this.refreshButton.Name = "ReseButton";
            this.refreshButton.Size = new System.Drawing.Size(60, 25);
            this.refreshButton.Text = "Refresh";
            this.refreshButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.refreshButton.FlatAppearance.BorderColor = System.Drawing.Color.Yellow; // Replace with your desired color
            this.refreshButton.Click += new System.EventHandler(this.Refresh_Click);
            this.refreshButton.Location = new System.Drawing.Point(this.addButton.Right + 10, this.addButton.Top);



            this.Controls.Add(addButton);
            this.Controls.Add(refreshButton);
            this.Controls.Add(this.dataGridView);
            // Set the form's properties
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Name = "TableGrid";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            int centerX = (this.ClientSize.Width - this.dataGridView.Width) / 2;
            int centerY = (this.ClientSize.Height - this.dataGridView.Height) / 2;
            this.dataGridView.Location = new System.Drawing.Point(centerX, centerY);

            // this.addButton.Image = global::CRUD_APP.Properties.Resources.icons8_menu_30;


            this.ResumeLayout(false);

        }

        #endregion
    }
}