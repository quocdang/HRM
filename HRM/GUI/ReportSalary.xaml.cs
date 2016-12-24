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
using DTO;
using BUS;
using HRM.GUI;
using System.Data;
using Microsoft.Reporting.WinForms;

namespace HRM.GUI
{
    /// <summary>
    /// Interaction logic for RptContact.xaml
    /// </summary>
    public partial class ReportSalary : UserControl, WPFTabbedMDI
    {
        public ReportSalary()
        {
            InitializeComponent();
            DemoReport.ProcessingMode = ProcessingMode.Local;
            DemoReport.Load += DemoReport_Load;
        }

        private void DemoReport_Load(object sender, EventArgs e)
        {
            //var db = BUS.BUS.ListContract();
            //DTO.HRM db = new DTO.HRM();
            ////var data = db.CONTRACT;
            //DemoReport.ProcessingMode = ProcessingMode.Local;
            //DemoReport.LocalReport.ReportPath = "C:\\Users\\minhq\\OneDrive\\Project\\HRM\\HRM\\GUI\\Report1.rdlc";

            DataSet1 dataset = new DataSet1();
            dataset.BeginInit();
            //fill data into DataSet
            DataSet1TableAdapters.CONTRACTTableAdapter datasetAdapter =
                new DataSet1TableAdapters.CONTRACTTableAdapter();

            datasetAdapter.ClearBeforeFill = true;
            datasetAdapter.Fill(dataset.CONTRACT);
            ReportDataSource rptdataSource = new ReportDataSource();
            rptdataSource.Name = "DataSet1";
            rptdataSource.Value = dataset.CONTRACT;

            DemoReport.LocalReport.DataSources.Add(rptdataSource);


            DemoReport.LocalReport.ReportEmbeddedResource = "HRM.Report1.rdlc";
            //DemoReport.LocalReport.ReportEmbeddedResource = "GUI.Report1.rdlc";
            DemoReport.RefreshReport();
            dataset.EndInit();
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
                return "ReportSalary";
            }
        }

        public string Title
        {
            get { return "ReportSalary"; }
        }

        public void Save()
        {
        }

        public void Delete()
        {
        }

        #endregion
    }
}
