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
    /// Interaction logic for Reward.xaml
    /// </summary>
    public partial class Reward : UserControl, WPFTabbedMDI
    {
        public Reward()
        {
            InitializeComponent();
            ICollectionView collectionView = CollectionViewSource.GetDefaultView(BUS.BUS.ListReward());
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
                return "Reward";
            }
        }
        /// <summary>
        /// Set Title
        /// </summary>
        public string Title
        {
            get { return "Reward"; }
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
                var DecideDate = (Grid.Columns[3].GetCellContent(item) as ContentPresenter);

                REWARD _Reward = new REWARD();
                _Reward.RewardName = (Grid.Columns[0].GetCellContent(item) as TextBlock).Text;
                _Reward.EmployeeID = (Grid.Columns[2].GetCellContent(item) as ComboBox).SelectedValue.ToString();
                _Reward.DecideNum = (Grid.Columns[0].GetCellContent(item) as TextBlock).Text;
                _Reward.DecideDate = (DecideDate.ContentTemplate.FindName("DecideDate", DecideDate) as DatePicker).SelectedDate;
                BUS.BUS.InsertReward(_Reward);
            }
        }


        /// <summary>
        /// Delete Method to Delete Item From DataGrid
        /// </summary>
        public void Delete()
        {
            REWARD Item = Grid.SelectedItem as REWARD;
            int ID = Item.ID;
            BUS.BUS.DeleteRewardItem(ID);
            Grid.ItemsSource = BUS.BUS.ListReward();
        }

        #endregion
    }
}
