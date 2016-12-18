﻿using System;
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
            //var row_list = GetDataGridRows(LstEmployee);
            //foreach (var item in row_list)
            //{
            //    var dateofbirth = (LstEmployee.Columns[3].GetCellContent(item) as ContentPresenter);
            //    EMPLOYEE emp = new EMPLOYEE();
            //    emp.EmployeeID = (LstEmployee.Columns[0].GetCellContent(item) as TextBlock).Text;
            //    emp.FirstName = (LstEmployee.Columns[1].GetCellContent(item) as TextBlock).Text;
            //    emp.LastName = (LstEmployee.Columns[2].GetCellContent(item) as TextBlock).Text;
            //    emp.DOB = (dateofbirth.ContentTemplate.FindName("DateBirth", dateofbirth) as DatePicker).SelectedDate;
            //    emp.Address = (LstEmployee.Columns[4].GetCellContent(item) as TextBlock).Text;
            //    emp.Email = (LstEmployee.Columns[5].GetCellContent(item) as TextBlock).Text;
            //    emp.Phone = (LstEmployee.Columns[6].GetCellContent(item) as TextBlock).Text;
            //    emp.Gender = (bool)(LstEmployee.Columns[7].GetCellContent(item) as ComboBox).SelectedValue;
            //    emp.PostionID = CheckNullComboBox(item, 8);
            //    emp.DeptID =  CheckNullComboBox(item, 9);
            //    emp.GroupID = CheckNullComboBox(item, 10);

            //    BUS.BUS.InsertEmployee(emp);
            //    LstEmployee.ItemsSource = BUS.BUS.DsEmployee();

            //}
        }

        private string CheckNullComboBox(DataGridRow item,int Index)
        {
            return (LstEmployee.Columns[Index].GetCellContent(item) as ComboBox).SelectedValue == null ? "" : (LstEmployee.Columns[Index].GetCellContent(item) as ComboBox).SelectedValue.ToString();
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

        private void LstEmployee_Loaded(object sender, RoutedEventArgs e)
        {
            ICollectionView collectionView = CollectionViewSource.GetDefaultView(BUS.BUS.DsEmployee());
            lmDB = collectionView;
            LstEmployee.ItemsSource = collectionView;
            // Load data for combobox
            XGender.ItemsSource = ListGender.Gender;
            Department.ItemsSource = BUS.BUS.DsDept();
            Group.ItemsSource = BUS.BUS.DsGroup();
            Position.ItemsSource = BUS.BUS.DsPos();
            //LstEmployee.ItemsSource = BUS.BUS.DsEmployee();
        }
        bool isInsertMode = false;
        bool isBeingEdited = false;
        private void LstEmployee_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void LstEmployee_BeginningEdit(object sender, DataGridBeginningEditEventArgs e)
        {
            isBeingEdited = true;
        }

        private void LstEmployee_AddingNewItem(object sender, AddingNewItemEventArgs e)
        {
            isInsertMode = true;
        }

        private void LstEmployee_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            EMPLOYEE employee = new EMPLOYEE();
            EMPLOYEE emp = e.Row.DataContext as EMPLOYEE;
            if (isInsertMode)
            {
                var InsertRecord = MessageBox.Show("Do you want to add " + emp.FirstName + " as a new emploee?", "Confirm", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (InsertRecord == MessageBoxResult.Yes)
                {
                    employee.FirstName = emp.FirstName;
                    employee.LastName = emp.LastName;
                    employee.EmployeeID = emp.EmployeeID;
                    employee.DOB = emp.DOB;
                    employee.Address = employee.Address;
                    employee.Email = employee.Email;
                    employee.Phone = employee.Phone;
                    employee.Gender = employee.Gender;
                    employee.PostionID = employee.PostionID;
                    employee.DeptID = employee.DeptID;
                    employee.GroupID = employee.GroupID;
                    BUS.BUS.InsertEmployee(employee);
                    MessageBox.Show(employee.FirstName + " " + employee.LastName + " has being added!", "Inserting Record", MessageBoxButton.OK, MessageBoxImage.Information);
                    LstEmployee.ItemsSource = BUS.BUS.DsEmployee();
                }
                else
                    LstEmployee.ItemsSource = BUS.BUS.DsEmployee();
            }
        }
    }
}