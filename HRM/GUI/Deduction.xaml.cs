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
    /// Interaction logic for Deduction.xaml
    /// </summary>
    public partial class Deduction : UserControl, WPFTabbedMDI
    {
        List<DEDUCTION> LstItemChange;
        DEDUCTION NewRow;
        public Deduction()
        {
            InitializeComponent();
            ICollectionView collectionView = CollectionViewSource.GetDefaultView(BUS.BUS.ListAllowance());
            Grid.ItemsSource = collectionView;
            LstItemChange = new List<DEDUCTION>();
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
                return "Deduction";
            }
        }
        /// <summary>
        /// Set Title
        /// </summary>
        public string Title
        {
            get { return "Deduction"; }
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
                //DEDUCTION _Deduct = new DEDUCTION();
                //_Deduct.Descr = (Grid.Columns[3].GetCellContent(item) as TextBlock).Text;
                //_Deduct.Name = (Grid.Columns[1].GetCellContent(item) as TextBlock).Text;
                //_Deduct.Rate = int.Parse((Grid.Columns[2].GetCellContent(item) as TextBlock).Text);
                BUS.BUS.InsertDeduction(item);
                Grid.ItemsSource = BUS.BUS.ListDeduction();
            }
        }


        /// <summary>
        /// Delete Method to Delete Item From DataGrid
        /// </summary>
        public void Delete()
        {
            int ID= (Grid.SelectedItem as DEDUCTION).ID;
            BUS.BUS.DeleteDeductItem(ID);
            Grid.ItemsSource = BUS.BUS.ListDeduction();
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
            NewRow = Grid.SelectedItem as DEDUCTION;
            FrameworkElement Name = Grid.Columns[0].GetCellContent(e.Row);
            if (Name.GetType() == typeof(TextBox))
            {
                var eno = ((TextBox)Name).Text.Trim();
                NewRow.Name = eno;
            }
            FrameworkElement Rate = Grid.Columns[1].GetCellContent(e.Row);
            if (Rate.GetType() == typeof(TextBox))
            {
                var eno = int.Parse(((TextBox)Rate).Text);
                NewRow.Rate = eno;
            }
            FrameworkElement Descr = Grid.Columns[2].GetCellContent(e.Row);
            if (Descr.GetType() == typeof(TextBox))
            {
                var eno = ((TextBox)Descr).Text;
                NewRow.Descr = eno;
            }


        }

    }
}
