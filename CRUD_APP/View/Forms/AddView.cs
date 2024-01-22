using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using framework.core_app;
namespace framework.View.Forms
{
    public partial class AddView<T> : Form
    {
        private T dataItem;
        private Button saveButton;

        public AddView(T item = default(T))
        {
            InitializeComponent();
            dataItem = item;
            InitializeControls();
        }
        private void InitializeControls()
        {
            // Create a Panel to contain the dynamically generated controls
            PropertyInfo[] properties = typeof(T).GetProperties();


            for (int i=0;i< properties.Length;i++)
            {
                if (properties[i].Name.ToLower() == "id")
                {
                    continue;
                }
                    // Create label
                    Label label = new Label();
                label.Text = properties[i].Name;
                

                // Create textbox
                TextBox textBox = new TextBox();
                textBox.Name = properties[i].Name; // Set the name to the property name for easy reference
                // Set the initial value if updating
                if (dataItem != null)
                {
                    object value = properties[i].GetValue(dataItem);
                    textBox.Text = value != null ? value.ToString() : string.Empty;
                }
                if (properties[i].PropertyType == typeof(DateTime) && properties[i].Name.Equals("updated_at", StringComparison.OrdinalIgnoreCase))
                {
                    textBox.Text = "";
                    // textBox.Text = DateTime.Now.ToString(); // You can modify this based on your requirements
                    textBox.Enabled = false; // Optionally, disable the textbox for the UpdatedAt property
                }else 
                if (properties[i].PropertyType == typeof(DateTime) && properties[i].Name.Equals("created_at", StringComparison.OrdinalIgnoreCase))
                {
                    textBox.Text = DisplayDate.displayDateTime(); // You can modify this based on your requirements

                    // textBox.Text = DateTime.Now.ToString(); // You can modify this based on your requirements
                    textBox.Enabled = false; // Optionally, disable the textbox for the UpdatedAt property
                }

                tableLayoutPanel.Controls.Add(label,0,i);
                tableLayoutPanel.Controls.Add(textBox,1,i);

            }
            saveButton = new Button();
            saveButton.Text = "Save";
            saveButton.Click += SaveButton_Click;
            tableLayoutPanel.Controls.Add(saveButton, 1, properties.Length);            
        }
        private void SaveButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        public T GetData()
        {
            T newData = Activator.CreateInstance<T>(); // Create a new instance of type T

            PropertyInfo[] properties = typeof(T).GetProperties();
            foreach (var control in tableLayoutPanel.Controls.OfType<TextBox>())
            {
                var property = properties.FirstOrDefault(p => p.Name.Equals(control.Name, StringComparison.OrdinalIgnoreCase));

                if (property != null)
                {
                    object value;

                    if (property.Name == "created_at")
                    {
                        value = DateTime.Now;
                    }
                    else if (property.Name == "updated_at")
                    {
                        value = DateTime.Parse("1/1/1753 12:00:00 AM");

                    }
                    else
                    {
                        value = Convert.ChangeType(control.Text, property.PropertyType);
                    }

                    property.SetValue(newData, value);
                }
            }
            return newData;
        }
    }
}
