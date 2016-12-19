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
        public EMPLOYEE NewRow;
        public List<EMPLOYEE> LstItemChange;
        public Employees()
        {
            InitializeComponent();

            LstItemChange = new List<EMPLOYEE>();
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
            foreach (EMPLOYEE item in LstItemChange)
            {
                //var dateofbirth = (LstEmployee.Columns[3].GetCellContent(item) as ContentPresenter);
                //EMPLOYEE emp = new EMPLOYEE();
                //emp.EmployeeID = (LstEmployee.Columns[0].GetCellContent(item) as TextBlock).Text;
                //emp.FirstName = (LstEmployee.Columns[1].GetCellContent(item) as TextBlock).Text;
                //emp.LastName = (LstEmployee.Columns[2].GetCellContent(item) as TextBlock).Text;
                //emp.DOB = (dateofbirth.ContentTemplate.FindName("DateBirth", dateofbirth) as DatePicker).SelectedDate;
                //emp.Address = (LstEmployee.Columns[4].GetCellContent(item) as TextBlock).Text;
                //emp.Email = (LstEmployee.Columns[5].GetCellContent(item) as TextBlock).Text;
                //emp.Phone = (LstEmployee.Columns[6].GetCellContent(item) as TextBlock).Text;
                //emp.Gender = (bool)(LstEmployee.Columns[7].GetCellContent(item) as ComboBox).SelectedValue;
                //emp.PostionID = CheckNullComboBox(item, 8);
                //emp.DeptID = CheckNullComboBox(item, 9);
                //emp.GroupID = CheckNullComboBox(item, 10);

                BUS.BUS.InsertEmployee(item);
                LstEmployee.ItemsSource = BUS.BUS.DsEmployee();

            }
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
            LstEmployee.ItemsSource = collectionView;
            // Load data for combobox
            XGender.ItemsSource = ListGender.Gender;
            Department.ItemsSource = BUS.BUS.DsDept();
            Group.ItemsSource = BUS.BUS.DsGroup();
            Position.ItemsSource = BUS.BUS.DsPos();
            //LstEmployee.ItemsSource = BUS.BUS.DsEmployee();
        }

        private void LstEmployee_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            LstItemChange.Add(NewRow);
        }

        private void LstEmployee_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            NewRow = LstEmployee.SelectedItem as EMPLOYEE;
            FrameworkElement EmpID = LstEmployee.Columns[0].GetCellContent(e.Row);
            if (EmpID.GetType() == typeof(TextBox))
            {
                var eno = ((TextBox)EmpID).Text.Trim();
                NewRow.EmployeeID = eno;
            }
            FrameworkElement FirstName = LstEmployee.Columns[1].GetCellContent(e.Row);
            if (FirstName.GetType() == typeof(TextBox))
            {
                var eno = ((TextBox)FirstName).Text;
                NewRow.FirstName = eno;
            }
            FrameworkElement LastName = LstEmployee.Columns[2].GetCellContent(e.Row);
            if (LastName.GetType() == typeof(TextBox))
            {
                var eno = ((TextBox)LastName).Text;
                NewRow.LastName = eno;
            }
            FrameworkElement dateofbirth = LstEmployee.Columns[3].GetCellContent(e.Row);
            if (dateofbirth.GetType() == typeof(ContentPresenter))
            {
                var _dateofbirth = ((ContentPresenter)dateofbirth);
                if ((_dateofbirth.ContentTemplate.FindName("dateofbirth", _dateofbirth) as DatePicker).SelectedDate != null)
                {
                    NewRow.DOB = (_dateofbirth.ContentTemplate.FindName("dateofbirth", _dateofbirth) as DatePicker).SelectedDate;
                }

            }
            FrameworkElement Address = LstEmployee.Columns[4].GetCellContent(e.Row);
            if (Address.GetType() == typeof(TextBox))
            {
                var eno = ((TextBox)Address).Text.Trim();
                NewRow.Address = eno;
            }
            FrameworkElement Email = LstEmployee.Columns[5].GetCellContent(e.Row);
            if (Email.GetType() == typeof(TextBox))
            {
                var eno = ((TextBox)Email).Text;
                NewRow.Email = eno;
            }
            FrameworkElement Phone = LstEmployee.Columns[6].GetCellContent(e.Row);
            if (Phone.GetType() == typeof(TextBox))
            {
                var eno = ((TextBox)Phone).Text;
                NewRow.Phone = eno;
            }
            FrameworkElement Gender = LstEmployee.Columns[7].GetCellContent(e.Row);
            if (Gender.GetType() == typeof(ComboBox))
            {
                var eno = (bool)((ComboBox)Gender).SelectedValue;
                NewRow.Gender = eno;
            }
            FrameworkElement Position = LstEmployee.Columns[8].GetCellContent(e.Row);
            if (Position.GetType() == typeof(ComboBox))
            {
                var eno = ((ComboBox)Position).SelectedValue.ToString();
                NewRow.PostionID = eno;
            }
            FrameworkElement DeptID = LstEmployee.Columns[9].GetCellContent(e.Row);
            if (Gender.GetType() == typeof(ComboBox))
            {
                var eno = ((ComboBox)DeptID).SelectedValue.ToString();
                NewRow.DeptID = eno;
            }
            FrameworkElement GroupID = LstEmployee.Columns[10].GetCellContent(e.Row);
            if (GroupID.GetType() == typeof(ComboBox))
            {
                var eno = ((ComboBox)GroupID).SelectedValue.ToString();
                NewRow.GroupID = eno;
            }




        }
    }
}