using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using framework.core_app;
namespace framework.View.Forms
{
    public partial class BaseForm<T> : Form where T : class, BaseEntity
    {
        protected readonly IServiceApp<T> _service;
        private List<T> dataList;

        public BaseForm()
        {
            _service = App.instance().GetServiceApp<T>();
            InitializeComponent();
            SetupDataGrid();
            AddButtonsToGrid();
        }

        

        private void SetupDataGrid()
        {
            dataList = _service.read().ToList();
            BindingSource bindingSource = new BindingSource
            {
                DataSource = dataList,
            };
            this.dataGridView.DataSource = bindingSource;
            foreach (DataGridViewColumn column in dataGridView.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
        }

        protected  void AddButton_Click(object sender, EventArgs e)
        {
            using (AddView<T> addForm = new AddView<T>())
            {
                DialogResult result = addForm.ShowDialog();
                if (result == DialogResult.OK)
                {
                    T newItem = addForm.GetData();
                    newItem.Id = auth_helper.GenerateShortGuid();
                    if (newItem == null)
                        MessageBox.Show("000");
                    _service.create(newItem);
                    SetupDataGrid();
                }
            }
        }
        protected void Refresh_Click(object sender, EventArgs e)
        {
            SetupDataGrid();
        }


        protected void UpdateMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedCells.Count > 0)
            {
                int rowIndex = dataGridView.SelectedCells[0].RowIndex;
                if (rowIndex >= 0)
                {
                    T selectedItem = dataList[rowIndex];
                    using (UpdateView<T> updateForm = new UpdateView<T>(selectedItem))
                    {
                        DialogResult result = updateForm.ShowDialog();
                        if (result == DialogResult.OK)
                        {
                            T newItem = updateForm.GetData();

                            if (newItem == null)
                            {
                                MessageBox.Show("Update canceled.");
                                return;
                            }
                            newItem.Id = selectedItem.Id;

                            _service.update(newItem);
                            SetupDataGrid();


                        }
                    }
                }
            }
        }



        protected void DataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
        }


        protected void AddButtonsToGrid()
        {
            // Add a column for buttons at the end
            DataGridViewButtonColumn addButton = new DataGridViewButtonColumn();
            addButton.HeaderText = "";
            addButton.Text = "Update";
            addButton.UseColumnTextForButtonValue = true;

            DataGridViewButtonColumn updateButton = new DataGridViewButtonColumn();
            updateButton.HeaderText = "";
            updateButton.Text = "Delete";
            updateButton.UseColumnTextForButtonValue = true; 
            


            dataGridView.Columns.Add(addButton);
            dataGridView.Columns.Add(updateButton);

            dataGridView.CellContentClick += DataGridView_CellContentClick;
            dataGridView.CellClick += DataGridView_CellClick;
        }


        private void DataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if ((e.ColumnIndex == 0 || e.ColumnIndex == 1) && e.RowIndex< dataGridView.RowCount-1)
            {
                if (dataGridView.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
                {
                    string buttonText = dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();

                    switch (buttonText)
                    {
                        case "Update":
                            UpdateMenuItem_Click(sender, e);
                            break;
                        case "Delete":

                            _service.delete((T)dataGridView.Rows[e.RowIndex].DataBoundItem);
                            SetupDataGrid();
                            break;


                        default:
                            break;
                    }
                }
            }
        }

        protected void DataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex == dataGridView.Columns.Count - 1 && e.RowIndex >= 0)
            {


            }
        }

    }

}
