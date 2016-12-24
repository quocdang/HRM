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
using BUS;

namespace HRM.GUI
{
    /// <summary>
    /// Interaction logic for DeductionFee.xaml
    /// </summary>
    public partial class DeductionFee : Window
    {
        DTO.HRM db = new DTO.HRM();
        public DeductionFee()
        {
            InitializeComponent();
            ICollectionView collectionViewDeduction = CollectionViewSource.GetDefaultView(BUS.BUS.ListDeduction());

            listBoxDeduction.ItemsSource = collectionViewDeduction;

            comboBox.ItemsSource = BUS.BUS.DsEmployee();

        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            var s =  comboBox.SelectedItem as EMPLOYEE;
            List<EMP_DEDUCTED> lst = new List<EMP_DEDUCTED>();
            foreach (DEDUCTION item in listBoxDeduction.SelectedItems)
            {
                EMP_DEDUCTED enp_de = new EMP_DEDUCTED();
                enp_de.EmployeeID = s.EmployeeID;
                enp_de.DeductCode = item.ID;
                lst.Add(enp_de);
            }
            BUS.BUS.InsertEmpDeducted(lst);
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
