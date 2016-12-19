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
    /// Interaction logic for SalaryAdvance.xaml
    /// </summary>
    public partial class SalaryAdvance : UserControl, WPFTabbedMDI
    {
        List<SALARY_ADVANCE> LstItemChange;
        SALARY_ADVANCE NewRow;
        public SalaryAdvance()
        {
            InitializeComponent();
            ICollectionView collectionView = CollectionViewSource.GetDefaultView(BUS.BUS.ListAdvance());
            Grid.ItemsSource = collectionView;
            EmployeeID.ItemsSource = BUS.BUS.DsEmployee();
            LstItemChange = new List<SALARY_ADVANCE>();

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
                return "Department";
            }
        }
        /// <summary>
        /// Set Title
        /// </summary>
        public string Title
        {
            get { return "Department"; }
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
                //SALARY_ADVANCE _Advance = new SALARY_ADVANCE();
                //_Advance.SalaryAdvanceCode = (Grid.Columns[0].GetCellContent(item) as TextBlock).Text;
                //_Advance.Reason = (Grid.Columns[3].GetCellContent(item) as TextBlock).Text;
                //_Advance.Money = decimal.Parse((Grid.Columns[2].GetCellContent(item) as TextBlock).Text);
                //_Advance.EmployeeID = (Grid.Columns[1].GetCellContent(item) as ComboBox).SelectedValue.ToString();

                BUS.BUS.InsertAdvance(item);
            }
            Grid.ItemsSource = BUS.BUS.ListAdvance();
        }


        /// <summary>
        /// Delete Method to Delete Item From DataGrid
        /// </summary>
        public void Delete()
        {
            SALARY_ADVANCE Item = Grid.SelectedItem as SALARY_ADVANCE;
            string ID = Item.SalaryAdvanceCode;
            BUS.BUS.DeleteAdvanceItem(ID);
            Grid.ItemsSource = BUS.BUS.ListAdvance();
        }

        #endregion

        private void Grid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            NewRow = Grid.SelectedItem as SALARY_ADVANCE;
            FrameworkElement SalaryAdvanceCode = Grid.Columns[1].GetCellContent(e.Row);
            if (SalaryAdvanceCode.GetType() == typeof(TextBox))
            {
                var eno = ((TextBox)SalaryAdvanceCode).Text.Trim();
                NewRow.SalaryAdvanceCode = eno;
            }
            FrameworkElement EmpID = Grid.Columns[0].GetCellContent(e.Row);
            if (EmpID.GetType() == typeof(ComboBox))
            {
                var eno = ((ComboBox)EmpID).SelectedValue.ToString();
                NewRow.EmployeeID = eno;
            }
            FrameworkElement Money = Grid.Columns[1].GetCellContent(e.Row);
            if (Money.GetType() == typeof(TextBox))
            {
                var eno = decimal.Parse(((TextBox)Money).Text.Trim());
                NewRow.Money = eno;
            }
            FrameworkElement Reason = Grid.Columns[2].GetCellContent(e.Row);
            if (Reason.GetType() == typeof(TextBox))
            {
                var eno = ((TextBox)Reason).Text.Trim();
                NewRow.Reason = eno;
            }
        }

        private void Grid_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            LstItemChange.Add(NewRow);
        }
    }
}
