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
    /// Interaction logic for Working.xaml
    /// </summary>
    public partial class Working : UserControl, WPFTabbedMDI
    {
        public Working()
        {
            InitializeComponent();
            ICollectionView collectionView = CollectionViewSource.GetDefaultView(BUS.BUS.ListWorking());
            Grid.ItemsSource = collectionView;
            Position.ItemsSource = BUS.BUS.DsPos();
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
                return "Working";
            }
        }
        /// <summary>
        /// Set Title
        /// </summary>
        public string Title
        {
            get { return "Working"; }
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
                WORKING _work = new WORKING();
                _work.Reason = (Grid.Columns[5].GetCellContent(item) as TextBlock).Text;
                _work.DecideNum = (Grid.Columns[6].GetCellContent(item) as TextBlock).Text;
                _work.FromDate = (FromDate.ContentTemplate.FindName("FromDate", FromDate) as DatePicker).SelectedDate;
                _work.ToDate = (ToDate.ContentTemplate.FindName("ToDate", ToDate) as DatePicker).SelectedDate;
                _work.EmployeeID = (Grid.Columns[1].GetCellContent(item) as ComboBox).SelectedValue.ToString();
                _work.PositionID = (Grid.Columns[4].GetCellContent(item) as ComboBox).SelectedValue.ToString();

                BUS.BUS.InsertWorking(_work);
                Grid.ItemsSource = BUS.BUS.ListWorking();

            }
        }


        /// <summary>
        /// Delete Method to Delete Item From DataGrid
        /// </summary>
        public void Delete()
        {
            WORKING Item = Grid.SelectedItem as WORKING;
            int ID = Item.ID;
            BUS.BUS.DeleteWorkingItem(ID);
            Grid.ItemsSource = BUS.BUS.ListWorking();
        }

        #endregion
    }
}
