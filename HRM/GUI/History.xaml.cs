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
    /// Interaction logic for History.xaml
    /// </summary>
    public partial class History : UserControl, WPFTabbedMDI
    {
        public History()
        {
            InitializeComponent();
            ICollectionView collectionView = CollectionViewSource.GetDefaultView(BUS.BUS.ListHistory());
            Grid.ItemsSource = collectionView;
            EmployeeID.ItemsSource = BUS.BUS.DsEmployee();
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
                return "History";
            }
        }
        /// <summary>
        /// Set Title
        /// </summary>
        public string Title
        {
            get { return "History"; }
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
            var row_list = GetDataGridRows(Grid);

            foreach (var item in row_list)
            {
                var FromDate = (Grid.Columns[2].GetCellContent(item) as ContentPresenter);
                var ToDate = (Grid.Columns[3].GetCellContent(item) as ContentPresenter);
                HISTORY _History = new HISTORY();
                _History.ID = int.Parse((Grid.Columns[0].GetCellContent(item) as TextBlock).Text);
                _History.Place = (Grid.Columns[4].GetCellContent(item) as TextBlock).Text;
                _History.Position = (Grid.Columns[5].GetCellContent(item) as TextBlock).Text;
                _History.Reason = (Grid.Columns[6].GetCellContent(item) as TextBlock).Text;
                _History.ToDate = (ToDate.ContentTemplate.FindName("ToDate", ToDate) as DatePicker).SelectedDate;
                _History.FromDate = (FromDate.ContentTemplate.FindName("FromDate", FromDate) as DatePicker).SelectedDate;
                _History.EmployeeID = (Grid.Columns[1].GetCellContent(item) as ComboBox).SelectedValue.ToString();
                BUS.BUS.InsertHistory(_History);
                Grid.ItemsSource = BUS.BUS.ListHistory();
            }
        }


        /// <summary>
        /// Delete Method to Delete Item From DataGrid
        /// </summary>
        public void Delete()
        {
            HISTORY Item = Grid.SelectedItem as HISTORY;
            int ID = Item.ID;
            BUS.BUS.DeleteHistoryItem(ID);
            Grid.ItemsSource = BUS.BUS.ListHistory();
        }

        #endregion
    }
}
