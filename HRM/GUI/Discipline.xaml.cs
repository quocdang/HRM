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
    /// Interaction logic for Discipline.xaml
    /// </summary>
    public partial class Discipline : UserControl, WPFTabbedMDI
    {
        List<DISCIPLINE> LstItemChange;
        DISCIPLINE NewRow;
        public Discipline()
        {
            InitializeComponent();
            ICollectionView collectionView = CollectionViewSource.GetDefaultView(BUS.BUS.ListDiscipline());
            Grid.ItemsSource = collectionView;
            EmployeeID.ItemsSource = BUS.BUS.DsEmployee();
            LstItemChange = new List<DISCIPLINE>();
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
                return "Discipline";
            }
        }
        /// <summary>
        /// Set Title
        /// </summary>
        public string Title
        {
            get { return "Discipline"; }
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
                //var Date = (Grid.Columns[3].GetCellContent(item) as ContentPresenter);

                //DISCIPLINE _Discipline = new DISCIPLINE();
                //_Discipline.Date = (Date.ContentTemplate.FindName("Date", Date) as DatePicker).SelectedDate;
                //_Discipline.EmployeeID = (Grid.Columns[1].GetCellContent(item) as ComboBox).SelectedValue.ToString();
                //_Discipline.Descr = (Grid.Columns[2].GetCellContent(item) as TextBlock).Text;
                BUS.BUS.InsertDiscipline(item);
                Grid.ItemsSource = BUS.BUS.ListDiscipline();
            }
        }


        /// <summary>
        /// Delete Method to Delete Item From DataGrid
        /// </summary>
        public void Delete()
        {
            DISCIPLINE item = Grid.SelectedItem as DISCIPLINE;
            int ID = item.ID;
            BUS.BUS.DeleteDisciplineItem(ID);
            Grid.ItemsSource = BUS.BUS.ListDiscipline();
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
            NewRow = Grid.SelectedItem as DISCIPLINE;
            FrameworkElement EmpID = Grid.Columns[0].GetCellContent(e.Row);
            if (EmpID.GetType() == typeof(ComboBox))
            {
                var eno = ((ComboBox)EmpID).SelectedValue.ToString();
                NewRow.EmployeeID = eno;
            }
            FrameworkElement Descr = Grid.Columns[1].GetCellContent(e.Row);
            if (Descr.GetType() == typeof(TextBox))
            {
                var eno = ((TextBox)Descr).Text;
                NewRow.Descr = eno;
            }
            FrameworkElement Date = Grid.Columns[2].GetCellContent(e.Row);
            if (Date.GetType() == typeof(ContentPresenter))
            {
                var _Date = ((ContentPresenter)Date);
                if ((_Date.ContentTemplate.FindName("Date", _Date) as DatePicker).SelectedDate != null)
                {
                    NewRow.Date = (_Date.ContentTemplate.FindName("Date", _Date) as DatePicker).SelectedDate;
                }

            }
            



        }

    }
}
