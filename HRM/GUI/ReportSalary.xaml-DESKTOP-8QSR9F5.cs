using Microsoft.Reporting.WinForms;
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
using System.Windows.Shapes;

namespace HRM.GUI
{
    /// <summary>
    /// Interaction logic for rptLuong.xaml
    /// </summary>
    public partial class ReportSalary : UserControl, WPFTabbedMDI
    {
        HRMDataSetTableAdapters.SALARYTableAdapter _dataAdapter;
        HRMDataSet salaryDataSet;
        public ReportSalary()
        {
            InitializeComponent();
            RptViewer.Load += RptViewer_Load;
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
                return "ReportSalary";
            }
        }
        /// <summary>
        /// Set Title
        /// </summary>
        public string Title
        {
            get { return "ReportSalary"; }
        }

        #endregion
        private bool _isRptViewerLoaded;
        private void RptViewer_Load(object sender, EventArgs e)
        {
            if (!_isRptViewerLoaded)
            {
                LocalReport report = new LocalReport();
                report.ReportEmbeddedResource = "HRM.Report.SalaryReport.rdlc";


                //Create the dataset            
                salaryDataSet = new HRMDataSet();
                _dataAdapter = new HRMDataSetTableAdapters.SALARYTableAdapter();

                salaryDataSet.DataSetName = "SalaryDataSet";
                salaryDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
                _dataAdapter.ClearBeforeFill = true;

                //Created datasource and binding source
                ReportDataSource dataSource = new ReportDataSource();
                System.Windows.Forms.BindingSource source = new System.Windows.Forms.BindingSource();
            }
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Delete()
        {
            throw new NotImplementedException();
        }
    }
}
