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
        public Paysheet()
        {
            InitializeComponent();
            ICollectionView collectionView = CollectionViewSource.GetDefaultView(BUS.BUS.DsLuong());
            LstSalary.ItemsSource = collectionView;
            //PropertyGroupDescription groupDescription = new PropertyGroupDescription();
            //groupDescription.PropertyName = "Age";
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
            var row_list = GetDataGridRows(LstSalary);
            foreach (DataGridRow item in row_list)
            {
                TextBlock r = LstSalary.Columns[0].GetCellContent(item) as TextBlock;
                TextBlock t = LstSalary.Columns[1].GetCellContent(item) as TextBlock;
                TextBlock n = LstSalary.Columns[2].GetCellContent(item) as TextBlock;
                BUS.BUS.InsertSalary(r.Text, t.Text,Convert.ToInt32(n.Text));
            }
            LstSalary.ItemsSource = BUS.BUS.DsLuong();
        }

        public void Delete()
        {
            SALARY sal = LstSalary.SelectedItem as SALARY;
            string ID = sal.ID;
            BUS.BUS.DeleteSalary(ID);
            LstSalary.ItemsSource = BUS.BUS.DsLuong();
        }

        #endregion
    }
}
