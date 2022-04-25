using HRIS.Controller;
using HRIS.Database;
using HRIS.Entities;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

namespace HRIS
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private const string STAFF_KEY = "viewableStaff";
        private StaffController staffController;


        public MainWindow()
        {
            InitializeComponent();
            staffController = (StaffController)(Application.Current.FindResource(STAFF_KEY) as ObjectDataProvider).ObjectInstance;
            

        }


        private void StaffListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0)
            {
                staffDetails.DataContext = DBAdapter.GetFullStaffDetails((Staff)e.AddedItems[0]);

            }
        }

        private void addStaff_Click(object sender, RoutedEventArgs e)
        {
            string ID = textBox_id.Text;
            string GivenName = textBox_first.Text;
            string FamilyName = textBox_last.Text;
            staffController.Add(ID, GivenName, FamilyName);
            MessageBox.Show("Updated successully!");
        }

        //private void StaffListBox_MouseDoubleClick(object sender, EventArgs e)
        //{
        //    if (StaffListBox.SelectedItem != null)
        //    {
        //        MessageBox.Show(StaffListBox.SelectedItem.ToString());
        //    }
        //}
        private void StaffListBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                addStaff_Click(sender, e);
            }
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            McDataGrid.DataContext = GetEmployeeList();
        }

        private DataTable GetEmployeeList()
        {
            DataTable dtEmployees = new DataTable();
            string connString = ConfigurationManager.ConnectionStrings["hris"].ConnectionString;

            using(SqlConnection con = new SqlConnection(connString))
            {
                using(SqlCommand cmd = new SqlCommand("SELECT * FROM Staff", con))
                {
                    con.Open();

                    SqlDataReader reader = cmd.ExecuteReader();

                    dtEmployees.Load(reader);
                }
            }
            return dtEmployees;
        }

        private void McDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        //private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    if (e.AddedItems.Count > 0)
        //    {
        //        McDataGrid.DataContext = (System.Collections.IEnumerable)DBAdapter.GetFullStaffDetails((Staff)e.AddedItems[0]);
        //    }
        //}
    }
}
