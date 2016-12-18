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
        public List<CONTRACT> LstContract;
        public CONTRACT NewRow;
        public Contract()
        {
            InitializeComponent();
            ICollectionView collectionView = CollectionViewSource.GetDefaultView(BUS.BUS.ListContract());
            Grid.ItemsSource = collectionView;
            ContactType.ItemsSource = BUS.BUS.ListContractType();
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

            foreach (CONTRACT item in LstContract)
            {
                //var FromDate = (Grid.Columns[3].GetCellContent(item) as ContentPresenter);
                //var ToDate = (Grid.Columns[4].GetCellContent(item) as ContentPresenter);
                //var SignDate = (Grid.Columns[6].GetCellContent(item) as ContentPresenter);
                //var ValidDate = (Grid.Columns[7].GetCellContent(item) as ContentPresenter);
                //CONTRACT _Contract = new CONTRACT();
                //_Contract.ContractCode = (Grid.Columns[0].GetCellContent(item) as TextBlock).Text;
                //_Contract.ContractType = (int)(Grid.Columns[1].GetCellContent(item) as ComboBox).SelectedValue;

                //_Contract.FromDate = (FromDate.ContentTemplate.FindName("FromDate", FromDate) as DatePicker).SelectedDate;
                //_Contract.EmployeeID = (Grid.Columns[2].GetCellContent(item) as ComboBox).SelectedValue.ToString();
                //_Contract.Salary = decimal.Parse((Grid.Columns[5].GetCellContent(item) as TextBlock).Text);
                //_Contract.SignDate = (SignDate.ContentTemplate.FindName("SignDate", SignDate) as DatePicker).SelectedDate;
                //_Contract.ToDate = (ToDate.ContentTemplate.FindName("ToDate", ToDate) as DatePicker).SelectedDate;
                //_Contract.ValidDate = (ValidDate.ContentTemplate.FindName("ValidDate", ValidDate) as DatePicker).SelectedDate;

                BUS.BUS.InsertContract(item);
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

        private void Grid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            NewRow = Grid.SelectedItem as CONTRACT;
            
            FrameworkElement ContractCode = Grid.Columns[0].GetCellContent(e.Row);
            if (ContractCode.GetType() == typeof(TextBox))
            {
                var eno = ((TextBox)ContractCode).Text;
                NewRow.ContractCode = eno;
            }
            FrameworkElement ContractType = Grid.Columns[1].GetCellContent(e.Row);
            if (ContractType.GetType() == typeof(ComboBox))
            {
                var eno = int.Parse(((ComboBox)ContractType).SelectedValue.ToString());
                NewRow.ContractType = eno;
            }
            FrameworkElement EmpID = Grid.Columns[2].GetCellContent(e.Row);
            if (EmpID.GetType() == typeof(ComboBox))
            {
                var eno = ((ComboBox)EmpID).SelectedValue.ToString();
                NewRow.EmployeeID = eno;
            }
            FrameworkElement FromDate = Grid.Columns[3].GetCellContent(e.Row);
            if (FromDate.GetType() == typeof(ContentPresenter))
            {
                var _FromDate = ((ContentPresenter)FromDate);
                if ((_FromDate.ContentTemplate.FindName("FromDate", _FromDate) as DatePicker).SelectedDate != null)
                {
                    NewRow.FromDate = (_FromDate.ContentTemplate.FindName("FromDate", _FromDate) as DatePicker).SelectedDate;
                }

            }
            FrameworkElement ToDate = Grid.Columns[4].GetCellContent(e.Row);
            if (ToDate.GetType() == typeof(ContentPresenter))
            {
                var _ToDate = ((ContentPresenter)FromDate);
                if ((_ToDate.ContentTemplate.FindName("ToDate", _ToDate) as DatePicker).SelectedDate != null)
                {
                    NewRow.ToDate = (_ToDate.ContentTemplate.FindName("ToDate", _ToDate) as DatePicker).SelectedDate;
                }

            }
            FrameworkElement Salary = Grid.Columns[5].GetCellContent(e.Row);
            if (Salary.GetType() == typeof(TextBox))
            {
                var eno = decimal.Parse(((TextBox)Salary).Text);
                NewRow.Salary = eno;
            }
            FrameworkElement SignDate = Grid.Columns[6].GetCellContent(e.Row);
            if (SignDate.GetType() == typeof(ContentPresenter))
            {
                var _SignDate = ((ContentPresenter)SignDate);
                if ((_SignDate.ContentTemplate.FindName("SignDate", _SignDate) as DatePicker).SelectedDate != null)
                {
                    NewRow.SignDate = (_SignDate.ContentTemplate.FindName("SignDate", _SignDate) as DatePicker).SelectedDate;
                }

            }
            FrameworkElement ValidDate = Grid.Columns[7].GetCellContent(e.Row);
            if (ValidDate.GetType() == typeof(ContentPresenter))
            {
                var _ValidDate = ((ContentPresenter)ValidDate);
                if ((_ValidDate.ContentTemplate.FindName("ValidDate", _ValidDate) as DatePicker).SelectedDate != null)
                {
                    NewRow.ValidDate = (_ValidDate.ContentTemplate.FindName("ValidDate", _ValidDate) as DatePicker).SelectedDate;
                }

            }

        }

        private void Grid_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            LstContract.Add(NewRow);
        }
    }
}
