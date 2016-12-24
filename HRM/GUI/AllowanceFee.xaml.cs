using System;
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
using System.Windows.Shapes;
using DTO;

namespace HRM.GUI
{
    /// <summary>
    /// Interaction logic for AllowanceFee.xaml
    /// </summary>
    public partial class AllowanceFee : Window
    {
        public AllowanceFee()
        {
            InitializeComponent();
            ICollectionView collectionViewAllowance = CollectionViewSource.GetDefaultView(BUS.BUS.ListAllowance());

            listBoxAllowance.ItemsSource = collectionViewAllowance;
            comboBox.ItemsSource = BUS.BUS.DsEmployee();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            var s = comboBox.SelectedItem as EMPLOYEE;
            List<EMP_ALLOWANCE> Lst = new List<EMP_ALLOWANCE>();
            foreach (ALLOWANCE item in listBoxAllowance.SelectedItems)
            {
                EMP_ALLOWANCE emp_alo = new EMP_ALLOWANCE();
                emp_alo.EmployeeID = s.EmployeeID;
                emp_alo.AllowanceCode = item.ID;
                Lst.Add(emp_alo);
            }
            BUS.BUS.InsertEmpAllowance(Lst);
            this.Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
