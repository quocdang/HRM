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
        public SalaryAdvance()
        {
            InitializeComponent();
            ICollectionView collectionView = CollectionViewSource.GetDefaultView(BUS.BUS.ListAdvance());
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
            var row_list = GetDataGridRows(Grid);

            foreach (var item in row_list)
            {
                SALARY_ADVANCE _Advance = new SALARY_ADVANCE();
                _Advance.SalaryAdvanceCode = (Grid.Columns[0].GetCellContent(item) as TextBlock).Text;
                _Advance.Reason = (Grid.Columns[3].GetCellContent(item) as TextBlock).Text;
                _Advance.Money = decimal.Parse((Grid.Columns[2].GetCellContent(item) as TextBlock).Text);
                _Advance.EmployeeID = (Grid.Columns[1].GetCellContent(item) as ComboBox).SelectedValue.ToString();

                BUS.BUS.InsertAdvance(_Advance);
            }
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
    }
}
