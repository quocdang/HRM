using System;
using System.Collections;
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
using System.ComponentModel;

namespace HRM
{
    
    public partial class Paysheet : UserControl,WPFTabbedMDI
    {
        List<SALARY> LstItemChange;
        SALARY NewRow;
        public Paysheet()
        {
            InitializeComponent();
            ICollectionView collectionView = CollectionViewSource.GetDefaultView(BUS.BUS.DsLuong());
            Grid.ItemsSource = BUS.BUS.DsLuong();
            EmployeeID.ItemsSource = BUS.BUS.DsEmployee();
            LstItemChange = new List<SALARY>();
        }

        #region ITabbedMDI Members

        public UserControl CurrType
        {
            get
            {
                return this;
            }
        }

        public bool Active
        {
            get
            {
                return true;
            }
        }

        public string UniqueTabName
        {
            get
            {
                return "Paysheet";
            }
        }

        public string Title
        {
            get { return "Paysheet"; }
        }

        public IEnumerable<DataGridRow> GetDataGridRows(DataGrid grid)
        {
            var itemsSource = grid.ItemsSource as IEnumerable;
            if (null == itemsSource) yield return null;
            foreach (var item in itemsSource)
            {
                var row = grid.ItemContainerGenerator.ContainerFromItem(item) as DataGridRow;
                if (null != row) yield return row;
            }
        }

        public void Save()
        {
            //var row_list = GetDataGridRows(LstSalary);
            foreach (SALARY item in LstItemChange)
            {
                //TextBlock r = LstSalary.Columns[0].GetCellContent(item) as TextBlock;
                //TextBlock t = LstSalary.Columns[1].GetCellContent(item) as TextBlock;
                //TextBlock n = LstSalary.Columns[2].GetCellContent(item) as TextBlock;
                BUS.BUS.InsertSalary(item);
            }
            Grid.ItemsSource = BUS.BUS.DsLuong();
        }

        public void Delete()
        {
            SALARY sal = Grid.SelectedItem as SALARY;
            string ID = sal.ID;
            BUS.BUS.DeleteSalary(ID);
            Grid.ItemsSource = BUS.BUS.DsLuong();
        }

        #endregion

        private void Grid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            NewRow = Grid.SelectedItem as SALARY;
            FrameworkElement EmpID = Grid.Columns[0].GetCellContent(e.Row);
            if (EmpID.GetType() == typeof(ComboBox))
            {
                var eno = ((ComboBox)EmpID).SelectedValue.ToString();
                NewRow.EmployeeID = eno;
            }
            FrameworkElement WorkDays = Grid.Columns[1].GetCellContent(e.Row);
            if (WorkDays.GetType() == typeof(TextBox))
            {
                var eno = int.Parse(((TextBox)WorkDays).Text.Trim());
                NewRow.WorkDays = eno;
            }
            FrameworkElement Allowance = Grid.Columns[2].GetCellContent(e.Row);
            if (Allowance.GetType() == typeof(ComboBox))
            {
                var eno = ((ComboBox)Allowance).SelectedValue;
                //NewRow.Allowance = eno;
            }
            FrameworkElement Deducttion = Grid.Columns[3].GetCellContent(e.Row);
            if (Deducttion.GetType() == typeof(ComboBox))
            {
                var eno = ((ComboBox)Deducttion).SelectedValue;
                //NewRow.Deducttion = eno;
            }
            FrameworkElement Descr = Grid.Columns[4].GetCellContent(e.Row);
            if (Descr.GetType() == typeof(TextBox))
            {
                var eno = ((TextBox)Descr).Text;
                //NewRow.RealSalary = eno;
            }
        }

        private void Grid_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            LstItemChange.Add(NewRow);

        }

        private void CheckBox_Click(object sender, RoutedEventArgs e)
        {
            CheckBox clickedBox = (CheckBox)sender;

            
        }
    }
}
