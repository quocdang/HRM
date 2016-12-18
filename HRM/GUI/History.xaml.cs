using DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        List<HISTORY> LstItemChange;
        HISTORY NewRow;
        public History()
        {
            InitializeComponent();
            ICollectionView collectionView = CollectionViewSource.GetDefaultView(BUS.BUS.ListHistory());
            Grid.ItemsSource = collectionView;
            EmployeeID.ItemsSource = BUS.BUS.DsEmployee();
            LstItemChange = new List<HISTORY>();

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

            foreach (HISTORY item in LstItemChange)
            {
                //var FromDate = (Grid.Columns[1].GetCellContent(item) as ContentPresenter);
                //var ToDate = (Grid.Columns[2].GetCellContent(item) as ContentPresenter);
                //HISTORY _History = new HISTORY();
                //_History.Place = (Grid.Columns[3].GetCellContent(item) as TextBlock).Text;
                //_History.Position = (Grid.Columns[4].GetCellContent(item) as TextBlock).Text;
                //_History.Reason = (Grid.Columns[5].GetCellContent(item) as TextBlock).Text;
                //_History.ToDate = (ToDate.ContentTemplate.FindName("ToDate", ToDate) as DatePicker).SelectedDate;
                //_History.FromDate = (FromDate.ContentTemplate.FindName("FromDate", FromDate) as DatePicker).SelectedDate;
                //_History.EmployeeID = (Grid.Columns[0].GetCellContent(item) as ComboBox).SelectedValue.ToString();
                BUS.BUS.InsertHistory(item);
                Grid.ItemsSource = BUS.BUS.ListHistory();
            }
        }


        /// <summary>
        /// Delete Method to Delete Item From DataGrid
        /// </summary>
        public void Delete()
        {
            //foreach (int ID in LstItemChange)
            //{
            //    BUS.BUS.DeleteHistoryItem(ID);
            //}

            //HISTORY Item = Grid.SelectedItem as HISTORY;
            //int ID = Item.ID;
            //BUS.BUS.DeleteHistoryItem(ID);
            Grid.ItemsSource = BUS.BUS.ListHistory();
        }

        #endregion

        private void Grid_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            //FrameworkElement element = Grid.Columns[6].GetCellContent(e.Row);
            //if (element.GetType() == typeof(CheckBox))
            //{
            //    if (((CheckBox)element).IsChecked == true)
            //    {
            //        HISTORY Item = Grid.SelectedItem as HISTORY;
            //        LstItemChange.Add(Item.ID);
            //    }
            //}
            //HISTORY Item = Grid.SelectedItem as HISTORY;
            LstItemChange.Add(NewRow);

        }

        private void Grid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            NewRow = Grid.SelectedItem as HISTORY;
            FrameworkElement EmpID = Grid.Columns[0].GetCellContent(e.Row);
            if (EmpID.GetType() == typeof(ComboBox))
            {
                var eno = ((ComboBox)EmpID).SelectedValue.ToString();
                NewRow.EmployeeID = eno;
            }
            FrameworkElement FromDate = Grid.Columns[1].GetCellContent(e.Row);
            if (FromDate.GetType() == typeof(ContentPresenter))
            {
                var _FromDate = ((ContentPresenter)FromDate);
                if ((_FromDate.ContentTemplate.FindName("FromDate", _FromDate) as DatePicker).SelectedDate != null)
                {
                    NewRow.FromDate = (_FromDate.ContentTemplate.FindName("FromDate", _FromDate) as DatePicker).SelectedDate;
                }

            }
            FrameworkElement ToDate = Grid.Columns[2].GetCellContent(e.Row);
            if (ToDate.GetType() == typeof(ContentPresenter))
            {
                var _ToDate = ((ContentPresenter)ToDate);
                if ((_ToDate.ContentTemplate.FindName("ToDate", _ToDate) as DatePicker).SelectedDate != null)
                {
                    NewRow.ToDate = (_ToDate.ContentTemplate.FindName("ToDate", _ToDate) as DatePicker).SelectedDate;
                }

            }
            FrameworkElement Place = Grid.Columns[3].GetCellContent(e.Row);
            if (Place.GetType() == typeof(TextBox))
            {
                var eno = ((TextBox)Place).Text;
                NewRow.Place = eno;
            }
            FrameworkElement Position = Grid.Columns[4].GetCellContent(e.Row);
            if (Position.GetType() == typeof(TextBox))
            {
                var eno = ((TextBox)Position).Text;
                NewRow.Position = eno;
            }
            FrameworkElement Reason = Grid.Columns[5].GetCellContent(e.Row);
            if (EmpID.GetType() == typeof(TextBox))
            {
                var eno = ((TextBox)EmpID).Text;
                NewRow.Reason = eno;
            }
           

        }
    }
}
