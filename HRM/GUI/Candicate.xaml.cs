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
    /// Interaction logic for Candicates.xaml
    /// </summary>
    public partial class Candicate : UserControl, WPFTabbedMDI
    {
        public IEnumerable lmdb;
        public Candicate()
        {
            InitializeComponent();
            ICollectionView collectionView = CollectionViewSource.GetDefaultView(BUS.BUS.ListAllowance());
            Grid.ItemsSource = collectionView;
            lmdb = collectionView;
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
            foreach (CANDIDATE item in lmdb)
            {
                CANDIDATE _Candicate = new CANDIDATE();
                _Candicate.CandidateCode = item.CandidateCode;
                _Candicate.Birthday = item.Birthday;
                _Candicate.BirthPlace = item.BirthPlace;
                _Candicate.CellPhone = item.CellPhone;
                _Candicate.ContactAddress = item.ContactAddress;
                _Candicate.Education = item.Education;
                _Candicate.Email = item.Email;
                _Candicate.Experience = item.Experience;
                _Candicate.FirstName = item.FirstName;
                _Candicate.Gender = item.Gender;
                _Candicate.HomePhone = item.HomePhone;
                _Candicate.Job = item.Job;
                _Candicate.Language = item.Language;
                _Candicate.LastName = item.LastName;
                _Candicate.MainAddress = item.MainAddress;
                _Candicate.RecruitmentCode = item.RecruitmentCode;
                _Candicate.Photo = item.Photo;
                _Candicate.ExpectSalary = item.ExpectSalary;
                BUS.BUS.InsertCandicate(_Candicate);
            }
        }


        /// <summary>
        /// Delete Method to Delete Item From DataGrid
        /// </summary>
        public void Delete()
        {
            CANDIDATE can = Grid.SelectedItem as CANDIDATE;
            string Code = can.CandidateCode;
            BUS.BUS.DeleteCandicateItem(Code);
            Grid.ItemsSource = BUS.BUS.ListCandicate();
        }

        #endregion
    }
}
