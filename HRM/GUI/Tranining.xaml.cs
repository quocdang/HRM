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
        List<TRAINNING> LstItemChange;
        TRAINNING NewRow;
        public Tranining()
        {
            InitializeComponent();
            ICollectionView collectionView = CollectionViewSource.GetDefaultView(BUS.BUS.ListTrainning());
            Grid.ItemsSource = collectionView;
            EmployeeID.ItemsSource = BUS.BUS.DsEmployee();
            LstItemChange = new List<TRAINNING>();
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
            foreach (var item in LstItemChange)
            {
                //var FromDate = (Grid.Columns[2].GetCellContent(item) as ContentPresenter);
                //var ToDate = (Grid.Columns[3].GetCellContent(item) as ContentPresenter);
                //TRAINNING _train = new TRAINNING();
                //_train.Reason = (Grid.Columns[5].GetCellContent(item) as TextBlock).Text;
                //_train.Place = (Grid.Columns[4].GetCellContent(item) as TextBlock).Text;
                //_train.Time = (Grid.Columns[6].GetCellContent(item) as TextBlock).Text;
                //_train.FromDate = (FromDate.ContentTemplate.FindName("FromDate", FromDate) as DatePicker).SelectedDate;
                //_train.ToDate = (ToDate.ContentTemplate.FindName("ToDate", ToDate) as DatePicker).SelectedDate;
                //_train.Result = (Grid.Columns[9].GetCellContent(item) as TextBlock).Text;
                //_train.Note = (Grid.Columns[8].GetCellContent(item) as TextBlock).Text;
                //_train.EmployeeID = (Grid.Columns[1].GetCellContent(item) as ComboBox).SelectedValue.ToString();
                //_train.Descr = (Grid.Columns[7].GetCellContent(item) as TextBlock).Text;
                BUS.BUS.InsertTrainning(item);
                Grid.ItemsSource = BUS.BUS.ListTrainning();

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

        private void Grid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            NewRow = Grid.SelectedItem as TRAINNING;
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
            FrameworkElement Reason = Grid.Columns[4].GetCellContent(e.Row);
            if (Reason.GetType() == typeof(TextBox))
            {
                var eno = ((TextBox)Reason).Text;
                NewRow.Reason = eno;
            }
            FrameworkElement Time = Grid.Columns[5].GetCellContent(e.Row);
            if (Time.GetType() == typeof(TextBox))
            {
                var eno = ((TextBox)Time).Text;
                NewRow.Time = eno;
            }
            FrameworkElement Descr = Grid.Columns[6].GetCellContent(e.Row);
            if (Descr.GetType() == typeof(TextBox))
            {
                var eno = ((TextBox)Descr).Text;
                NewRow.Descr = eno;
            }
            FrameworkElement Note = Grid.Columns[7].GetCellContent(e.Row);
            if (Note.GetType() == typeof(TextBox))
            {
                var eno = ((TextBox)Note).Text;
                NewRow.Note = eno;
            }
            FrameworkElement Result = Grid.Columns[8].GetCellContent(e.Row);
            if (Result.GetType() == typeof(TextBox))
            {
                var eno = ((TextBox)Result).Text;
                NewRow.Result = eno;
            }
        }

        private void Grid_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            LstItemChange.Add(NewRow);
        }
    }
}
