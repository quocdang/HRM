using DTO;
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
    /// Interaction logic for Contract.xaml
    /// </summary>
    public partial class Contract : UserControl,WPFTabbedMDI
    {
        public IEnumerable lmdb;
        public Contract()
        {
            InitializeComponent();
            ICollectionView collectionView = CollectionViewSource.GetDefaultView(BUS.BUS.ListContract());
            Grid.ItemsSource = collectionView;
            lmdb = collectionView;

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
                return "Contract";
            }
        }
        /// <summary>
        /// Set Title
        /// </summary>
        public string Title
        {
            get { return "Contract"; }
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
            foreach (CONTRACT item in lmdb)
            {
                CONTRACT _Contract = new CONTRACT();
                _Contract.ContractCode = item.ContractCode;
                _Contract.ContractType = item.ContractType;
                _Contract.FromDate = item.FromDate;
                _Contract.EmployeeID = item.EmployeeID;
                _Contract.Salary = item.Salary;
                _Contract.SignDate = item.SignDate;
                _Contract.ToDate = item.ToDate;
                _Contract.ValidDate = item.ValidDate;

                Grid.ItemsSource = BUS.BUS.ListContract();
            }
        }


        /// <summary>
        /// Delete Method to Delete Item From DataGrid
        /// </summary>
        public void Delete()
        {
            CONTRACT cont = Grid.SelectedItem as CONTRACT;
            string Code = cont.ContractCode;
            BUS.BUS.DeleteContractItem(Code);
            Grid.ItemsSource = BUS.BUS.ListContract();
        }

        #endregion
    }
}
