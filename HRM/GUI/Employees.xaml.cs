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
namespace HRM
{
    public partial class Employees : UserControl,WPFTabbedMDI
    {
        public Employees()
        {
            InitializeComponent();
            ICollectionView collectionView = CollectionViewSource.GetDefaultView(BUS.BUS.DsEmployee());
            LstEmployee.ItemsSource = collectionView;
            //LstEmployee.ItemsSource = BUS.BUS.DsEmployee();

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
            var row_list = GetDataGridRows(LstEmployee);
            foreach (DataGridRow item in row_list)
            {
                TextBlock r = LstEmployee.Columns[0].GetCellContent(item) as TextBlock;
                TextBlock t = LstEmployee.Columns[1].GetCellContent(item) as TextBlock;
                TextBlock n = LstEmployee.Columns[2].GetCellContent(item) as TextBlock;
                BUS.BUS.InsertEmployee(r.Text, t.Text, n.Text);
            }
            LstEmployee.ItemsSource = BUS.BUS.DsEmployee();

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
    }
}