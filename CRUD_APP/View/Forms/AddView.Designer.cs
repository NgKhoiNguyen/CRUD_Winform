using System;
using System.Drawing; // Add this using directive for the Color class
using System.Windows.Forms;

namespace framework.View.Forms
{
    partial class AddView<T>
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private TableLayoutPanel tableLayoutPanel;
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
            this.tableLayoutPanel.ColumnCount = 2; // Increase the row count to accommodate the Register link
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(300, 200); // Increase the size to accommodate the Register link
            this.tableLayoutPanel.TabIndex = 0;
            this.tableLayoutPanel.BackColor = SystemColors.Control; // Set the background color to the default
            this.tableLayoutPanel.Anchor = AnchorStyles.None;

            this.ClientSize = new System.Drawing.Size(600, 350);
            this.tableLayoutPanel.Location = new System.Drawing.Point((this.ClientSize.Width - this.tableLayoutPanel.Width) / 2,
                                                             (this.ClientSize.Height - this.tableLayoutPanel.Height) / 2);
            this.Controls.Add(this.tableLayoutPanel);
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Text = "Add View";
            this.tableLayoutPanel.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion
    }
}