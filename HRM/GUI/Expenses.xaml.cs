using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace HRM.GUI
{
    /// <summary>
    /// Interaction logic for Expenses.xaml
    /// </summary>
    public partial class Expenses : UserControl,WPFTabbedMDI
    {
        public IEnumerable lmdb;
        public Expenses()
        {
            InitializeComponent();

            ICollectionView collectionViewAllowance = CollectionViewSource.GetDefaultView(BUS.BUS.ListAllowance());
            ICollectionView collectionViewDeduction = CollectionViewSource.GetDefaultView(BUS.BUS.ListDeduction());

            listBoxAllowance.ItemsSource = collectionViewAllowance;
            listBoxDeduction.ItemsSource = collectionViewDeduction;

            comboBox.ItemsSource = BUS.BUS.DsEmployee();
            comboBox.DisplayMemberPath = "EmployeeID";
            comboBox.SelectedValuePath = "EmployeeID";
            comboBox.SelectedValue = "EmployeeID";
        }
        #region ITabbedMDI Members
        /// <summary>
        /// Get Employee UserControl to return MDI
        /// </summary>
        public UserControl CurrType
        {
            get
            {
                return this;
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
                return "Expenses";
            }
        }
        /// <summary>
        /// Set Title
        /// </summary>
        public string Title
        {
            get { return "Expenses"; }
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
            //var row_list = GetDataGridRows(Grid);
            //foreach (var item in lmdb)
            //{
            //    ALLOWANCE allowance = new ALLOWANCE();
            //    allowance.Code = item.Code;
            //    allowance.Name = item.Name;
            //    allowance.Money = item.Money;
            //    allowance.Descr = item.Descr;
            //    BUS.BUS.InsertAllowance(allowance);
            //}
        }


        /// <summary>
        /// Delete Method to Delete Item From DataGrid
        /// </summary>
        public void Delete()
        {
            //ALLOWANCE emp = Grid.SelectedItem as ALLOWANCE;
            //string EmpID = emp.Code;
            //BUS.BUS.DeleteAllowanceItem(EmpID);
            //Grid.ItemsSource = BUS.BUS.ListAllowance();
        }

        #endregion
    }
}
