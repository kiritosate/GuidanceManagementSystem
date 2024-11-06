using CuoreUI.Controls;
using GuidanceManagementSystem.methods;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GuidanceManagementSystem.View_Frms
{
    public partial class registration_view : Form
    {
        public registration_view()
        {
            InitializeComponent();
            fetchService = new MyFetch();
        }

        private BindingSource bindingSource = new BindingSource();
        private methods.MyFetch fetchService;
        private String StudentId;

        private void cuiTextBox21_ContentChanged(object sender, EventArgs e)
        {
            string searchText = cuiTextBox21.Content.Trim();

            if (!string.IsNullOrEmpty(searchText))
            {
                bindingSource.Filter = $"Student_ID LIKE '%{searchText}%' OR " +
                                       $"Course LIKE '%{searchText}%' OR " +
                                       $"Year LIKE '%{searchText}%' OR " +
                                       $"Firstname LIKE '%{searchText}%' OR " +
                                       $"Middlename LIKE '%{searchText}%' OR " +
                                       $"Lastname LIKE '%{searchText}%' OR " +
                                       $"Sex LIKE '%{searchText}%'";
            }
            else
            {
                bindingSource.RemoveFilter();
            }
        }

        private void LoadDataIntoDataGridView(DataGridView dataGridView)
        {
            MySqlDataAdapter adapter = fetchService.GetIndividualDataPending();
            DataTable dataTable = new DataTable();

            adapter.Fill(dataTable);

            bindingSource.DataSource = dataTable;   // Fill the DataTable with data
            dataGridView.DataSource = bindingSource; // Bind the DataTable to the DataGridView
            AddActionColumns();

        }

        private void AddActionColumns()
        {
            // Create the View column
            DataGridViewImageColumn viewColumn = new DataGridViewImageColumn();
            viewColumn.HeaderText = "View";
            viewColumn.Name = "imgView";
            viewColumn.Image = Properties.Resources.eye_96px; // Replace with your resource image
            viewColumn.ImageLayout = DataGridViewImageCellLayout.Zoom; // Optionally set layout
            dataGridView1.Columns.Add(viewColumn);

            // Create the Edit column
            DataGridViewImageColumn editColumn = new DataGridViewImageColumn();
            editColumn.HeaderText = "Edit";
            editColumn.Name = "imgEdit";
            //editColumn.Image = Properties.Resources.pencil_96px; // Replace with your resource image
            editColumn.ImageLayout = DataGridViewImageCellLayout.Zoom; // Optionally set layout
            dataGridView1.Columns.Add(editColumn);
            // Create the Delete column
            DataGridViewImageColumn deleteColumn = new DataGridViewImageColumn();
            deleteColumn.HeaderText = "Delete";
            deleteColumn.Name = "imgDelete";
            //deleteColumn.Image = Properties.Resources.delete_trash_96px; // Replace with your resource image
            deleteColumn.ImageLayout = DataGridViewImageCellLayout.Zoom; // Optionally set layout
            dataGridView1.Columns.Add(deleteColumn);
        }

        private void registration_view_Load(object sender, EventArgs e)
        {
            timer1.Start();
            LoadDataIntoDataGridView(dataGridView1);
        }

        private void cuiButton2_Click(object sender, EventArgs e)
        {
            webserver_view ws = new webserver_view();
            ws.ShowDialog();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(webserver_view._serverUp)
            {
                cuiButton2.Image = Properties.Resources.cloud_sync_480px;
            }
            else
            {
                cuiButton2.Image = Properties.Resources.cloud_cross_480px;
            }
            
        }
    }
}
