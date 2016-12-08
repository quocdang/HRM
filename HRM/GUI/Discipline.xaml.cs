﻿using DTO;
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
        public IEnumerable lmdb;
        public Discipline()
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
            foreach (DISCIPLINE item in lmdb)
            {
                DISCIPLINE _Discipline = new DISCIPLINE();
                _Discipline.ID = item.ID;
                _Discipline.Date = item.Date;
                _Discipline.EmployeeID = item.EmployeeID;
                _Discipline.Descr = item.Descr;
                BUS.BUS.InsertDiscipline(_Discipline);
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
    }
}
