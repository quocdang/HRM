using DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for Candicates.xaml
    /// </summary>
    public partial class Candicate : UserControl, WPFTabbedMDI
    {
        public Candicate()
        {
            InitializeComponent();
            ICollectionView collectionView = CollectionViewSource.GetDefaultView(BUS.BUS.ListAllowance());
            Grid.ItemsSource = collectionView;
            XGender.ItemsSource = ListGender.Gender;

        }
        public class GenderS
        {
            public string Code { set; get; }
            public string Name { set; get; }
        }
        public static class ListGender
        {
            static ListGender()
            {
                Gender = new ObservableCollection<GenderS>
                 {
                     new GenderS{Name = "Nam", Code = "True"},
                     new GenderS{Name = "Nữ", Code = "False"}
                 };
            }
            public static ObservableCollection<GenderS> Gender { set; get; }
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
                return "Candicate";
            }
        }
        /// <summary>
        /// Set Title
        /// </summary>
        public string Title
        {
            get { return "Candicate"; }
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
                var dateofbirth = (Grid.Columns[5].GetCellContent(item) as ContentPresenter);
                CANDIDATE _Candicate = new CANDIDATE();
                _Candicate.CandidateCode = (Grid.Columns[0].GetCellContent(item) as TextBlock).Text;
                _Candicate.Birthday = (dateofbirth.ContentTemplate.FindName("DateBirth", dateofbirth) as DatePicker).SelectedDate;
                _Candicate.BirthPlace = (Grid.Columns[6].GetCellContent(item) as TextBlock).Text;
                _Candicate.CellPhone = (Grid.Columns[9].GetCellContent(item) as TextBlock).Text;
                _Candicate.ContactAddress = (Grid.Columns[8].GetCellContent(item) as TextBlock).Text;
                _Candicate.Education = (Grid.Columns[13].GetCellContent(item) as TextBlock).Text;
                _Candicate.Email = (Grid.Columns[11].GetCellContent(item) as TextBlock).Text;
                _Candicate.Experience = (Grid.Columns[15].GetCellContent(item) as TextBlock).Text;
                _Candicate.FirstName = (Grid.Columns[2].GetCellContent(item) as TextBlock).Text;
                _Candicate.Gender = (bool)(Grid.Columns[4].GetCellContent(item) as ComboBox).SelectedValue;
                _Candicate.HomePhone = (Grid.Columns[10].GetCellContent(item) as TextBlock).Text;
                _Candicate.Job = (Grid.Columns[14].GetCellContent(item) as TextBlock).Text;
                _Candicate.Language = (Grid.Columns[12].GetCellContent(item) as TextBlock).Text;
                _Candicate.LastName = (Grid.Columns[3].GetCellContent(item) as TextBlock).Text;
                _Candicate.MainAddress = (Grid.Columns[7].GetCellContent(item) as TextBlock).Text;
                _Candicate.RecruitmentCode = (Grid.Columns[1].GetCellContent(item) as TextBlock).Text;
                //_Candicate.Photo = (Grid.Columns[0].GetCellContent(item) as TextBlock).Text;
                _Candicate.ExpectSalary = decimal.Parse((Grid.Columns[16].GetCellContent(item) as TextBlock).Text);
                BUS.BUS.InsertCandicate(_Candicate);
                Grid.ItemsSource = BUS.BUS.ListCandicate();

            }
        }
        /// <summary>
        /// Delete Method to Delete Item From DataGrid
        /// </summary>
        public void Delete()
        {
            //CANDIDATE can = Grid.SelectedItem as CANDIDATE;
            string Code = (Grid.SelectedItem as CANDIDATE).CandidateCode;
            BUS.BUS.DeleteCandicateItem(Code);
            Grid.ItemsSource = BUS.BUS.ListCandicate();
        }

        #endregion
    }
}
