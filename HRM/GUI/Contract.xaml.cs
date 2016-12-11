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
            lmdb = collectionView;
            Grid.ItemsSource = collectionView;

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
            foreach (CONTRACT Item in lmdb)
            {
                CONTRACT _Contract = new CONTRACT();
                _Contract.ContractCode = Item.ContractCode;
                _Contract.ContractType = Item.ContractType;
                _Contract.FromDate = Item.FromDate;
                _Contract.EmployeeID = Item.EmployeeID;
                _Contract.Salary = Item.Salary;
                _Contract.SignDate = Item.SignDate;
                _Contract.ToDate = Item.ToDate;
                _Contract.ValidDate = Item.ValidDate;

                BUS.BUS.InsertContract(_Contract);
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
