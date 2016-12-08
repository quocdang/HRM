using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using BUS;
using DTO;
using System.Data;
using System.ComponentModel;
using System.Collections;
using System.Collections.ObjectModel;

namespace HRM
{
    
    public partial class Employees : UserControl,WPFTabbedMDI
    {
        public IEnumerable lmDB;
        public Employees()
        {
            InitializeComponent();
            ICollectionView collectionView = CollectionViewSource.GetDefaultView(BUS.BUS.DsEmployee());
            LstEmployee.ItemsSource = collectionView;
            lmDB = collectionView;
            // Load data for combobox
            XGender.ItemsSource = ListGender.Gender;
            Department.ItemsSource = BUS.BUS.DsDept();
            Room.ItemsSource = BUS.BUS.DsRoom();
            Group.ItemsSource = BUS.BUS.DsGroup();
            Position.ItemsSource = BUS.BUS.DsPos();
            LstEmployee.ScrollIntoView(LstEmployee.Items.GetItemAt(LstEmployee.Items.Count -1));
            //LstEmployee.ItemsSource = BUS.BUS.DsEmployee();

        }
        public class GenderS
        {
            public string Code { set; get; }
            public string Name { set; get; }
        }
        public static class ListGender
        {
            static ListGender()
            {
                Gender = new ObservableCollection<GenderS>
                 {
                     new GenderS{Name = "Nam", Code = "True"},
                     new GenderS{Name = "Nữ", Code = "False"}
                 };
            }
            public static ObservableCollection<GenderS> Gender { set; get; }
        }
        #region ITabbedMDI Members
        /// <summary>
        /// Get Employee UserControl to return MDI
        /// </summary>
        public UserControl CurrType
        {
            get
            {
                return this ;
            }
        }

        /// <summary>
        /// Check active
        /// </summary>
        public bool Active
        {
            get
            {
                return true;
            }
        }
        /// <summary>
        /// Set Name of UC
        /// </summary>
        public string UniqueTabName
        {
            get
            {
                return "Employees";
            }
        }
        /// <summary>
        /// Set Title
        /// </summary>
        public string Title
        {
            get { return "Employees"; }
        }
        /// <summary>
        /// Get List Rows From DataGridRow
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public IEnumerable<DataGridRow> GetDataGridRows(DataGrid grid)
        {
            var itemsSource = grid.ItemsSource as IEnumerable;
            if (itemsSource == null) yield return null;
            foreach (var item in itemsSource)
            {
                var row = grid.ItemContainerGenerator.ContainerFromItem(item) as DataGridRow;
                if (row != null) yield return row;
            }
        }

        /// <summary>
        /// Save Method To Insert Or Update
        /// </summary>
        public void Save()
        {
            foreach (EMPLOYEE item in lmDB)
            {

                EMPLOYEE emp = new EMPLOYEE();
                emp.EmployeeID = item.EmployeeID;
                emp.FirstName = item.FirstName;
                emp.LastName = item.LastName;
                emp.Gender = item.Gender;
                emp.DOB = item.DOB;
                emp.Address = item.Address;
                emp.Email = item.Email;
                emp.Phone = item.Phone;
                emp.PostionID = item.PostionID;
                emp.DeptID = item.DeptID;
                emp.RoomID = item.RoomID;
                emp.GroupID = item.GroupID;

                BUS.BUS.InsertEmployee(emp);
                LstEmployee.ItemsSource = BUS.BUS.DsEmployee();

            }            
        }

        private string CheckNullComboBox(DataGridRow item,int Index)
        {
            return (LstEmployee.Columns[Index].GetCellContent(item) as ComboBox).SelectedValue == null ? "" : (LstEmployee.Columns[11].GetCellContent(item) as ComboBox).SelectedValue.ToString();
        }

        /// <summary>
        /// Delete Method to Delete Item From DataGrid
        /// </summary>
        public void Delete()
        {
            EMPLOYEE emp = LstEmployee.SelectedItem as EMPLOYEE;
            string EmpID = emp.EmployeeID;
            BUS.BUS.DeleteEmployee(EmpID);
            LstEmployee.ItemsSource = BUS.BUS.DsEmployee();
        }

        #endregion

        private void LstEmployee_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            LstEmployee.ScrollIntoView(e.Row.Item);
        }
    }
}