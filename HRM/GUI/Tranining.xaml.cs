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
    /// Interaction logic for Tranining.xaml
    /// </summary>
    public partial class Tranining : UserControl, WPFTabbedMDI
    {
        public IEnumerable lmdb;
        public Tranining()
        {
            InitializeComponent();
            ICollectionView collectionView = CollectionViewSource.GetDefaultView(BUS.BUS.ListTrainning());
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
                return "Trainning";
            }
        }
        /// <summary>
        /// Set Title
        /// </summary>
        public string Title
        {
            get { return "Trainning"; }
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
            foreach (TRAINNING item in lmdb)
            {
                TRAINNING _train = new TRAINNING();
                _train.ID = item.ID;
                _train.Reason = item.Reason;
                _train.Place = item.Place;
                _train.Time = item.Time;
                _train.FromDate = item.FromDate;
                _train.ToDate = item.ToDate;
                _train.Result = item.Result;
                _train.Note = item.Note;
                _train.EmployeeID = item.EmployeeID;
                _train.Descr = item.Descr;
                BUS.BUS.InsertTrainning(_train);
            }
        }


        /// <summary>
        /// Delete Method to Delete Item From DataGrid
        /// </summary>
        public void Delete()
        {
            TRAINNING Item = Grid.SelectedItem as TRAINNING;
            int ID = Item.ID;
            BUS.BUS.DeleteTrainningItem(ID);
            Grid.ItemsSource = BUS.BUS.ListTrainning();
        }

        #endregion
    }
}
